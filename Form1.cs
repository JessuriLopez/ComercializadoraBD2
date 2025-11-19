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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_agregar_proveedor", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@ReferenciaTributaria", txtRTN.Text);
                cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
                cmd.Parameters.AddWithValue("@TipoProveedor", cmbTipo.Text);
                cmd.Parameters.AddWithValue("@LimiteCredito", decimal.Parse(txtLimiteCredito.Text));

                cmd.ExecuteNonQuery();
                MessageBox.Show("Proveedor agregado correctamente");
                con.Close();
                ListarProveedores();
            }
    }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un proveedor para editar.");
                return;
            }

            int id = Convert.ToInt32(dgvProveedores.CurrentRow.Cells["ProveedorID"].Value);
            string nombreEmpresa = txtNombre.Text;
            MessageBox.Show("Editando proveedor: " + nombreEmpresa);

            //int id = Convert.ToInt32(dgvProveedores.CurrentRow.Cells["ProveedorID"].Value);

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_editar_proveedor", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProveedorID", id);
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@ReferenciaTributaria", txtRTN.Text);
                cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
                cmd.Parameters.AddWithValue("@TipoProveedor", cmbTipo.Text);
                decimal limiteCredito;

                if (!decimal.TryParse(txtLimiteCredito.Text, out limiteCredito))
                {
                    MessageBox.Show("Por favor ingresa un número válido en el campo 'Límite de Crédito'.");
                    return;
                }

                cmd.Parameters.AddWithValue("@LimiteCredito", limiteCredito);
                cmd.Parameters.AddWithValue("@Estado", 1);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Proveedor actualizado correctamente");
                con.Close();
                ListarProveedores();
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_listar_proveedores", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                    dgvProveedores.DataSource = dt;
                else
                    MessageBox.Show("No hay proveedores registrados");

                con.Close();
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un proveedor para eliminar.");
                return;
            }

            int id = Convert.ToInt32(dgvProveedores.CurrentRow.Cells["ProveedorID"].Value);

            DialogResult respuesta = MessageBox.Show(
                "¿Estás seguro de que deseas eliminar este proveedor?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (respuesta == DialogResult.No)
            {
                return; 
            }

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_eliminar_proveedor", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ProveedorID", id);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Proveedor eliminado correctamente");
                ListarProveedores();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar proveedor: " + ex.Message);
            }
        }

        private void ListarProveedores()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_listar_proveedores", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvProveedores.DataSource = dt;
                con.Close();
            }
        }

        private void dgvProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvProveedores.Rows[e.RowIndex];
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtRTN.Text = fila.Cells["ReferenciaTributaria"].Value.ToString();
                txtTelefono.Text = fila.Cells["Telefono"].Value.ToString();
                txtEmail.Text = fila.Cells["Email"].Value.ToString();
                txtDireccion.Text = fila.Cells["Direccion"].Value.ToString();
                cmbTipo.Text = fila.Cells["TipoProveedor"].Value.ToString();
                txtLimiteCredito.Text = fila.Cells["LimiteCredito"].Value.ToString();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
