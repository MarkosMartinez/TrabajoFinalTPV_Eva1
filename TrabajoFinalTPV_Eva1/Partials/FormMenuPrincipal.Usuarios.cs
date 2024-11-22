using System.Data.OleDb;

namespace TrabajoFinalTPV_Eva1
{
    public partial class FormMenuPrincipal : Form
    {
        private void btnUInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Escribe los datos del usuario y pulsa en el botón de añadir para crearlo.\n\nPara editarlo seleccionalo y cambia los datos que quieras.\nSi el campo de la contraseña esta vacia a la hora de editarlo, se mantendra la anterior sino se sobreescribira", "Información de usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void cargarUsuarios()
        {
            // Configurar el ListView
            listViewGUUsuarios.Clear();
            listViewGUUsuarios.View = View.Details;
            listViewGUUsuarios.Columns.Add("Nombre", 100);
            listViewGUUsuarios.Columns.Add("Tipo", 50);

            // Conectar a la base de datos de Access
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Usuario, Tipo FROM Usuarios";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(reader["Usuario"].ToString());
                            item.SubItems.Add(reader["Tipo"].ToString());
                            listViewGUUsuarios.Items.Add(item);
                        }
                    }
                }
            }
        }

        private void listViewGUUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewGUUsuarios.SelectedItems.Count == 1)
            {
                var selectedItem = listViewGUUsuarios.SelectedItems[0];
                userSeleccionado = selectedItem.SubItems[0].Text;
                btnGUAddModify.BackgroundImage = TrabajoFinalTPV_Eva1.Properties.Resources.user_edit;
                textBoxGUNombre.Text = selectedItem.SubItems[0].Text;
                checkBoxGUAdmin.Checked = selectedItem.SubItems[1].Text == "admin";
                btnGUEliminar.Visible = true;
                textBoxGUPass.Text = string.Empty;
            }
            else
            {
                userSeleccionado = null;
                btnGUAddModify.BackgroundImage = TrabajoFinalTPV_Eva1.Properties.Resources.user_plus;
                textBoxGUNombre.Text = string.Empty;
                checkBoxGUAdmin.Checked = false;
                btnGUEliminar.Visible = false;
            }
        }

        private void btnGUEliminar_Click(object sender, EventArgs e)
        {
            if (userSeleccionado != null)
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string queryDeleteReservas = "DELETE FROM Reservas WHERE Usuario = ?";
                    using (OleDbCommand command = new OleDbCommand(queryDeleteReservas, connection))
                    {
                        command.Parameters.AddWithValue("@Usuario", userSeleccionado);
                        command.ExecuteNonQuery();
                    }

                    string queryDeleteUsuario = "DELETE FROM Usuarios WHERE Usuario = ?";
                    using (OleDbCommand command = new OleDbCommand(queryDeleteUsuario, connection))
                    {
                        command.Parameters.AddWithValue("@Usuario", userSeleccionado);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Usuario eliminado correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargarUsuarios();
                textBoxGUNombre.Text = string.Empty;
                checkBoxGUAdmin.Checked = false;
                textBoxGUPass.Text = string.Empty;
                btnGUAddModify.BackgroundImage = TrabajoFinalTPV_Eva1.Properties.Resources.user_plus;
            }
            btnGUEliminar.Visible = false;
        }

        private void btnGUAddModify_Click(object sender, EventArgs e)
        {
            if (userSeleccionado != null)
            {
                if (string.IsNullOrEmpty(textBoxGUNombre.Text))
                {
                    MessageBox.Show("Por favor, rellene todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Usuarios SET Tipo = ?, Usuario = ? WHERE Usuario = ?";

                    // Verificar si la contraseña no está vacía
                    if (!string.IsNullOrEmpty(textBoxGUPass.Text))
                    {
                        query = "UPDATE Usuarios SET Tipo = ?, Contraseña = ?, Usuario = ? WHERE Usuario = ?";
                    }

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Tipo", checkBoxGUAdmin.Checked ? "admin" : "user");

                        // Agregar parámetro de contraseña si no está vacía
                        if (!string.IsNullOrEmpty(textBoxGUPass.Text))
                        {
                            command.Parameters.AddWithValue("@Contraseña", HashPassword(textBoxGUPass.Text));
                        }

                        command.Parameters.AddWithValue("@Usuario", textBoxGUNombre.Text);
                        command.Parameters.AddWithValue("@UsuarioOriginal", userSeleccionado);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Usuario modificado correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    textBoxGUNombre.Text = string.Empty;
                    textBoxGUPass.Text = string.Empty;
                    checkBoxGUAdmin.Checked = false;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(textBoxGUNombre.Text) || string.IsNullOrEmpty(textBoxGUPass.Text))
                {
                    MessageBox.Show("Por favor, rellene todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    string queryCheckUser = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = ?";
                    using (OleDbCommand checkCommand = new OleDbCommand(queryCheckUser, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@Usuario", textBoxGUNombre.Text);
                        int userCount = (int)checkCommand.ExecuteScalar();

                        if (userCount > 0)
                        {
                            MessageBox.Show("El usuario ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    string query = "INSERT INTO Usuarios (Usuario, Contraseña, Tipo) VALUES (?, ?, ?)";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Usuario", textBoxGUNombre.Text);
                        command.Parameters.AddWithValue("@Contraseña", HashPassword(textBoxGUPass.Text));
                        command.Parameters.AddWithValue("@Tipo", checkBoxGUAdmin.Checked ? "admin" : "user");
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Usuario añadido correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxGUNombre.Text = string.Empty;
                    textBoxGUPass.Text = string.Empty;
                    checkBoxGUAdmin.Checked = false;
                }
            }
            cargarUsuarios();
        }



    }
}
