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
    public partial class FrmLotes : Form
    {
        public FrmLotes()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmLotes_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void CargarProductos()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        "SELECT ProductoID, Nombre FROM Productos WHERE Estado = 1", con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbProducto.DataSource = dt;
                    cmbProducto.DisplayMember = "Nombre";
                    cmbProducto.ValueMember = "ProductoID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
        }
        private void CargarLotes(string storedProcedure)
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(storedProcedure, con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvLotes.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar lotes: " + ex.Message);
            }
        }

        private void btnLotesActivos_Click(object sender, EventArgs e)
        {
            CargarLotes("sp_listar_lotes");
        }

        private void btnProximosVencer_Click(object sender, EventArgs e)
        {
            CargarLotes("sp_listar_lotes_proximos");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("sp_agregar_lote", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ProductoID", cmbProducto.SelectedValue);
                    cmd.Parameters.AddWithValue("@NumeroLote", txtNumeroLote.Text);
                    cmd.Parameters.AddWithValue("@FechaVencimiento", dtpFechaVencimiento.Value);
                    cmd.Parameters.AddWithValue("@CantidadInicial", int.Parse(txtCantidadInicial.Text));
                    cmd.Parameters.AddWithValue("@CantidadActual", int.Parse(txtCantidadInicial.Text));
                    cmd.Parameters.AddWithValue("@UbicacionAlmacen", txtUbicacion.Text);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Lote creado exitosamente.");
                CargarLotes("sp_listar_lotes");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar lote: " + ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvLotes.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un lote para editar.");
                return;
            }

            int loteID = Convert.ToInt32(dgvLotes.CurrentRow.Cells["LoteID"].Value);

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_editar_lote", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@LoteID", loteID);
                cmd.Parameters.AddWithValue("@FechaVencimiento", dtpFechaVencimiento.Value);
                cmd.Parameters.AddWithValue("@CantidadActual", int.Parse(txtCantidadActual.Text));
                cmd.Parameters.AddWithValue("@UbicacionAlmacen", txtUbicacion.Text);
                cmd.Parameters.AddWithValue("@Estado", 1);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Lote actualizado correctamente");
                CargarLotes("sp_listar_lotes");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvLotes.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un lote para eliminar.");
                return;
            }

            int loteID = Convert.ToInt32(dgvLotes.CurrentRow.Cells["LoteID"].Value);

            DialogResult result = MessageBox.Show(
                "¿Seguro que deseas eliminar este lote?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.No)
                return;

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_eliminar_lote", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@LoteID", loteID);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Lote eliminado correctamente");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("No se puede eliminar el lote: " + ex.Message);
            }
            finally
            {
                CargarLotes("sp_listar_lotes");
            }


        }

        private void dgvLotes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; 

            DataGridViewRow fila = dgvLotes.Rows[e.RowIndex];

            cmbProducto.SelectedValue = fila.Cells["ProductoID"].Value;
            txtNumeroLote.Text = fila.Cells["NumeroLote"].Value.ToString();
            dtpFechaVencimiento.Value = Convert.ToDateTime(fila.Cells["FechaVencimiento"].Value);
            txtCantidadInicial.Text = fila.Cells["CantidadInicial"].Value.ToString();
            txtCantidadActual.Text = fila.Cells["CantidadActual"].Value.ToString();
            txtUbicacion.Text = fila.Cells["UbicacionAlmacen"].Value.ToString();
        }
    }
}
