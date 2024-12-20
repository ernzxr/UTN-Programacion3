﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace Vistas
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
           
            string usuario = txtUsuario.Text;
            string contraseña = txtPass.Text;

         
            NegocioUsuario negocioUsuario = new NegocioUsuario();
            NegocioMedico negocioMedico = new NegocioMedico();


            string tipoUsuario = negocioUsuario.VerificarUsuario(usuario, contraseña);

            if (tipoUsuario == "Administrador")
            {
                // Usuario administrador: Redirigimos a la página de inicio de admin
                Session["TipoUsuario"] = 1;
                Session["Usuario"] = usuario; // Guardamos el usuario en sesión
                Response.Redirect("InicioAdmin.aspx");
              

            }
            else if (tipoUsuario == "Médico")
            {
                // Usuario médico: Redirigimos a la página de inicio de médico
                Session["TipoUsuario"] = 2;
                Session["Usuario"] = usuario; // Guardamos el usuario en sesión

                Medico medico = new Medico();
                medico = negocioMedico.ObtenerDatosMedicoPorUsuario(usuario);
                string legajo = medico.getLegajo();
                Session["Legajo"] = legajo; // Guardamos el legajo en sesión

                Response.Redirect("InicioMedico.aspx");
            }
            else if (tipoUsuario == "Credenciales incorrectas")
            {
           
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Usuario o contraseña incorrectos. Por favor, intente nuevamente.";
                txtUsuario.Text = "";
                txtPass.Text = "";
            }
            else
            {
                
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Ha ocurrido un error inesperado. Comuníquese con soporte.";
                txtUsuario.Text = "";
                txtPass.Text = "";

            }

        }
       


    }
}
