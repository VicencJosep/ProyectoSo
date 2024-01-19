namespace FOSSA_DamasGame
{
    partial class ConsultasForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ConsultarBtn = new System.Windows.Forms.Button();
            this.Fecha1Box = new System.Windows.Forms.TextBox();
            this.Fecha2Box = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(342, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(239, 130);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(577, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 78);
            this.label2.TabIndex = 2;
            this.label2.Text = "Introduce dos fechas que\r\ndelimiten el intervalo que \r\nquieres consultar.\r\nAsegur" +
    "ate que sigue el \r\nsiguiente formato:\r\nAAAA-MM-DD hh:mm:ss";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(577, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "FECHA 1:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(577, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "FECHA 2:";
            // 
            // ConsultarBtn
            // 
            this.ConsultarBtn.Location = new System.Drawing.Point(608, 233);
            this.ConsultarBtn.Name = "ConsultarBtn";
            this.ConsultarBtn.Size = new System.Drawing.Size(84, 26);
            this.ConsultarBtn.TabIndex = 5;
            this.ConsultarBtn.Text = "CONSULTAR";
            this.ConsultarBtn.UseVisualStyleBackColor = true;
            this.ConsultarBtn.Click += new System.EventHandler(this.ConsultarBtn_Click);
            // 
            // Fecha1Box
            // 
            this.Fecha1Box.Location = new System.Drawing.Point(637, 158);
            this.Fecha1Box.Name = "Fecha1Box";
            this.Fecha1Box.Size = new System.Drawing.Size(100, 20);
            this.Fecha1Box.TabIndex = 6;
            // 
            // Fecha2Box
            // 
            this.Fecha2Box.Location = new System.Drawing.Point(637, 194);
            this.Fecha2Box.Name = "Fecha2Box";
            this.Fecha2Box.Size = new System.Drawing.Size(100, 20);
            this.Fecha2Box.TabIndex = 7;
            // 
            // ConsultasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Fecha2Box);
            this.Controls.Add(this.Fecha1Box);
            this.Controls.Add(this.ConsultarBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "ConsultasForm";
            this.Text = "Form de consultas";
            this.Load += new System.EventHandler(this.ConsultasForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ConsultarBtn;
        private System.Windows.Forms.TextBox Fecha1Box;
        private System.Windows.Forms.TextBox Fecha2Box;
    }
}