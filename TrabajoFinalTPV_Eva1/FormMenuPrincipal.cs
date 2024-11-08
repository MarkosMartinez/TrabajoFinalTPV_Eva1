using System.Text;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace TrabajoFinalTPV_Eva1
{
    public partial class FormMenuPrincipal : Form
    {
        private string userType;
        private string userSeleecionado = null;
        public FormMenuPrincipal(string userName, string userType)
        {
            InitializeComponent();
            this.userType = userType;
            groupBoxReservas.Visible = true;
            listViewUsuarios.SelectedIndexChanged += listViewUsuarios_SelectedIndexChanged;

            //toolTip1.SetToolTip(textBoxGUPass, "Cambiar la contraseña remplazara la contraseña actual");
        }

        private void FormMenuPrincipal_Load(object sender, EventArgs e)
        {
            if (userType == "admin")
            {
                btnAlmacen.Visible = true;
                btnUsuarios.Visible = true;
            }
            else
            {
                btnAlmacen.Visible = false;
                btnUsuarios.Visible = false;
            }
        }

        private void btnAlmacen_Click(object sender, EventArgs e)
        {
            groupBoxAlmacen.Visible = true;
            groupBoxConsumos.Visible = false;
            groupBoxReservas.Visible = false;
            groupBoxUsuarios.Visible = false;
        }

        private void btnConsumos_Click(object sender, EventArgs e)
        {
            groupBoxConsumos.Visible = true;
            groupBoxAlmacen.Visible = false;
            groupBoxReservas.Visible = false;
            groupBoxUsuarios.Visible = false;
        }

        private void btnReservas_Click(object sender, EventArgs e)
        {
            groupBoxConsumos.Visible = false;
            groupBoxAlmacen.Visible = false;
            groupBoxReservas.Visible = true;
            groupBoxUsuarios.Visible = false;
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            splitContainer1.IsSplitterFixed = true;
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            groupBoxUsuarios.Visible = true;
            groupBoxConsumos.Visible = false;
            groupBoxAlmacen.Visible = false;
            groupBoxReservas.Visible = false;

            cargarUsuarios();

        }

        private void listViewUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewUsuarios.SelectedItems.Count == 1)
            {
                var selectedItem = listViewUsuarios.SelectedItems[0];
                userSeleecionado = selectedItem.SubItems[0].Text;
                btnGUAddModify.Text = "Modificar";
                textBoxGUNombre.Text = selectedItem.SubItems[0].Text;
                checkBoxGUAdmin.Checked = selectedItem.SubItems[1].Text == "admin";
                btnGUEliminar.Enabled = true;
                textBoxGUPass.Text = string.Empty;
            }
            else
            {
                userSeleecionado = null;
                btnGUAddModify.Text = "Añadir";
                textBoxGUNombre.Text = string.Empty;
                checkBoxGUAdmin.Checked = false;
                btnGUEliminar.Enabled = false;
            }
        }

        private void cargarUsuarios()
        {
            // Configurar el ListView
            listViewUsuarios.Clear();
            listViewUsuarios.View = View.Details;
            listViewUsuarios.Columns.Add("Nombre", 100);
            listViewUsuarios.Columns.Add("Tipo", 50);

            // Conectar a la base de datos de Access
            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BBDD", "Sociedad.accdb")};";
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
                            listViewUsuarios.Items.Add(item);
                        }
                    }
                }
            }
        }

        private void btnGUEliminar_Click(object sender, EventArgs e)
        {
            if (userSeleecionado != null)
            {
                string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BBDD", "Sociedad.accdb")};";
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Usuarios WHERE Usuario = ?";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Usuario", userSeleecionado);
                        command.ExecuteNonQuery();
                    }
                }
                cargarUsuarios();
            }
            btnGUEliminar.Enabled = false;
        }

        private void btnGUAddModify_Click(object sender, EventArgs e)
        {
            if (userSeleecionado != null)
            {
                if (string.IsNullOrEmpty(textBoxGUNombre.Text))
                {
                    MessageBox.Show("Por favor, rellene todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BBDD", "Sociedad.accdb")};";
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
                        command.Parameters.AddWithValue("@UsuarioOriginal", userSeleecionado);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Usuario modificado correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(textBoxGUNombre.Text) || string.IsNullOrEmpty(textBoxGUPass.Text))
                {
                    MessageBox.Show("Por favor, rellene todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BBDD", "Sociedad.accdb")};";
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
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
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }


    }
}