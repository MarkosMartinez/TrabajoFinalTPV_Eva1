﻿namespace TrabajoFinalTPV_Eva1
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
            bntExit = new Button();
            btnLogout = new Button();
            btnUsuarios = new Button();
            btnAlmacen = new Button();
            btnPedido = new Button();
            btnReservas = new Button();
            groupBoxReservas = new GroupBox();
            labelReservas = new Label();
            listViewReservas = new ListView();
            btnAddModifyReserva = new Button();
            comboBoxTipoReservas = new ComboBox();
            dateTimePickerReservas = new DateTimePicker();
            btnMesa6 = new Button();
            btnMesa5 = new Button();
            btnMesa4 = new Button();
            btnMesa3 = new Button();
            btnMesa2 = new Button();
            btnMesa1 = new Button();
            pictureBox1 = new PictureBox();
            groupBoxPedido = new GroupBox();
            labelPTotal = new Label();
            textBoxPTotal = new TextBox();
            buttonPEliminarProducto = new Button();
            buttonModPCantidad = new Button();
            textBoxPCantidad = new TextBox();
            pictureBoxPreviewProducto = new PictureBox();
            buttonTicket = new Button();
            listViewProductos = new ListView();
            listViewCategorias = new ListView();
            dataGridViewPedido = new DataGridView();
            groupBoxAlmacen = new GroupBox();
            comboBoxGACategoria = new ComboBox();
            btnGABuscarIMG = new Button();
            btnGASubirLocal = new Button();
            pictureBoxGAProducto = new PictureBox();
            listViewGAAlmacen = new ListView();
            btnGAEliminar = new Button();
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
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBoxReservas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBoxPedido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPreviewProducto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPedido).BeginInit();
            groupBoxAlmacen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGAProducto).BeginInit();
            groupBoxUsuarios.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(2, 1);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(bntExit);
            splitContainer1.Panel1.Controls.Add(btnLogout);
            splitContainer1.Panel1.Controls.Add(btnUsuarios);
            splitContainer1.Panel1.Controls.Add(btnAlmacen);
            splitContainer1.Panel1.Controls.Add(btnPedido);
            splitContainer1.Panel1.Controls.Add(btnReservas);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBoxReservas);
            splitContainer1.Panel2.Controls.Add(groupBoxPedido);
            splitContainer1.Panel2.Controls.Add(groupBoxAlmacen);
            splitContainer1.Panel2.Controls.Add(groupBoxUsuarios);
            splitContainer1.Size = new Size(797, 449);
            splitContainer1.SplitterDistance = 152;
            splitContainer1.TabIndex = 2;
            splitContainer1.SplitterMoved += splitContainer1_SplitterMoved;
            // 
            // bntExit
            // 
            bntExit.BackgroundImage = Properties.Resources.exit;
            bntExit.BackgroundImageLayout = ImageLayout.Zoom;
            bntExit.FlatAppearance.BorderSize = 0;
            bntExit.FlatStyle = FlatStyle.Flat;
            bntExit.Location = new Point(10, 411);
            bntExit.Name = "bntExit";
            bntExit.Size = new Size(40, 30);
            bntExit.TabIndex = 5;
            bntExit.UseVisualStyleBackColor = true;
            bntExit.Click += btnExit_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackgroundImage = Properties.Resources.logout;
            btnLogout.BackgroundImageLayout = ImageLayout.Zoom;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Location = new Point(107, 410);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(40, 30);
            btnLogout.TabIndex = 4;
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnUsuarios
            // 
            btnUsuarios.Location = new Point(10, 140);
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
            btnAlmacen.Location = new Point(10, 97);
            btnAlmacen.Name = "btnAlmacen";
            btnAlmacen.Size = new Size(126, 23);
            btnAlmacen.TabIndex = 2;
            btnAlmacen.Text = "Gestionar Almacen";
            btnAlmacen.UseVisualStyleBackColor = true;
            btnAlmacen.Visible = false;
            btnAlmacen.Click += btnAlmacen_Click;
            // 
            // btnPedido
            // 
            btnPedido.Location = new Point(10, 54);
            btnPedido.Name = "btnPedido";
            btnPedido.Size = new Size(126, 23);
            btnPedido.TabIndex = 1;
            btnPedido.Text = "Gestionar Pedido";
            btnPedido.UseVisualStyleBackColor = true;
            btnPedido.Click += btnPedido_Click;
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
            // groupBoxReservas
            // 
            groupBoxReservas.Controls.Add(labelReservas);
            groupBoxReservas.Controls.Add(listViewReservas);
            groupBoxReservas.Controls.Add(btnAddModifyReserva);
            groupBoxReservas.Controls.Add(comboBoxTipoReservas);
            groupBoxReservas.Controls.Add(dateTimePickerReservas);
            groupBoxReservas.Controls.Add(btnMesa6);
            groupBoxReservas.Controls.Add(btnMesa5);
            groupBoxReservas.Controls.Add(btnMesa4);
            groupBoxReservas.Controls.Add(btnMesa3);
            groupBoxReservas.Controls.Add(btnMesa2);
            groupBoxReservas.Controls.Add(btnMesa1);
            groupBoxReservas.Controls.Add(pictureBox1);
            groupBoxReservas.Location = new Point(0, 0);
            groupBoxReservas.Name = "groupBoxReservas";
            groupBoxReservas.Size = new Size(638, 446);
            groupBoxReservas.TabIndex = 0;
            groupBoxReservas.TabStop = false;
            groupBoxReservas.Text = "Reservas";
            groupBoxReservas.Visible = false;
            // 
            // labelReservas
            // 
            labelReservas.AutoSize = true;
            labelReservas.Location = new Point(466, 199);
            labelReservas.Name = "labelReservas";
            labelReservas.Size = new Size(120, 15);
            labelReservas.TabIndex = 10;
            labelReservas.Text = "Lista de tus Reservas: ";
            // 
            // listViewReservas
            // 
            listViewReservas.Location = new Point(435, 230);
            listViewReservas.Name = "listViewReservas";
            listViewReservas.Size = new Size(200, 210);
            listViewReservas.TabIndex = 9;
            listViewReservas.UseCompatibleStateImageBehavior = false;
            // 
            // btnAddModifyReserva
            // 
            btnAddModifyReserva.Location = new Point(466, 167);
            btnAddModifyReserva.Name = "btnAddModifyReserva";
            btnAddModifyReserva.Size = new Size(100, 23);
            btnAddModifyReserva.TabIndex = 8;
            btnAddModifyReserva.Text = "Modificar Reserva";
            btnAddModifyReserva.UseVisualStyleBackColor = true;
            btnAddModifyReserva.Click += btnAddModifyReserva_Click;
            // 
            // comboBoxTipoReservas
            // 
            comboBoxTipoReservas.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTipoReservas.FormattingEnabled = true;
            comboBoxTipoReservas.Items.AddRange(new object[] { "Desayuno", "Comida", "Cena" });
            comboBoxTipoReservas.Location = new Point(466, 108);
            comboBoxTipoReservas.Name = "comboBoxTipoReservas";
            comboBoxTipoReservas.Size = new Size(100, 23);
            comboBoxTipoReservas.TabIndex = 7;
            comboBoxTipoReservas.SelectedIndexChanged += comboBoxTipoReservas_SelectedIndexChanged;
            // 
            // dateTimePickerReservas
            // 
            dateTimePickerReservas.Format = DateTimePickerFormat.Short;
            dateTimePickerReservas.Location = new Point(466, 50);
            dateTimePickerReservas.Name = "dateTimePickerReservas";
            dateTimePickerReservas.Size = new Size(100, 23);
            dateTimePickerReservas.TabIndex = 6;
            dateTimePickerReservas.Value = new DateTime(2024, 11, 12, 12, 31, 11, 0);
            dateTimePickerReservas.ValueChanged += dateTimePickerReservas_ValueChanged;
            // 
            // btnMesa6
            // 
            btnMesa6.BackColor = Color.FromArgb(180, 139, 107);
            btnMesa6.BackgroundImage = Properties.Resources.mesa_libre;
            btnMesa6.BackgroundImageLayout = ImageLayout.Zoom;
            btnMesa6.FlatAppearance.BorderSize = 0;
            btnMesa6.FlatStyle = FlatStyle.Flat;
            btnMesa6.Location = new Point(202, 309);
            btnMesa6.Name = "btnMesa6";
            btnMesa6.Size = new Size(100, 67);
            btnMesa6.TabIndex = 5;
            btnMesa6.Tag = "";
            btnMesa6.UseVisualStyleBackColor = false;
            btnMesa6.Click += btnMesa_Click;
            // 
            // btnMesa5
            // 
            btnMesa5.BackColor = Color.FromArgb(180, 139, 107);
            btnMesa5.BackgroundImage = Properties.Resources.mesa_libre;
            btnMesa5.BackgroundImageLayout = ImageLayout.Zoom;
            btnMesa5.FlatAppearance.BorderSize = 0;
            btnMesa5.FlatStyle = FlatStyle.Flat;
            btnMesa5.Location = new Point(202, 179);
            btnMesa5.Name = "btnMesa5";
            btnMesa5.Size = new Size(100, 68);
            btnMesa5.TabIndex = 4;
            btnMesa5.Tag = "";
            btnMesa5.UseVisualStyleBackColor = false;
            btnMesa5.Click += btnMesa_Click;
            // 
            // btnMesa4
            // 
            btnMesa4.BackColor = Color.FromArgb(180, 139, 107);
            btnMesa4.BackgroundImage = Properties.Resources.mesa_libre;
            btnMesa4.BackgroundImageLayout = ImageLayout.Zoom;
            btnMesa4.FlatAppearance.BorderSize = 0;
            btnMesa4.FlatStyle = FlatStyle.Flat;
            btnMesa4.Location = new Point(202, 50);
            btnMesa4.Name = "btnMesa4";
            btnMesa4.Size = new Size(100, 68);
            btnMesa4.TabIndex = 3;
            btnMesa4.Tag = "";
            btnMesa4.UseVisualStyleBackColor = false;
            btnMesa4.Click += btnMesa_Click;
            // 
            // btnMesa3
            // 
            btnMesa3.BackColor = Color.FromArgb(180, 139, 107);
            btnMesa3.BackgroundImage = Properties.Resources.mesa_libre;
            btnMesa3.BackgroundImageLayout = ImageLayout.Zoom;
            btnMesa3.FlatAppearance.BorderSize = 0;
            btnMesa3.FlatStyle = FlatStyle.Flat;
            btnMesa3.Location = new Point(46, 310);
            btnMesa3.Name = "btnMesa3";
            btnMesa3.Size = new Size(100, 65);
            btnMesa3.TabIndex = 2;
            btnMesa3.Tag = "";
            btnMesa3.UseVisualStyleBackColor = false;
            btnMesa3.Click += btnMesa_Click;
            // 
            // btnMesa2
            // 
            btnMesa2.BackColor = Color.FromArgb(180, 139, 107);
            btnMesa2.BackgroundImage = Properties.Resources.mesa_libre;
            btnMesa2.BackgroundImageLayout = ImageLayout.Zoom;
            btnMesa2.FlatAppearance.BorderSize = 0;
            btnMesa2.FlatStyle = FlatStyle.Flat;
            btnMesa2.Location = new Point(46, 180);
            btnMesa2.Name = "btnMesa2";
            btnMesa2.Size = new Size(100, 67);
            btnMesa2.TabIndex = 1;
            btnMesa2.Tag = "";
            btnMesa2.UseVisualStyleBackColor = false;
            btnMesa2.Click += btnMesa_Click;
            // 
            // btnMesa1
            // 
            btnMesa1.BackColor = Color.FromArgb(180, 139, 107);
            btnMesa1.BackgroundImage = Properties.Resources.mesa_libre;
            btnMesa1.BackgroundImageLayout = ImageLayout.Zoom;
            btnMesa1.FlatAppearance.BorderSize = 0;
            btnMesa1.FlatStyle = FlatStyle.Flat;
            btnMesa1.Location = new Point(46, 50);
            btnMesa1.Name = "btnMesa1";
            btnMesa1.Size = new Size(100, 67);
            btnMesa1.TabIndex = 0;
            btnMesa1.Tag = "";
            btnMesa1.UseVisualStyleBackColor = false;
            btnMesa1.Click += btnMesa_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(180, 139, 107);
            pictureBox1.Image = Properties.Resources.fondo;
            pictureBox1.Location = new Point(26, 22);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(403, 415);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // groupBoxPedido
            // 
            groupBoxPedido.Controls.Add(labelPTotal);
            groupBoxPedido.Controls.Add(textBoxPTotal);
            groupBoxPedido.Controls.Add(buttonPEliminarProducto);
            groupBoxPedido.Controls.Add(buttonModPCantidad);
            groupBoxPedido.Controls.Add(textBoxPCantidad);
            groupBoxPedido.Controls.Add(pictureBoxPreviewProducto);
            groupBoxPedido.Controls.Add(buttonTicket);
            groupBoxPedido.Controls.Add(listViewProductos);
            groupBoxPedido.Controls.Add(listViewCategorias);
            groupBoxPedido.Controls.Add(dataGridViewPedido);
            groupBoxPedido.Location = new Point(0, 0);
            groupBoxPedido.Name = "groupBoxPedido";
            groupBoxPedido.Size = new Size(638, 446);
            groupBoxPedido.TabIndex = 0;
            groupBoxPedido.TabStop = false;
            groupBoxPedido.Text = "Pedidos";
            groupBoxPedido.Visible = false;
            // 
            // labelPTotal
            // 
            labelPTotal.AutoSize = true;
            labelPTotal.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPTotal.Location = new Point(511, 214);
            labelPTotal.Name = "labelPTotal";
            labelPTotal.Size = new Size(82, 17);
            labelPTotal.TabIndex = 9;
            labelPTotal.Text = "Precio final:";
            // 
            // textBoxPTotal
            // 
            textBoxPTotal.Location = new Point(511, 236);
            textBoxPTotal.Name = "textBoxPTotal";
            textBoxPTotal.ReadOnly = true;
            textBoxPTotal.Size = new Size(114, 23);
            textBoxPTotal.TabIndex = 8;
            // 
            // buttonPEliminarProducto
            // 
            buttonPEliminarProducto.Location = new Point(511, 89);
            buttonPEliminarProducto.Name = "buttonPEliminarProducto";
            buttonPEliminarProducto.Size = new Size(114, 23);
            buttonPEliminarProducto.TabIndex = 7;
            buttonPEliminarProducto.Text = "Eliminar producto";
            buttonPEliminarProducto.UseVisualStyleBackColor = true;
            buttonPEliminarProducto.Visible = false;
            buttonPEliminarProducto.Click += buttonPEliminarProducto_Click;
            // 
            // buttonModPCantidad
            // 
            buttonModPCantidad.Location = new Point(511, 54);
            buttonModPCantidad.Name = "buttonModPCantidad";
            buttonModPCantidad.Size = new Size(114, 23);
            buttonModPCantidad.TabIndex = 6;
            buttonModPCantidad.Text = "Modificar cantidad";
            buttonModPCantidad.UseVisualStyleBackColor = true;
            buttonModPCantidad.Visible = false;
            buttonModPCantidad.Click += buttonModPCantidad_Click;
            // 
            // textBoxPCantidad
            // 
            textBoxPCantidad.Location = new Point(511, 21);
            textBoxPCantidad.Name = "textBoxPCantidad";
            textBoxPCantidad.Size = new Size(114, 23);
            textBoxPCantidad.TabIndex = 5;
            textBoxPCantidad.Visible = false;
            // 
            // pictureBoxPreviewProducto
            // 
            pictureBoxPreviewProducto.Location = new Point(496, 302);
            pictureBoxPreviewProducto.Name = "pictureBoxPreviewProducto";
            pictureBoxPreviewProducto.Size = new Size(145, 147);
            pictureBoxPreviewProducto.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxPreviewProducto.TabIndex = 4;
            pictureBoxPreviewProducto.TabStop = false;
            // 
            // buttonTicket
            // 
            buttonTicket.Enabled = false;
            buttonTicket.Location = new Point(511, 273);
            buttonTicket.Name = "buttonTicket";
            buttonTicket.Size = new Size(112, 23);
            buttonTicket.TabIndex = 3;
            buttonTicket.Text = "Generar Ticket";
            buttonTicket.UseVisualStyleBackColor = true;
            buttonTicket.Click += buttonTicket_Click;
            // 
            // listViewProductos
            // 
            listViewProductos.FullRowSelect = true;
            listViewProductos.Location = new Point(169, 302);
            listViewProductos.MultiSelect = false;
            listViewProductos.Name = "listViewProductos";
            listViewProductos.Size = new Size(233, 144);
            listViewProductos.TabIndex = 2;
            listViewProductos.UseCompatibleStateImageBehavior = false;
            listViewProductos.SelectedIndexChanged += listViewProductos_SelectedIndexChanged;
            listViewProductos.DoubleClick += listViewProductos_DoubleClick;
            // 
            // listViewCategorias
            // 
            listViewCategorias.FullRowSelect = true;
            listViewCategorias.Location = new Point(2, 302);
            listViewCategorias.MultiSelect = false;
            listViewCategorias.Name = "listViewCategorias";
            listViewCategorias.Size = new Size(155, 144);
            listViewCategorias.TabIndex = 1;
            listViewCategorias.UseCompatibleStateImageBehavior = false;
            listViewCategorias.SelectedIndexChanged += listViewCategorias_SelectedIndexChanged;
            // 
            // dataGridViewPedido
            // 
            dataGridViewPedido.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPedido.Location = new Point(2, 15);
            dataGridViewPedido.MultiSelect = false;
            dataGridViewPedido.Name = "dataGridViewPedido";
            dataGridViewPedido.RowTemplate.ReadOnly = true;
            dataGridViewPedido.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPedido.Size = new Size(493, 285);
            dataGridViewPedido.TabIndex = 0;
            dataGridViewPedido.SelectionChanged += dataGridViewPedido_SelectionChanged;
            // 
            // groupBoxAlmacen
            // 
            groupBoxAlmacen.Controls.Add(comboBoxGACategoria);
            groupBoxAlmacen.Controls.Add(btnGABuscarIMG);
            groupBoxAlmacen.Controls.Add(btnGASubirLocal);
            groupBoxAlmacen.Controls.Add(pictureBoxGAProducto);
            groupBoxAlmacen.Controls.Add(listViewGAAlmacen);
            groupBoxAlmacen.Controls.Add(btnGAEliminar);
            groupBoxAlmacen.Controls.Add(btnGAAddModify);
            groupBoxAlmacen.Controls.Add(textBoxGAPrecio);
            groupBoxAlmacen.Controls.Add(textBoxGACantidad);
            groupBoxAlmacen.Controls.Add(textBoxGAProducto);
            groupBoxAlmacen.Location = new Point(0, 0);
            groupBoxAlmacen.Name = "groupBoxAlmacen";
            groupBoxAlmacen.Size = new Size(638, 446);
            groupBoxAlmacen.TabIndex = 0;
            groupBoxAlmacen.TabStop = false;
            groupBoxAlmacen.Text = "Almacen";
            groupBoxAlmacen.Visible = false;
            // 
            // comboBoxGACategoria
            // 
            comboBoxGACategoria.FormattingEnabled = true;
            comboBoxGACategoria.Location = new Point(448, 100);
            comboBoxGACategoria.Name = "comboBoxGACategoria";
            comboBoxGACategoria.Size = new Size(174, 23);
            comboBoxGACategoria.TabIndex = 13;
            comboBoxGACategoria.SelectedIndexChanged += comboBoxGACategoria_SelectedIndexChanged;
            // 
            // btnGABuscarIMG
            // 
            btnGABuscarIMG.BackgroundImage = Properties.Resources.buscar;
            btnGABuscarIMG.BackgroundImageLayout = ImageLayout.Zoom;
            btnGABuscarIMG.FlatAppearance.BorderSize = 0;
            btnGABuscarIMG.FlatStyle = FlatStyle.Flat;
            btnGABuscarIMG.Location = new Point(548, 129);
            btnGABuscarIMG.Name = "btnGABuscarIMG";
            btnGABuscarIMG.Size = new Size(75, 32);
            btnGABuscarIMG.TabIndex = 12;
            btnGABuscarIMG.UseVisualStyleBackColor = true;
            btnGABuscarIMG.Click += btnGABuscarIMG_Click;
            // 
            // btnGASubirLocal
            // 
            btnGASubirLocal.BackgroundImage = Properties.Resources.subir;
            btnGASubirLocal.BackgroundImageLayout = ImageLayout.Zoom;
            btnGASubirLocal.FlatAppearance.BorderSize = 0;
            btnGASubirLocal.FlatStyle = FlatStyle.Flat;
            btnGASubirLocal.Location = new Point(448, 129);
            btnGASubirLocal.Name = "btnGASubirLocal";
            btnGASubirLocal.Size = new Size(75, 32);
            btnGASubirLocal.TabIndex = 11;
            btnGASubirLocal.UseVisualStyleBackColor = true;
            btnGASubirLocal.Click += btnGASubirLocal_Click;
            // 
            // pictureBoxGAProducto
            // 
            pictureBoxGAProducto.Location = new Point(448, 265);
            pictureBoxGAProducto.Name = "pictureBoxGAProducto";
            pictureBoxGAProducto.Size = new Size(175, 172);
            pictureBoxGAProducto.SizeMode = PictureBoxSizeMode.Zoom;
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
            btnGAEliminar.Location = new Point(448, 207);
            btnGAEliminar.Name = "btnGAEliminar";
            btnGAEliminar.Size = new Size(175, 23);
            btnGAEliminar.TabIndex = 8;
            btnGAEliminar.Text = "Eliminar";
            btnGAEliminar.UseVisualStyleBackColor = true;
            btnGAEliminar.Click += btnGAEliminar_Click;
            // 
            // btnGAAddModify
            // 
            btnGAAddModify.Location = new Point(448, 173);
            btnGAAddModify.Name = "btnGAAddModify";
            btnGAAddModify.Size = new Size(175, 23);
            btnGAAddModify.TabIndex = 6;
            btnGAAddModify.Text = "Añadir";
            btnGAAddModify.UseVisualStyleBackColor = true;
            btnGAAddModify.Click += btnGAAddModify_Click;
            // 
            // textBoxGAPrecio
            // 
            textBoxGAPrecio.Location = new Point(548, 60);
            textBoxGAPrecio.Name = "textBoxGAPrecio";
            textBoxGAPrecio.PlaceholderText = "Precio";
            textBoxGAPrecio.Size = new Size(75, 23);
            textBoxGAPrecio.TabIndex = 5;
            // 
            // textBoxGACantidad
            // 
            textBoxGACantidad.Location = new Point(448, 60);
            textBoxGACantidad.Name = "textBoxGACantidad";
            textBoxGACantidad.PlaceholderText = "Cantidad";
            textBoxGACantidad.Size = new Size(75, 23);
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
            groupBoxReservas.ResumeLayout(false);
            groupBoxReservas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBoxPedido.ResumeLayout(false);
            groupBoxPedido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPreviewProducto).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPedido).EndInit();
            groupBoxAlmacen.ResumeLayout(false);
            groupBoxAlmacen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGAProducto).EndInit();
            groupBoxUsuarios.ResumeLayout(false);
            groupBoxUsuarios.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private SplitContainer splitContainer1;
        private GroupBox groupBoxReservas;
        private Button btnReservas;
        private Button btnPedido;
        private GroupBox groupBoxPedido;
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
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private TextBox textBoxGAProducto;
        private TextBox textBoxGACantidad;
        private TextBox textBoxGAPrecio;
        private Button btnGAAddModify;
        private Button btnGAEliminar;
        private ListView listViewGAAlmacen;
        private Button btnGABuscarIMG;
        private Button btnGASubirLocal;
        private PictureBox pictureBoxGAProducto;
        private Button btnLogout;
        private Button btnMesa6;
        private Button btnMesa5;
        private Button btnMesa4;
        private Button btnMesa3;
        private Button btnMesa2;
        private Button btnMesa1;
        private Button btnAddModifyReserva;
        private ComboBox comboBoxTipoReservas;
        private DateTimePicker dateTimePickerReservas;
        private ListView listViewReservas;
        private Label labelReservas;
        private DataGridView dataGridViewPedido;
        private ListView listViewCategorias;
        private ListView listViewProductos;
        private Button buttonTicket;
        private PictureBox pictureBoxPreviewProducto;
        private Button buttonModPCantidad;
        private TextBox textBoxPCantidad;
        private Button buttonPEliminarProducto;
        private Label labelPTotal;
        private TextBox textBoxPTotal;
        private PictureBox pictureBox1;
        private Button bntExit;
        private ComboBox comboBoxGACategoria;
    }
}