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
    public partial class FremCUentasBancariasCliente : Form
    {

        private void LimpiarCampos()
        {
           
            txtNombreBanco.Text = string.Empty; 
            txtNumeroCuenta.Text = string.Empty;

           
            cmbTipoCuenta.SelectedIndex = -1;
            comboBoxEstado.SelectedIndex = -1;

            txtSaldoActual.Text = string.Empty;
            txtNombreBanco.Focus();

            
        }
        public FremCUentasBancariasCliente()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxEstado.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbTipoCuenta.DropDownStyle = ComboBoxStyle.DropDownList;


        }

        private void FremCUentasBancariasCliente_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ConsultarCuentasBancarias", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                    datagridCuentaBancaria.DataSource = dt;
                else
                    MessageBox.Show("No hay CLientes registrados");

                con.Close();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            
            if (datagridCuentaBancaria.CurrentRow == null)
            {
                MessageBox.Show("Selecciona una cuenta bancaria para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            int id = Convert.ToInt32(datagridCuentaBancaria.CurrentRow.Cells["CuentaBancariaID"].Value);

            string CuentaBancaria = txtNombreBanco.Text;
            // MessageBox.Show("Editando Banco: " + CuentaBancaria); // Puedes dejar esta línea para depuración

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarCuentaBancaria", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    int estadoValor = (comboBoxEstado.Text == "Activo") ? 1 : 0;
                  
                    cmd.Parameters.AddWithValue("@CuentaID", id);
                    cmd.Parameters.AddWithValue("@NombreBanco", txtNombreBanco.Text);
                    cmd.Parameters.AddWithValue("@NumeroCuenta", txtNumeroCuenta.Text);
                    cmd.Parameters.AddWithValue("@TipoCuenta", cmbTipoCuenta.Text);
                    cmd.Parameters.AddWithValue("@Estado", estadoValor); 

                    

                    
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cuenta bancaria actualizada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    con.Close();
                    LimpiarCampos();
                    ListarCuentasBancarias(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar la cuenta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListarCuentasBancarias()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ConsultarCuentasBancarias", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                datagridCuentaBancaria.DataSource = dt;
                con.Close();

            }
        }

        private void datagridCuentaBancaria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            datagridCuentaBancaria.ReadOnly = true;
            if (datagridCuentaBancaria.CurrentRow == null)
                return;

            txtNombreBanco.Text = datagridCuentaBancaria.CurrentRow.Cells["NombreBanco"].Value.ToString();
            txtNumeroCuenta.Text = datagridCuentaBancaria.CurrentRow.Cells["NumeroCuenta"].Value.ToString();
            cmbTipoCuenta.Text = datagridCuentaBancaria.CurrentRow.Cells["TipoCuenta"].Value.ToString();
            comboBoxEstado.Text = datagridCuentaBancaria.CurrentRow.Cells["Estado"].Value.ToString();
            txtSaldoActual.Text = datagridCuentaBancaria.CurrentRow.Cells["SaldoActual"].Value.ToString();
        }

        private void txtSaldoActual_TextChanged(object sender, EventArgs e)
        {
            
            txtSaldoActual.ReadOnly = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // 1. Validar que los campos no estén vacíos (opcional pero recomendado)
            if (string.IsNullOrWhiteSpace(txtNombreBanco.Text) || string.IsNullOrWhiteSpace(txtNumeroCuenta.Text))
            {
                MessageBox.Show("Por favor, completa el nombre del banco y el número de cuenta.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    // 2. Usar el nuevo procedimiento almacenado de INSERT
                    SqlCommand cmd = new SqlCommand("sp_AgregarCuentaBancaria", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 3. Obtener los valores de los controles

                    // Convertir 'Activo'/'Inactivo' a 1/0 (BIT)
                    int estadoValor = (comboBoxEstado.Text == "Activo") ? 1 : 0;

                    // 4. Agregar los parámetros requeridos por el SP
                    // Nota: No se requiere el @CuentaID
                    cmd.Parameters.AddWithValue("@NombreBanco", txtNombreBanco.Text);
                    cmd.Parameters.AddWithValue("@NumeroCuenta", txtNumeroCuenta.Text);
                    cmd.Parameters.AddWithValue("@TipoCuenta", cmbTipoCuenta.Text);
                    cmd.Parameters.AddWithValue("@Estado", estadoValor); // Enviamos el 1 o 0

                    // 5. Ejecutar el comando para insertar la nueva cuenta
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Nueva cuenta bancaria guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                   
                    LimpiarCampos();

                    ListarCuentasBancarias();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar la cuenta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }

}
