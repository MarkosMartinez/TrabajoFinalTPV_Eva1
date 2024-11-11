namespace TrabajoFinalTPV_Eva1
{
    partial class FormMenuPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            btnUsuarios = new Button();
            btnAlmacen = new Button();
            btnConsumos = new Button();
            btnReservas = new Button();
            groupBoxAlmacen = new GroupBox();
            btnGABuscarIMG = new Button();
            btnGASubirLocal = new Button();
            pictureBoxGAProducto = new PictureBox();
            listViewGAAlmacen = new ListView();
            btnGAEliminar = new Button();
            textBoxGACategoria = new TextBox();
            btnGAAddModify = new Button();
            textBoxGAPrecio = new TextBox();
            textBoxGACantidad = new TextBox();
            textBoxGAProducto = new TextBox();
            groupBoxUsuarios = new GroupBox();
            textBoxGUNombre = new TextBox();
            textBoxGUPass = new TextBox();
            checkBoxGUAdmin = new CheckBox();
            btnGUAddModify = new Button();
            btnGUEliminar = new Button();
            listViewGUUsuarios = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            groupBoxReservas = new GroupBox();
            listViewReservas = new ListView();
            groupBoxConsumos = new GroupBox();
            listViewConsumo = new ListView();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBoxAlmacen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGAProducto).BeginInit();
            groupBoxUsuarios.SuspendLayout();
            groupBoxReservas.SuspendLayout();
            groupBoxConsumos.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(2, 1);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(btnUsuarios);
            splitContainer1.Panel1.Controls.Add(btnAlmacen);
            splitContainer1.Panel1.Controls.Add(btnConsumos);
            splitContainer1.Panel1.Controls.Add(btnReservas);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBoxAlmacen);
            splitContainer1.Panel2.Controls.Add(groupBoxUsuarios);
            splitContainer1.Panel2.Controls.Add(groupBoxReservas);
            splitContainer1.Panel2.Controls.Add(groupBoxConsumos);
            splitContainer1.Size = new Size(797, 449);
            splitContainer1.SplitterDistance = 152;
            splitContainer1.TabIndex = 2;
            splitContainer1.SplitterMoved += splitContainer1_SplitterMoved;
            // 
            // btnUsuarios
            // 
            btnUsuarios.Location = new Point(10, 131);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(126, 23);
            btnUsuarios.TabIndex = 3;
            btnUsuarios.Text = "Gestionar Usuarios";
            btnUsuarios.UseVisualStyleBackColor = true;
            btnUsuarios.Visible = false;
            btnUsuarios.Click += btnUsuarios_Click;
            // 
            // btnAlmacen
            // 
            btnAlmacen.Location = new Point(10, 93);
            btnAlmacen.Name = "btnAlmacen";
            btnAlmacen.Size = new Size(126, 23);
            btnAlmacen.TabIndex = 2;
            btnAlmacen.Text = "Gestionar Almacen";
            btnAlmacen.UseVisualStyleBackColor = true;
            btnAlmacen.Visible = false;
            btnAlmacen.Click += btnAlmacen_Click;
            // 
            // btnConsumos
            // 
            btnConsumos.Location = new Point(10, 54);
            btnConsumos.Name = "btnConsumos";
            btnConsumos.Size = new Size(126, 23);
            btnConsumos.TabIndex = 1;
            btnConsumos.Text = "Gestionar Consumo";
            btnConsumos.UseVisualStyleBackColor = true;
            btnConsumos.Click += btnConsumos_Click;
            // 
            // btnReservas
            // 
            btnReservas.Location = new Point(10, 11);
            btnReservas.Name = "btnReservas";
            btnReservas.Size = new Size(126, 26);
            btnReservas.TabIndex = 0;
            btnReservas.Text = "Gestionar Reservas";
            btnReservas.UseVisualStyleBackColor = true;
            btnReservas.Click += btnReservas_Click;
            // 
            // groupBoxAlmacen
            // 
            groupBoxAlmacen.Controls.Add(btnGABuscarIMG);
            groupBoxAlmacen.Controls.Add(btnGASubirLocal);
            groupBoxAlmacen.Controls.Add(pictureBoxGAProducto);
            groupBoxAlmacen.Controls.Add(listViewGAAlmacen);
            groupBoxAlmacen.Controls.Add(btnGAEliminar);
            groupBoxAlmacen.Controls.Add(textBoxGACategoria);
            groupBoxAlmacen.Controls.Add(btnGAAddModify);
            groupBoxAlmacen.Controls.Add(textBoxGAPrecio);
            groupBoxAlmacen.Controls.Add(textBoxGACantidad);
            groupBoxAlmacen.Controls.Add(textBoxGAProducto);
            groupBoxAlmacen.Location = new Point(0, 0);
            groupBoxAlmacen.Name = "groupBoxAlmacen";
            groupBoxAlmacen.Size = new Size(641, 446);
            groupBoxAlmacen.TabIndex = 0;
            groupBoxAlmacen.TabStop = false;
            groupBoxAlmacen.Text = "Almacen";
            groupBoxAlmacen.Visible = false;
            // 
            // btnGABuscarIMG
            // 
            btnGABuscarIMG.Location = new Point(548, 131);
            btnGABuscarIMG.Name = "btnGABuscarIMG";
            btnGABuscarIMG.Size = new Size(75, 23);
            btnGABuscarIMG.TabIndex = 12;
            btnGABuscarIMG.Text = "Buscar";
            btnGABuscarIMG.UseVisualStyleBackColor = true;
            btnGABuscarIMG.Click += btnGABuscarIMG_Click;
            // 
            // btnGASubirLocal
            // 
            btnGASubirLocal.Location = new Point(448, 131);
            btnGASubirLocal.Name = "btnGASubirLocal";
            btnGASubirLocal.Size = new Size(75, 23);
            btnGASubirLocal.TabIndex = 11;
            btnGASubirLocal.Text = "Subir";
            btnGASubirLocal.UseVisualStyleBackColor = true;
            btnGASubirLocal.Click += btnGASubirLocal_Click;
            // 
            // pictureBoxGAProducto
            // 
            pictureBoxGAProducto.Location = new Point(448, 265);
            pictureBoxGAProducto.Name = "pictureBoxGAProducto";
            pictureBoxGAProducto.Size = new Size(175, 172);
            pictureBoxGAProducto.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxGAProducto.TabIndex = 10;
            pictureBoxGAProducto.TabStop = false;
            // 
            // listViewGAAlmacen
            // 
            listViewGAAlmacen.FullRowSelect = true;
            listViewGAAlmacen.Location = new Point(6, 19);
            listViewGAAlmacen.MultiSelect = false;
            listViewGAAlmacen.Name = "listViewGAAlmacen";
            listViewGAAlmacen.Size = new Size(437, 421);
            listViewGAAlmacen.TabIndex = 9;
            listViewGAAlmacen.UseCompatibleStateImageBehavior = false;
            listViewGAAlmacen.SelectedIndexChanged += listViewGAAlmacen_SelectedIndexChanged;
            // 
            // btnGAEliminar
            // 
            btnGAEliminar.Enabled = false;
            btnGAEliminar.Location = new Point(448, 206);
            btnGAEliminar.Name = "btnGAEliminar";
            btnGAEliminar.Size = new Size(175, 23);
            btnGAEliminar.TabIndex = 8;
            btnGAEliminar.Text = "Eliminar";
            btnGAEliminar.UseVisualStyleBackColor = true;
            btnGAEliminar.Click += btnGAEliminar_Click;
            // 
            // textBoxGACategoria
            // 
            textBoxGACategoria.Location = new Point(448, 100);
            textBoxGACategoria.Name = "textBoxGACategoria";
            textBoxGACategoria.PlaceholderText = "Categoria";
            textBoxGACategoria.Size = new Size(175, 23);
            textBoxGACategoria.TabIndex = 7;
            // 
            // btnGAAddModify
            // 
            btnGAAddModify.Location = new Point(448, 166);
            btnGAAddModify.Name = "btnGAAddModify";
            btnGAAddModify.Size = new Size(175, 23);
            btnGAAddModify.TabIndex = 6;
            btnGAAddModify.Text = "Añadir";
            btnGAAddModify.UseVisualStyleBackColor = true;
            btnGAAddModify.Click += btnGAAddModify_Click;
            // 
            // textBoxGAPrecio
            // 
            textBoxGAPrecio.Location = new Point(556, 60);
            textBoxGAPrecio.Name = "textBoxGAPrecio";
            textBoxGAPrecio.PlaceholderText = "Precio";
            textBoxGAPrecio.Size = new Size(67, 23);
            textBoxGAPrecio.TabIndex = 5;
            // 
            // textBoxGACantidad
            // 
            textBoxGACantidad.Location = new Point(448, 60);
            textBoxGACantidad.Name = "textBoxGACantidad";
            textBoxGACantidad.PlaceholderText = "Cantidad";
            textBoxGACantidad.Size = new Size(67, 23);
            textBoxGACantidad.TabIndex = 4;
            // 
            // textBoxGAProducto
            // 
            textBoxGAProducto.Location = new Point(448, 19);
            textBoxGAProducto.Name = "textBoxGAProducto";
            textBoxGAProducto.PlaceholderText = "Producto";
            textBoxGAProducto.Size = new Size(175, 23);
            textBoxGAProducto.TabIndex = 3;
            // 
            // groupBoxUsuarios
            // 
            groupBoxUsuarios.Controls.Add(textBoxGUNombre);
            groupBoxUsuarios.Controls.Add(textBoxGUPass);
            groupBoxUsuarios.Controls.Add(checkBoxGUAdmin);
            groupBoxUsuarios.Controls.Add(btnGUAddModify);
            groupBoxUsuarios.Controls.Add(btnGUEliminar);
            groupBoxUsuarios.Controls.Add(listViewGUUsuarios);
            groupBoxUsuarios.Location = new Point(0, 0);
            groupBoxUsuarios.Name = "groupBoxUsuarios";
            groupBoxUsuarios.Size = new Size(638, 446);
            groupBoxUsuarios.TabIndex = 0;
            groupBoxUsuarios.TabStop = false;
            groupBoxUsuarios.Text = "Usuarios";
            groupBoxUsuarios.Visible = false;
            // 
            // textBoxGUNombre
            // 
            textBoxGUNombre.Location = new Point(448, 19);
            textBoxGUNombre.Name = "textBoxGUNombre";
            textBoxGUNombre.PlaceholderText = "Nombre";
            textBoxGUNombre.Size = new Size(175, 23);
            textBoxGUNombre.TabIndex = 0;
            // 
            // textBoxGUPass
            // 
            textBoxGUPass.Location = new Point(448, 60);
            textBoxGUPass.Name = "textBoxGUPass";
            textBoxGUPass.PasswordChar = '*';
            textBoxGUPass.PlaceholderText = "Contraseña";
            textBoxGUPass.Size = new Size(177, 23);
            textBoxGUPass.TabIndex = 1;
            // 
            // checkBoxGUAdmin
            // 
            checkBoxGUAdmin.AutoSize = true;
            checkBoxGUAdmin.Location = new Point(453, 100);
            checkBoxGUAdmin.Name = "checkBoxGUAdmin";
            checkBoxGUAdmin.Size = new Size(62, 19);
            checkBoxGUAdmin.TabIndex = 2;
            checkBoxGUAdmin.Text = "Admin";
            checkBoxGUAdmin.UseVisualStyleBackColor = true;
            // 
            // btnGUAddModify
            // 
            btnGUAddModify.Location = new Point(521, 96);
            btnGUAddModify.Name = "btnGUAddModify";
            btnGUAddModify.Size = new Size(102, 23);
            btnGUAddModify.TabIndex = 3;
            btnGUAddModify.Text = "Añadir";
            btnGUAddModify.UseVisualStyleBackColor = true;
            btnGUAddModify.Click += btnGUAddModify_Click;
            // 
            // btnGUEliminar
            // 
            btnGUEliminar.Enabled = false;
            btnGUEliminar.Location = new Point(448, 137);
            btnGUEliminar.Name = "btnGUEliminar";
            btnGUEliminar.Size = new Size(175, 23);
            btnGUEliminar.TabIndex = 4;
            btnGUEliminar.Text = "Eliminar Usuario";
            btnGUEliminar.UseVisualStyleBackColor = true;
            btnGUEliminar.Click += btnGUEliminar_Click;
            // 
            // listViewGUUsuarios
            // 
            listViewGUUsuarios.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            listViewGUUsuarios.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listViewGUUsuarios.FullRowSelect = true;
            listViewGUUsuarios.Location = new Point(6, 19);
            listViewGUUsuarios.MultiSelect = false;
            listViewGUUsuarios.Name = "listViewGUUsuarios";
            listViewGUUsuarios.Size = new Size(437, 421);
            listViewGUUsuarios.TabIndex = 0;
            listViewGUUsuarios.UseCompatibleStateImageBehavior = false;
            listViewGUUsuarios.SelectedIndexChanged += listViewGUUsuarios_SelectedIndexChanged;
            // 
            // groupBoxReservas
            // 
            groupBoxReservas.Controls.Add(listViewReservas);
            groupBoxReservas.Location = new Point(0, 0);
            groupBoxReservas.Name = "groupBoxReservas";
            groupBoxReservas.Size = new Size(638, 446);
            groupBoxReservas.TabIndex = 0;
            groupBoxReservas.TabStop = false;
            groupBoxReservas.Text = "Reservas";
            groupBoxReservas.Visible = false;
            // 
            // listViewReservas
            // 
            listViewReservas.FullRowSelect = true;
            listViewReservas.Location = new Point(6, 19);
            listViewReservas.MultiSelect = false;
            listViewReservas.Name = "listViewReservas";
            listViewReservas.Size = new Size(626, 427);
            listViewReservas.TabIndex = 1;
            listViewReservas.UseCompatibleStateImageBehavior = false;
            // 
            // groupBoxConsumos
            // 
            groupBoxConsumos.Controls.Add(listViewConsumo);
            groupBoxConsumos.Location = new Point(0, 0);
            groupBoxConsumos.Name = "groupBoxConsumos";
            groupBoxConsumos.Size = new Size(448, 446);
            groupBoxConsumos.TabIndex = 0;
            groupBoxConsumos.TabStop = false;
            groupBoxConsumos.Text = "Consumos";
            groupBoxConsumos.Visible = false;
            // 
            // listViewConsumo
            // 
            listViewConsumo.FullRowSelect = true;
            listViewConsumo.Location = new Point(6, 19);
            listViewConsumo.MultiSelect = false;
            listViewConsumo.Name = "listViewConsumo";
            listViewConsumo.Size = new Size(436, 421);
            listViewConsumo.TabIndex = 1;
            listViewConsumo.UseCompatibleStateImageBehavior = false;
            // 
            // FormMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "FormMenuPrincipal";
            Text = "FormMenuPrincipal";
            Load += FormMenuPrincipal_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBoxAlmacen.ResumeLayout(false);
            groupBoxAlmacen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGAProducto).EndInit();
            groupBoxUsuarios.ResumeLayout(false);
            groupBoxUsuarios.PerformLayout();
            groupBoxReservas.ResumeLayout(false);
            groupBoxConsumos.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private SplitContainer splitContainer1;
        private GroupBox groupBoxReservas;
        private Button btnReservas;
        private Button btnConsumos;
        private GroupBox groupBoxConsumos;
        private Button btnAlmacen;
        private GroupBox groupBoxAlmacen;
        private Button btnUsuarios;
        private GroupBox groupBoxUsuarios;
        private Button btnGUEliminar;
        private Button btnGUAddModify;
        private CheckBox checkBoxGUAdmin;
        private TextBox textBoxGUPass;
        private TextBox textBoxGUNombre;
        private ListView listViewGUUsuarios;
        private ListView listViewReservas;
        private ListView listViewConsumo;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private TextBox textBoxGAProducto;
        private TextBox textBoxGACantidad;
        private TextBox textBoxGAPrecio;
        private TextBox textBoxGACategoria;
        private Button btnGAAddModify;
        private Button btnGAEliminar;
        private ListView listViewGAAlmacen;
        private Button btnGABuscarIMG;
        private Button btnGASubirLocal;
        private PictureBox pictureBoxGAProducto;
    }
}