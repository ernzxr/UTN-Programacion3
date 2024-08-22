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
            this.lblIngresoDatos = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnReturm2
            // 
            this.btnReturm2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnReturm2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturm2.Location = new System.Drawing.Point(220, 317);
            this.btnReturm2.Name = "btnReturm2";
            this.btnReturm2.Size = new System.Drawing.Size(156, 30);
            this.btnReturm2.TabIndex = 0;
            this.btnReturm2.Text = "Volver al Menú Principal";
            this.btnReturm2.UseVisualStyleBackColor = true;
            this.btnReturm2.Click += new System.EventHandler(this.btnReturm2_Click);
            // 
            // lblIngresoDatos
            // 
            this.lblIngresoDatos.AutoSize = true;
            this.lblIngresoDatos.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngresoDatos.Location = new System.Drawing.Point(81, 66);
            this.lblIngresoDatos.Name = "lblIngresoDatos";
            this.lblIngresoDatos.Size = new System.Drawing.Size(114, 19);
            this.lblIngresoDatos.TabIndex = 1;
            this.lblIngresoDatos.Text = "Ingreso de Datos";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(88, 143);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(78, 19);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "NOMBRE";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellido.Location = new System.Drawing.Point(88, 177);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(84, 19);
            this.lblApellido.TabIndex = 3;
            this.lblApellido.Text = "APELLIDO";
            // 
            // ExerciseFormTwo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblIngresoDatos);
            this.Controls.Add(this.btnReturm2);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ExerciseFormTwo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExerciseFormTwo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReturm2;
        private System.Windows.Forms.Label lblIngresoDatos;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
    }
}