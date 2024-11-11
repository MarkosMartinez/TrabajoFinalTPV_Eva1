using System.Data.OleDb;
using System.Text.Json;
using System.Windows.Forms;
using DotNetEnv;

namespace TrabajoFinalTPV_Eva1
{
    public partial class FormMenuPrincipal : Form
    {

        private void cargarAlmacen()
        {
            // Configurar el DataGridView
            listViewGAAlmacen.Clear();
            listViewGAAlmacen.View = View.Details;
            listViewGAAlmacen.Columns.Add("Producto", 100);
            listViewGAAlmacen.Columns.Add("Categoria", 100);
            listViewGAAlmacen.Columns.Add("Cantidad", 70);
            listViewGAAlmacen.Columns.Add("Precio", 50);

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
                textBoxGACategoria.Text = selectedItem.SubItems[1].Text;
                textBoxGACantidad.Text = selectedItem.SubItems[2].Text;
                textBoxGAPrecio.Text = selectedItem.SubItems[3].Text;
                btnGAEliminar.Enabled = true;
                cargarImagen(textBoxGAProducto.Text);
            }
            else
            {
                productoSeleccionado = null;
                btnGAAddModify.Text = "Añadir";
                textBoxGAProducto.Text = string.Empty;
                textBoxGACategoria.Text = string.Empty;
                textBoxGACantidad.Text = string.Empty;
                textBoxGAPrecio.Text = string.Empty;
                btnGAEliminar.Enabled = false;
                pictureBoxGAProducto.Image = null;
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
                }
                cargarAlmacen();
            }
            btnGAEliminar.Enabled = false;
        }

        private void btnGAAddModify_Click(object sender, EventArgs e)
        {
            if (productoSeleccionado != null)
            {
                if (string.IsNullOrEmpty(textBoxGAProducto.Text) || string.IsNullOrEmpty(textBoxGACategoria.Text) || string.IsNullOrEmpty(textBoxGACantidad.Text) || string.IsNullOrEmpty(textBoxGAPrecio.Text) || !int.TryParse(textBoxGACantidad.Text, out _) || !decimal.TryParse(textBoxGAPrecio.Text, out _))
                {
                    MessageBox.Show("Rellene todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../../BBDD", "Sociedad.accdb")};";
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Almacen SET Producto = ?, Categoria = ?, Cantidad = ?, Precio = ?, imgPath = ? WHERE Producto = ?";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Producto", textBoxGAProducto.Text);
                        command.Parameters.AddWithValue("@Categoria", textBoxGACategoria.Text);
                        command.Parameters.AddWithValue("@Cantidad", textBoxGACantidad.Text);
                        command.Parameters.AddWithValue("@Precio", textBoxGAPrecio.Text);
                        command.Parameters.AddWithValue("@imgPath", productoIMGPath ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Producto", productoSeleccionado);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Producto modificado correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(textBoxGAProducto.Text) || string.IsNullOrEmpty(textBoxGACategoria.Text) || string.IsNullOrEmpty(textBoxGACantidad.Text) || string.IsNullOrEmpty(textBoxGAPrecio.Text) || !int.TryParse(textBoxGACantidad.Text, out _) || !decimal.TryParse(textBoxGAPrecio.Text, out _))
                {
                    MessageBox.Show("Rellene todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../../BBDD", "Sociedad.accdb")};";
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Almacen (Producto, Categoria, Cantidad, Precio, imgPath) VALUES (?, ?, ?, ?, ?)";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Producto", textBoxGAProducto.Text);
                        command.Parameters.AddWithValue("@Categoria", textBoxGACategoria.Text);
                        command.Parameters.AddWithValue("@Cantidad", textBoxGACantidad.Text);
                        command.Parameters.AddWithValue("@Precio", textBoxGAPrecio.Text);
                        command.Parameters.AddWithValue("@imgPath", productoIMGPath ?? (object)DBNull.Value);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Producto añadido correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            cargarAlmacen();
        }

        private void btnGASubirLocal_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Fichero de Imagen (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string sourceFilePath = openFileDialog.FileName;
                    string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    string imagesDirectory = Path.Combine(projectDirectory, "../../../../ProductosIMG");
                    Directory.CreateDirectory(imagesDirectory);
                    string destFilePath = Path.Combine(imagesDirectory, Path.GetFileName(sourceFilePath));
                    File.Copy(sourceFilePath, destFilePath, true);
                    string imagePath = destFilePath;

                    Uri projectUri = new Uri(projectDirectory);
                    Uri imageUri = new Uri(imagePath);
                    string relativePath = projectUri.MakeRelativeUri(imageUri).ToString();
                    productoIMGPath = relativePath;
                    pictureBoxGAProducto.Image = Image.FromFile(imagePath);
                }
            }
        }

        private async void btnGABuscarIMG_Click(object sender, EventArgs e)
        {
            try
            {
                string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string envFilePath = Path.Combine(projectDirectory, "../../../../.env");
                DotNetEnv.Env.Load(envFilePath);

                string apiKey = Environment.GetEnvironmentVariable("API_KEY");
                string cx = Environment.GetEnvironmentVariable("CX");
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
                                string imageUrl = items[0].GetProperty("link").GetString();

                                using (HttpClient imageClient = new HttpClient())
                                {
                                    HttpResponseMessage imageResponse = await imageClient.GetAsync(imageUrl);
                                    if (imageResponse.IsSuccessStatusCode)
                                    {
                                        using (Stream imageStream = await imageResponse.Content.ReadAsStreamAsync())
                                        {
                                            string imagesDirectory = Path.Combine(projectDirectory, "../../../../ProductosIMG");
                                            Directory.CreateDirectory(imagesDirectory);

                                            Uri projectUri = new Uri(projectDirectory);
                                            Uri imageUri = new Uri(Path.Combine(imagesDirectory, $"{query}.jpg"));
                                            string relativePath = projectUri.MakeRelativeUri(imageUri).ToString();
                                            productoIMGPath = relativePath;

                                            using (FileStream fileStream = new FileStream(productoIMGPath, FileMode.Create, FileAccess.Write))
                                            {
                                                await imageStream.CopyToAsync(fileStream);
                                            }
                                            pictureBoxGAProducto.Image = Image.FromFile(productoIMGPath);
                                        }
                                    }
                                    else
                                    {
                                        throw new Exception("No se pudo descargar la imagen");
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("No se encontraron imágenes para la búsqueda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Error en la solicitud: {response.ReasonPhrase}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarImagen(string Producto)
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
                            string imgPath = reader["imgPath"].ToString();
                            if (!string.IsNullOrEmpty(imgPath))
                            {
                                pictureBoxGAProducto.Image = Image.FromFile(imgPath);
                            }
                        }
                    }
                }
            }
        }


    }
}
