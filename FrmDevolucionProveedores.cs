using ComercializadoraBD2;
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
    public partial class FrmDevolucionProveedores : Form
    {
        public int DevolucionID = 0;
        public FrmDevolucionProveedores()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmDevolucionProveedores_Load(object sender, EventArgs e)
        {
            CargarOrdenes();
            CargarMotivos();
            CargarEstados();
            GenerarNumeroDevolucion();
            CargarProveedores();

        }

        private void CargarMotivos()
        {
            cmbMotivoDevolucion.Items.Clear();
            cmbMotivoDevolucion.Items.Add("Vencido");
            cmbMotivoDevolucion.Items.Add("Defectuoso");
            cmbMotivoDevolucion.Items.Add("NoSolicitado");
            cmbMotivoDevolucion.Items.Add("Otro");
            cmbMotivoDevolucion.SelectedIndex = 0;
        }

        private void CargarEstados()
        {
            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("Pendiente");
            cmbEstado.Items.Add("Aprobada");
            cmbEstado.SelectedIndex = 0;
        }
        private void GenerarNumeroDevolucion()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    string query = @"SELECT TOP 1 NumeroDevolucion FROM DevolucionesProveedores ORDER BY DevolucionID DESC";
                    SqlCommand cmd = new SqlCommand(query, con);
                    var result = cmd.ExecuteScalar();

                    int siguienteNumero = 1;
                    if (result != null && result != DBNull.Value)
                    {
                        string ultimo = result.ToString();
                        string numero = ultimo.Split('-')[1];
                        siguienteNumero = int.Parse(numero) + 1;
                    }
                    txtNumeroDevolucion.Text = "DEV-" + siguienteNumero.ToString("0000");
                    txtNumeroDevolucion.ReadOnly = true;
                }
            }
            catch
            {
                txtNumeroDevolucion.Text = "DEV-0001";
            }
        }

        private void CargarOrdenes()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                string query = @"
            SELECT 
                o.OrdenCompraID, 
                o.NumeroOrden, 
                p.ProveedorID, 
                p.Nombre AS NombreProveedor
            FROM OrdenesCompra o
            INNER JOIN Proveedores p ON o.ProveedorID = p.ProveedorID
            WHERE o.Estado IN ('Aprobada', 'Pendiente')"; // incluir los estados que necesites

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbNumeroOrden.DataSource = dt;
                cmbNumeroOrden.DisplayMember = "NumeroOrden";
                cmbNumeroOrden.ValueMember = "OrdenCompraID";
            }
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


        private void btnAgregarDetalles_Click(object sender, EventArgs e)
        {
            FrmDetalleDevolucionProveedores frm = new FrmDetalleDevolucionProveedores();
            frm.Owner = this;
            frm.DevolucionID = this.DevolucionID;
            frm.ShowDialog();

        }

        private void cmbNumeroOrden_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNumeroOrden.SelectedValue != null && int.TryParse(cmbNumeroOrden.SelectedValue.ToString(), out int ordenID))
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand(
                        @"SELECT ProveedorID 
                  FROM OrdenesCompra
                  WHERE OrdenCompraID = @OrdenID", con);
                    cmd.Parameters.AddWithValue("@OrdenID", ordenID);
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    con.Close();

                    if (result != null && result != DBNull.Value)
                    {
                        cmbProveedor.SelectedValue = (int)result;
                        cmbProveedor.Enabled = false; 
                    }
                }
            }

        }


        private void btnGuardarDevolucion_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("sp_insertar_devolucion_proveedor", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ProveedorID", cmbProveedor.SelectedValue);
                    cmd.Parameters.AddWithValue("@OrdenCompraID", cmbNumeroOrden.SelectedValue);
                    cmd.Parameters.AddWithValue("@NumeroDevolucion", txtNumeroDevolucion.Text.Trim());
                    cmd.Parameters.AddWithValue("@MotivoDevolucion", cmbMotivoDevolucion.Text.Trim());
                    cmd.Parameters.AddWithValue("@Total", 0);
                    cmd.Parameters.AddWithValue("@Estado", cmbEstado.Text);
                    cmd.Parameters.AddWithValue("@Observaciones", txtObservaciones.Text.Trim());

                    SqlParameter outputId = new SqlParameter("@DevolucionID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    this.DevolucionID = (int)outputId.Value;
                    MessageBox.Show("Devolución registrada correctamente.", "Éxito",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la devolución: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
