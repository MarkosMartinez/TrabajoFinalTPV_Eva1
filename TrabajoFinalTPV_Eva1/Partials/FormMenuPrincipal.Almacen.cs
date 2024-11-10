using System.Data.OleDb;

namespace TrabajoFinalTPV_Eva1
{
    public partial class FormMenuPrincipal : Form
    {

        private void cargarAlmacen()
        {
            // Configurar el ListView
            listViewAlmacen.Clear();
            listViewAlmacen.View = View.Details;
            listViewAlmacen.Columns.Add("Producto", 100);
            listViewAlmacen.Columns.Add("Categoria", 100);
            listViewAlmacen.Columns.Add("Precio", 50);
            listViewAlmacen.Columns.Add("Cantidad", 50);

            // Conectar a la base de datos de Access
            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../../BBDD", "Sociedad.accdb")};";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Producto, Categoria, Precio, Cantidad FROM Almacen";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(reader["Producto"].ToString());
                            item.SubItems.Add(reader["Categoria"].ToString());
                            item.SubItems.Add(reader["Precio"].ToString());
                            item.SubItems.Add(reader["Cantidad"].ToString());
                            listViewAlmacen.Items.Add(item);
                        }
                    }
                }
            }
        }

    }
}
