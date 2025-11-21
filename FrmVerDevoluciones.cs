using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComercializadoraBD2
{
    public partial class FrmVerDevoluciones : Form
    {
        private int DevolucionIDSeleccionada = 0;
        private bool CargandoDetalles = false;
        public FrmVerDevoluciones()
        {
            InitializeComponent();
        }

        private void FrmVerDevoluciones_Load(object sender, EventArgs e)
        {
            CargarDevoluciones();
            ConfigurarDgvDetalles();
        }


        private void CargarDevoluciones()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_listar_devoluciones_proveedores", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvDevoluciones.DataSource = dt;
            }
        }

        private void dgvDevoluciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DevolucionIDSeleccionada = Convert.ToInt32(dgvDevoluciones.Rows[e.RowIndex].Cells["DevolucionID"].Value);
            CargarDetalles();
        }

        private void CargarDetalles()
        {
            if (DevolucionIDSeleccionada == 0) return;

            CargandoDetalles = true;

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_DetalleDevolucion_ListarPorDevolucion", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@DevolucionID", DevolucionIDSeleccionada);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvDetalles.DataSource = dt;
            }

            ConfigurarDgvDetalles();
            CargandoDetalles = false;
        }


        private void ConfigurarDgvDetalles()
        {
            if (dgvDetalles.Columns.Contains("Cantidad")) dgvDetalles.Columns["Cantidad"].ReadOnly = false;
            if (dgvDetalles.Columns.Contains("PrecioUnitario")) dgvDetalles.Columns["PrecioUnitario"].ReadOnly = false;
            if (dgvDetalles.Columns.Contains("Producto")) dgvDetalles.Columns["Producto"].ReadOnly = true;
            if (dgvDetalles.Columns.Contains("NumeroLote")) dgvDetalles.Columns["NumeroLote"].ReadOnly = true;
            if (dgvDetalles.Columns.Contains("SubTotal")) dgvDetalles.Columns["SubTotal"].ReadOnly = true;
        }

        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CargandoDetalles || dgvDetalles.CurrentRow == null) return;

            GuardarDetalleEditado();
        }

        private void GuardarDetalleEditado()
        {
            int detalleID = Convert.ToInt32(dgvDetalles.CurrentRow.Cells["DetalleDevolucionID"].Value);
            int cantidad = Convert.ToInt32(dgvDetalles.CurrentRow.Cells["Cantidad"].Value);
            decimal precio = Convert.ToDecimal(dgvDetalles.CurrentRow.Cells["PrecioUnitario"].Value);

            decimal subtotal = cantidad * precio;
            dgvDetalles.CurrentRow.Cells["SubTotal"].Value = subtotal;

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_DetalleDevolucion_Actualizar", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DetalleDevolucionID", detalleID);
                cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                cmd.Parameters.AddWithValue("@PrecioUnitario", precio);
                cmd.Parameters.AddWithValue("@ProductoID", dgvDetalles.CurrentRow.Cells["ProductoID"].Value);
                cmd.Parameters.AddWithValue("@LoteID", dgvDetalles.CurrentRow.Cells["LoteID"].Value);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (DevolucionIDSeleccionada == 0) return;

            if (MessageBox.Show("¿Eliminar devolución completa?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("sp_eliminar_devolucion_proveedor", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DevolucionID", DevolucionIDSeleccionada);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Devolución eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarDevoluciones();
                dgvDetalles.DataSource = null;
                DevolucionIDSeleccionada = 0;
            }
        }
    }
}
