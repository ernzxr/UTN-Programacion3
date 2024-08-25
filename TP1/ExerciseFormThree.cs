using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1
{
    public partial class ExerciseFormThree : Form
    {
        public ExerciseFormThree()
        {
            InitializeComponent();
        }

        private void btnReturnMenu3_Click(object sender, EventArgs e)
        {
            this.Close();
            MainForm formMenuPrincipal = new MainForm();
            formMenuPrincipal.Show();
        }

        private void btnSeleccionado_Click(object sender, EventArgs e)
        {
            if(chkOficio.CheckedItems.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un oficio.");
                return;
            }

            lblMensaje.Text = "Usted seleccionó los siguientes elementos: ";

            if (rbtnFemale.Checked == true)
            {
                lblMostrarSexo.Text = "Sexo: " + rbtnFemale.Text;
            }
            else
            {
                lblMostrarSexo.Text = "Sexo: " + (string)(rbtnMale.Checked ? "Masculino" : "Otro");
            }

            lblEstadoCivil.Text = "Estado Civil: " + (string)(rbSoltero.Checked ? "Soltero" : "Casado");

            lbl_Oficio.Text = "Oficio:";

            lbl0.Text = "- ";
            lbl1.Text = "- ";
            lbl2.Text = "- ";
            lbl3.Text = "- ";
            lbl4.Text = "- ";


            Label[] labels = {lbl0, lbl1, lbl2, lbl3, lbl4};

            int labelIndex = 0;

            foreach (int index in chkOficio.CheckedIndices)
            {
                labels[labelIndex].Visible = true;
                labels[labelIndex].Text += chkOficio.Items[index].ToString();
                labelIndex++;
            }
        }
    }
}
