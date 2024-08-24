using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TP1
{
    public partial class ExerciseFormOne : Form
    {
        public ExerciseFormOne()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim() != "") //si el texto es distinto de vacio, o sea tiene datos, agrego un nombre
            {
                if (lbNombres.Items.Count <= 0) //si la lista esta vacia
                {
                    //agrego lo que haya en el textbox en el listBox
                    lbNombres.Items.Add(txtNombre.Text.Trim());
                    //limpiar el textbox(reiniciar)
                    txtNombre.Text = "";
                    UpdateButtonsStates();
                }
                else
                {
                    int index = lbNombres.FindString(txtNombre.Text.Trim());//busco dentro del listbox si el nombre existe
                    if (index < 0)
                    {
                        lbNombres.Items.Add(txtNombre.Text.Trim()); //si no existe lo agrego
                        txtNombre.Text = "";
                        UpdateButtonsStates();
                    }
                    else
                    {
                        MessageBox.Show("El nombre " + txtNombre.Text.Trim() + " ya existe en la lista. Ingrese otro nombre.","Atención",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                        //Si esta repetido, muestro un cartel aclaratorio
                    }
                }
            }
            else //sino muestro un cartel aclaratorio
            {
                MessageBox.Show("No pueden haber espacios vacios, intentelo de nuevo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void UpdateButtonsStates()
        {
            btnMover.Enabled = lbNombres.Items.Count > 0;
            btnMoverTodo.Enabled = lbNombres.Items.Count > 0;
        }

        private void btnMoverTodo_Click(object sender, EventArgs e)
        {
            
            foreach(var item in lbNombres.Items)
            {
                lbNombresSeleccionados.Items.Add(item.ToString());
            }
            lbNombres.Items.Clear();
            UpdateButtonsStates();

           /* Este código no mueve todo, solo lo seleccionado puede ser selección múltiple simple
            
            List<string> listaAux = new List<string>(); // Creo una lista temporal para que me guarde los seleccionados

            if (lbNombres.SelectedItems.Count > 0) // verifico que haya elementos seleccionados
            {
                foreach (string item in lbNombres.SelectedItems)
                {
                    listaAux.Add(item); // Guardo los elementos seleccionados en la lista auxiliar
                }

                foreach (string item in listaAux)

                {
                    lbNombresSeleccionados.Items.Add(item); // agrago los elementos de la lista auxiliar a la lista de Nombres seleccionados
                    lbNombres.Items.Remove(item); // Uso remove para limpiar de a un elemento

                }

            }
            else
            {
                MessageBox.Show("No hay elementos para mover", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }*/



        }

        private void btnReturnMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMover_Click(object sender, EventArgs e)
        {
            if (lbNombres.SelectedItem != null)
            {
                String item = lbNombres.SelectedItem.ToString();
                lbNombresSeleccionados.Items.Add(item);
                lbNombres.Items.Remove(lbNombres.SelectedItem);

            }
            else
            {
                MessageBox.Show("Debe seleccionar un nombre de la lista", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);  
            }      
            UpdateButtonsStates();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            string name = txtNombre.Text.Trim();
            if (name.Length > 0)
            {
                btnAgregar.Enabled = true;
            }
            else
            {
                btnAgregar.Enabled = false;
            }
        }

        /*
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool yaExiste = false;

            if (txtNombre.Text.Trim() != "")
            {
                foreach (string nombre in lbNombres.Items)
                {
                    if (nombre.ToUpper() == txtNombre.Text.ToUpper())
                    {
                        yaExiste = true;
                    }
                }

                if (yaExiste)
                {
                    MessageBox.Show("El nombre que desea ingresar ya existe en la lista.");
                }
                else
                {
                    lbNombres.Items.Add(txtNombre.Text.Trim());
                    txtNombre.Clear();
                }
            }
            else
            {
                MessageBox.Show("No hay ningún caracter ingresado");
            }
        }
        */
    }
}
