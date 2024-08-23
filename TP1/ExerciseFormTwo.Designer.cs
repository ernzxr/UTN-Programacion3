namespace TP1
{
    partial class ExerciseFormTwo
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
            this.btnReturm2 = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.gpBox_Datos = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.gpBox_Datos.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReturm2
            // 
            this.btnReturm2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnReturm2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturm2.Location = new System.Drawing.Point(293, 390);
            this.btnReturm2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReturm2.Name = "btnReturm2";
            this.btnReturm2.Size = new System.Drawing.Size(208, 37);
            this.btnReturm2.TabIndex = 0;
            this.btnReturm2.Text = "Volver al Menú Principal";
            this.btnReturm2.UseVisualStyleBackColor = true;
            this.btnReturm2.Click += new System.EventHandler(this.btnReturm2_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(7, 133);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(106, 26);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "NOMBRE:";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellido.Location = new System.Drawing.Point(7, 181);
            this.lblApellido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(111, 26);
            this.lblApellido.TabIndex = 3;
            this.lblApellido.Text = "APELLIDO:";
            // 
            // gpBox_Datos
            // 
            this.gpBox_Datos.Controls.Add(this.textBox2);
            this.gpBox_Datos.Controls.Add(this.textBox1);
            this.gpBox_Datos.Controls.Add(this.lblNombre);
            this.gpBox_Datos.Controls.Add(this.lblApellido);
            this.gpBox_Datos.Location = new System.Drawing.Point(12, 12);
            this.gpBox_Datos.Name = "gpBox_Datos";
            this.gpBox_Datos.Size = new System.Drawing.Size(380, 363);
            this.gpBox_Datos.TabIndex = 4;
            this.gpBox_Datos.TabStop = false;
            this.gpBox_Datos.Text = "Ingreso de Datos";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(128, 133);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(223, 22);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(128, 181);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(223, 22);
            this.textBox2.TabIndex = 5;
            // 
            // ExerciseFormTwo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gpBox_Datos);
            this.Controls.Add(this.btnReturm2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ExerciseFormTwo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExerciseFormTwo";
            this.gpBox_Datos.ResumeLayout(false);
            this.gpBox_Datos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReturm2;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.GroupBox gpBox_Datos;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
    }
}