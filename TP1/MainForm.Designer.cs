namespace TP1
{
    partial class MainForm
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
            this.btnExerciseOne = new System.Windows.Forms.Button();
            this.btnExerciseTwo = new System.Windows.Forms.Button();
            this.btnExerciseThree = new System.Windows.Forms.Button();
            this.lblMainTitle = new System.Windows.Forms.Label();
            this.lblGroupMembers = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnExerciseOne
            // 
            this.btnExerciseOne.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExerciseOne.Enabled = false;
            this.btnExerciseOne.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExerciseOne.Location = new System.Drawing.Point(89, 75);
            this.btnExerciseOne.Name = "btnExerciseOne";
            this.btnExerciseOne.Size = new System.Drawing.Size(108, 51);
            this.btnExerciseOne.TabIndex = 0;
            this.btnExerciseOne.Text = "EJERCICIO 1";
            this.btnExerciseOne.UseVisualStyleBackColor = true;
            // 
            // btnExerciseTwo
            // 
            this.btnExerciseTwo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExerciseTwo.Enabled = false;
            this.btnExerciseTwo.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExerciseTwo.Location = new System.Drawing.Point(203, 75);
            this.btnExerciseTwo.Name = "btnExerciseTwo";
            this.btnExerciseTwo.Size = new System.Drawing.Size(108, 51);
            this.btnExerciseTwo.TabIndex = 1;
            this.btnExerciseTwo.Text = "EJERCICIO 2";
            this.btnExerciseTwo.UseVisualStyleBackColor = true;
            // 
            // btnExerciseThree
            // 
            this.btnExerciseThree.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExerciseThree.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExerciseThree.Location = new System.Drawing.Point(317, 75);
            this.btnExerciseThree.Name = "btnExerciseThree";
            this.btnExerciseThree.Size = new System.Drawing.Size(108, 51);
            this.btnExerciseThree.TabIndex = 2;
            this.btnExerciseThree.Text = "EJERCICIO 3";
            this.btnExerciseThree.UseVisualStyleBackColor = true;
            this.btnExerciseThree.Click += new System.EventHandler(this.btnExerciseThree_Click);
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMainTitle.AutoSize = true;
            this.lblMainTitle.Font = new System.Drawing.Font("Montserrat", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainTitle.Location = new System.Drawing.Point(127, 31);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(252, 29);
            this.lblMainTitle.TabIndex = 3;
            this.lblMainTitle.Text = "TRABAJO PRACTICO 1";
            // 
            // lblGroupMembers
            // 
            this.lblGroupMembers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblGroupMembers.AutoSize = true;
            this.lblGroupMembers.Font = new System.Drawing.Font("Montserrat", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroupMembers.Location = new System.Drawing.Point(173, 141);
            this.lblGroupMembers.Name = "lblGroupMembers";
            this.lblGroupMembers.Size = new System.Drawing.Size(168, 29);
            this.lblGroupMembers.TabIndex = 4;
            this.lblGroupMembers.Text = "INTEGRANTES";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 442);
            this.Controls.Add(this.lblGroupMembers);
            this.Controls.Add(this.lblMainTitle);
            this.Controls.Add(this.btnExerciseThree);
            this.Controls.Add(this.btnExerciseTwo);
            this.Controls.Add(this.btnExerciseOne);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Formulario Principal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExerciseOne;
        private System.Windows.Forms.Button btnExerciseTwo;
        private System.Windows.Forms.Button btnExerciseThree;
        private System.Windows.Forms.Label lblMainTitle;
        private System.Windows.Forms.Label lblGroupMembers;
    }
}