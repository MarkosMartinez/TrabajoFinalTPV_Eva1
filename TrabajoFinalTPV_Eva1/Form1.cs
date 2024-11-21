using System.Data.OleDb;
using System.Security.Cryptography;
using System.Text;


namespace TrabajoFinalTPV_Eva1
{
    public partial class Form1 : Form
    {
        private string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../../BBDD", "Sociedad.accdb")};";

        public Form1()
        {
            InitializeComponent();
            textBoxUser.KeyDown += new KeyEventHandler(textBoxUser_KeyDown);
            textBoxPass.KeyDown += new KeyEventHandler(textBoxPass_KeyDown);
        }
        private void textBoxUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(this, new EventArgs());
            }
        }

        private void textBoxPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(this, new EventArgs());
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = textBoxUser.Text;
            string pass = HashPassword(textBoxPass.Text);
            var (isValid, tipo) = ValidateUser(user, pass);

            if (isValid)
            {
                FormMenuPrincipal formMenuPrincipal = new FormMenuPrincipal(user, tipo, this);
                formMenuPrincipal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private (bool isValid, string tipo) ValidateUser(string user, string pass)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT Tipo FROM Usuarios WHERE Usuario = ? AND Contraseña = ?";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Usuario", user);
                        command.Parameters.AddWithValue("@Contraseña", pass);

                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string tipo = reader["Tipo"].ToString();
                                return (true, tipo);
                            }
                            else
                            {
                                return (false, null);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return (false, null);
                }
                finally
                {
                    connection.Close();
                }
            }
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

        private void buttonPassEye_Click(object sender, EventArgs e)
        {
            //Ocultara o mostrara la contraseña
            if (textBoxPass.PasswordChar == '*')
            {
                textBoxPass.PasswordChar = '\0';
                buttonPassEye.BackgroundImage = Properties.Resources.eye_closed;
            }
            else
            {
                textBoxPass.PasswordChar = '*';
                buttonPassEye.BackgroundImage = Properties.Resources.eye;
            }
        }
    }
}
