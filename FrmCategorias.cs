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
    public partial class FrmCategorias : Form
    {
        public FrmCategorias()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("sp_agregar_categoria", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nombre", txtNombreCategoria.Text);
                cmd.Parameters.AddWithValue("@Descripcion", textDescripcion.Text);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Categoría agregada correctamente");
                    ListarCategorias();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar categoría: " + ex.Message);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow == null)
            {
                MessageBox.Show("Selecciona una categoría para editar.");
                return;
            }

            int id = Convert.ToInt32(dgvCategorias.CurrentRow.Cells["CategoriaID"].Value);

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("sp_editar_categoria", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CategoriaID", id);
                cmd.Parameters.AddWithValue("@Nombre", txtNombreCategoria.Text);
                cmd.Parameters.AddWithValue("@Descripcion", textDescripcion.Text);
                cmd.Parameters.AddWithValue("@Estado", 1); // Para mantener activa

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Categoría actualizada correctamente");
                    ListarCategorias();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al editar categoría: " + ex.Message);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow == null)
            {
                MessageBox.Show("Selecciona una categoría para eliminar.");
                return;
            }

            int id = Convert.ToInt32(dgvCategorias.CurrentRow.Cells["CategoriaID"].Value);

            DialogResult r = MessageBox.Show(
                "¿Seguro quieres eliminar esta categoría?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (r == DialogResult.No) return;

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("sp_eliminar_categoria", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CategoriaID", id);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Categoría eliminada correctamente");
                    ListarCategorias();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar categoría: " + ex.Message);
                }
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            ListarCategorias();
        }

        private void ListarCategorias()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("sp_listar_categorias", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvCategorias.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hay categorías activas registradas.");
                }
            }
        }

        private void dgvCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = dgvCategorias.Rows[e.RowIndex];

                txtNombreCategoria.Text = fila.Cells["Nombre"].Value.ToString();
                textDescripcion.Text = fila.Cells["Descripcion"].Value.ToString();
            }
        }

        private void FrmCategorias_Load(object sender, EventArgs e)
        {

        }
    }
}
