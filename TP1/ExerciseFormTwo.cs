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
            // MainForm formMenuPrincipal = new MainForm();
            // formMenuPrincipal.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Si lo que hay en textNombre y txtApellido esta vacio
            if (txtNombre.Text.Trim() != "" && txtApellido.Text.Trim() != "")
            {
                String nCompleto = txtApellido.Text.Trim() + " " + txtNombre.Text.Trim(); // concateno el nombre y el apellido antes de agregarlo a la lista

                if (lbLista.Items.Count <= 0) //verifico si el listbox esta vacio
                {
                    lbLista.Items.Add(nCompleto);//si esta vacio agrego el nombre completo
                    // luego limpio los TextBox
                    txtNombre.Clear();
                    txtApellido.Clear();
                }
                else
                {
                    int index = lbLista.FindString(nCompleto);//si la lista contiene elementos busco dentro del listbox si el nombre completo existe
                    if (index < 0)
                    {
                        lbLista.Items.Add(nCompleto.Trim()); //si no existe lo agrego
                        txtNombre.Clear();
                        txtApellido.Clear();
                    }
                    else
                    {
                        //Si esta repetido, muestro un cartel aclaratorio
                        MessageBox.Show(nCompleto + " ya existe en la lista. Ingrese otro nombre y apellido.", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                        txtNombre.Clear();
                        txtApellido.Clear();
                    }
                }
                                                                 
            }
            else
            {
                // muestro mensaje aclaratorio en caso de no cumplir con la condicion 
                MessageBox.Show("Debe completar ambos campos.","Atención",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void UpdateButtonsState()
        {
            bool hasSelectedItem = lbLista.SelectedItem != null;
            btnBorrar.Enabled = hasSelectedItem;
            btnDeseleccionar.Enabled = hasSelectedItem;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if(lbLista.SelectedItem != null)
            {
                lbLista.Items.Remove(lbLista.SelectedItem);
                UpdateButtonsState();
            }
            else
            {
                MessageBox.Show("Seleccione un elemento de la lista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeseleccionar_Click(object sender, EventArgs e)
        {
            lbLista.SelectedItem = null;
            UpdateButtonsState();
        }

        private void lbLista_SelectedValueChanged(object sender, EventArgs e)
        {
            UpdateButtonsState();
        }

        private void lbLista_MouseClick(object sender, MouseEventArgs e)
        {
            if (lbLista.IndexFromPoint(e.Location) == -1)
            {
                lbLista.SelectedItem = null;
                UpdateButtonsState();
            }
        }
    }
  }

