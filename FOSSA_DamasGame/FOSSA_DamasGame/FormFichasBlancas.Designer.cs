namespace FOSSA_DamasGame
{
    partial class FormFichasBlancas
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
            this.Tablero = new System.Windows.Forms.Panel();
            this.chat = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.EnviarChat_Button = new System.Windows.Forms.Button();
            this.MouseMoveLable = new System.Windows.Forms.Label();
            this.MouseMoveLabel2 = new System.Windows.Forms.Label();
            this.Turnolbl = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Tablero
            // 
            this.Tablero.Location = new System.Drawing.Point(12, 28);
            this.Tablero.Name = "Tablero";
            this.Tablero.Size = new System.Drawing.Size(368, 247);
            this.Tablero.TabIndex = 0;
            this.Tablero.Click += new System.EventHandler(this.Tablero_Click);
            this.Tablero.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Tablero_MouseClick);
            this.Tablero.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Tablero_MouseMove);
            // 
            // chat
            // 
            this.chat.FormattingEnabled = true;
            this.chat.Location = new System.Drawing.Point(850, 180);
            this.chat.Name = "chat";
            this.chat.Size = new System.Drawing.Size(147, 121);
            this.chat.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(850, 334);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(67, 20);
            this.textBox1.TabIndex = 2;
            // 
            // EnviarChat_Button
            // 
            this.EnviarChat_Button.Location = new System.Drawing.Point(951, 334);
            this.EnviarChat_Button.Name = "EnviarChat_Button";
            this.EnviarChat_Button.Size = new System.Drawing.Size(83, 34);
            this.EnviarChat_Button.TabIndex = 3;
            this.EnviarChat_Button.Text = "ENVIAR MENSAJJE";
            this.EnviarChat_Button.UseVisualStyleBackColor = true;
            this.EnviarChat_Button.Click += new System.EventHandler(this.EnviarChat_Button_Click);
            // 
            // MouseMoveLable
            // 
            this.MouseMoveLable.AutoSize = true;
            this.MouseMoveLable.Location = new System.Drawing.Point(847, 155);
            this.MouseMoveLable.Name = "MouseMoveLable";
            this.MouseMoveLable.Size = new System.Drawing.Size(35, 13);
            this.MouseMoveLable.TabIndex = 4;
            this.MouseMoveLable.Text = "label1";
            // 
            // MouseMoveLabel2
            // 
            this.MouseMoveLabel2.AutoSize = true;
            this.MouseMoveLabel2.Location = new System.Drawing.Point(909, 155);
            this.MouseMoveLabel2.Name = "MouseMoveLabel2";
            this.MouseMoveLabel2.Size = new System.Drawing.Size(35, 13);
            this.MouseMoveLabel2.TabIndex = 5;
            this.MouseMoveLabel2.Text = "label1";
            // 
            // Turnolbl
            // 
            this.Turnolbl.AutoSize = true;
            this.Turnolbl.Font = new System.Drawing.Font("Showcard Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Turnolbl.Location = new System.Drawing.Point(897, 46);
            this.Turnolbl.MaximumSize = new System.Drawing.Size(100, 100);
            this.Turnolbl.MinimumSize = new System.Drawing.Size(100, 55);
            this.Turnolbl.Name = "Turnolbl";
            this.Turnolbl.Size = new System.Drawing.Size(100, 55);
            this.Turnolbl.TabIndex = 6;
            this.Turnolbl.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(901, 531);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormFichasBlancas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 610);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Turnolbl);
            this.Controls.Add(this.MouseMoveLabel2);
            this.Controls.Add(this.MouseMoveLable);
            this.Controls.Add(this.EnviarChat_Button);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.chat);
            this.Controls.Add(this.Tablero);
            this.Name = "FormFichasBlancas";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormFichasBlancas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Tablero;
        private System.Windows.Forms.ListBox chat;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button EnviarChat_Button;
        private System.Windows.Forms.Label MouseMoveLable;
        private System.Windows.Forms.Label MouseMoveLabel2;
        private System.Windows.Forms.Label Turnolbl;
        private System.Windows.Forms.Button button1;
    }
}