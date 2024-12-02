using System.Text;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace TrabajoFinalTPV_Eva1
{
    public partial class FormMenuPrincipal : Form
    {
        private string userType;
        private string user;
        private string userSeleccionado = null;
        private string productoSeleccionado = null;
        private string productoIMGPath = null;
        private string categoriaSeleccionada = null;
        private string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../../BBDD", "Sociedad.accdb")};";
        private Form formLogin = null;
        public FormMenuPrincipal(string userName, string userType, Form formLogin)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.userType = userType;
            this.user = userName;
            this.formLogin = formLogin;
            listViewGUUsuarios.SelectedIndexChanged += listViewGUUsuarios_SelectedIndexChanged;

            groupBoxReservas.Visible = true;
            comboBoxTipoReservas.SelectedIndex = 0;
            dateTimePickerReservas.MinDate = DateTime.Now;
            cargarReservas();
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
            groupBoxPedido.Visible = false;
            groupBoxReservas.Visible = false;
            groupBoxUsuarios.Visible = false;
            cargarAlmacen();
        }

        private void btnPedido_Click(object sender, EventArgs e)
        {
            groupBoxPedido.Visible = true;
            groupBoxAlmacen.Visible = false;
            groupBoxReservas.Visible = false;
            groupBoxUsuarios.Visible = false;
            cargarCategoriaProductosPedido();
        }

        private void btnReservas_Click(object sender, EventArgs e)
        {
            groupBoxPedido.Visible = false;
            groupBoxAlmacen.Visible = false;
            groupBoxReservas.Visible = true;
            groupBoxUsuarios.Visible = false;
            cargarReservas();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            splitContainer1.IsSplitterFixed = true;
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            groupBoxUsuarios.Visible = true;
            groupBoxPedido.Visible = false;
            groupBoxAlmacen.Visible = false;
            groupBoxReservas.Visible = false;

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

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (formLogin != null && !formLogin.IsDisposed) formLogin.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            formLogin.Close();
            this.Close();
        }

        
    }
}