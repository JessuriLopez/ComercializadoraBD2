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
    public partial class ClientesCRUD : Form
    {
        public ClientesCRUD()
        {
            InitializeComponent();
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvClientes.Rows[e.RowIndex];
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtRTN.Text = fila.Cells["ReferenciaTributaria"].Value.ToString();
                txtTelefono.Text = fila.Cells["Telefono"].Value.ToString();
                txtEmail.Text = fila.Cells["Email"].Value.ToString();
                txtDireccion.Text = fila.Cells["Direccion"].Value.ToString();
                cmbTipo.Text = fila.Cells["TipoCliente"].Value.ToString();
                txtLimiteCredito.Text = fila.Cells["LimiteCredito"].Value.ToString();
                chkPrecioEspecial.Checked = Convert.ToBoolean(fila.Cells["PrecioEspecial"].Value);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_agregar_cliente", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@ReferenciaTributaria", txtRTN.Text);
                    cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
                    cmd.Parameters.AddWithValue("@TipoCliente", cmbTipo.Text);
                    cmd.Parameters.AddWithValue("@LimiteCredito", decimal.Parse(txtLimiteCredito.Text));
                    cmd.Parameters.AddWithValue("@PrecioEspecial", chkPrecioEspecial.Checked);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cliente agregado correctamente");
                    ListarClientes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar cliente: " + ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un cliente para editar.");
                return;
            }

            try
            {
                int id = Convert.ToInt32(dgvClientes.CurrentRow.Cells["ClienteID"].Value);

                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_editar_cliente", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ClienteID", id);
                    cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@ReferenciaTributaria", txtRTN.Text);
                    cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
                    cmd.Parameters.AddWithValue("@TipoCliente", cmbTipo.Text);
                    cmd.Parameters.AddWithValue("@LimiteCredito", decimal.Parse(txtLimiteCredito.Text));
                    cmd.Parameters.AddWithValue("@PrecioEspecial", chkPrecioEspecial.Checked);
                    cmd.Parameters.AddWithValue("@Estado", 1);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cliente actualizado correctamente");
                    ListarClientes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar cliente: " + ex.Message);
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            ListarClientes();
        }

        private void ListarClientes()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_listar_clientes", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvClientes.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar clientes: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            {
                if (dgvClientes.CurrentRow == null)
                {
                    MessageBox.Show("Selecciona un cliente para eliminar.");
                    return;
                }

                int id = Convert.ToInt32(dgvClientes.CurrentRow.Cells["ClienteID"].Value);

                DialogResult respuesta = MessageBox.Show(
                    "¿Estás seguro de que deseas eliminar este cliente?",
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
                        SqlCommand cmd = new SqlCommand("sp_eliminar_cliente", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ClienteID", id);

                        cmd.ExecuteNonQuery();
                     
                    }

                    MessageBox.Show("Cliente eliminado correctamente.");
                    ListarClientes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar cliente: " + ex.Message);
                }
            }
        }
    }
}
