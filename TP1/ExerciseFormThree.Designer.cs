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
            this.gbxGenre.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxGenre
            // 
            this.gbxGenre.Controls.Add(this.rbtnOther);
            this.gbxGenre.Controls.Add(this.rbtnFemale);
            this.gbxGenre.Controls.Add(this.rbtnMale);
            this.gbxGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxGenre.Location = new System.Drawing.Point(120, 42);
            this.gbxGenre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbxGenre.Name = "gbxGenre";
            this.gbxGenre.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbxGenre.Size = new System.Drawing.Size(368, 79);
            this.gbxGenre.TabIndex = 0;
            this.gbxGenre.TabStop = false;
            this.gbxGenre.Text = "Sexo";
            // 
            // rbtnOther
            // 
            this.rbtnOther.AutoSize = true;
            this.rbtnOther.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnOther.Location = new System.Drawing.Point(269, 33);
            this.rbtnOther.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbtnOther.Name = "rbtnOther";
            this.rbtnOther.Size = new System.Drawing.Size(61, 21);
            this.rbtnOther.TabIndex = 3;
            this.rbtnOther.Text = "Otro";
            this.rbtnOther.UseVisualStyleBackColor = true;
            // 
            // rbtnFemale
            // 
            this.rbtnFemale.AutoSize = true;
            this.rbtnFemale.Checked = true;
            this.rbtnFemale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnFemale.Location = new System.Drawing.Point(28, 33);
            this.rbtnFemale.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbtnFemale.Name = "rbtnFemale";
            this.rbtnFemale.Size = new System.Drawing.Size(99, 21);
            this.rbtnFemale.TabIndex = 1;
            this.rbtnFemale.TabStop = true;
            this.rbtnFemale.Text = "Femenino";
            this.rbtnFemale.UseVisualStyleBackColor = true;
            // 
            // rbtnMale
            // 
            this.rbtnMale.AutoSize = true;
            this.rbtnMale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnMale.Location = new System.Drawing.Point(148, 33);
            this.rbtnMale.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbtnMale.Name = "rbtnMale";
            this.rbtnMale.Size = new System.Drawing.Size(101, 21);
            this.rbtnMale.TabIndex = 2;
            this.rbtnMale.Text = "Masculino";
            this.rbtnMale.UseVisualStyleBackColor = true;
            // 
            // ExerciseFormThree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 542);
            this.Controls.Add(this.gbxGenre);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
    }
}