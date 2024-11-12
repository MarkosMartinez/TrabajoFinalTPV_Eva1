using System.Data.OleDb;

namespace TrabajoFinalTPV_Eva1
{
    public partial class FormMenuPrincipal : Form
    {
        Boolean listoPrincipio = false;
        private void cargarReservas()
        {
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
            listoPrincipio = true;
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

                        for (int i = 1; i <= 6; i++)
                        {
                            Button btnMesa = this.Controls.Find($"btnMesa{i}", true).FirstOrDefault() as Button;
                            if (btnMesa != null)
                            {
                                btnMesa.BackgroundImage = Properties.Resources.mesa_libre;
                                btnMesa.Enabled = true;
                            }
                        }

                        while (reader.Read())
                        {
                            string[] mesasReservadas = reader["Mesa"].ToString().Split(',');
                            string usuarioReserva = reader["Usuario"].ToString();
                            var imagenMesa = Properties.Resources.mesa_libre;

                            for (int i = 0; i < mesasReservadas.Length; i++)
                            {
                                string mesaReserva = mesasReservadas[i];
                                Button btnMesa = this.Controls.Find($"btnMesa{mesaReserva}", true).FirstOrDefault() as Button;
                                if (btnMesa != null)
                                {
                                    if (reader["Usuario"].ToString().ToLower() == user.ToLower())
                                    {
                                        btnMesa.BackgroundImage = Properties.Resources.mesa_ocupada_usuario;
                                    }
                                    else
                                    {
                                        btnMesa.BackgroundImage = Properties.Resources.mesa_ocupada;
                                        btnMesa.Enabled = false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void comboBoxTipoReservas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listoPrincipio) cargarReservas();
        }

        private void dateTimePickerReservas_ValueChanged(object sender, EventArgs e)
        {
            if (listoPrincipio) cargarReservas();
        }


    }
}
