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
    public partial class FrmDetalleRecepcion : Form
    {
        public int RecepcionID = 0;
        public FrmDetalleRecepcion()
        {
            InitializeComponent();
        }

        private void FrmDetalleRecepcion_Load(object sender, EventArgs e)
        {
            CargarDetalleOrden();       
            CargarProductosDeOrden();   
            CargarDetallesRecepcion();
        }

        private int ObtenerOrdenCompraID()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT OrdenCompraID FROM RecepcionesCompra WHERE RecepcionID = @RecepcionID",
                    con);

                cmd.Parameters.AddWithValue("@RecepcionID", RecepcionID);

                con.Open();
                object result = cmd.ExecuteScalar();
                con.Close();

                return (result != null) ? Convert.ToInt32(result) : 0;
            }
        }

        private void CargarDetalleOrden()
        {
            int ordenCompraID = ObtenerOrdenCompraID();

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT DetalleOrdenID, ProductoID, Cantidad  
              FROM DetalleOrdenCompra 
              WHERE OrdenCompraID = @OrdenCompraID", con);

                da.SelectCommand.Parameters.AddWithValue("@OrdenCompraID", ordenCompraID);

                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbDetalleOrden.DataSource = dt;
                cmbDetalleOrden.DisplayMember = "DetalleOrdenID";
                cmbDetalleOrden.ValueMember = "DetalleOrdenID";

                cmbDetalleOrden.Enabled = false;
            }
        }


        private void CargarProductosDeOrden()
        {
            int ordenCompraID = ObtenerOrdenCompraID();

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT P.ProductoID, P.Nombre 
              FROM Productos P
              INNER JOIN DetalleOrdenCompra D ON P.ProductoID = D.ProductoID
              WHERE D.OrdenCompraID = @OrdenCompraID", con);

                da.SelectCommand.Parameters.AddWithValue("@OrdenCompraID", ordenCompraID);

                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbProducto.DataSource = dt;
                cmbProducto.DisplayMember = "Nombre";
                cmbProducto.ValueMember = "ProductoID";
            }
        }


        private void CargarDetallesRecepcion()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_listar_detalle_por_recepcion", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@RecepcionID", RecepcionID);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvDetalles.DataSource = dt;
            }
        }


        private void btnVerDetalles_Click(object sender, EventArgs e)
        {
            if (dgvDetalles.CurrentRow != null)
            {
                cmbDetalleOrden.SelectedValue = dgvDetalles.CurrentRow.Cells["DetalleOrdenID"].Value;
                cmbProducto.SelectedValue = dgvDetalles.CurrentRow.Cells["ProductoID"].Value;
                txtCantidad.Text = dgvDetalles.CurrentRow.Cells["CantidadRecibida"].Value.ToString();
                txtNumeroLote.Text = dgvDetalles.CurrentRow.Cells["NumeroLote"].Value.ToString();
                dtpFechaVencimiento.Value = Convert.ToDateTime(dgvDetalles.CurrentRow.Cells["FechaVencimiento"].Value);
                txtUbicacion.Text = dgvDetalles.CurrentRow.Cells["UbicacionAlmacen"].Value.ToString();
                chkAceptado.Checked = Convert.ToBoolean(dgvDetalles.CurrentRow.Cells["Aceptado"].Value);
                txtMotivo.Text = dgvDetalles.CurrentRow.Cells["MotivoRechazo"].Value.ToString();
            }
        }

        private void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("sp_agregar_detalle_recepcion", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RecepcionID", RecepcionID);
                    cmd.Parameters.AddWithValue("@DetalleOrdenID", cmbDetalleOrden.SelectedValue);
                    cmd.Parameters.AddWithValue("@ProductoID", cmbProducto.SelectedValue);
                    cmd.Parameters.AddWithValue("@CantidadRecibida", int.Parse(txtCantidad.Text));
                    cmd.Parameters.AddWithValue("@NumeroLote", txtNumeroLote.Text.Trim());
                    cmd.Parameters.AddWithValue("@FechaVencimiento", dtpFechaVencimiento.Value);
                    cmd.Parameters.AddWithValue("@UbicacionAlmacen", txtUbicacion.Text.Trim());
                    cmd.Parameters.AddWithValue("@Aceptado", chkAceptado.Checked);
                    cmd.Parameters.AddWithValue("@MotivoRechazo", txtMotivo.Text.Trim());

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                MessageBox.Show("Detalle de recepción agregado correctamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarDetallesRecepcion();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar detalle: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarDetalle_Click(object sender, EventArgs e)
        {
            if (dgvDetalles.CurrentRow != null)
            {
                int detalleID = Convert.ToInt32(dgvDetalles.CurrentRow.Cells["DetalleRecepcionID"].Value);
                if (MessageBox.Show("¿Desea eliminar este detalle?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection con = Conexion.ObtenerConexion())
                        {
                            SqlCommand cmd = new SqlCommand("sp_eliminar_detalle_recepcion", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@DetalleRecepcionID", detalleID);

                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }

                        MessageBox.Show("Detalle eliminado correctamente.", "Éxito",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CargarDetallesRecepcion();
                        LimpiarCampos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar detalle: " + ex.Message, "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }


        }

        private void LimpiarCampos()
        {
            txtCantidad.Text = "";
            txtNumeroLote.Text = "";
            txtUbicacion.Text = "";
            txtMotivo.Text = "";
            chkAceptado.Checked = false;
            if (cmbProducto.Items.Count > 0)
                cmbProducto.SelectedIndex = 0;
            if (cmbDetalleOrden.Items.Count > 0)
                cmbDetalleOrden.SelectedIndex = 0;
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedValue == null) return;
            if (cmbProducto.SelectedValue is DataRowView) return;

            int productoID = Convert.ToInt32(cmbProducto.SelectedValue);

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand(
                    @"SELECT DetalleOrdenID 
              FROM DetalleOrdenCompra 
              WHERE ProductoID = @ProductoID AND OrdenCompraID = 
              (SELECT OrdenCompraID FROM RecepcionesCompra WHERE RecepcionID = @RecepcionID)",
                    con);

                cmd.Parameters.AddWithValue("@ProductoID", productoID);
                cmd.Parameters.AddWithValue("@RecepcionID", RecepcionID);

                con.Open();
                object result = cmd.ExecuteScalar();
                con.Close();

                if (result != null)
                {
                    cmbDetalleOrden.SelectedValue = Convert.ToInt32(result);
                }
            }
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
