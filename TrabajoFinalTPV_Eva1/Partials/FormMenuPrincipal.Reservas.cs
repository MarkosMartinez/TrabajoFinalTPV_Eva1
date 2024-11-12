using System.Data.OleDb;

namespace TrabajoFinalTPV_Eva1
{
    public partial class FormMenuPrincipal : Form
    {
        private void cargarReservas()
        {
            comboBoxTipoReservas.SelectedIndex = 0; // Valor por defecto
            dateTimePickerReservas.MinDate = DateTime.Now;
            updateListaReservas();
            updateMesas();
        }
        private void updateListaReservas()
        {
            listViewReservas.Clear();
            listViewReservas.View = View.Details;
            listViewReservas.Columns.Add("Fecha", 75);
            listViewReservas.Columns.Add("Tipo", 75);
            listViewReservas.Columns.Add("Mesa", 40);
            //listViewReservas.Columns.Add("Nombre", 50);

            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../../BBDD", "Sociedad.accdb")};";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Fecha, Tipo, Mesa, Usuario FROM Reservas WHERE Fecha >= @FechaActual AND Usuario = @User";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FechaActual", DateTime.Now.Date);
                    command.Parameters.AddWithValue("@User", user);
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(Convert.ToDateTime(reader["Fecha"]).ToString("dd/MM/yyyy"));
                            item.SubItems.Add(reader["Tipo"].ToString());
                            item.SubItems.Add(reader["Mesa"].ToString());
                            //item.SubItems.Add(reader["Usuario"].ToString());
                            listViewReservas.Items.Add(item);
                        }
                    }
                }
            }
        }
        private void updateMesas()
        {
            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../../BBDD", "Sociedad.accdb")};";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Mesa, Usuario FROM Reservas WHERE Fecha >= @FechaActual AND Tipo = @Tipo";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FechaActual", DateTime.Now.Date);
                    command.Parameters.AddWithValue("@Tipo", comboBoxTipoReservas.SelectedItem.ToString());
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //Cambiar estado mesas. Ocupado, Ocupado por el mismo user, Libre y Seleccionado
                        }
                    }
                }
            }
        }


    }
}
