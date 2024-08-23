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
    public partial class ExerciseFormTwo : Form
    {
        public ExerciseFormTwo()
        {
            InitializeComponent();
        }

        private void btnReturm2_Click(object sender, EventArgs e)
        {
            this.Close();
            MainForm formMenuPrincipal = new MainForm();
            formMenuPrincipal.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Si lo que hay en textNombre y txtApellido esta vacio
            if (txtNombre.Text != "" && txtApellido.Text != "")
            {
                // Agrego el nombre completo al ListBox
                lbLista.Items.Add(txtNombre.Text + " " + txtApellido.Text);

                // luego limpio los TextBox
                txtNombre.Clear();
                txtApellido.Clear();
            }
            else
            {
                // muestro mensaje aclaratorio en caso de no complir con la condicion 
                MessageBox.Show("Debe completar ambos campos.");
            }
        }
    }
  }

