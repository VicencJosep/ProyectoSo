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
            this.Queries_Button = new System.Windows.Forms.Button();
            this.Entorno = new System.Windows.Forms.RadioButton();
            this.nombres = new System.Windows.Forms.RadioButton();
            this.Dificultad = new System.Windows.Forms.RadioButton();
            this.Enviar = new System.Windows.Forms.Button();
            this.QueriesText = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ConectadosGrid = new System.Windows.Forms.DataGridView();
            this.Conectados_Button = new System.Windows.Forms.Button();
            this.Timer_Conectados = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ConectadosGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // Desconectar_Button
            // 
            this.Desconectar_Button.Location = new System.Drawing.Point(15, 404);
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
            this.Conectar_Button.Size = new System.Drawing.Size(115, 74);
            this.Conectar_Button.TabIndex = 2;
            this.Conectar_Button.Text = "CONECTAR";
            this.Conectar_Button.UseVisualStyleBackColor = true;
            this.Conectar_Button.Click += new System.EventHandler(this.Conectar_Button_Click);
            // 
            // Registrar_Buttton
            // 
            this.Registrar_Buttton.Location = new System.Drawing.Point(67, 311);
            this.Registrar_Buttton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Registrar_Buttton.Name = "Registrar_Buttton";
            this.Registrar_Buttton.Size = new System.Drawing.Size(100, 50);
            this.Registrar_Buttton.TabIndex = 3;
            this.Registrar_Buttton.Text = "REGISTRAR";
            this.Registrar_Buttton.UseVisualStyleBackColor = true;
            this.Registrar_Buttton.Click += new System.EventHandler(this.Registrar_Buttton_Click);
            // 
            // usuario
            // 
            this.usuario.Location = new System.Drawing.Point(145, 194);
            this.usuario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(100, 22);
            this.usuario.TabIndex = 4;
            // 
            // Contraeña
            // 
            this.Contraeña.AutoSize = true;
            this.Contraeña.Location = new System.Drawing.Point(51, 258);
            this.Contraeña.Name = "Contraeña";
            this.Contraeña.Size = new System.Drawing.Size(76, 16);
            this.Contraeña.TabIndex = 5;
            this.Contraeña.Text = "Contraseña";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Usuario";
            // 
            // contraseña
            // 
            this.contraseña.Location = new System.Drawing.Point(145, 258);
            this.contraseña.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.contraseña.Name = "contraseña";
            this.contraseña.Size = new System.Drawing.Size(100, 22);
            this.contraseña.TabIndex = 7;
            // 
            // IniciarSesion_Button
            // 
            this.IniciarSesion_Button.Location = new System.Drawing.Point(203, 311);
            this.IniciarSesion_Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.IniciarSesion_Button.Name = "IniciarSesion_Button";
            this.IniciarSesion_Button.Size = new System.Drawing.Size(100, 50);
            this.IniciarSesion_Button.TabIndex = 9;
            this.IniciarSesion_Button.Text = "INICAR SESION";
            this.IniciarSesion_Button.UseVisualStyleBackColor = true;
            this.IniciarSesion_Button.Click += new System.EventHandler(this.IniciarSesion_Button_Click);
            // 
            // Queries_Button
            // 
            this.Queries_Button.Location = new System.Drawing.Point(771, 23);
            this.Queries_Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Queries_Button.Name = "Queries_Button";
            this.Queries_Button.Size = new System.Drawing.Size(15, 23);
            this.Queries_Button.TabIndex = 10;
            this.Queries_Button.Text = "Queries";
            this.Queries_Button.UseVisualStyleBackColor = true;
            this.Queries_Button.Click += new System.EventHandler(this.Queries_Button_Click);
            // 
            // Entorno
            // 
            this.Entorno.AutoSize = true;
            this.Entorno.Location = new System.Drawing.Point(531, 119);
            this.Entorno.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Entorno.Name = "Entorno";
            this.Entorno.Size = new System.Drawing.Size(126, 20);
            this.Entorno.TabIndex = 11;
            this.Entorno.TabStop = true;
            this.Entorno.Text = "Entorno(query 1)";
            this.Entorno.UseVisualStyleBackColor = true;
            // 
            // nombres
            // 
            this.nombres.AutoSize = true;
            this.nombres.Location = new System.Drawing.Point(531, 148);
            this.nombres.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nombres.Name = "nombres";
            this.nombres.Size = new System.Drawing.Size(135, 20);
            this.nombres.TabIndex = 12;
            this.nombres.TabStop = true;
            this.nombres.Text = "Nombres y Fecha";
            this.nombres.UseVisualStyleBackColor = true;
            this.nombres.CheckedChanged += new System.EventHandler(this.nombres_CheckedChanged);
            // 
            // Dificultad
            // 
            this.Dificultad.AutoSize = true;
            this.Dificultad.Location = new System.Drawing.Point(531, 176);
            this.Dificultad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Dificultad.Name = "Dificultad";
            this.Dificultad.Size = new System.Drawing.Size(83, 20);
            this.Dificultad.TabIndex = 13;
            this.Dificultad.TabStop = true;
            this.Dificultad.Text = "Dificultad";
            this.Dificultad.UseVisualStyleBackColor = true;
            this.Dificultad.CheckedChanged += new System.EventHandler(this.Dificultad_CheckedChanged);
            // 
            // Enviar
            // 
            this.Enviar.Location = new System.Drawing.Point(535, 204);
            this.Enviar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Enviar.Name = "Enviar";
            this.Enviar.Size = new System.Drawing.Size(140, 28);
            this.Enviar.TabIndex = 14;
            this.Enviar.Text = "ENVIAR";
            this.Enviar.UseVisualStyleBackColor = true;
            this.Enviar.Click += new System.EventHandler(this.Enviar_Click);
            // 
            // QueriesText
            // 
            this.QueriesText.Location = new System.Drawing.Point(535, 87);
            this.QueriesText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.QueriesText.Name = "QueriesText";
            this.QueriesText.Size = new System.Drawing.Size(132, 22);
            this.QueriesText.TabIndex = 15;
            // 
            // ConectadosGrid
            // 
            this.ConectadosGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ConectadosGrid.Location = new System.Drawing.Point(499, 267);
            this.ConectadosGrid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ConectadosGrid.Name = "ConectadosGrid";
            this.ConectadosGrid.RowHeadersWidth = 51;
            this.ConectadosGrid.Size = new System.Drawing.Size(224, 130);
            this.ConectadosGrid.TabIndex = 16;
            this.ConectadosGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ConectadosGrid_CellContentClick);
            // 
            // Conectados_Button
            // 
            this.Conectados_Button.Location = new System.Drawing.Point(541, 405);
            this.Conectados_Button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Conectados_Button);
            this.Controls.Add(this.ConectadosGrid);
            this.Controls.Add(this.QueriesText);
            this.Controls.Add(this.Enviar);
            this.Controls.Add(this.Dificultad);
            this.Controls.Add(this.nombres);
            this.Controls.Add(this.Entorno);
            this.Controls.Add(this.Queries_Button);
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
        private System.Windows.Forms.Button Queries_Button;
        private System.Windows.Forms.RadioButton Entorno;
        private System.Windows.Forms.RadioButton nombres;
        private System.Windows.Forms.RadioButton Dificultad;
        private System.Windows.Forms.Button Enviar;
        private System.Windows.Forms.TextBox QueriesText;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridView ConectadosGrid;
        private System.Windows.Forms.Button Conectados_Button;
        private System.Windows.Forms.Timer Timer_Conectados;
    }
}

