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
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.gpBox_Elementos = new System.Windows.Forms.GroupBox();
            this.lbLista = new System.Windows.Forms.ListBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.gpBox_Datos.SuspendLayout();
            this.gpBox_Elementos.SuspendLayout();
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
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(5, 108);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(82, 19);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "NOMBRE:";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellido.Location = new System.Drawing.Point(5, 147);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(88, 19);
            this.lblApellido.TabIndex = 3;
            this.lblApellido.Text = "APELLIDO:";
            // 
            // gpBox_Datos
            // 
            this.gpBox_Datos.Controls.Add(this.btnAgregar);
            this.gpBox_Datos.Controls.Add(this.textBox2);
            this.gpBox_Datos.Controls.Add(this.textBox1);
            this.gpBox_Datos.Controls.Add(this.lblNombre);
            this.gpBox_Datos.Controls.Add(this.lblApellido);
            this.gpBox_Datos.Location = new System.Drawing.Point(9, 10);
            this.gpBox_Datos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gpBox_Datos.Name = "gpBox_Datos";
            this.gpBox_Datos.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gpBox_Datos.Size = new System.Drawing.Size(285, 295);
            this.gpBox_Datos.TabIndex = 4;
            this.gpBox_Datos.TabStop = false;
            this.gpBox_Datos.Text = "Ingreso de Datos";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(96, 147);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(168, 20);
            this.textBox2.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(96, 108);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(168, 20);
            this.textBox1.TabIndex = 4;
            // 
            // gpBox_Elementos
            // 
            this.gpBox_Elementos.Controls.Add(this.lbLista);
            this.gpBox_Elementos.Location = new System.Drawing.Point(312, 10);
            this.gpBox_Elementos.Name = "gpBox_Elementos";
            this.gpBox_Elementos.Size = new System.Drawing.Size(276, 295);
            this.gpBox_Elementos.TabIndex = 5;
            this.gpBox_Elementos.TabStop = false;
            this.gpBox_Elementos.Text = "Elementos";
            // 
            // lbLista
            // 
            this.lbLista.FormattingEnabled = true;
            this.lbLista.Location = new System.Drawing.Point(33, 33);
            this.lbLista.Name = "lbLista";
            this.lbLista.Size = new System.Drawing.Size(207, 199);
            this.lbLista.TabIndex = 0;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(83, 241);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(92, 39);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // ExerciseFormTwo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.gpBox_Elementos);
            this.Controls.Add(this.gpBox_Datos);
            this.Controls.Add(this.btnReturm2);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ExerciseFormTwo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExerciseFormTwo";
            this.gpBox_Datos.ResumeLayout(false);
            this.gpBox_Datos.PerformLayout();
            this.gpBox_Elementos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReturm2;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.GroupBox gpBox_Datos;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.GroupBox gpBox_Elementos;
        private System.Windows.Forms.ListBox lbLista;
    }
}