namespace FOSSA_DamasGame
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Conectar_Button = new System.Windows.Forms.Button();
            this.Desconectar_Button = new System.Windows.Forms.Button();
            this.Aceptar_Button = new System.Windows.Forms.Button();
            this.Denegar_Button = new System.Windows.Forms.Button();
            this.UsuarioBox = new System.Windows.Forms.TextBox();
            this.contraseña = new System.Windows.Forms.TextBox();
            this.Usuario = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Registrar_Button = new System.Windows.Forms.Button();
            this.Iniciar_Button = new System.Windows.Forms.Button();
            this.Conectados = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.oPCIONESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resultadosDeMisPartidasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarPartidaPorFechaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ForzarAperturaForm = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Estadolbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Conectados)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Conectar_Button
            // 
            this.Conectar_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Conectar_Button.Location = new System.Drawing.Point(48, 19);
            this.Conectar_Button.Name = "Conectar_Button";
            this.Conectar_Button.Size = new System.Drawing.Size(99, 27);
            this.Conectar_Button.TabIndex = 0;
            this.Conectar_Button.Text = "CONECTAR";
            this.Conectar_Button.UseVisualStyleBackColor = false;
            this.Conectar_Button.Click += new System.EventHandler(this.Conectar_Button_Click);
            // 
            // Desconectar_Button
            // 
            this.Desconectar_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.Desconectar_Button.Location = new System.Drawing.Point(707, 404);
            this.Desconectar_Button.Name = "Desconectar_Button";
            this.Desconectar_Button.Size = new System.Drawing.Size(99, 30);
            this.Desconectar_Button.TabIndex = 1;
            this.Desconectar_Button.Text = "DESCONECTAR";
            this.Desconectar_Button.UseVisualStyleBackColor = false;
            this.Desconectar_Button.Click += new System.EventHandler(this.Desconectar_Button_Click);
            // 
            // Aceptar_Button
            // 
            this.Aceptar_Button.BackColor = System.Drawing.Color.LightGreen;
            this.Aceptar_Button.Location = new System.Drawing.Point(387, 321);
            this.Aceptar_Button.Name = "Aceptar_Button";
            this.Aceptar_Button.Size = new System.Drawing.Size(82, 41);
            this.Aceptar_Button.TabIndex = 2;
            this.Aceptar_Button.Text = "Aceptar Invitación";
            this.Aceptar_Button.UseVisualStyleBackColor = false;
            this.Aceptar_Button.Click += new System.EventHandler(this.Aceptar_Button_Click);
            // 
            // Denegar_Button
            // 
            this.Denegar_Button.BackColor = System.Drawing.Color.LightCoral;
            this.Denegar_Button.Location = new System.Drawing.Point(489, 321);
            this.Denegar_Button.Name = "Denegar_Button";
            this.Denegar_Button.Size = new System.Drawing.Size(82, 41);
            this.Denegar_Button.TabIndex = 3;
            this.Denegar_Button.Text = "Denegar Invitación";
            this.Denegar_Button.UseVisualStyleBackColor = false;
            this.Denegar_Button.Click += new System.EventHandler(this.Denegar_Button_Click);
            // 
            // UsuarioBox
            // 
            this.UsuarioBox.Location = new System.Drawing.Point(71, 16);
            this.UsuarioBox.Name = "UsuarioBox";
            this.UsuarioBox.Size = new System.Drawing.Size(100, 20);
            this.UsuarioBox.TabIndex = 4;
            // 
            // contraseña
            // 
            this.contraseña.Location = new System.Drawing.Point(71, 63);
            this.contraseña.Name = "contraseña";
            this.contraseña.Size = new System.Drawing.Size(100, 20);
            this.contraseña.TabIndex = 5;
            // 
            // Usuario
            // 
            this.Usuario.AutoSize = true;
            this.Usuario.Location = new System.Drawing.Point(9, 23);
            this.Usuario.Name = "Usuario";
            this.Usuario.Size = new System.Drawing.Size(43, 13);
            this.Usuario.TabIndex = 6;
            this.Usuario.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Contraseña";
            // 
            // Registrar_Button
            // 
            this.Registrar_Button.Location = new System.Drawing.Point(27, 109);
            this.Registrar_Button.Name = "Registrar_Button";
            this.Registrar_Button.Size = new System.Drawing.Size(79, 38);
            this.Registrar_Button.TabIndex = 8;
            this.Registrar_Button.Text = "REGISTRAR";
            this.Registrar_Button.UseVisualStyleBackColor = true;
            this.Registrar_Button.Click += new System.EventHandler(this.Registrar_Button_Click);
            // 
            // Iniciar_Button
            // 
            this.Iniciar_Button.Location = new System.Drawing.Point(112, 109);
            this.Iniciar_Button.Name = "Iniciar_Button";
            this.Iniciar_Button.Size = new System.Drawing.Size(77, 38);
            this.Iniciar_Button.TabIndex = 9;
            this.Iniciar_Button.Text = "INICIAR SESIÓN";
            this.Iniciar_Button.UseVisualStyleBackColor = true;
            this.Iniciar_Button.Click += new System.EventHandler(this.Iniciar_Button_Click);
            // 
            // Conectados
            // 
            this.Conectados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Conectados.Location = new System.Drawing.Point(401, 153);
            this.Conectados.Name = "Conectados";
            this.Conectados.Size = new System.Drawing.Size(150, 162);
            this.Conectados.TabIndex = 10;
            this.Conectados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Conectados_CellContentClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oPCIONESToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(842, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // oPCIONESToolStripMenuItem
            // 
            this.oPCIONESToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eliminarUsuarioToolStripMenuItem,
            this.consultasToolStripMenuItem,
            this.resultadosDeMisPartidasToolStripMenuItem,
            this.consultarPartidaPorFechaToolStripMenuItem});
            this.oPCIONESToolStripMenuItem.Name = "oPCIONESToolStripMenuItem";
            this.oPCIONESToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.oPCIONESToolStripMenuItem.Text = "OPCIONES";
            // 
            // eliminarUsuarioToolStripMenuItem
            // 
            this.eliminarUsuarioToolStripMenuItem.Name = "eliminarUsuarioToolStripMenuItem";
            this.eliminarUsuarioToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.eliminarUsuarioToolStripMenuItem.Text = "Eliminar Usuario";
            this.eliminarUsuarioToolStripMenuItem.Click += new System.EventHandler(this.eliminarUsuarioToolStripMenuItem_Click);
            // 
            // consultasToolStripMenuItem
            // 
            this.consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            this.consultasToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.consultasToolStripMenuItem.Text = "Con quién he jugado?";
            this.consultasToolStripMenuItem.Click += new System.EventHandler(this.consultasToolStripMenuItem_Click);
            // 
            // resultadosDeMisPartidasToolStripMenuItem
            // 
            this.resultadosDeMisPartidasToolStripMenuItem.Name = "resultadosDeMisPartidasToolStripMenuItem";
            this.resultadosDeMisPartidasToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.resultadosDeMisPartidasToolStripMenuItem.Text = "Resultados de mis partidas";
            this.resultadosDeMisPartidasToolStripMenuItem.Click += new System.EventHandler(this.resultadosDeMisPartidasToolStripMenuItem_Click);
            // 
            // consultarPartidaPorFechaToolStripMenuItem
            // 
            this.consultarPartidaPorFechaToolStripMenuItem.Name = "consultarPartidaPorFechaToolStripMenuItem";
            this.consultarPartidaPorFechaToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.consultarPartidaPorFechaToolStripMenuItem.Text = "Consultar Partida Por Fecha";
            this.consultarPartidaPorFechaToolStripMenuItem.Click += new System.EventHandler(this.consultarPartidaPorFechaToolStripMenuItem_Click);
            // 
            // ForzarAperturaForm
            // 
            this.ForzarAperturaForm.Location = new System.Drawing.Point(33, 362);
            this.ForzarAperturaForm.Name = "ForzarAperturaForm";
            this.ForzarAperturaForm.Size = new System.Drawing.Size(46, 34);
            this.ForzarAperturaForm.TabIndex = 15;
            this.ForzarAperturaForm.Text = "FORZAR FORM BLANCAS";
            this.ForzarAperturaForm.UseVisualStyleBackColor = true;
            this.ForzarAperturaForm.Click += new System.EventHandler(this.ForzarAperturaForm_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.UsuarioBox);
            this.groupBox1.Controls.Add(this.contraseña);
            this.groupBox1.Controls.Add(this.Usuario);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Registrar_Button);
            this.groupBox1.Controls.Add(this.Iniciar_Button);
            this.groupBox1.Location = new System.Drawing.Point(141, 153);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(195, 164);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registrar/IniciarSesión";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox2.Controls.Add(this.Estadolbl);
            this.groupBox2.Controls.Add(this.Conectar_Button);
            this.groupBox2.Location = new System.Drawing.Point(606, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "INFO";
            // 
            // Estadolbl
            // 
            this.Estadolbl.AutoSize = true;
            this.Estadolbl.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Estadolbl.Location = new System.Drawing.Point(70, 71);
            this.Estadolbl.Name = "Estadolbl";
            this.Estadolbl.Size = new System.Drawing.Size(52, 15);
            this.Estadolbl.TabIndex = 15;
            this.Estadolbl.Text = "label1";
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 470);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ForzarAperturaForm);
            this.Controls.Add(this.Conectados);
            this.Controls.Add(this.Denegar_Button);
            this.Controls.Add(this.Aceptar_Button);
            this.Controls.Add(this.Desconectar_Button);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormPrincipal";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Conectados)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Conectar_Button;
        private System.Windows.Forms.Button Desconectar_Button;
        private System.Windows.Forms.Button Aceptar_Button;
        private System.Windows.Forms.Button Denegar_Button;
        private System.Windows.Forms.TextBox UsuarioBox;
        private System.Windows.Forms.TextBox contraseña;
        private System.Windows.Forms.Label Usuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Registrar_Button;
        private System.Windows.Forms.Button Iniciar_Button;
        private System.Windows.Forms.DataGridView Conectados;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem oPCIONESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarUsuarioToolStripMenuItem;
        private System.Windows.Forms.Button ForzarAperturaForm;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resultadosDeMisPartidasToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label Estadolbl;
        private System.Windows.Forms.ToolStripMenuItem consultarPartidaPorFechaToolStripMenuItem;
    }
}

