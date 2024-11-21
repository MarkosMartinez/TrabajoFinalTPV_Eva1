using System.Data.OleDb;

namespace TrabajoFinalTPV_Eva1
{
    public partial class FormMenuPrincipal : Form
    {
        private void cargarCategoriaProductosPedido()
        {
            if (pictureBoxPreviewProducto.Image != null)
            {
                pictureBoxPreviewProducto.Image.Dispose();
                pictureBoxPreviewProducto.Image = null;
            }
            dataGridViewPedido.ClearSelection();
            listViewCategorias.SelectedItems.Clear();
            listViewProductos.SelectedItems.Clear();

            textBoxPCantidad.Visible = false;
            buttonModPCantidad.Visible = false;
            buttonPEliminarProducto.Visible = false;
            productoSeleccionado = null;

            listViewCategorias.Items.Clear();
            listViewCategorias.View = View.Details;
            listViewProductos.Items.Clear();
            listViewProductos.Columns.Clear();
            listViewProductos.View = View.Details;
            if (listViewCategorias.Columns.Cast<ColumnHeader>().All(c => c.Text != "Categorias")) listViewCategorias.Columns.Add("Categorias", 150);

            if (dataGridViewPedido.Columns["Producto"] == null)
            {
                dataGridViewPedido.Columns.Add("Producto", "Producto");
                dataGridViewPedido.Columns["Producto"].Width = 200;
                dataGridViewPedido.Columns.Add("Cantidad", "Cantidad");
                dataGridViewPedido.Columns.Add("Precio", "Precio");
            }

            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../../BBDD", "Sociedad.accdb")};";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT DISTINCT Categoria FROM Almacen";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listViewCategorias.Items.Add(reader["Categoria"].ToString());
                        }
                    }
                }
            }
        }

        private void listViewCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewCategorias.SelectedItems.Count == 1)
            {
                cargarProductosPedido(listViewCategorias.SelectedItems[0].SubItems[0].Text);
            }
            else
            {
                listViewProductos.Items.Clear();
            }
        }

        private void cargarProductosPedido(string categoria)
        {
            if (categoria == categoriaSeleccionada) return;
            categoriaSeleccionada = categoria;
            listViewProductos.Items.Clear();
            listViewProductos.View = View.Details;
            listViewProductos.Columns.Clear();
            listViewProductos.Columns.Add("Producto", 120);
            listViewProductos.Columns.Add("Stock", 50);
            listViewProductos.Columns.Add("Precio", 50);

            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../../BBDD", "Sociedad.accdb")};";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {

                string query = "SELECT Producto, Cantidad, Precio FROM Almacen WHERE Categoria = ?";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@Categoria", categoria);
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(reader["Producto"].ToString());
                            item.SubItems.Add(reader["Cantidad"].ToString());
                            item.SubItems.Add(reader["Precio"].ToString());
                            listViewProductos.Items.Add(item);
                        }
                    }
                }
            }
        }

        private void listViewProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewProductos.SelectedItems.Count == 1)
            {
                cargarImagen(listViewProductos.SelectedItems[0].SubItems[0].Text, pictureBoxPreviewProducto);
            }
            else
            {
                if (pictureBoxPreviewProducto.Image != null)
                {
                    pictureBoxPreviewProducto.Image.Dispose();
                    pictureBoxPreviewProducto.Image = null;
                }
            }
        }

        private void listViewProductos_DoubleClick(object sender, EventArgs e)
        {
            if (listViewProductos.SelectedItems.Count == 1)
            {
                string producto = listViewProductos.SelectedItems[0].SubItems[0].Text;
                bool productoExistente = false;
                bool errorStock = false;

                foreach (DataGridViewRow row in dataGridViewPedido.Rows)
                {
                    var cell = row.Cells["Producto"];
                    if (cell != null && cell.Value != null && cell.Value.ToString() == producto)
                    {
                        if (ComprobarCantidadStock(cell.Value.ToString(), (int)row.Cells["Cantidad"].Value + 1))
                        {
                            row.Cells["Cantidad"].Value = (int)row.Cells["Cantidad"].Value + 1;
                            row.Cells["Precio"].Value = Double.Parse(listViewProductos.SelectedItems[0].SubItems[2].Text) * (int)row.Cells["Cantidad"].Value;
                            productoExistente = true;
                            dataGridViewPedido.ClearSelection();
                            row.Selected = true;
                            errorStock = false;
                            break;
                        }
                        else
                        {
                            MessageBox.Show("La cantidad solicitada supera el stock disponible.", "Error de Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            errorStock = true;
                        }
                    }
                }

                if (!productoExistente && !errorStock)
                {
                    string precio = listViewProductos.SelectedItems[0].SubItems[2].Text;
                    int rowIndex = dataGridViewPedido.Rows.Add(producto, 1, precio);
                    dataGridViewPedido.ClearSelection();
                    dataGridViewPedido.Rows[rowIndex].Selected = true;
                }
                actualizarPrecioTotal();
            }
        }
        private void dataGridViewPedido_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewPedido.SelectedRows.Count == 1 && dataGridViewPedido.SelectedRows[0].Cells["Producto"].Value != null)
            {
                productoSeleccionado = dataGridViewPedido.SelectedRows[0].Cells["Producto"].Value.ToString();
                cargarImagen(dataGridViewPedido.SelectedRows[0].Cells["Producto"].Value.ToString(), pictureBoxPreviewProducto);
                textBoxPCantidad.Text = dataGridViewPedido.SelectedRows[0].Cells["Cantidad"].Value.ToString();
                textBoxPCantidad.Visible = true;
                buttonModPCantidad.Visible = true;
                buttonPEliminarProducto.Visible = true;
            }
            else
            {
                textBoxPCantidad.Visible = false;
                buttonModPCantidad.Visible = false;
                buttonPEliminarProducto.Visible = false;
            }
        }
        private bool ComprobarCantidadStock(string producto, int cantidad)
        {
            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../../BBDD", "Sociedad.accdb")};";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Cantidad FROM Almacen WHERE Producto = ?";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Producto", producto);
                    object result = command.ExecuteScalar();
                    if (result == null)
                    {
                        // El producto ya no existe, eliminarlo del pedido
                        foreach (DataGridViewRow row in dataGridViewPedido.Rows)
                        {
                            var cell = row.Cells["Producto"];
                            if (cell != null && cell.Value != null && cell.Value.ToString() == producto)
                            {
                                dataGridViewPedido.Rows.Remove(row);
                                actualizarPrecioTotal();
                                break;
                            }
                        }
                        return false;
                    }
                    int stock = (int)result;
                    return cantidad <= stock;
                }
            }
        }

        private void buttonModPCantidad_Click(object sender, EventArgs e)
        {
            if (productoSeleccionado != null)
            {
                int nuevaCantidad = Int32.Parse(textBoxPCantidad.Text);
                if (ComprobarCantidadStock(productoSeleccionado, nuevaCantidad))
                {
                    foreach (DataGridViewRow row in dataGridViewPedido.Rows)
                    {
                        var cell = row.Cells["Producto"];
                        if (cell != null && cell.Value != null && cell.Value.ToString() == productoSeleccionado)
                        {
                            Double precioUnidad = Double.Parse(row.Cells["Precio"].Value.ToString()) / Double.Parse(row.Cells["Cantidad"].Value.ToString());
                            row.Cells["Cantidad"].Value = nuevaCantidad;
                            row.Cells["Precio"].Value = precioUnidad * nuevaCantidad;
                            break;
                        }
                    }
                    actualizarPrecioTotal();
                }
                else
                {
                    MessageBox.Show("La cantidad solicitada supera el stock disponible.", "Error de Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonPEliminarProducto_Click(object sender, EventArgs e)
        {
            if (productoSeleccionado != null)
            {
                foreach (DataGridViewRow row in dataGridViewPedido.Rows)
                {
                    var cell = row.Cells["Producto"];
                    if (cell != null && cell.Value != null && cell.Value.ToString() == productoSeleccionado)
                    {
                        dataGridViewPedido.Rows.Remove(row);
                        productoSeleccionado = null;
                        dataGridViewPedido.ClearSelection();
                        break;
                    }
                }
                actualizarPrecioTotal();
            }
        }

        private void actualizarPrecioTotal()
        {
            // Actualiza el precio total del pedido
            double precioTotal = 0;
            foreach (DataGridViewRow row in dataGridViewPedido.Rows)
            {
                var cell = row.Cells["Precio"];
                if (cell != null && cell.Value != null)
                {
                    precioTotal += Double.Parse(cell.Value.ToString());
                }
            }
            if (precioTotal > 0)
            {
                buttonTicket.Enabled = true;
                textBoxPTotal.Text = precioTotal.ToString();
            }
            else
            {
                buttonTicket.Enabled = false;
                textBoxPTotal.Text = "";
            }
        }

        private void buttonTicket_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.Title = "Guardar Ticket de Compra";
                saveFileDialog.FileName = "Ticket";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        writer.WriteLine("Ticket de Compra");
                        writer.WriteLine($"Fecha y Hora: {DateTime.Now}");
                        writer.WriteLine(new string('*', 50));
                        writer.WriteLine("{0,-20} {1,-10} {2,-10}", "Producto", "Cantidad", "Precio");
                        writer.WriteLine(new string('-', 50));

                        foreach (DataGridViewRow row in dataGridViewPedido.Rows)
                        {
                            if (row.Cells["Producto"].Value != null)
                            {
                                string producto = row.Cells["Producto"].Value?.ToString() ?? string.Empty;
                                string cantidad = row.Cells["Cantidad"].Value?.ToString() ?? string.Empty;
                                string precio = row.Cells["Precio"].Value?.ToString() ?? string.Empty;
                                writer.WriteLine("{0,-20} {1,-10} {2,-10}", producto, cantidad, precio);
                            }
                        }
                        writer.WriteLine(new string('*', 50));
                        writer.WriteLine($"Precio Total: {textBoxPTotal.Text}€");
                    }
                    MessageBox.Show("Ticket guardado correctamente!", "Ticket Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewPedido.Rows.Clear();
                    cargarCategoriaProductosPedido();
                }
            }
        }
    }

}
