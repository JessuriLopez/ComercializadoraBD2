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
    public partial class FrmDetalleOrdenCompra : Form
    {
        public int OrdenCompraID;
        public FrmDetalleOrdenCompra()
        {
            InitializeComponent();
        }

        private void btnAgregarDetalle_Click(object sender, EventArgs e)
        {

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("sp_agregar_detalle_orden", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@OrdenCompraID", OrdenCompraID);
                    cmd.Parameters.AddWithValue("@ProductoID", cmbProducto.SelectedValue);
                    cmd.Parameters.AddWithValue("@Cantidad", int.Parse(txtCantidad.Text));
                    cmd.Parameters.AddWithValue("@PrecioUnitario", decimal.Parse(txtPrecioUnitario.Text));
                    cmd.Parameters.AddWithValue("@SubTotal", decimal.Parse(txtSubTotal.Text));
                    cmd.Parameters.AddWithValue("@Estado", cmbEstado.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                MessageBox.Show("Detalle agregado correctamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarDetalles();
                ActualizarTotalesOrden();
                RecalcularTotales();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar detalle: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FrmDetalleOrdenCompra_Load(object sender, EventArgs e)
        {
            CargarProductos();
            CargarEstados();
            CargarDetalles();

        }

        private void ActualizarTotalesOrden()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_actualizar_totales_orden", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrdenCompraID", OrdenCompraID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        private void CargarProductos()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT ProductoID, Nombre, PrecioCompra FROM Productos WHERE Estado = 1", con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbProducto.DataSource = dt;
                cmbProducto.DisplayMember = "Nombre";
                cmbProducto.ValueMember = "ProductoID";
            }
        }


        private void CargarEstados()
        {
            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("Pendiente");
            cmbEstado.Items.Add("Recibido");
            cmbEstado.Items.Add("Parcial");
            cmbEstado.Items.Add("Cancelado");
            cmbEstado.SelectedIndex = 0;
        }





        private void txtSubT_TextChanged(object sender, EventArgs e)
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


        private void CargarDetalles()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "sp_listar_detalle_por_orden", con);

                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@OrdenCompraID", OrdenCompraID);

                DataTable dt = new DataTable();
                da.Fill(dt);

                if (!dt.Columns.Contains("Impuesto"))
                    dt.Columns.Add("Impuesto", typeof(decimal));

                foreach (DataRow row in dt.Rows)
                {
                    decimal sub = row["SubTotal"] != DBNull.Value ? Convert.ToDecimal(row["SubTotal"]) : 0;
                    decimal porc = row["PorcentajeImpuesto"] != DBNull.Value ? Convert.ToDecimal(row["PorcentajeImpuesto"]) : 0;
                    row["Impuesto"] = Math.Round(sub * porc / 100, 2);
                }

                dgvDetalles.DataSource = dt;
            }
        }

        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnVerDetalles_Click(object sender, EventArgs e)
        {
            if (dgvDetalles.CurrentRow != null)
            {
                cmbProducto.SelectedValue = dgvDetalles.CurrentRow.Cells["ProductoID"].Value;
                txtCantidad.Text = dgvDetalles.CurrentRow.Cells["Cantidad"].Value.ToString();
                txtPrecioUnitario.Text = dgvDetalles.CurrentRow.Cells["PrecioUnitario"].Value.ToString();
                txtSubTotal.Text = dgvDetalles.CurrentRow.Cells["SubTotal"].Value.ToString();
                cmbEstado.Text = dgvDetalles.CurrentRow.Cells["Estado"].Value.ToString();
            }

            CargarDetalles();
            ActualizarTotalesOrden();
            RecalcularTotales();

        }


        private void btnEliminarDetalle_Click(object sender, EventArgs e)
        {
            if (dgvDetalles.CurrentRow != null)
            {
                int detalleID = Convert.ToInt32(dgvDetalles.CurrentRow.Cells["DetalleOrdenID"].Value);
                if (MessageBox.Show("¿Desea eliminar este detalle?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection con = Conexion.ObtenerConexion())
                        {
                            SqlCommand cmd = new SqlCommand("sp_eliminar_detalle_orden", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@DetalleOrdenID", detalleID);

                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }

                        MessageBox.Show("Detalle eliminado correctamente.", "Éxito",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CargarDetalles();
                        LimpiarCampos();
                        ActualizarTotalesOrden();
                        RecalcularTotales();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar detalle: " + ex.Message,
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnRecalcular_Click(object sender, EventArgs e)
        {
            RecalcularTotales();
        }


        private void RecalcularTotales()
        {
            decimal subtotalProductos = 0;
            decimal totalImpuestos = 0;
            decimal total = 0;

            foreach (DataGridViewRow row in dgvDetalles.Rows)
            {
                if (row.Cells["SubTotal"].Value != null)
                    subtotalProductos += Convert.ToDecimal(row.Cells["SubTotal"].Value);

                if (row.Cells["Impuesto"].Value != null)
                    totalImpuestos += Convert.ToDecimal(row.Cells["Impuesto"].Value);
            }

            txtSubT.Text = subtotalProductos.ToString("0.00");
            txtImpuesto.Text = totalImpuestos.ToString("0.00");
            total = subtotalProductos + totalImpuestos;
            txtTotal.Text = total.ToString("0.00");
        }


        private void cmbProducto_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedValue != null)
            {
                DataRowView row = (DataRowView)cmbProducto.SelectedItem;
                txtPrecioUnitario.Text = row["PrecioCompra"].ToString();
                CalcularSubtotal();
            }
        }

        private void txtImpuestoPorcentaje_TextChanged(object sender, EventArgs e)
        {
            RecalcularTotales();
        }

        private void LimpiarCampos()
        {
            txtCantidad.Text = "";
            txtPrecioUnitario.Text = "";
            txtSubTotal.Text = "0.00";
            cmbProducto.SelectedIndex = 0;
            cmbEstado.SelectedIndex = 0;
        }

        private void txtImpuesto_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            CalcularSubtotal();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
