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
    public partial class FrmVerOrdenesDeCompra : Form
    {
        private int OrdenCompraIDSeleccionada = 0;
        private bool CargandoDetalles = false;
        public FrmVerOrdenesDeCompra()
        {
            InitializeComponent();
        }

        private void FrmVerOrdenesDeCompra_Load(object sender, EventArgs e)
        {
            CargarOrdenes();
            ConfigurarDgvDetalles();
        }


        private void CargarDetalles()
        {
            if (OrdenCompraIDSeleccionada == 0)
                return;

            CargandoDetalles = true;

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_listar_detalle_por_orden", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@OrdenCompraID", OrdenCompraIDSeleccionada);

                DataTable dt = new DataTable();
                da.Fill(dt);

                // Asegurar columna Impuesto
                if (!dt.Columns.Contains("Impuesto"))
                    dt.Columns.Add("Impuesto", typeof(decimal));

                // Calcular impuestos
                foreach (DataRow row in dt.Rows)
                {
                    decimal sub = row["SubTotal"] != DBNull.Value ? Convert.ToDecimal(row["SubTotal"]) : 0;
                    decimal porc = row["PorcentajeImpuesto"] != DBNull.Value ? Convert.ToDecimal(row["PorcentajeImpuesto"]) : 0;
                    row["Impuesto"] = Math.Round(sub * porc / 100, 2);
                }

                dgvDetalles.DataSource = dt;

                // Asegurar columna en el DGV
                if (!dgvDetalles.Columns.Contains("Impuesto"))
                {
                    dgvDetalles.Columns.Add("Impuesto", "Impuesto");
                    dgvDetalles.Columns["Impuesto"].DataPropertyName = "Impuesto";
                }
            }
            ConfigurarDgvDetalles();
            CargandoDetalles = false;

            RecalcularTotales();
        }


        private void ConfigurarDgvDetalles()
        {
            if (dgvDetalles.Columns.Contains("Cantidad")) dgvDetalles.Columns["Cantidad"].ReadOnly = false;
            if (dgvDetalles.Columns.Contains("PrecioUnitario")) dgvDetalles.Columns["PrecioUnitario"].ReadOnly = false;
            if (dgvDetalles.Columns.Contains("Estado")) dgvDetalles.Columns["Estado"].ReadOnly = true;
            if (dgvDetalles.Columns.Contains("Producto")) dgvDetalles.Columns["Producto"].ReadOnly = true;
            if (dgvDetalles.Columns.Contains("SubTotal")) dgvDetalles.Columns["SubTotal"].ReadOnly = true;
            if (dgvDetalles.Columns.Contains("Impuesto")) dgvDetalles.Columns["Impuesto"].ReadOnly = true;
        }



        private void CargarOrdenes()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_listar_ordenes_compra", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvOrdenes.DataSource = dt;
            }
        }


        private void BuscarOrdenes()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_buscar_ordenes", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Texto", txtBuscar.Text);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvOrdenes.DataSource = dt;
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvOrdenes.CurrentRow == null)
                return;

            int id = Convert.ToInt32(dgvOrdenes.CurrentRow.Cells["OrdenCompraID"].Value);

            if (MessageBox.Show("¿Eliminar orden?", "Confirmar", MessageBoxButtons.YesNo)
                == DialogResult.No)
                return;

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_eliminar_orden_compra", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrdenCompraID", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Orden eliminada.");

            CargarOrdenes();
        }
        private void ActualizarTotalesOrden()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_actualizar_totales_orden", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrdenCompraID", OrdenCompraIDSeleccionada);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            CargarDetalles();
        }

        private void RecalcularTotales()
        {
            decimal subtotalProductos = 0;
            decimal totalImpuestos = 0;

            foreach (DataGridViewRow row in dgvDetalles.Rows)
            {
                if (row.Cells["SubTotal"].Value != DBNull.Value)
                    subtotalProductos += Convert.ToDecimal(row.Cells["SubTotal"].Value);

                if (row.Cells["Impuesto"].Value != null &&
                    row.Cells["Impuesto"].Value != DBNull.Value)
                    totalImpuestos += Convert.ToDecimal(row.Cells["Impuesto"].Value);
            }

            lblSubTotal.Text = subtotalProductos.ToString("0.00");
            lblImpuesto.Text = totalImpuestos.ToString("0.00");
            lblTotal.Text = (subtotalProductos + totalImpuestos).ToString("0.00");
        }



        private void GuardarDetalleEditado()
        {
            int detalleID = Convert.ToInt32(dgvDetalles.CurrentRow.Cells["DetalleOrdenID"].Value);
            int cantidad = Convert.ToInt32(dgvDetalles.CurrentRow.Cells["Cantidad"].Value);
            string estado = dgvDetalles.CurrentRow.Cells["Estado"].Value.ToString();
            decimal precio = Convert.ToDecimal(dgvDetalles.CurrentRow.Cells["PrecioUnitario"].Value);

            decimal subtotal = cantidad * precio;
            dgvDetalles.CurrentRow.Cells["SubTotal"].Value = subtotal;

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_editar_detalle_orden", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DetalleOrdenID", detalleID);
                cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                cmd.Parameters.AddWithValue("@PrecioUnitario", precio);
                cmd.Parameters.AddWithValue("@SubTotal", subtotal);
                cmd.Parameters.AddWithValue("@Estado", estado);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (CargandoDetalles || dgvDetalles.CurrentRow == null)
                return;

            GuardarDetalleEditado();
            RecalcularTotales();
            ActualizarTotalesOrden();
        }

        private void dgvOrdenes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            OrdenCompraIDSeleccionada =
                Convert.ToInt32(dgvOrdenes.Rows[e.RowIndex].Cells["OrdenCompraID"].Value);

            CargarDetalles();
            RecalcularTotales();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarOrdenes();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Trim() == "")
                CargarOrdenes();
            else
                BuscarOrdenes();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvDetalles.CurrentRow == null)
                return;

            foreach (DataGridViewRow row in dgvDetalles.Rows)
            {
                int detalleID = row.Cells["DetalleOrdenID"].Value != DBNull.Value
                                ? Convert.ToInt32(row.Cells["DetalleOrdenID"].Value)
                                : 0;

                int cantidad = row.Cells["Cantidad"].Value != DBNull.Value
                                ? Convert.ToInt32(row.Cells["Cantidad"].Value)
                                : 0;

                decimal precio = row.Cells["PrecioUnitario"].Value != DBNull.Value
                                ? Convert.ToDecimal(row.Cells["PrecioUnitario"].Value)
                                : 0;

                string estado = row.Cells["Estado"].Value != DBNull.Value
                                ? row.Cells["Estado"].Value.ToString()
                                : "Pendiente";

                decimal porcImpuesto = row.Cells["PorcentajeImpuesto"].Value != DBNull.Value
                                ? Convert.ToDecimal(row.Cells["PorcentajeImpuesto"].Value)
                                : 0;

                decimal subtotal = cantidad * precio;

                row.Cells["SubTotal"].Value = subtotal;
                row.Cells["Impuesto"].Value = Math.Round(subtotal * porcImpuesto / 100, 2);

                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("sp_editar_detalle_orden", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DetalleOrdenID", detalleID);
                    cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@PrecioUnitario", precio);
                    cmd.Parameters.AddWithValue("@SubTotal", subtotal);
                    cmd.Parameters.AddWithValue("@Estado", estado);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            RecalcularTotales();
            ActualizarTotalesOrden();

            MessageBox.Show("Detalles de la orden actualizados correctamente.", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}