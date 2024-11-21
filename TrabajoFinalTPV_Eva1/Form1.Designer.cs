namespace TrabajoFinalTPV_Eva1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            textBoxUser = new TextBox();
            textBoxPass = new TextBox();
            btnLogin = new Button();
            buttonPassEye = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(60, 25);
            label1.Name = "label1";
            label1.Size = new Size(168, 30);
            label1.TabIndex = 0;
            label1.Text = "Inicio de Sesión";
            // 
            // textBoxUser
            // 
            textBoxUser.Location = new Point(62, 67);
            textBoxUser.Name = "textBoxUser";
            textBoxUser.PlaceholderText = "Nombre";
            textBoxUser.Size = new Size(160, 23);
            textBoxUser.TabIndex = 1;
            // 
            // textBoxPass
            // 
            textBoxPass.Location = new Point(62, 112);
            textBoxPass.Name = "textBoxPass";
            textBoxPass.PasswordChar = '*';
            textBoxPass.PlaceholderText = "Contraseña";
            textBoxPass.Size = new Size(160, 23);
            textBoxPass.TabIndex = 2;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(79, 158);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(126, 23);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Iniciar Sesión";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // buttonPassEye
            // 
            buttonPassEye.BackgroundImage = Properties.Resources.eye;
            buttonPassEye.BackgroundImageLayout = ImageLayout.Zoom;
            buttonPassEye.FlatAppearance.BorderSize = 0;
            buttonPassEye.FlatStyle = FlatStyle.Flat;
            buttonPassEye.Location = new Point(228, 107);
            buttonPassEye.Name = "buttonPassEye";
            buttonPassEye.Size = new Size(37, 32);
            buttonPassEye.TabIndex = 4;
            buttonPassEye.UseVisualStyleBackColor = true;
            buttonPassEye.Click += buttonPassEye_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 229);
            Controls.Add(buttonPassEye);
            Controls.Add(btnLogin);
            Controls.Add(textBoxPass);
            Controls.Add(textBoxUser);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxUser;
        private TextBox textBoxPass;
        private Button btnLogin;
        private Button buttonPassEye;
    }
}
