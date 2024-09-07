using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP3
{
    public partial class ejercicio1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void cusvLocalidad_ServerValidate(object source, ServerValidateEventArgs args)
        {
           
                bool noExiste = true;
                foreach (ListItem i in ddlLocalidades.Items)
                {
                    if (args.Value.ToUpper().Trim() == i.Value.ToUpper().Trim())
                    {
                        noExiste = false;
                        break;
                    }

                }

                if (noExiste)
                {
                    ddlLocalidades.Items.Add(args.Value);
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                }

            
          
            txtLocalidad.Text = " ";

        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }

        protected void btnGuardarUsuario_Click( object sender, EventArgs e)
        {
            lblUsuarioGuardado.Text = string.Empty;

            if (Page.IsValid)
            {
                lblUsuarioGuardado.Text = " Bienvenido/a:  " + txtUsuario.Text + " !!!";
                lblUsuarioGuardado.ForeColor = System.Drawing.Color.Green;
                txtUsuario.Text = "";
                txtCP.Text = "";
                txtEmail.Text = "";
                txtPassword.Text = "";
                ddlLocalidades.SelectedIndex = -1;


            }
            else
            {
                lblUsuarioGuardado.Text = "Por favor, complete todos los campos correctamente.";
                lblUsuarioGuardado.ForeColor = System.Drawing.Color.Red;
            }

        }
    }
}