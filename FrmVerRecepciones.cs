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
    public partial class FrmVerRecepciones : Form
    {
        private int RecepcionIDSeleccionada = 0;
        private bool CargandoDetalles = false;
        public FrmVerRecepciones()
        {
            InitializeComponent();
        }

        private void FrmVerRecepciones_Load(object sender, EventArgs e)
        {
            CargarRecepciones();
        }


        private void CargarRecepciones()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_listar_recepciones", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvRecepciones.DataSource = dt;
            }
        }
        private void CargarDetallesRecepcion()
        {
            if (RecepcionIDSeleccionada == 0)
                return;

            CargandoDetalles = true;

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_listar_detalle_por_recepcion", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@RecepcionID", RecepcionIDSeleccionada);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvDetallesRecepciones.DataSource = dt;
            }

            CargandoDetalles = false;
        }

        private void GuardarDetalleRecepcionEditado()
        {
            if (dgvDetallesRecepciones.CurrentRow == null) return;

            int detalleID = Convert.ToInt32(dgvDetallesRecepciones.CurrentRow.Cells["DetalleRecepcionID"].Value);
            int cantidad = Convert.ToInt32(dgvDetallesRecepciones.CurrentRow.Cells["CantidadRecibida"].Value);

            string lote = dgvDetallesRecepciones.CurrentRow.Cells["NumeroLote"].Value?.ToString();
            DateTime fechaVenc = Convert.ToDateTime(dgvDetallesRecepciones.CurrentRow.Cells["FechaVencimiento"].Value);
            string ubicacion = dgvDetallesRecepciones.CurrentRow.Cells["UbicacionAlmacen"].Value?.ToString();
            bool aceptado = Convert.ToBoolean(dgvDetallesRecepciones.CurrentRow.Cells["Aceptado"].Value);
            string motivo = dgvDetallesRecepciones.CurrentRow.Cells["MotivoRechazo"].Value?.ToString();

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_editar_detalle_recepcion", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DetalleRecepcionID", detalleID);
                cmd.Parameters.AddWithValue("@CantidadRecibida", cantidad);
                cmd.Parameters.AddWithValue("@NumeroLote", lote);
                cmd.Parameters.AddWithValue("@FechaVencimiento", fechaVenc);
                cmd.Parameters.AddWithValue("@UbicacionAlmacen", ubicacion);
                cmd.Parameters.AddWithValue("@Aceptado", aceptado);
                cmd.Parameters.AddWithValue("@MotivoRechazo", motivo);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void dgvDetallesRecepciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CargandoDetalles) return;

            GuardarDetalleRecepcionEditado();
        }

        private void dgvRecepciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            RecepcionIDSeleccionada =
                Convert.ToInt32(dgvRecepciones.Rows[e.RowIndex].Cells["RecepcionID"].Value);

            CargarDetallesRecepcion();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvRecepciones.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvRecepciones.CurrentRow.Cells["RecepcionID"].Value);

            if (MessageBox.Show("¿Eliminar recepción?", "Confirmar",
                MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_eliminar_recepcion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RecepcionID", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Recepción eliminada.");
            CargarRecepciones();
        }
    }
}
