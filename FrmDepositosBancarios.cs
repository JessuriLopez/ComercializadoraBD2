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
    public partial class FrmDepositosBancarios : Form
    {
        private void CargarNumerosDeCuenta()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                try
                {
                    con.Open();

                    // Llama al procedimiento que devuelve todas las cuentas bancarias
                    SqlCommand cmd = new SqlCommand("sp_ConsultarCuentasBancarias", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        // 1. Asignar la fuente de datos al ComboBox
                        cmbCuenta.DataSource = dt;

                        // 2. DisplayMember: Define qué columna se MUESTRA en la lista
                        cmbCuenta.DisplayMember = "NumeroCuenta";

                        // 3. ValueMember: Define el valor INTERNO (ID) que se almacena
                        cmbCuenta.ValueMember = "CuentaBancariaID";
                    }
                    else
                    {
                        MessageBox.Show("No hay números de cuenta para mostrar.", "Información");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar las cuentas: " + ex.Message);
                }
            }
        }
        private void CargarDatosEnDataGrid()
        {
            // Verifica si el objeto datagridCuentaBancaria existe antes de usarlo.
            // Además, se asume que 'Conexion.ObtenerConexion()' y las clases necesarias están accesibles.

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                try
                {
                    con.Open();

                    // 1. Configura el comando para llamar al Stored Procedure
                    SqlCommand cmd = new SqlCommand("sp_ConsultarDepositos", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 2. Utiliza SqlDataAdapter y DataTable para llenar la estructura de datos
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // 3. Asigna el resultado al DataGrid si hay datos
                    if (dt.Rows.Count > 0)
                    {
                        // Asigna el DataTable como fuente de datos para el DataGrid
                        dgDepositos.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("No hay Cuentas Bancarias registradas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Si no hay datos, es bueno limpiar la fuente
                        dgDepositos.DataSource = null;
                    }
                }
                catch (SqlException ex)
                {
                    // Manejo de errores de SQL
                    MessageBox.Show("Error de base de datos al cargar cuentas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    // Manejo de otros errores
                    MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } // El 'using' se encarga automáticamente de con.Close() y con.Dispose()
        }

        public FrmDepositosBancarios()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtObservaciones_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgDepositos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmDepositosBancarios_Load(object sender, EventArgs e)
        {
            CargarDatosEnDataGrid();
            CargarNumerosDeCuenta();
        }

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            

    // Validar selección de cuenta
    if (cmbCuenta.SelectedValue == null || (int)cmbCuenta.SelectedValue <= 0)
            {
                MessageBox.Show("Por favor, seleccione una cuenta bancaria válida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCuenta.Focus();
                return;
            }

            // Obtener el ID de la cuenta (el valor que está en ValueMember)
            int cuentaID = Convert.ToInt32(cmbCuenta.SelectedValue);

            // Validar y obtener el monto
            if (!decimal.TryParse(txtMonto.Text, out decimal montoTotal) || montoTotal <= 0)
            {
                MessageBox.Show("Ingrese un monto de depósito válido (mayor a 0).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMonto.Focus();
                return;
            }

            // Obtener las observaciones
            string observaciones = txtobservaciones.Text;


            // 2. **CONEXIÓN Y EJECUCIÓN DEL PROCEDIMIENTO**

            // Usamos el SP que realiza la inserción y genera el correlativo
            string spName = "sp_GuardarDeposito";

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(spName, con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 3. **ASIGNACIÓN DE PARÁMETROS**

                    // @CuentaBancariaID (tomado del ComboBox)
                    cmd.Parameters.AddWithValue("@CuentaBancariaID", cuentaID);

                    // @Monto (tomado del TextBox)
                    cmd.Parameters.AddWithValue("@Monto", montoTotal);

                    // @Observaciones (tomado del TextBox)
                    cmd.Parameters.AddWithValue("@Observaciones", observaciones);

                    // @UsuarioID (Por defecto es 2 en el SP, pero lo enviamos por si acaso o para consistencia)
                    // Si el SP ya lo tiene por defecto, este es opcional, pero seguro de enviar.
                    cmd.Parameters.AddWithValue("@UsuarioID", 2);

                    // Ejecutar el comando (no esperamos resultados, solo que se inserte)
                    cmd.ExecuteNonQuery();

                    // 4. **CONFIRMACIÓN Y LIMPIEZA**

                    MessageBox.Show("Depósito registrado exitosamente. El saldo ha sido actualizado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar campos del formulario
                    txtMonto.Clear();
                    txtobservaciones.Clear();
                    cmbCuenta.SelectedIndex = 0; // O la lógica que uses para resetear

                    // Opcional: Si tienes un DataGrid mostrando saldos, refrescarlo aquí
                    // CargarDatosEnDataGrid(); 
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error de base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            CargarDatosEnDataGrid();
        }
    }
}
