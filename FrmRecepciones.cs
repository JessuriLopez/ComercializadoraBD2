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
    
    public partial class FrmRecepciones : Form
    {

        public int RecepcionID = 0;
        public FrmRecepciones()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmRecepciones_Load(object sender, EventArgs e)
        {
            CargarOrdenesPendientes();
            CargarUsuarios();
            CargarEstadosRecepcion();
            GenerarNumeroRemision();
        }

        private void GenerarNumeroRemision()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();

                    string query = @"
                    SELECT TOP 1 NumeroRemision
                    FROM RecepcionesCompra
                    ORDER BY RecepcionID DESC";

                    SqlCommand cmd = new SqlCommand(query, con);
                    var result = cmd.ExecuteScalar();

                    int siguiente = 1;

                    if (result != null && result != DBNull.Value)
                    {
                        string ultimo = result.ToString();         // RM-0004
                        string numero = ultimo.Split('-')[1];      // 0004
                        siguiente = int.Parse(numero) + 1;
                    }

                    txtNumRemision.Text = "RM-" + siguiente.ToString("0000");
                    txtNumRemision.ReadOnly = true;
                }
            }
            catch
            {
                txtNumRemision.Text = "RM-0001";
            }
        }

        private void CargarOrdenesPendientes()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT OrdenCompraID, NumeroOrden FROM OrdenesCompra WHERE Estado = 'Pendiente'",
                    con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbNumOrden.DataSource = dt;
                cmbNumOrden.DisplayMember = "NumeroOrden";
                cmbNumOrden.ValueMember = "OrdenCompraID";
            }
        }

        private void CargarUsuarios()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT UsuarioID, NombreUsuario FROM Usuarios WHERE IsDelete = 0",
                    con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbUsuario.DataSource = dt;
                cmbUsuario.DisplayMember = "NombreUsuario";
                cmbUsuario.ValueMember = "UsuarioID";
            }
        }

        private void CargarEstadosRecepcion()
        {
            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("Pendiente");
            cmbEstado.Items.Add("Recibido");
            cmbEstado.Items.Add("Parcial");
            cmbEstado.Items.Add("Cancelada");
            cmbEstado.SelectedIndex = 0;
        }

        private void btnRecibir_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("sp_agregar_recepcion", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@OrdenCompraID", cmbNumOrden.SelectedValue);
                    cmd.Parameters.AddWithValue("@UsuarioID", cmbUsuario.SelectedValue);
                    cmd.Parameters.AddWithValue("@NumeroRemision", txtNumRemision.Text.Trim());
                    cmd.Parameters.AddWithValue("@Observaciones", txtObservaciones.Text.Trim());
                    cmd.Parameters.AddWithValue("@EstadoRecepcion", cmbEstado.Text);

                    SqlParameter output = new SqlParameter("@RecepcionID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(output);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    RecepcionID = (int)output.Value;

                    MessageBox.Show("Recepción guardada correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la recepción: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDetallesRecepcion_Click(object sender, EventArgs e)
        {
            FrmDetalleRecepcion frm = new FrmDetalleRecepcion();
            frm.Owner = this;
            frm.RecepcionID = this.RecepcionID;
            frm.ShowDialog();
        }
    }
}
