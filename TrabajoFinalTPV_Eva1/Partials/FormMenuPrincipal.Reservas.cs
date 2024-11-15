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
                    command.Parameters.AddWithValue("@User", user.ToLower());
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
                                btnMesa.Tag = "libre";
                            }
                        }

                        while (reader.Read())
                        {
                            string[] mesasReservadas = reader["Mesa"].ToString().Split(',');
                            string usuarioReserva = reader["Usuario"].ToString();

                            for (int i = 0; i < mesasReservadas.Length; i++)
                            {
                                string mesaReserva = mesasReservadas[i];
                                Button btnMesa = this.Controls.Find($"btnMesa{mesaReserva}", true).FirstOrDefault() as Button;
                                if (btnMesa != null)
                                {
                                    if (reader["Usuario"].ToString().ToLower() == user.ToLower())
                                    {
                                        btnMesa.BackgroundImage = Properties.Resources.mesa_ocupada_usuario;
                                        btnMesa.Tag = "ocupada_usuario";
                                    }
                                    else
                                    {
                                        btnMesa.BackgroundImage = Properties.Resources.mesa_ocupada;
                                        btnMesa.Tag = "ocupada";
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

        private void btnMesa_Click(object sender, EventArgs e)
        {
            Button btnMesaClick = sender as Button;
            if (btnMesaClick != null)
            {
                if (btnMesaClick.Tag == "libre")
                {
                    btnMesaClick.BackgroundImage = Properties.Resources.mesa_seleccionada;
                    btnMesaClick.Tag = "seleccionada";
                }
                else if (btnMesaClick.Tag == "seleccionada")
                {
                    btnMesaClick.BackgroundImage = Properties.Resources.mesa_libre;
                    btnMesaClick.Tag = "libre";
                }
                else if (btnMesaClick.Tag.ToString() == "ocupada_usuario")
                {
                    btnMesaClick.BackgroundImage = Properties.Resources.mesa_libre;
                    btnMesaClick.Tag = "libre";
                }
            }
        }
        private void btnAddModifyReserva_Click(object sender, EventArgs e)
        {
            if (comboBoxTipoReservas.SelectedItem == null || dateTimePickerReservas.Value == null)
            {
                MessageBox.Show("Por favor, seleccione un tipo de reserva y una fecha válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string tipoReserva = comboBoxTipoReservas.SelectedItem.ToString();
            string fechaReserva = dateTimePickerReservas.Value.ToString("yyyy/MM/dd");
            List<string> mesasSeleccionadas = new List<string>();

            for (int i = 1; i <= 6; i++)
            {
                Button btnMesa = this.Controls.Find($"btnMesa{i}", true).FirstOrDefault() as Button;
                if (btnMesa != null && btnMesa.Tag == "seleccionada")
                {
                    mesasSeleccionadas.Add(btnMesa.Name.Split("btnMesa")[1]);
                }
            }

            if (mesasSeleccionadas.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione al menos una mesa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string mesas = string.Join(",", mesasSeleccionadas);
            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../../BBDD", "Sociedad.accdb")};";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Reservas (Fecha, Tipo, Mesa, Usuario) VALUES (@Fecha, @Tipo, @Mesa, @Usuario)";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Fecha", fechaReserva);
                    command.Parameters.AddWithValue("@Tipo", tipoReserva);
                    command.Parameters.AddWithValue("@Mesa", mesas);
                    command.Parameters.AddWithValue("@Usuario", user.ToLower());

                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Reserva añadida/modificada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarReservas();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al añadir/modificar la reserva: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


    }
}
