using System.Data.OleDb;
using System.Text.Json;
using System.Windows.Forms;
using DotNetEnv;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using Image = System.Drawing.Image;

namespace TrabajoFinalTPV_Eva1
{
    public partial class FormMenuPrincipal : Form
    {
        private void btnAInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Para añadir un producto, rellene los campos y pulse el botón 'Añadir/Modificar'.\nPara modificar un producto, selecciónelo de la lista y modifique los campos necesarios, después pulse el botón 'Añadir/Modificar'.\nPara crear una nueva categoria, selecciona en 'Categorias' la opcion de 'Nueva', despues escriba el nuevo nombre y pulse en 'Aceptar'\nPara eliminar un producto, seleccione el producto de la lista y pulse el botón 'Eliminar'.\n\nPara buscar una imagen, introduzca el nombre del producto y pulse el botón 'Buscar' o subela desde tu equipo con el boton de 'Subir fichero'", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
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
                btnGAAddModify.BackgroundImage = TrabajoFinalTPV_Eva1.Properties.Resources.archive_edit;
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
                btnGAAddModify.BackgroundImage = TrabajoFinalTPV_Eva1.Properties.Resources.archive_plus;
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
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string queryImgPath = "SELECT imgPath FROM Almacen WHERE Producto = ?";
                    string imgPath = null;
                    using (OleDbCommand commandImgPath = new OleDbCommand(queryImgPath, connection))
                    {
                        commandImgPath.Parameters.AddWithValue("@Producto", productoSeleccionado);
                        using (OleDbDataReader reader = commandImgPath.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                imgPath = reader["imgPath"].ToString();
                            }
                        }
                    }

                    string query = "DELETE FROM Almacen WHERE Producto = ?";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Producto", productoSeleccionado);
                        command.ExecuteNonQuery();
                    }

                    if (!string.IsNullOrEmpty(imgPath) && File.Exists(imgPath))
                    {
                        if (pictureBoxGAProducto.Image != null)
                        {
                            pictureBoxGAProducto.Image.Dispose();
                            pictureBoxGAProducto.Image = null;
                        }
                        File.Delete(imgPath);
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
                    btnGAAddModify.BackgroundImage = TrabajoFinalTPV_Eva1.Properties.Resources.archive_plus;
                }
                cargarAlmacen();
            }
            btnGAEliminar.Enabled = false;
        }

        private void btnGAAddModify_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxGAProducto.Text) || comboBoxGACategoria.SelectedIndex == -1 || string.IsNullOrEmpty(textBoxGACantidad.Text) || !int.TryParse(textBoxGACantidad.Text, out int cantidad) || cantidad <= 0 || string.IsNullOrEmpty(textBoxGAPrecio.Text) || !decimal.TryParse(textBoxGAPrecio.Text, out decimal precio) || precio < 0)
            {
                MessageBox.Show("Rellene todos los campos o comprueba que sean validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
                        // Si el Producto ya existe, actualizarlo
                        string queryUpdate = "UPDATE Almacen SET Categoria = ?, Cantidad = ?, Precio = ?, imgPath = ? WHERE Producto = ?";
                        using (OleDbCommand commandUpdate = new OleDbCommand(queryUpdate, connection))
                        {
                            commandUpdate.Parameters.AddWithValue("@Categoria", comboBoxGACategoria.SelectedItem.ToString());
                            commandUpdate.Parameters.AddWithValue("@Cantidad", textBoxGACantidad.Text);
                            commandUpdate.Parameters.AddWithValue("@Precio", textBoxGAPrecio.Text.Trim().Replace('.', ','));
                            commandUpdate.Parameters.AddWithValue("@imgPath", productoIMGPath ?? (object)DBNull.Value);
                            commandUpdate.Parameters.AddWithValue("@Producto", textBoxGAProducto.Text);
                            commandUpdate.ExecuteNonQuery();
                        }
                        MessageBox.Show("Producto actualizado correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Si el producto no existe, insertar
                        string queryInsert = "INSERT INTO Almacen (Producto, Categoria, Cantidad, Precio, imgPath) VALUES (?, ?, ?, ?, ?)";
                        using (OleDbCommand commandInsert = new OleDbCommand(queryInsert, connection))
                        {
                            commandInsert.Parameters.AddWithValue("@Producto", textBoxGAProducto.Text);
                            commandInsert.Parameters.AddWithValue("@Categoria", comboBoxGACategoria.SelectedItem.ToString());
                            commandInsert.Parameters.AddWithValue("@Cantidad", textBoxGACantidad.Text);
                            commandInsert.Parameters.AddWithValue("@Precio", textBoxGAPrecio.Text.Trim().Replace('.', ','));
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
            btnGAAddModify.BackgroundImage = TrabajoFinalTPV_Eva1.Properties.Resources.archive_plus;
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
                                        string imagePath = Path.Combine(projectDirectory, "../../../../assets/ProductosIMG", $"{query}.jpg");
                                        if (File.Exists(imagePath))
                                        {
                                            File.Delete(imagePath);
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
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF (*.pdf)|*.pdf";
                saveFileDialog.FileName = "Almacen";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    using (Document document = new Document(PageSize.A4))
                    {
                        PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                        document.Open();

                        var fontDefault = FontFactory.GetFont(FontFactory.COURIER, 10, BaseColor.BLACK);
                        var fontRed = FontFactory.GetFont(FontFactory.COURIER, 10, BaseColor.RED);

                        string titles = string.Format("{0,-25} {1,-20} {2,-10} {3,-10} {4,-20}",
                            "Producto", "Categoria", "Cantidad", "Precio", "Minimo Disponible");
                        document.Add(new Paragraph(titles, fontDefault));

                        Paragraph separator = new Paragraph(new Chunk(new LineSeparator(1.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_CENTER, 1)));
                        document.Add(separator);

                        using (OleDbConnection connection = new OleDbConnection(connectionString))
                        {
                            connection.Open();
                            string query = "SELECT * FROM Almacen";
                            using (OleDbCommand command = new OleDbCommand(query, connection))
                            {
                                using (OleDbDataReader reader = command.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        string producto = reader["Producto"].ToString();
                                        string categoria = reader["Categoria"].ToString();
                                        int cantidad = int.Parse(reader["Cantidad"].ToString());
                                        decimal precio = decimal.Parse(reader["Precio"].ToString());
                                        int minimoDisponible = int.Parse(reader["MinimoDisponible"].ToString());

                                        string row = string.Format("{0,-25} {1,-20} {2,-10} {3,-10} {4,-20}",
                                            producto, categoria, cantidad, precio, minimoDisponible);

                                        iTextSharp.text.Font fontToUse = cantidad < minimoDisponible ? fontRed : fontDefault;

                                        document.Add(new Paragraph(row, fontToUse));
                                    }
                                }
                            }
                        }
                    }
                    MessageBox.Show("PDF generado correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


    }
}
