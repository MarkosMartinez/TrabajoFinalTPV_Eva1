using System.Data.OleDb;
using System.Text.Json;
using System.Windows.Forms;
using DotNetEnv;

namespace TrabajoFinalTPV_Eva1
{
    public partial class FormMenuPrincipal : Form
    {
        private void cargarCategorias()
        {
            // Suponiendo que tienes un método para obtener las categorías
            List<string> categorias = ObtenerCategorias();

            comboBoxGACategoria.Items.Clear();
            foreach (var categoria in categorias)
            {
                comboBoxGACategoria.Items.Add(categoria);
            }
            comboBoxGACategoria.Items.Add("Nueva categoria");
        }

        private void comboBoxGACategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxGACategoria.SelectedItem != null && comboBoxGACategoria.SelectedItem.ToString() == "Nueva categoria")
            {
                string nuevaCategoria = Microsoft.VisualBasic.Interaction.InputBox("Introduce el nombre de la nueva categoría", "Nueva categoría", "");
                if (string.IsNullOrEmpty(nuevaCategoria))
                {
                    comboBoxGACategoria.SelectedIndex = -1;
                }
                else
                {
                    comboBoxGACategoria.Items.Insert(comboBoxGACategoria.Items.Count - 1, nuevaCategoria);
                    comboBoxGACategoria.SelectedIndex = comboBoxGACategoria.Items.Count - 2;
                }
            }
        }


        private void cargarAlmacen()
        {
            // Configurar el DataGridView
            listViewGAAlmacen.Clear();
            listViewGAAlmacen.View = View.Details;
            listViewGAAlmacen.Columns.Add("Producto", 100);
            listViewGAAlmacen.Columns.Add("Categoria", 100);
            listViewGAAlmacen.Columns.Add("Cantidad", 70);
            listViewGAAlmacen.Columns.Add("Precio", 50);
            productoSeleccionado = null;
            comboBoxGACategoria.SelectedItem = null;
            cargarCategorias();

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
                            item.SubItems.Add(reader["Cantidad"].ToString());
                            item.SubItems.Add(reader["Precio"].ToString());
                            listViewGAAlmacen.Items.Add(item);
                        }
                    }
                }
            }
        }

        private void listViewGAAlmacen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewGAAlmacen.SelectedItems.Count == 1)
            {
                var selectedItem = listViewGAAlmacen.SelectedItems[0];
                productoSeleccionado = selectedItem.SubItems[0].Text;
                btnGAAddModify.Text = "Modificar";
                textBoxGAProducto.Text = selectedItem.SubItems[0].Text;
                comboBoxGACategoria.SelectedIndex = comboBoxGACategoria.FindStringExact(selectedItem.SubItems[1].Text);
                textBoxGACantidad.Text = selectedItem.SubItems[2].Text;
                textBoxGAPrecio.Text = selectedItem.SubItems[3].Text;
                btnGAEliminar.Enabled = true;
                cargarImagen(textBoxGAProducto.Text, pictureBoxGAProducto);
            }
            else
            {
                productoIMGPath = null;
                productoSeleccionado = null;
                btnGAAddModify.Text = "Añadir";
                textBoxGAProducto.Text = string.Empty;
                comboBoxGACategoria.SelectedIndex = -1;
                textBoxGACantidad.Text = string.Empty;
                textBoxGAPrecio.Text = string.Empty;
                btnGAEliminar.Enabled = false;
                if (pictureBoxGAProducto.Image != null)
                {
                    pictureBoxGAProducto.Image.Dispose();
                    pictureBoxGAProducto.Image = null;
                }
            }
        }

        private void btnGAEliminar_Click(object sender, EventArgs e)
        {
            if (productoSeleccionado != null)
            {
                string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../../BBDD", "Sociedad.accdb")};";
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Almacen WHERE Producto = ?";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Producto", productoSeleccionado);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Producto eliminado correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    productoSeleccionado = null;
                    textBoxGACantidad.Text = string.Empty;
                    textBoxGAProducto.Text = string.Empty;
                    textBoxGAPrecio.Text = string.Empty;
                    comboBoxGACategoria.SelectedIndex = -1;
                    if (pictureBoxGAProducto.Image != null)
                    {
                        pictureBoxGAProducto.Image.Dispose();
                        pictureBoxGAProducto.Image = null;
                    }
                    btnGAAddModify.Text = "Añadir";
                }
                cargarAlmacen();
            }
            btnGAEliminar.Enabled = false;
        }

        private void btnGAAddModify_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxGAProducto.Text) || comboBoxGACategoria.SelectedIndex == -1 || string.IsNullOrEmpty(textBoxGACantidad.Text) || string.IsNullOrEmpty(textBoxGAPrecio.Text) || !int.TryParse(textBoxGACantidad.Text, out _) || !decimal.TryParse(textBoxGAPrecio.Text, out _))
            {
                MessageBox.Show("Rellene todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../../BBDD", "Sociedad.accdb")};";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string queryCheck = "SELECT COUNT(*) FROM Almacen WHERE Producto = ?";
                using (OleDbCommand commandCheck = new OleDbCommand(queryCheck, connection))
                {
                    commandCheck.Parameters.AddWithValue("@Producto", textBoxGAProducto.Text);
                    int count = (int)commandCheck.ExecuteScalar();

                    if (count > 0)
                    {
                        // Producto ya existe, actualizar
                        string queryUpdate = "UPDATE Almacen SET Categoria = ?, Cantidad = ?, Precio = ?, imgPath = ? WHERE Producto = ?";
                        using (OleDbCommand commandUpdate = new OleDbCommand(queryUpdate, connection))
                        {
                            commandUpdate.Parameters.AddWithValue("@Categoria", comboBoxGACategoria.SelectedItem.ToString());
                            commandUpdate.Parameters.AddWithValue("@Cantidad", textBoxGACantidad.Text);
                            commandUpdate.Parameters.AddWithValue("@Precio", textBoxGAPrecio.Text);
                            commandUpdate.Parameters.AddWithValue("@imgPath", productoIMGPath ?? (object)DBNull.Value);
                            commandUpdate.Parameters.AddWithValue("@Producto", textBoxGAProducto.Text);
                            commandUpdate.ExecuteNonQuery();
                        }
                        MessageBox.Show("Producto actualizado correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Producto no existe, insertar
                        string queryInsert = "INSERT INTO Almacen (Producto, Categoria, Cantidad, Precio, imgPath) VALUES (?, ?, ?, ?, ?)";
                        using (OleDbCommand commandInsert = new OleDbCommand(queryInsert, connection))
                        {
                            commandInsert.Parameters.AddWithValue("@Producto", textBoxGAProducto.Text);
                            commandInsert.Parameters.AddWithValue("@Categoria", comboBoxGACategoria.SelectedItem.ToString());
                            commandInsert.Parameters.AddWithValue("@Cantidad", textBoxGACantidad.Text);
                            commandInsert.Parameters.AddWithValue("@Precio", textBoxGAPrecio.Text);
                            commandInsert.Parameters.AddWithValue("@imgPath", productoIMGPath ?? (object)DBNull.Value);
                            commandInsert.ExecuteNonQuery();
                        }
                        MessageBox.Show("Producto añadido correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            cargarAlmacen();
            productoSeleccionado = null;
            textBoxGACantidad.Text = string.Empty;
            textBoxGAProducto.Text = string.Empty;
            textBoxGAPrecio.Text = string.Empty;
            comboBoxGACategoria.SelectedIndex = -1;
            btnGAAddModify.Text = "Añadir";
            btnGAEliminar.Enabled = false;
            if (pictureBoxGAProducto.Image != null)
            {
                pictureBoxGAProducto.Image.Dispose();
                pictureBoxGAProducto.Image = null;
            }
            cargarCategorias();
        }

        private void btnGASubirLocal_Click(object sender, EventArgs e)
        {
            if(textBoxGAProducto.Text == string.Empty || textBoxGAProducto.Text == " ")
            {
                MessageBox.Show("Introduce un nombre de producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Fichero de Imagen (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Liberar la imagen actual antes de cargar una nueva
                    if (pictureBoxGAProducto.Image != null)
                    {
                        pictureBoxGAProducto.Image.Dispose();
                        pictureBoxGAProducto.Image = null;
                    }

                    string sourceFilePath = openFileDialog.FileName;
                    string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    string imagesDirectory = Path.Combine(projectDirectory, "../../../../assets/ProductosIMG");
                    Directory.CreateDirectory(imagesDirectory);
                    string destFilePath = Path.Combine(imagesDirectory, $"{textBoxGAProducto.Text}{Path.GetExtension(sourceFilePath)}");
                    File.Copy(sourceFilePath, destFilePath, true);
                    string imagePath = destFilePath;

                    Uri projectUri = new Uri(projectDirectory);
                    Uri imageUri = new Uri(imagePath);
                    string relativePath = Uri.UnescapeDataString(projectUri.MakeRelativeUri(imageUri).ToString());
                    productoIMGPath = relativePath;


                    // Cargar la imagen en memoria antes de asignarla al PictureBox
                    using (MemoryStream memoryStream = new MemoryStream(File.ReadAllBytes(imagePath)))
                    {
                        pictureBoxGAProducto.Image = Image.FromStream(memoryStream);
                    }
                }
            }
        }

        private async void btnGABuscarIMG_Click(object sender, EventArgs e)
        {
            try
            {

                pictureBoxGAProducto.Image = Image.FromFile("../../../../assets/loading.gif");
                string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string envFilePath = Path.Combine(projectDirectory, "../../../../.env");
                DotNetEnv.Env.Load(envFilePath);

                string apiKey = Environment.GetEnvironmentVariable("API_KEY") ?? string.Empty;
                string cx = Environment.GetEnvironmentVariable("CX") ?? string.Empty;
                string query = textBoxGAProducto.Text;
                string requestUri = $"https://www.googleapis.com/customsearch/v1?key={apiKey}&cx={cx}&q={query}&searchType=image&num=1&fields=items(link)";
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(requestUri);
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        using (JsonDocument doc = JsonDocument.Parse(jsonResponse))
                        {
                            JsonElement root = doc.RootElement;
                            if (root.TryGetProperty("items", out JsonElement items) && items.GetArrayLength() > 0)
                            {
                                string imageUrl = items[0].GetProperty("link").GetString() ?? string.Empty;

                                using (HttpClient imageClient = new HttpClient())
                                {
                                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, imageUrl);
                                    request.Headers.Add("User-Agent", "TrabajoFinalTPV_Eva1 (Windows NT 10.0; Win64; x64)"); //El User-Agent se usa para que en algunas webs no de error al obtener las imagenes. Por ejemplo, Wikipedia.
                                    HttpResponseMessage imageResponse = await imageClient.SendAsync(request);
                                    if (imageResponse.IsSuccessStatusCode)
                                    {
                                        using (Stream imageStream = await imageResponse.Content.ReadAsStreamAsync())
                                        {
                                            string imagesDirectory = Path.Combine(projectDirectory, "../../../../assets/ProductosIMG");
                                            Directory.CreateDirectory(imagesDirectory);

                                            // Liberar la imagen actual antes de descargar una nueva
                                            if (pictureBoxGAProducto.Image != null)
                                            {
                                                pictureBoxGAProducto.Image.Dispose();
                                                pictureBoxGAProducto.Image = null;
                                            }

                                            string imagePath = Path.Combine(imagesDirectory, $"{query}.jpg");

                                            using (FileStream fileStream = new FileStream(imagePath, FileMode.Create, FileAccess.Write))
                                            {
                                                await imageStream.CopyToAsync(fileStream);
                                            }

                                            Uri projectUri = new Uri(projectDirectory);
                                            Uri imageUri = new Uri(imagePath);
                                            string relativePath = Uri.UnescapeDataString(projectUri.MakeRelativeUri(imageUri).ToString());
                                            productoIMGPath = relativePath;

                                            // Cargar la imagen en memoria antes de asignarla al PictureBox
                                            using (MemoryStream memoryStream = new MemoryStream(File.ReadAllBytes(imagePath)))
                                            {
                                                pictureBoxGAProducto.Image = Image.FromStream(memoryStream);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (pictureBoxGAProducto.Image != null)
                                        {
                                            pictureBoxGAProducto.Image.Dispose();
                                            pictureBoxGAProducto.Image = null;
                                        }
                                        throw new Exception("No se pudo descargar la imagen");
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("No se encontraron imágenes para la búsqueda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                if (pictureBoxGAProducto.Image != null)
                                {
                                    pictureBoxGAProducto.Image.Dispose();
                                    pictureBoxGAProducto.Image = null;
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Error en la solicitud: {response.ReasonPhrase}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (pictureBoxGAProducto.Image != null)
                        {
                            pictureBoxGAProducto.Image.Dispose();
                            pictureBoxGAProducto.Image = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (pictureBoxGAProducto.Image != null)
                {
                    pictureBoxGAProducto.Image.Dispose();
                    pictureBoxGAProducto.Image = null;
                }
            }
        }

        private void cargarImagen(string Producto, PictureBox pictureBox)
        {
            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../../BBDD", "Sociedad.accdb")};";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT imgPath FROM Almacen WHERE Producto = ?";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Producto", Producto);
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string imgPath = reader["imgPath"].ToString() ?? string.Empty;
                            if (!string.IsNullOrEmpty(imgPath) && File.Exists(Uri.UnescapeDataString(imgPath)))
                            {
                                if (pictureBox.Image != null)
                                {
                                    pictureBox.Image.Dispose();
                                    pictureBox.Image = null;
                                }
                                productoIMGPath = imgPath;
                                using (MemoryStream memoryStream = new MemoryStream(File.ReadAllBytes(Uri.UnescapeDataString(imgPath))))
                                {
                                    pictureBox.Image = Image.FromStream(memoryStream);
                                }
                            }
                            else
                            {
                                pictureBox.Image = null;
                            }
                        }
                        else
                        {
                            pictureBox.Image = null;
                        }
                    }
                }
            }
        }
        private List<string> ObtenerCategorias()
        {
            List<string> categorias = new List<string>();
            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../../BBDD", "Sociedad.accdb")};";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT DISTINCT Categoria FROM Almacen";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categorias.Add(reader["Categoria"].ToString());
                        }
                    }
                }
            }
            return categorias;
        }
    }
}
