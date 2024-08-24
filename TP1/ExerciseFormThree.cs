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

            if (chkOficio.CheckedItems.Count > 0)
            {

            }
            else
            {
                MessageBox.Show("Debe seleccionar un oficio.");
            }
        }
    }
}
