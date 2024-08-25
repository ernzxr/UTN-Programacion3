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
            // No se debe abrir un nuevo formulario principal
            // MainForm formMenuPrincipal = new MainForm();
            // formMenuPrincipal.Show();
        }

        private void btnSeleccionado_Click(object sender, EventArgs e)
        {
            if(chkOficio.CheckedItems.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un oficio.");
                lblMensaje.Text = "";
                return;
            }

            lblMensaje.Text = "";
            lblMensaje.Text += "Usted seleccionó los siguientes elementos:\n";

            lblMensaje.Text += rbtnMale.Checked
                ? "\nSexo: Masculino"
                : rbtnFemale.Checked
                ? "\nSexo: Femenino"
                : "\nSexo: Otro";

            lblMensaje.Text += rbSoltero.Checked
                ? "\nEstado Civil: Soltero"
                : "\nEstado Civil: Casado";

            lblMensaje.Text += "\nOficio:";
            foreach (string job in chkOficio.CheckedItems)
            {
                lblMensaje.Text += "\n  - " + job;
            }
        }
    }
}
