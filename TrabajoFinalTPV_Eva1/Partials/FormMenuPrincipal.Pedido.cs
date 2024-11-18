using System.Data.OleDb;

namespace TrabajoFinalTPV_Eva1
{
    public partial class FormMenuPrincipal : Form
    {
        private void cargarCategoriaProductosPedido()
        {
            listViewCategorias.Items.Clear();
            listViewCategorias.View = View.Details;
            listViewProductos.Columns.Clear();
            listViewCategorias.Columns.Add("Categorias", 150);

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

    }

}
