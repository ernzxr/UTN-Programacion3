namespace TP1
{
    partial class ExerciseFormThree
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
            this.gbxGenre = new System.Windows.Forms.GroupBox();
            this.rbtnOther = new System.Windows.Forms.RadioButton();
            this.rbtnFemale = new System.Windows.Forms.RadioButton();
            this.rbtnMale = new System.Windows.Forms.RadioButton();
            this.btnReturnMenu3 = new System.Windows.Forms.Button();
            this.gbxGenre.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxGenre
            // 
            this.gbxGenre.Controls.Add(this.rbtnOther);
            this.gbxGenre.Controls.Add(this.rbtnFemale);
            this.gbxGenre.Controls.Add(this.rbtnMale);
            this.gbxGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxGenre.Location = new System.Drawing.Point(90, 34);
            this.gbxGenre.Name = "gbxGenre";
            this.gbxGenre.Size = new System.Drawing.Size(276, 64);
            this.gbxGenre.TabIndex = 0;
            this.gbxGenre.TabStop = false;
            this.gbxGenre.Text = "Sexo";
            // 
            // rbtnOther
            // 
            this.rbtnOther.AutoSize = true;
            this.rbtnOther.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnOther.Location = new System.Drawing.Point(202, 27);
            this.rbtnOther.Name = "rbtnOther";
            this.rbtnOther.Size = new System.Drawing.Size(49, 17);
            this.rbtnOther.TabIndex = 3;
            this.rbtnOther.Text = "Otro";
            this.rbtnOther.UseVisualStyleBackColor = true;
            // 
            // rbtnFemale
            // 
            this.rbtnFemale.AutoSize = true;
            this.rbtnFemale.Checked = true;
            this.rbtnFemale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnFemale.Location = new System.Drawing.Point(21, 27);
            this.rbtnFemale.Name = "rbtnFemale";
            this.rbtnFemale.Size = new System.Drawing.Size(79, 17);
            this.rbtnFemale.TabIndex = 1;
            this.rbtnFemale.TabStop = true;
            this.rbtnFemale.Text = "Femenino";
            this.rbtnFemale.UseVisualStyleBackColor = true;
            // 
            // rbtnMale
            // 
            this.rbtnMale.AutoSize = true;
            this.rbtnMale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnMale.Location = new System.Drawing.Point(111, 27);
            this.rbtnMale.Name = "rbtnMale";
            this.rbtnMale.Size = new System.Drawing.Size(82, 17);
            this.rbtnMale.TabIndex = 2;
            this.rbtnMale.Text = "Masculino";
            this.rbtnMale.UseVisualStyleBackColor = true;
            // 
            // btnReturnMenu3
            // 
            this.btnReturnMenu3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnReturnMenu3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturnMenu3.Location = new System.Drawing.Point(154, 376);
            this.btnReturnMenu3.Name = "btnReturnMenu3";
            this.btnReturnMenu3.Size = new System.Drawing.Size(156, 30);
            this.btnReturnMenu3.TabIndex = 1;
            this.btnReturnMenu3.Text = "Volver al Menu Principal";
            this.btnReturnMenu3.UseVisualStyleBackColor = true;
            this.btnReturnMenu3.Click += new System.EventHandler(this.btnReturnMenu3_Click);
            // 
            // ExerciseFormThree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 440);
            this.Controls.Add(this.btnReturnMenu3);
            this.Controls.Add(this.gbxGenre);
            this.MaximizeBox = false;
            this.Name = "ExerciseFormThree";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExerciseFormThree";
            this.gbxGenre.ResumeLayout(false);
            this.gbxGenre.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxGenre;
        private System.Windows.Forms.RadioButton rbtnFemale;
        private System.Windows.Forms.RadioButton rbtnMale;
        private System.Windows.Forms.RadioButton rbtnOther;
        private System.Windows.Forms.Button btnReturnMenu3;
    }
}