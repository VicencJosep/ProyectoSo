namespace FOSSA_DamasGame
{
    partial class FormFichasNegras
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
            this.MouseMoveLable = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.EnviarChat_Button = new System.Windows.Forms.Button();
            this.Turnolbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Tablero
            // 
            this.Tablero.Location = new System.Drawing.Point(44, 44);
            this.Tablero.Name = "Tablero";
            this.Tablero.Size = new System.Drawing.Size(246, 190);
            this.Tablero.TabIndex = 0;
            this.Tablero.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Tablero_MouseClick);
            this.Tablero.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Tablero_MouseMove);
            // 
            // chat
            // 
            this.chat.FormattingEnabled = true;
            this.chat.Location = new System.Drawing.Point(770, 224);
            this.chat.Name = "chat";
            this.chat.Size = new System.Drawing.Size(120, 95);
            this.chat.TabIndex = 1;
            // 
            // MouseMoveLable
            // 
            this.MouseMoveLable.AutoSize = true;
            this.MouseMoveLable.Location = new System.Drawing.Point(778, 196);
            this.MouseMoveLable.Name = "MouseMoveLable";
            this.MouseMoveLable.Size = new System.Drawing.Size(35, 13);
            this.MouseMoveLable.TabIndex = 2;
            this.MouseMoveLable.Text = "label1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(736, 339);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            // 
            // EnviarChat_Button
            // 
            this.EnviarChat_Button.Location = new System.Drawing.Point(866, 331);
            this.EnviarChat_Button.Name = "EnviarChat_Button";
            this.EnviarChat_Button.Size = new System.Drawing.Size(75, 35);
            this.EnviarChat_Button.TabIndex = 4;
            this.EnviarChat_Button.Text = "ENVIAR MENSAJE";
            this.EnviarChat_Button.UseVisualStyleBackColor = true;
            this.EnviarChat_Button.Click += new System.EventHandler(this.EnviarChat_Button_Click_1);
            // 
            // Turnolbl
            // 
            this.Turnolbl.AutoSize = true;
            this.Turnolbl.Font = new System.Drawing.Font("Showcard Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Turnolbl.Location = new System.Drawing.Point(777, 66);
            this.Turnolbl.MaximumSize = new System.Drawing.Size(100, 100);
            this.Turnolbl.MinimumSize = new System.Drawing.Size(100, 55);
            this.Turnolbl.Name = "Turnolbl";
            this.Turnolbl.Size = new System.Drawing.Size(100, 55);
            this.Turnolbl.TabIndex = 5;
            this.Turnolbl.Text = "label1";
            // 
            // FormFichasNegras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 596);
            this.Controls.Add(this.Turnolbl);
            this.Controls.Add(this.EnviarChat_Button);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.MouseMoveLable);
            this.Controls.Add(this.chat);
            this.Controls.Add(this.Tablero);
            this.Name = "FormFichasNegras";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.FormFichasNegras_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Tablero;
        private System.Windows.Forms.ListBox chat;
        private System.Windows.Forms.Label MouseMoveLable;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button EnviarChat_Button;
        private System.Windows.Forms.Label Turnolbl;
    }
}