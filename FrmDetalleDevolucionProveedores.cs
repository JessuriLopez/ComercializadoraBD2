using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComercializadoraBD2
{
    public partial class FrmDetalleDevolucionProveedores : Form
    {
        public int DevolucionID;
        public FrmDetalleDevolucionProveedores()
        {
            InitializeComponent();
        }

        private void FrmDetalleDevolucionProveedores_Load(object sender, EventArgs e)
        {
            CargarProductosDeOrden();
            CargarDetalles();
        }


        private int ObtenerOrdenCompraID()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT OrdenCompraID FROM DevolucionesProveedores WHERE DevolucionID = @DevolucionID",
                    con);

                cmd.Parameters.AddWithValue("@DevolucionID", DevolucionID);

                con.Open();
                object result = cmd.ExecuteScalar();
                con.Close();

                return (result != null) ? Convert.ToInt32(result) : 0;
            }
        }
        private void CargarProductosDeOrden()
        {
            int ordenID = ObtenerOrdenCompraID();

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT P.ProductoID, P.Nombre, D.PrecioUnitario
              FROM Productos P
              INNER JOIN DetalleOrdenCompra D ON P.ProductoID = D.ProductoID
              WHERE D.OrdenCompraID = @OrdenCompraID", con);

                da.SelectCommand.Parameters.AddWithValue("@OrdenCompraID", ordenID);

                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbProducto.DataSource = dt;
                cmbProducto.DisplayMember = "Nombre";
                cmbProducto.ValueMember = "ProductoID";
            }
        }


        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedItem is DataRowView row)
            {
                txtPrecioUnitario.Text = row["PrecioUnitario"].ToString();
            }

            if (cmbProducto.SelectedValue == null) return;
            if (cmbProducto.SelectedValue is DataRowView) return;

            int productoID = Convert.ToInt32(cmbProducto.SelectedValue);
            CargarLotesPorOrden(productoID);
        }

        private void CargarLotesPorOrden(int productoID)
        {
            int ordenID = ObtenerOrdenCompraID();

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT L.LoteID, L.NumeroLote
              FROM LotesProductos L
              INNER JOIN DetalleOrdenCompra D ON L.ProductoID = D.ProductoID
              WHERE L.ProductoID = @ProductoID
              AND D.OrdenCompraID = @OrdenCompraID", con);

                da.SelectCommand.Parameters.AddWithValue("@ProductoID", productoID);
                da.SelectCommand.Parameters.AddWithValue("@OrdenCompraID", ordenID);

                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbLote.DataSource = dt;
                cmbLote.DisplayMember = "NumeroLote";
                cmbLote.ValueMember = "LoteID";
            }
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            CalcularSubtotal();
        }

        private void txtPrecioUnitario_TextChanged(object sender, EventArgs e)
        {
            CalcularSubtotal();
        }


        private void CalcularSubtotal()
        {
            if (int.TryParse(txtCantidad.Text, out int cantidad) &&
                decimal.TryParse(txtPrecioUnitario.Text, out decimal precio))
            {
                txtSubTotal.Text = (cantidad * precio).ToString("0.00");
            }
            else
            {
                txtSubTotal.Text = "0.00";
            }
        }

        private void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("sp_DetalleDevolucion_Insertar", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DevolucionID", DevolucionID);
                    cmd.Parameters.AddWithValue("@ProductoID", cmbProducto.SelectedValue);
                    cmd.Parameters.AddWithValue("@LoteID", cmbLote.SelectedValue);
                    cmd.Parameters.AddWithValue("@Cantidad", int.Parse(txtCantidad.Text));
                    cmd.Parameters.AddWithValue("@PrecioUnitario", decimal.Parse(txtPrecioUnitario.Text));

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                MessageBox.Show("Detalle agregado correctamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarDetalles();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar detalle: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void CargarDetalles()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "sp_DetalleDevolucion_ListarPorDevolucion", con);

                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@DevolucionID", DevolucionID);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvDetalles.DataSource = dt;
            }
        }

        private void btnVerDetalles_Click(object sender, EventArgs e)
        {
            if (dgvDetalles.CurrentRow != null)
            {
                cmbProducto.SelectedValue = dgvDetalles.CurrentRow.Cells["ProductoID"].Value;
                cmbLote.SelectedValue = dgvDetalles.CurrentRow.Cells["LoteID"].Value;

                txtCantidad.Text = dgvDetalles.CurrentRow.Cells["Cantidad"].Value.ToString();
                txtPrecioUnitario.Text = dgvDetalles.CurrentRow.Cells["PrecioUnitario"].Value.ToString();
                txtSubTotal.Text = dgvDetalles.CurrentRow.Cells["SubTotal"].Value.ToString();

            }
        }

        private void btnEliminarDetalle_Click(object sender, EventArgs e)
        {
            if (dgvDetalles.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un registro primero.");
                return;
            }

            int id = Convert.ToInt32(dgvDetalles.CurrentRow.Cells["DetalleDevolucionID"].Value);

            if (MessageBox.Show("¿Desea eliminar este detalle?", "Confirmación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = Conexion.ObtenerConexion())
                    {
                        SqlCommand cmd = new SqlCommand("sp_DetalleDevolucion_Eliminar", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DetalleDevolucionID", id);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }

                    MessageBox.Show("Detalle eliminado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarDetalles();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar detalle: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }


        private void LimpiarCampos()
        {
            txtCantidad.Clear();
            txtPrecioUnitario.Clear();
            txtSubTotal.Text = "0.00";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Datos guardados correctamente.", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();

            if (this.Owner != null)
                this.Owner.Close();
        }
    }
}
