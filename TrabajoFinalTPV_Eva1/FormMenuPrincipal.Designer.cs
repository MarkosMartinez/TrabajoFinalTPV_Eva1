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
            groupBoxUsuarios = new GroupBox();
            textBoxGUNombre = new TextBox();
            textBoxGUPass = new TextBox();
            checkBoxGUAdmin = new CheckBox();
            btnGUAddModify = new Button();
            btnGUEliminar = new Button();
            listViewUsuarios = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            groupBoxReservas = new GroupBox();
            listViewReservas = new ListView();
            groupBoxConsumos = new GroupBox();
            listViewConsumo = new ListView();
            groupBoxAlmacen = new GroupBox();
            listViewAlmacen = new ListView();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBoxUsuarios.SuspendLayout();
            groupBoxReservas.SuspendLayout();
            groupBoxConsumos.SuspendLayout();
            groupBoxAlmacen.SuspendLayout();
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
            splitContainer1.Panel2.Controls.Add(groupBoxUsuarios);
            splitContainer1.Panel2.Controls.Add(groupBoxReservas);
            splitContainer1.Panel2.Controls.Add(groupBoxConsumos);
            splitContainer1.Panel2.Controls.Add(groupBoxAlmacen);
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
            // groupBoxUsuarios
            // 
            groupBoxUsuarios.Controls.Add(textBoxGUNombre);
            groupBoxUsuarios.Controls.Add(textBoxGUPass);
            groupBoxUsuarios.Controls.Add(checkBoxGUAdmin);
            groupBoxUsuarios.Controls.Add(btnGUAddModify);
            groupBoxUsuarios.Controls.Add(btnGUEliminar);
            groupBoxUsuarios.Controls.Add(listViewUsuarios);
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
            // listViewUsuarios
            // 
            listViewUsuarios.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            listViewUsuarios.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listViewUsuarios.FullRowSelect = true;
            listViewUsuarios.Location = new Point(6, 19);
            listViewUsuarios.MultiSelect = false;
            listViewUsuarios.Name = "listViewUsuarios";
            listViewUsuarios.Size = new Size(437, 421);
            listViewUsuarios.TabIndex = 0;
            listViewUsuarios.UseCompatibleStateImageBehavior = false;
            listViewUsuarios.SelectedIndexChanged += listViewUsuarios_SelectedIndexChanged;
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
            // groupBoxAlmacen
            // 
            groupBoxAlmacen.Controls.Add(listViewAlmacen);
            groupBoxAlmacen.Location = new Point(0, 0);
            groupBoxAlmacen.Name = "groupBoxAlmacen";
            groupBoxAlmacen.Size = new Size(448, 446);
            groupBoxAlmacen.TabIndex = 0;
            groupBoxAlmacen.TabStop = false;
            groupBoxAlmacen.Text = "Almacen";
            groupBoxAlmacen.Visible = false;
            // 
            // listViewAlmacen
            // 
            listViewAlmacen.FullRowSelect = true;
            listViewAlmacen.Location = new Point(6, 19);
            listViewAlmacen.MultiSelect = false;
            listViewAlmacen.Name = "listViewAlmacen";
            listViewAlmacen.Size = new Size(436, 421);
            listViewAlmacen.TabIndex = 1;
            listViewAlmacen.UseCompatibleStateImageBehavior = false;
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
            groupBoxUsuarios.ResumeLayout(false);
            groupBoxUsuarios.PerformLayout();
            groupBoxReservas.ResumeLayout(false);
            groupBoxConsumos.ResumeLayout(false);
            groupBoxAlmacen.ResumeLayout(false);
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
        private ListView listViewUsuarios;
        private ListView listViewAlmacen;
        private ListView listViewReservas;
        private ListView listViewConsumo;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
    }
}