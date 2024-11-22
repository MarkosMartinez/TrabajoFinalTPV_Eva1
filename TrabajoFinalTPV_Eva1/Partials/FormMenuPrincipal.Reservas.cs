using System.Data.OleDb;

namespace TrabajoFinalTPV_Eva1
{
    public partial class FormMenuPrincipal : Form
    {
        Boolean listoPrincipio = false;
        List<string> mesasUsuario = new List<string>();
        List<string> mesasUsuarioOriginal = new List<string>();

        private void btnRInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Para realizar una reserva, seleccione la fecha, el tipo, una mesa que esté libre (verde) y pulse en el botón de reservar.\n\nEl significado de los colores de las mesas es el siguiente:\nVerde: Disponible\nAmarillo: Seleccionado (sin reservar)\nAzul: Tus reservas\nRojo: Reservas de otros\n\nPuedes cancelar una reserva des-seleccionando su mesa reservada y pulsando en el botón de editar o hacer click en la lista para ir a la fecha de la reserva.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
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

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Fecha, Tipo, Mesa, Usuario FROM Reservas WHERE Fecha >= @FechaActual AND Usuario = @User ORDER BY Fecha";
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
                            listViewReservas.Items.Add(item);
                        }
                    }
                }
            }
            listoPrincipio = true;
        }
        private void updateMesas()
        {
            mesasUsuario.Clear();
            mesasUsuarioOriginal.Clear();
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Mesa, Usuario FROM Reservas WHERE Fecha = @Fecha AND Tipo = @Tipo";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Fecha", dateTimePickerReservas.Value.Date);
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
                                        mesasUsuario.Add(btnMesa.Name.ToString());


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
                        mesasUsuarioOriginal = mesasUsuario.ToList();
                    }
                }
            }
        }

        private void comboBoxTipoReservas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listoPrincipio) cargarReservas();
            listViewReservas.SelectedItems.Clear();
        }

        private void dateTimePickerReservas_ValueChanged(object sender, EventArgs e)
        {
            if (listoPrincipio) cargarReservas();
            listViewReservas.SelectedItems.Clear();
        }

        private void listViewReservas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewReservas.SelectedItems.Count > 0)
            {
                var selectedItem = listViewReservas.SelectedItems[0];
                if (selectedItem.SubItems.Count > 1)
                {
                    comboBoxTipoReservas.SelectedItem = selectedItem.SubItems[1].Text;
                    DateTime selectedDate = DateTime.ParseExact(selectedItem.SubItems[0].Text, "dd/MM/yyyy", null);
                    if (selectedDate >= dateTimePickerReservas.MinDate && selectedDate <= dateTimePickerReservas.MaxDate)
                    {
                        dateTimePickerReservas.Value = selectedDate;
                    }
                    else
                    {
                        MessageBox.Show("La fecha seleccionada está fuera del rango permitido.");
                    }
                }
            }
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
                    if (mesasUsuarioOriginal.Contains(btnMesaClick.Name.ToString()))
                    {
                        mesasUsuario.Add(btnMesaClick.Name.ToString());
                    }
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
                    mesasUsuario.Remove(btnMesaClick.Name.ToString());
                }
            }
        }

        private void btnAddModifyReserva_Click(object sender, EventArgs e)
        {
            //Eliminar las reservas o mesas canceladas
            var mesasFaltantes = mesasUsuarioOriginal.Except(mesasUsuario).Select(mesa => mesa.Replace("btnMesa", "")).ToList();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                foreach (var mesa in mesasFaltantes)
                {
                    string query = "SELECT Mesa FROM Reservas WHERE Usuario = @User AND Fecha = @Fecha AND Tipo = @Tipo AND Mesa LIKE @Mesa";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@User", user.ToLower());
                        command.Parameters.AddWithValue("@Fecha", dateTimePickerReservas.Value.Date);
                        command.Parameters.AddWithValue("@Tipo", comboBoxTipoReservas.SelectedItem.ToString());
                        command.Parameters.AddWithValue("@Mesa", "%" + mesa + "%");
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string[] mesasReservadas = reader["Mesa"].ToString().Split(',');
                                if (mesasReservadas.Length > 1)
                                {
                                    // Eliminar solo la mesa de la reserva
                                    string nuevasMesas = string.Join(",", mesasReservadas.Where(m => m != mesa));
                                    string updateQuery = "UPDATE Reservas SET Mesa = @NuevasMesas WHERE Usuario = @User AND Mesa LIKE @Mesa";
                                    using (OleDbCommand updateCommand = new OleDbCommand(updateQuery, connection))
                                    {
                                        updateCommand.Parameters.AddWithValue("@NuevasMesas", nuevasMesas);
                                        updateCommand.Parameters.AddWithValue("@User", user.ToLower());
                                        updateCommand.Parameters.AddWithValue("@Mesa", "%" + mesa + "%");
                                        updateCommand.ExecuteNonQuery();
                                    }
                                }
                                else
                                {
                                    // Eliminar la reserva completa
                                    string deleteQuery = "DELETE FROM Reservas WHERE Usuario = @User AND Mesa = @Mesa";
                                    using (OleDbCommand deleteCommand = new OleDbCommand(deleteQuery, connection))
                                    {
                                        deleteCommand.Parameters.AddWithValue("@User", user.ToLower());
                                        deleteCommand.Parameters.AddWithValue("@Mesa", mesa);
                                        deleteCommand.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                }
                mesasUsuario = mesasUsuario.Except(mesasFaltantes.Select(m => "btnMesa" + m)).ToList();
                foreach (var mesa in mesasFaltantes)
                {
                    Button btnMesa = this.Controls.Find($"btnMesa{mesa}", true).FirstOrDefault() as Button;
                    if (btnMesa != null)
                    {
                        btnMesa.BackgroundImage = Properties.Resources.mesa_libre;
                        btnMesa.Tag = "libre";
                    }
                }

            }

            List<string> mesasSeleccionadas = new List<string>();
            for (int i = 1; i <= 6; i++)
            {
                Button btnMesa = this.Controls.Find($"btnMesa{i}", true).FirstOrDefault() as Button;
                if (btnMesa != null)
                {
                    if(btnMesa.Tag == "seleccionada")
                    mesasSeleccionadas.Add(btnMesa.Name.ToString().Replace("btnMesa", ""));
                }
            }

            foreach (var mesa in mesasSeleccionadas)
            {
                string query = "SELECT Mesa FROM Reservas WHERE Usuario = @User AND Fecha = @Fecha AND Tipo = @Tipo";
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@User", user.ToLower());
                        command.Parameters.AddWithValue("@Fecha", dateTimePickerReservas.Value.Date);
                        command.Parameters.AddWithValue("@Tipo", comboBoxTipoReservas.SelectedItem.ToString());
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string mesasReservadas = reader["Mesa"].ToString();
                                string nuevasMesas = string.Join(",", mesasReservadas.Split(',').Distinct().Where(m => !string.IsNullOrEmpty(m))) + "," + mesa.Replace("btnMesa", "");
                                nuevasMesas = string.Join(",", nuevasMesas.Split(',').Distinct().Where(m => !string.IsNullOrEmpty(m)));
                                string updateQuery = "UPDATE Reservas SET Mesa = @NuevasMesas WHERE Usuario = @User AND Fecha = @Fecha AND Tipo = @Tipo";
                                using (OleDbCommand updateCommand = new OleDbCommand(updateQuery, connection))
                                {
                                    updateCommand.Parameters.AddWithValue("@NuevasMesas", nuevasMesas);
                                    updateCommand.Parameters.AddWithValue("@User", user.ToLower());
                                    updateCommand.Parameters.AddWithValue("@Fecha", dateTimePickerReservas.Value.Date);
                                    updateCommand.Parameters.AddWithValue("@Tipo", comboBoxTipoReservas.SelectedItem.ToString());
                                    updateCommand.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                string insertQuery = "INSERT INTO Reservas (Fecha, Tipo, Mesa, Usuario) VALUES (@Fecha, @Tipo, @Mesa, @User)";
                                using (OleDbCommand insertCommand = new OleDbCommand(insertQuery, connection))
                                {
                                    insertCommand.Parameters.AddWithValue("@Fecha", dateTimePickerReservas.Value.Date);
                                    insertCommand.Parameters.AddWithValue("@Tipo", comboBoxTipoReservas.SelectedItem.ToString());
                                    insertCommand.Parameters.AddWithValue("@Mesa", mesa.Replace("btnMesa", ""));
                                    insertCommand.Parameters.AddWithValue("@User", user.ToLower());
                                    insertCommand.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }
            }
            MessageBox.Show("Reservas modificadas correctamente", "Reserva", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cargarReservas();
        }

    }
}
