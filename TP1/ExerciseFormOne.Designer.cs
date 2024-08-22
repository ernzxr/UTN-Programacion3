namespace TP1
{
    partial class ExerciseFormOne
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
            this.lblIngreseNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lbNombres = new System.Windows.Forms.ListBox();
            this.btnMover = new System.Windows.Forms.Button();
            this.btnMoverTodo = new System.Windows.Forms.Button();
            this.lbNombresSeleccionados = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblIngreseNombre
            // 
            this.lblIngreseNombre.AutoSize = true;
            this.lblIngreseNombre.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngreseNombre.Location = new System.Drawing.Point(43, 58);
            this.lblIngreseNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIngreseNombre.Name = "lblIngreseNombre";
            this.lblIngreseNombre.Size = new System.Drawing.Size(188, 24);
            this.lblIngreseNombre.TabIndex = 0;
            this.lblIngreseNombre.Text = "Ingrese un nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(255, 57);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(347, 22);
            this.txtNombre.TabIndex = 1;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(611, 54);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(108, 32);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lbNombres
            // 
            this.lbNombres.FormattingEnabled = true;
            this.lbNombres.ItemHeight = 16;
            this.lbNombres.Location = new System.Drawing.Point(48, 108);
            this.lbNombres.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbNombres.Name = "lbNombres";
            this.lbNombres.Size = new System.Drawing.Size(291, 276);
            this.lbNombres.TabIndex = 3;
            // 
            // btnMover
            // 
            this.btnMover.Location = new System.Drawing.Point(363, 199);
            this.btnMover.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMover.Name = "btnMover";
            this.btnMover.Size = new System.Drawing.Size(100, 28);
            this.btnMover.TabIndex = 4;
            this.btnMover.Text = ">";
            this.btnMover.UseVisualStyleBackColor = true;
            // 
            // btnMoverTodo
            // 
            this.btnMoverTodo.Location = new System.Drawing.Point(363, 235);
            this.btnMoverTodo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMoverTodo.Name = "btnMoverTodo";
            this.btnMoverTodo.Size = new System.Drawing.Size(100, 28);
            this.btnMoverTodo.TabIndex = 5;
            this.btnMoverTodo.Text = ">>";
            this.btnMoverTodo.UseVisualStyleBackColor = true;
            this.btnMoverTodo.Click += new System.EventHandler(this.btnMoverTodo_Click);
            // 
            // lbNombresSeleccionados
            // 
            this.lbNombresSeleccionados.FormattingEnabled = true;
            this.lbNombresSeleccionados.ItemHeight = 16;
            this.lbNombresSeleccionados.Location = new System.Drawing.Point(483, 108);
            this.lbNombresSeleccionados.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbNombresSeleccionados.Name = "lbNombresSeleccionados";
            this.lbNombresSeleccionados.Size = new System.Drawing.Size(291, 276);
            this.lbNombresSeleccionados.TabIndex = 6;
            // 
            // ExerciseFormOne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 450);
            this.Controls.Add(this.lbNombresSeleccionados);
            this.Controls.Add(this.btnMoverTodo);
            this.Controls.Add(this.btnMover);
            this.Controls.Add(this.lbNombres);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblIngreseNombre);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ExerciseFormOne";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExerciseFormOne";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIngreseNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.ListBox lbNombres;
        private System.Windows.Forms.Button btnMover;
        private System.Windows.Forms.Button btnMoverTodo;
        private System.Windows.Forms.ListBox lbNombresSeleccionados;
    }
}