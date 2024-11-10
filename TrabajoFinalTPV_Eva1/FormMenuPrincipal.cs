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