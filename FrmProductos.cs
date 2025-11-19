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
    public partial class FrmProductos : Form
    {
        public FrmProductos()
        {
            InitializeComponent();
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            CargarCategorias();
        }

        private void CargarCategorias()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT CategoriaID, Nombre FROM Categorias WHERE Estado = 1", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbCategoria.DataSource = dt;
                cmbCategoria.DisplayMember = "Nombre";
                cmbCategoria.ValueMember = "CategoriaID";
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("sp_agregar_producto", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Codigo", txtCodigo.Text);
                cmd.Parameters.AddWithValue("@Nombre", txtNombreProd.Text);
                cmd.Parameters.AddWithValue("@Descripcion", txtDescripcionProd.Text);
                cmd.Parameters.AddWithValue("@CategoriaID", cmbCategoria.SelectedValue);
                cmd.Parameters.AddWithValue("@UnidadMedida", cmbUnidadMedida.Text);
                cmd.Parameters.AddWithValue("@PrecioCompra", decimal.Parse(txtPrecioCompra.Text));
                cmd.Parameters.AddWithValue("@PrecioVenta", decimal.Parse(txtPrecioVenta.Text));
                cmd.Parameters.AddWithValue("@PrecioVentaMayorista", decimal.Parse(txtPrecioMayorista.Text));
                cmd.Parameters.AddWithValue("@StockMinimo", int.Parse(txtStockMinimo.Text));
                cmd.Parameters.AddWithValue("@StockActual", int.Parse(txtStockActual.Text));
                cmd.Parameters.AddWithValue("@PorcentajeImpuesto", decimal.Parse(txtPorcentajeImpuesto.Text));
                cmd.Parameters.AddWithValue("@EsElaborado", chkElaborado.Checked ? 1 : 0);
                cmd.Parameters.AddWithValue("@RequiereRefrigeracion", chkRefrigerado.Checked ? 1 : 0);
                cmd.Parameters.AddWithValue("@Estado", 1);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Producto agregado correctamente");
                    ListarProductos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar producto: " + ex.Message);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un producto para editar.");
                return;
            }

            int id = Convert.ToInt32(dgvProductos.CurrentRow.Cells["ProductoID"].Value);

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("sp_editar_producto", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProductoID", id);
                cmd.Parameters.AddWithValue("@Codigo", txtCodigo.Text);
                cmd.Parameters.AddWithValue("@Nombre", txtNombreProd.Text);
                cmd.Parameters.AddWithValue("@Descripcion", txtDescripcionProd.Text);
                cmd.Parameters.AddWithValue("@CategoriaID", cmbCategoria.SelectedValue);
                cmd.Parameters.AddWithValue("@UnidadMedida", cmbUnidadMedida.Text);
                cmd.Parameters.AddWithValue("@PrecioCompra", decimal.Parse(txtPrecioCompra.Text));
                cmd.Parameters.AddWithValue("@PrecioVenta", decimal.Parse(txtPrecioVenta.Text));
                cmd.Parameters.AddWithValue("@PrecioVentaMayorista", decimal.Parse(txtPrecioMayorista.Text));
                cmd.Parameters.AddWithValue("@StockMinimo", int.Parse(txtStockMinimo.Text));
                cmd.Parameters.AddWithValue("@StockActual", int.Parse(txtStockActual.Text));
                cmd.Parameters.AddWithValue("@PorcentajeImpuesto", decimal.Parse(txtPorcentajeImpuesto.Text));
                cmd.Parameters.AddWithValue("@EsElaborado", chkElaborado.Checked ? 1 : 0);
                cmd.Parameters.AddWithValue("@RequiereRefrigeracion", chkRefrigerado.Checked ? 1 : 0);
                cmd.Parameters.AddWithValue("@Estado", 1);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Producto actualizado correctamente");
                    ListarProductos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al editar producto: " + ex.Message);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un producto para eliminar.");
                return;
            }

            int id = Convert.ToInt32(dgvProductos.CurrentRow.Cells["ProductoID"].Value);

            DialogResult r = MessageBox.Show(
                "¿Seguro quieres eliminar este producto?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (r == DialogResult.No)
                return;

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("sp_eliminar_producto", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProductoID", id);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Producto eliminado correctamente");
                    ListarProductos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar producto: " + ex.Message);
                }
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            {
                ListarProductos();
            }

        }

        private void ListarProductos()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("sp_listar_productos", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvProductos.DataSource = dt;

                if (dt.Rows.Count == 0)
                    MessageBox.Show("No hay productos activos registrados.");
            }
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];

                txtCodigo.Text = fila.Cells["Codigo"].Value.ToString();
                txtNombreProd.Text = fila.Cells["Nombre"].Value.ToString();
                txtDescripcionProd.Text = fila.Cells["Descripcion"].Value.ToString();
                cmbCategoria.Text = fila.Cells["Categoria"].Value.ToString();
                cmbUnidadMedida.Text = fila.Cells["UnidadMedida"].Value.ToString();
                txtPrecioCompra.Text = fila.Cells["PrecioCompra"].Value.ToString();
                txtPrecioVenta.Text = fila.Cells["PrecioVenta"].Value.ToString();
                txtPrecioMayorista.Text = fila.Cells["PrecioVentaMayorista"].Value.ToString();
                txtStockMinimo.Text = fila.Cells["StockMinimo"].Value.ToString();
                txtStockActual.Text = fila.Cells["StockActual"].Value.ToString();
                txtPorcentajeImpuesto.Text = fila.Cells["PorcentajeImpuesto"].Value.ToString();
                chkElaborado.Checked = Convert.ToBoolean(fila.Cells["EsElaborado"].Value);
                chkRefrigerado.Checked = Convert.ToBoolean(fila.Cells["RequiereRefrigeracion"].Value);
                chkEstado.Checked = Convert.ToBoolean(fila.Cells["Estado"].Value);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }    } 
