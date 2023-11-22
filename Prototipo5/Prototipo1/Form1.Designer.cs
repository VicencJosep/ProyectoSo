namespace Prototipo1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.Desconectar_Button = new System.Windows.Forms.Button();
            this.Conectar_Button = new System.Windows.Forms.Button();
            this.Registrar_Buttton = new System.Windows.Forms.Button();
            this.usuario = new System.Windows.Forms.TextBox();
            this.Contraeña = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.contraseña = new System.Windows.Forms.TextBox();
            this.IniciarSesion_Button = new System.Windows.Forms.Button();
            this.QueryID = new System.Windows.Forms.RadioButton();
            this.QueryDificultad = new System.Windows.Forms.RadioButton();
            this.QueryKills = new System.Windows.Forms.RadioButton();
            this.Enviar = new System.Windows.Forms.Button();
            this.BoxID = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ConectadosGrid = new System.Windows.Forms.DataGridView();
            this.Conectados_Button = new System.Windows.Forms.Button();
            this.Timer_Conectados = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BoxNom1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BoxNom2 = new System.Windows.Forms.TextBox();
            this.BoxFecha = new System.Windows.Forms.TextBox();
            this.BoxDificultad = new System.Windows.Forms.TextBox();
            this.Contlbl = new System.Windows.Forms.Label();
            this.QUERIES = new System.Windows.Forms.GroupBox();
            this.Invitar_Button = new System.Windows.Forms.Button();
            this.EnviarInvitación_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ConectadosGrid)).BeginInit();
            this.QUERIES.SuspendLayout();
            this.SuspendLayout();
            // 
            // Desconectar_Button
            // 
            this.Desconectar_Button.Location = new System.Drawing.Point(982, 482);
            this.Desconectar_Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Desconectar_Button.Name = "Desconectar_Button";
            this.Desconectar_Button.Size = new System.Drawing.Size(137, 33);
            this.Desconectar_Button.TabIndex = 1;
            this.Desconectar_Button.Text = "DESCONECTAR";
            this.Desconectar_Button.UseVisualStyleBackColor = true;
            this.Desconectar_Button.Click += new System.EventHandler(this.Desconectar_Button_Click);
            // 
            // Conectar_Button
            // 
            this.Conectar_Button.Location = new System.Drawing.Point(15, 23);
            this.Conectar_Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Conectar_Button.Name = "Conectar_Button";
            this.Conectar_Button.Size = new System.Drawing.Size(115, 42);
            this.Conectar_Button.TabIndex = 2;
            this.Conectar_Button.Text = "CONECTAR";
            this.Conectar_Button.UseVisualStyleBackColor = true;
            this.Conectar_Button.Click += new System.EventHandler(this.Conectar_Button_Click);
            // 
            // Registrar_Buttton
            // 
            this.Registrar_Buttton.Location = new System.Drawing.Point(42, 161);
            this.Registrar_Buttton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Registrar_Buttton.Name = "Registrar_Buttton";
            this.Registrar_Buttton.Size = new System.Drawing.Size(115, 34);
            this.Registrar_Buttton.TabIndex = 3;
            this.Registrar_Buttton.Text = "REGISTRAR";
            this.Registrar_Buttton.UseVisualStyleBackColor = true;
            this.Registrar_Buttton.Click += new System.EventHandler(this.Registrar_Buttton_Click);
            // 
            // usuario
            // 
            this.usuario.Location = new System.Drawing.Point(156, 87);
            this.usuario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(100, 22);
            this.usuario.TabIndex = 4;
            // 
            // Contraeña
            // 
            this.Contraeña.AutoSize = true;
            this.Contraeña.Location = new System.Drawing.Point(38, 119);
            this.Contraeña.Name = "Contraeña";
            this.Contraeña.Size = new System.Drawing.Size(76, 16);
            this.Contraeña.TabIndex = 5;
            this.Contraeña.Text = "Contraseña";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Usuario";
            // 
            // contraseña
            // 
            this.contraseña.Location = new System.Drawing.Point(156, 119);
            this.contraseña.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.contraseña.Name = "contraseña";
            this.contraseña.Size = new System.Drawing.Size(100, 22);
            this.contraseña.TabIndex = 7;
            // 
            // IniciarSesion_Button
            // 
            this.IniciarSesion_Button.Location = new System.Drawing.Point(190, 161);
            this.IniciarSesion_Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.IniciarSesion_Button.Name = "IniciarSesion_Button";
            this.IniciarSesion_Button.Size = new System.Drawing.Size(100, 50);
            this.IniciarSesion_Button.TabIndex = 9;
            this.IniciarSesion_Button.Text = "INICAR SESION";
            this.IniciarSesion_Button.UseVisualStyleBackColor = true;
            this.IniciarSesion_Button.Click += new System.EventHandler(this.IniciarSesion_Button_Click);
            // 
            // QueryID
            // 
            this.QueryID.AutoSize = true;
            this.QueryID.Location = new System.Drawing.Point(15, 37);
            this.QueryID.Margin = new System.Windows.Forms.Padding(4);
            this.QueryID.Name = "QueryID";
            this.QueryID.Size = new System.Drawing.Size(264, 20);
            this.QueryID.TabIndex = 11;
            this.QueryID.TabStop = true;
            this.QueryID.Text = "Consulta el ID de la partida con entorno:";
            this.QueryID.UseVisualStyleBackColor = true;
            // 
            // QueryDificultad
            // 
            this.QueryDificultad.AutoSize = true;
            this.QueryDificultad.Location = new System.Drawing.Point(15, 63);
            this.QueryDificultad.Margin = new System.Windows.Forms.Padding(4);
            this.QueryDificultad.Name = "QueryDificultad";
            this.QueryDificultad.Size = new System.Drawing.Size(256, 20);
            this.QueryDificultad.TabIndex = 12;
            this.QueryDificultad.TabStop = true;
            this.QueryDificultad.Text = "Consulta la dificultad de la partida con:";
            this.QueryDificultad.UseVisualStyleBackColor = true;
            this.QueryDificultad.CheckedChanged += new System.EventHandler(this.nombres_CheckedChanged);
            // 
            // QueryKills
            // 
            this.QueryKills.AutoSize = true;
            this.QueryKills.Location = new System.Drawing.Point(16, 208);
            this.QueryKills.Margin = new System.Windows.Forms.Padding(4);
            this.QueryKills.Name = "QueryKills";
            this.QueryKills.Size = new System.Drawing.Size(289, 20);
            this.QueryKills.TabIndex = 13;
            this.QueryKills.TabStop = true;
            this.QueryKills.Text = "Consulta las kills de la partida con dificultad:";
            this.QueryKills.UseVisualStyleBackColor = true;
            this.QueryKills.CheckedChanged += new System.EventHandler(this.Dificultad_CheckedChanged);
            // 
            // Enviar
            // 
            this.Enviar.Location = new System.Drawing.Point(123, 263);
            this.Enviar.Margin = new System.Windows.Forms.Padding(4);
            this.Enviar.Name = "Enviar";
            this.Enviar.Size = new System.Drawing.Size(140, 28);
            this.Enviar.TabIndex = 14;
            this.Enviar.Text = "ENVIAR";
            this.Enviar.UseVisualStyleBackColor = true;
            this.Enviar.Click += new System.EventHandler(this.Enviar_Click);
            // 
            // BoxID
            // 
            this.BoxID.Location = new System.Drawing.Point(311, 37);
            this.BoxID.Margin = new System.Windows.Forms.Padding(4);
            this.BoxID.Name = "BoxID";
            this.BoxID.Size = new System.Drawing.Size(132, 22);
            this.BoxID.TabIndex = 15;
            this.BoxID.TextChanged += new System.EventHandler(this.BoxID_TextChanged);
            // 
            // ConectadosGrid
            // 
            this.ConectadosGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ConectadosGrid.Location = new System.Drawing.Point(696, 68);
            this.ConectadosGrid.Margin = new System.Windows.Forms.Padding(4);
            this.ConectadosGrid.Name = "ConectadosGrid";
            this.ConectadosGrid.RowHeadersWidth = 51;
            this.ConectadosGrid.Size = new System.Drawing.Size(241, 376);
            this.ConectadosGrid.TabIndex = 16;
            this.ConectadosGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ConectadosGrid_CellContentClick);
            // 
            // Conectados_Button
            // 
            this.Conectados_Button.Location = new System.Drawing.Point(771, 452);
            this.Conectados_Button.Margin = new System.Windows.Forms.Padding(4);
            this.Conectados_Button.Name = "Conectados_Button";
            this.Conectados_Button.Size = new System.Drawing.Size(133, 31);
            this.Conectados_Button.TabIndex = 17;
            this.Conectados_Button.Text = "Refrescar Conectados";
            this.Conectados_Button.UseVisualStyleBackColor = true;
            this.Conectados_Button.Click += new System.EventHandler(this.Conectados_Button_Click);
            // 
            // Timer_Conectados
            // 
            this.Timer_Conectados.Tick += new System.EventHandler(this.Timer_Conectados_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 227);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "QUERIES";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "Nombre Jugador1 =";
            // 
            // BoxNom1
            // 
            this.BoxNom1.Location = new System.Drawing.Point(149, 98);
            this.BoxNom1.Margin = new System.Windows.Forms.Padding(4);
            this.BoxNom1.Name = "BoxNom1";
            this.BoxNom1.Size = new System.Drawing.Size(132, 22);
            this.BoxNom1.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 16);
            this.label4.TabIndex = 21;
            this.label4.Text = "Nombre Jugador2 =";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = " Fecha =";
            // 
            // BoxNom2
            // 
            this.BoxNom2.Location = new System.Drawing.Point(149, 128);
            this.BoxNom2.Margin = new System.Windows.Forms.Padding(4);
            this.BoxNom2.Name = "BoxNom2";
            this.BoxNom2.Size = new System.Drawing.Size(132, 22);
            this.BoxNom2.TabIndex = 23;
            // 
            // BoxFecha
            // 
            this.BoxFecha.Location = new System.Drawing.Point(149, 158);
            this.BoxFecha.Margin = new System.Windows.Forms.Padding(4);
            this.BoxFecha.Name = "BoxFecha";
            this.BoxFecha.Size = new System.Drawing.Size(132, 22);
            this.BoxFecha.TabIndex = 24;
            this.BoxFecha.TextChanged += new System.EventHandler(this.BoxFecha_TextChanged);
            // 
            // BoxDificultad
            // 
            this.BoxDificultad.Location = new System.Drawing.Point(311, 206);
            this.BoxDificultad.Margin = new System.Windows.Forms.Padding(4);
            this.BoxDificultad.Name = "BoxDificultad";
            this.BoxDificultad.Size = new System.Drawing.Size(132, 22);
            this.BoxDificultad.TabIndex = 25;
            // 
            // Contlbl
            // 
            this.Contlbl.AutoSize = true;
            this.Contlbl.Location = new System.Drawing.Point(317, 269);
            this.Contlbl.Name = "Contlbl";
            this.Contlbl.Size = new System.Drawing.Size(151, 16);
            this.Contlbl.TabIndex = 26;
            this.Contlbl.Text = "Operaciones realizadas";
            this.Contlbl.Click += new System.EventHandler(this.Contlbl_Click);
            // 
            // QUERIES
            // 
            this.QUERIES.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.QUERIES.Controls.Add(this.BoxDificultad);
            this.QUERIES.Controls.Add(this.Contlbl);
            this.QUERIES.Controls.Add(this.label3);
            this.QUERIES.Controls.Add(this.label4);
            this.QUERIES.Controls.Add(this.label5);
            this.QUERIES.Controls.Add(this.BoxFecha);
            this.QUERIES.Controls.Add(this.Enviar);
            this.QUERIES.Controls.Add(this.QueryKills);
            this.QUERIES.Controls.Add(this.BoxNom2);
            this.QUERIES.Controls.Add(this.QueryID);
            this.QUERIES.Controls.Add(this.QueryDificultad);
            this.QUERIES.Controls.Add(this.BoxNom1);
            this.QUERIES.Controls.Add(this.BoxID);
            this.QUERIES.Cursor = System.Windows.Forms.Cursors.Hand;
            this.QUERIES.Location = new System.Drawing.Point(26, 216);
            this.QUERIES.Name = "QUERIES";
            this.QUERIES.Size = new System.Drawing.Size(492, 319);
            this.QUERIES.TabIndex = 27;
            this.QUERIES.TabStop = false;
            this.QUERIES.Text = "QUERIES";
            // 
            // Invitar_Button
            // 
            this.Invitar_Button.Location = new System.Drawing.Point(1020, 97);
            this.Invitar_Button.Name = "Invitar_Button";
            this.Invitar_Button.Size = new System.Drawing.Size(77, 44);
            this.Invitar_Button.TabIndex = 28;
            this.Invitar_Button.Text = "Invitar";
            this.Invitar_Button.UseVisualStyleBackColor = true;
            this.Invitar_Button.Click += new System.EventHandler(this.Invitar_Button_Click);
            // 
            // EnviarInvitación_Button
            // 
            this.EnviarInvitación_Button.Location = new System.Drawing.Point(1022, 143);
            this.EnviarInvitación_Button.Name = "EnviarInvitación_Button";
            this.EnviarInvitación_Button.Size = new System.Drawing.Size(75, 52);
            this.EnviarInvitación_Button.TabIndex = 29;
            this.EnviarInvitación_Button.Text = "Enviar Invitación";
            this.EnviarInvitación_Button.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 628);
            this.Controls.Add(this.EnviarInvitación_Button);
            this.Controls.Add(this.Invitar_Button);
            this.Controls.Add(this.QUERIES);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Conectados_Button);
            this.Controls.Add(this.ConectadosGrid);
            this.Controls.Add(this.IniciarSesion_Button);
            this.Controls.Add(this.contraseña);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Contraeña);
            this.Controls.Add(this.usuario);
            this.Controls.Add(this.Registrar_Buttton);
            this.Controls.Add(this.Conectar_Button);
            this.Controls.Add(this.Desconectar_Button);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ConectadosGrid)).EndInit();
            this.QUERIES.ResumeLayout(false);
            this.QUERIES.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Desconectar_Button;
        private System.Windows.Forms.Button Conectar_Button;
        private System.Windows.Forms.Button Registrar_Buttton;
        private System.Windows.Forms.TextBox usuario;
        private System.Windows.Forms.Label Contraeña;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox contraseña;
        private System.Windows.Forms.Button IniciarSesion_Button;
        private System.Windows.Forms.RadioButton QueryID;
        private System.Windows.Forms.RadioButton QueryDificultad;
        private System.Windows.Forms.RadioButton QueryKills;
        private System.Windows.Forms.Button Enviar;
        private System.Windows.Forms.TextBox BoxID;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridView ConectadosGrid;
        private System.Windows.Forms.Button Conectados_Button;
        private System.Windows.Forms.Timer Timer_Conectados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox BoxNom1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox BoxNom2;
        private System.Windows.Forms.TextBox BoxFecha;
        private System.Windows.Forms.TextBox BoxDificultad;
        private System.Windows.Forms.Label Contlbl;
        private System.Windows.Forms.GroupBox QUERIES;
        private System.Windows.Forms.Button Invitar_Button;
        private System.Windows.Forms.Button EnviarInvitación_Button;
    }
}

