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
    public partial class FrmOrdenCompras : Form
    {

        public int OrdenCompraID = 0;
        public FrmOrdenCompras()
        {
            InitializeComponent();
        }

        private void FrmOrdenCompras_Load(object sender, EventArgs e)
        {
            CargarProveedores();
            CargarUsuarios();
            CargarPlazosPago();
            CargarMetodosPago();
            CargarEstados();
            GenerarNumeroOrden();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GenerarNumeroOrden()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();

                    string query = @"
                SELECT TOP 1 NumeroOrden 
                FROM OrdenesCompra 
                ORDER BY OrdenCompraID DESC";

                    SqlCommand cmd = new SqlCommand(query, con);
                    var result = cmd.ExecuteScalar();

                    int siguienteNumero = 1;

                    if (result != null && result != DBNull.Value)
                    {
                        string ultimo = result.ToString();

                        string numero = ultimo.Split('-')[1];
                        siguienteNumero = int.Parse(numero) + 1;
                    }
                    txtNumOrden.Text = "OC-" + siguienteNumero.ToString("0000");
                    txtNumOrden.ReadOnly = true;
                }
            }
            catch
            {
                txtNumOrden.Text = "OC-0001"; // En caso de que no existan órdenes
            }
        }





        private void btnGuardarOrden_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("sp_agregar_orden_compra", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@NumeroOrden", txtNumOrden.Text.Trim());
                    cmd.Parameters.AddWithValue("@ProveedorID", cmbProveedor.SelectedValue);
                    cmd.Parameters.AddWithValue("@UsuarioID", cmbUsuario.SelectedValue);
                    cmd.Parameters.AddWithValue("@FechaEntregaEsperada", dtpFechaEsperada.Value);
                    cmd.Parameters.AddWithValue("@PlazoPago", cmbPlazoPago.Text);
                    cmd.Parameters.AddWithValue("@MetodoPago", cmbMetodoPago.Text);
                    cmd.Parameters.AddWithValue("@SubTotal", 0);
                    cmd.Parameters.AddWithValue("@Impuesto", 0);
                    cmd.Parameters.AddWithValue("@Total", 0);
                    cmd.Parameters.AddWithValue("@Estado", cmbEstado.Text);
                    cmd.Parameters.AddWithValue("@Observaciones", txtObservaciones.Text);

                    // Parámetro OUTPUT
                    SqlParameter outputId = new SqlParameter("@OrdenCompraID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    // Guardar el ID generado
                    this.OrdenCompraID = (int)outputId.Value;

                    MessageBox.Show("Orden creada correctamente.", "Éxito",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la orden: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }



        private void CargarProveedores()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT ProveedorID, Nombre FROM Proveedores WHERE Estado = 1", con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbProveedor.DataSource = dt;
                cmbProveedor.DisplayMember = "Nombre";
                cmbProveedor.ValueMember = "ProveedorID";
            }
        }

        private void CargarUsuarios()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT UsuarioID, NombreUsuario FROM Usuarios WHERE IsDelete = 0", con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbUsuario.DataSource = dt;
                cmbUsuario.DisplayMember = "NombreUsuario";
                cmbUsuario.ValueMember = "UsuarioID";
            }
        }

        private void CargarPlazosPago()
        {
            cmbPlazoPago.Items.Clear();
            cmbPlazoPago.Items.Add("Contado");
            cmbPlazoPago.Items.Add("30 días");
            cmbPlazoPago.Items.Add("60 días");
            cmbPlazoPago.Items.Add("90 días");
            cmbPlazoPago.SelectedIndex = 0;
        }

        private void CargarMetodosPago()
        {
            cmbMetodoPago.Items.Clear();
            cmbMetodoPago.Items.Add("Transferencia");
            cmbMetodoPago.Items.Add("Efectivo");
            cmbMetodoPago.Items.Add("Cheque");
            cmbMetodoPago.Items.Add("Crédito");
            cmbMetodoPago.SelectedIndex = 0;
        }

        private void CargarEstados()
        {
            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("Pendiente");
            cmbEstado.Items.Add("Aprobada");
            cmbEstado.Items.Add("Cancelada");
            cmbEstado.SelectedIndex = 0; // Estado inicial
        }

        private void btnDetallesOrdenCompra_Click(object sender, EventArgs e)
        {
            FrmDetalleOrdenCompra frm = new FrmDetalleOrdenCompra();
            frm.OrdenCompraID = this.OrdenCompraID; 
            frm.ShowDialog();
        }
    }
}
