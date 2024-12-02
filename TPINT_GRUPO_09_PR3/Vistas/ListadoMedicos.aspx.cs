using Negocio;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

namespace Vistas
{
    public partial class ListadoMedicos : System.Web.UI.Page
    {
        NegocioMedico Negm = new NegocioMedico();
        NegocioNacionalidad negn = new NegocioNacionalidad();
        NegocioSexo negS = new NegocioSexo();
        NegocioProvincia NegProv = new NegocioProvincia();
        NegocioLocalidad negL = new NegocioLocalidad();
        NegocioEspecialidad negEs = new NegocioEspecialidad();

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                CargarNacionalidad(ddlNacionalidad_M);
                CargarSexo(ddlSexo_M);
                CargarDdlProvincia(ddlProvincia_M);
                CargarEspecialidad(ddlEspecialidad_M);
            }

        }
        public void CargarNacionalidad(DropDownList ddl)
        {
            DataTable Nacionalidad = negn.getTablaNacionalidad();
            ddl.DataSource = Nacionalidad;
            ddl.DataTextField = "Descripcion_Na";
            ddl.DataValueField = "Id_Nacionalidad_Na";
            ddl.DataBind();

            ddl.Items.Insert(0, new ListItem("Seleccionar...", "0"));
        }

        public void CargarEspecialidad(DropDownList ddl)
        {
            DataTable Especialidad = negEs.getTablaEspecialidad();
            ddl.DataSource = Especialidad;
            ddl.DataTextField = "Descripcion_Es";
            ddl.DataValueField = "Id_Especialidad_Es";
            ddl.DataBind();

            ddl.Items.Insert(0, new ListItem("Seleccionar...", "0"));
        }
        protected void CargarLocalidades(int idProvincia)
        {
            DataTable localidades = negL.getTablaLocalidad(idProvincia);

            ddlLocalidad_M.DataSource = localidades;
            ddlLocalidad_M.DataTextField = "Descripcion_Lo";
            ddlLocalidad_M.DataValueField = "Id_Localidad_Lo";
            ddlLocalidad_M.DataBind();

            ddlLocalidad_M.Items.Insert(0, new ListItem("Seleccionar...", "0"));
        }

        public void CargarLocalidad(DropDownList ddl, int idProv)
        {
            DataTable Localidad = negL.getLocalidad(idProv);
            ddl.DataSource = Localidad;
            ddl.DataTextField = "Descripcion_Lo";
            ddl.DataValueField = "Id_Localidad_Lo";
            ddl.DataBind();

            ddl.Items.Insert(0, new ListItem("Seleccionar...", "0"));
        }
        public void CargarSexo(DropDownList ddl)
        {
            DataTable sexo = negS.getTablaSexo();
            ddl.DataSource = sexo;
            ddl.DataTextField = "Descripcion_Ge";
            ddl.DataValueField = "Id_Genero_Ge";
            ddl.DataBind();

            ddl.Items.Insert(0, new ListItem("Seleccionar...", "0"));
        }
        public void CargarDdlProvincia(DropDownList ddl)
        {
            DataTable Provincia = NegProv.getTablaProvincia();
            ddl.DataSource = Provincia;
            ddl.DataTextField = "Descripcion_Pr";
            ddl.DataValueField = "Id_Provincia_Pr";
            ddl.DataBind();

            ddl.Items.Insert(0, new ListItem("Seleccionar...", "0"));
        }


        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string legajo = txtLegajo.Text;
            
            if (Negm.existeMedicoLIKE(legajo))
            {
                DataTable dt = Negm.getMedicoLIKE(legajo);
                Session["filtra"] = dt;
                gvMedicos.DataSource = dt;
                gvMedicos.DataBind();
                Session["contiene"] = true;

                txtLegajo.Text = "";
                lblError_Filtrar.Text = "";
            }
            else
            {
                lblError_Filtrar.Text = "El medico no existe/fue dado de baja.";
                gvMedicos.DataSource = null;
                gvMedicos.DataBind();
            }
        }
        protected void btnMostrarTodo_Click(object sender, EventArgs e)
        {
            gvMedicos.DataSource = Negm.getMedicos();
            gvMedicos.DataBind();
            Session["contiene"] = false;

            txtLegajo.Text = "";
            lblError_Filtrar.Text = "";
        }

        protected void btnModificar_Command1(object sender, CommandEventArgs e) 
        {
            if (e.CommandName == "Modificar")
            {
                string legajo = e.CommandArgument.ToString();
                                                                             
                DataTable dtMedico = Negm.getMedico(legajo);

                if (dtMedico != null && dtMedico.Rows.Count > 0)
                {
                    DataRow medico = dtMedico.Rows[0];

                    txtLegajo_M.Text = legajo;

                    ddlEspecialidad_M.SelectedValue = medico["Id_Especialidad"].ToString();
                    txtDNI_M.Text = medico["DNI"].ToString();
                    ddlNacionalidad_M.SelectedValue = medico["Id_Nacionalidad"].ToString();
                    txtNombre_M.Text = medico["Nombre"].ToString();
                    txtApellido_M.Text = medico["Apellido"].ToString();
                    ddlSexo_M.SelectedValue = medico["Id_Genero"].ToString();

                    DateTime fechaNacimiento = Convert.ToDateTime(medico["Fecha_De_Nacimiento"]);
                    txtFechaNacimiento_M.Text = fechaNacimiento.ToString("yyyy-MM-dd");

                    int idProvincia = negL.getIdProvincia(Convert.ToInt32(medico["Id_Localidad"].ToString()));
                    ddlProvincia_M.SelectedValue = idProvincia.ToString();

                    CargarLocalidad(ddlLocalidad_M, idProvincia);
                    ddlLocalidad_M.SelectedValue = medico["Id_Localidad"].ToString();
                   
                    txtDireccion_M.Text = medico["Direccion"].ToString();
                    txtEmail_M.Text = medico["Email"].ToString();
                    txtTelefono_M.Text = medico["Telefono"].ToString();

                    bool chequeado = Convert.ToBoolean(medico["Estado"]);
                    chkEstado_M.Checked = chequeado ? true : false;

                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "showModal", "showModal();", true);
            }
        }

        protected void ddlProvincia_M_SelectedIndexChanged(object sender, EventArgs e)
        {

            int idProvinciaSeleccionada = int.Parse(ddlProvincia_M.SelectedValue);
            CargarLocalidades(idProvinciaSeleccionada);

        }


        protected void btnEliminar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                string legajo = e.CommandArgument.ToString();
               
                 if(string.IsNullOrEmpty(legajo))
                {
                    return;
                }

                try
                {

                    DataTable dtMedico = Negm.getMedicoPorLegajo(legajo);

                    if (dtMedico != null && dtMedico.Rows.Count > 0)
                    {
                        DataRow Medico = dtMedico.Rows[0];

                        txtLegajo_E.Text = Medico["Legajo"].ToString();
                       
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showDeleteModal", "showDeleteModal();", true);

                    }
                    else
                    {
                        lblMensaje_E.Text = "Hubo un error al intentar eliminar el médico. Por favor, inténtelo nuevamente.";
                        lblMensaje_E.Visible = true;
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }

        }
        
        protected void btnConfirmDelete_Click(Object sender, EventArgs e)
        {
           bool borro = Negm.bajaMedico(txtLegajo_E.Text);

           gvMedicos.DataSource = Negm.getMedicos();
           gvMedicos.DataBind();
          
        }

        protected void btnModificarM_Click(Object sender, EventArgs e)
           {
            try
            {
                bool modifico = Negm.ModificarMedico(txtLegajo_M.Text, int.Parse(ddlEspecialidad_M.SelectedValue), txtDNI_M.Text, txtNombre_M.Text, txtApellido_M.Text, int.Parse(ddlSexo_M.SelectedValue), Convert.ToDateTime(txtFechaNacimiento_M.Text),
                    int.Parse(ddlNacionalidad_M.SelectedValue), int.Parse(ddlLocalidad_M.SelectedValue), txtDireccion_M.Text, txtEmail_M.Text, txtTelefono_M.Text, chkEstado_M.Checked);

                lblCatch.Text = "";

                gvMedicos.DataSource = Negm.getMedicos();
                gvMedicos.DataBind();

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Violation of UNIQUE KEY constraint"))
                {
                    lblCatch.Text = "El email ingresado ya está registrado en otro paciente.";
                    lblCatch.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lblCatch.Text = "Ocurrió un error inesperado: " + ex.Message;
                    lblCatch.ForeColor = System.Drawing.Color.Red;
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "showModal", "showModal();", true);
            }


           }

        protected void gvMedicos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var idEspecialidad = DataBinder.Eval(e.Row.DataItem, "Id_Especialidad");
            var idGenero = DataBinder.Eval(e.Row.DataItem, "Id_Genero");
            var idNacionalidad = DataBinder.Eval(e.Row.DataItem, "Id_Nacionalidad");
            var idLocalidad = DataBinder.Eval(e.Row.DataItem, "Id_Localidad");

            Label lblEspecialidad = (Label)e.Row.FindControl("lblEspecialidad");
            Label lblGenero = (Label)e.Row.FindControl("lblGenero");
            Label lblNacionalidad = (Label)e.Row.FindControl("lblNacionalidad");
            Label lblProvincia = (Label)e.Row.FindControl("lblProvincia");
            Label lblLocalidad = (Label)e.Row.FindControl("lblLocalidad");
            CheckBox chkEstado = (CheckBox)e.Row.FindControl("chkEstado");
            Button btnEliminar = (Button)e.Row.FindControl("btnEliminar");

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (lblEspecialidad != null && idEspecialidad != DBNull.Value)
                {
                    string descripcionEspecialidad = negEs.getDescripcionEspecialidad(Convert.ToInt32(idEspecialidad));

                    lblEspecialidad.Text = !string.IsNullOrEmpty(descripcionEspecialidad) ? descripcionEspecialidad : "No especificada";
                }
                else
                {
                    lblEspecialidad.Text = "No Disponible";
                }

                if (lblGenero != null && idGenero != DBNull.Value)
                {
                    // Convertir el valor de "Id_Genero" al enum Genero
                    if (Enum.IsDefined(typeof(Genero), idGenero))
                    {
                        // Convertimos el Id_Genero a su valor enum
                        Genero generoEnum = (Genero)Enum.ToObject(typeof(Genero), idGenero);
                        lblGenero.Text = generoEnum.ToString();
                    }
                    else
                    {
                        lblGenero.Text = "No especificado";
                    }
                }
                else
                {
                    lblGenero.Text = "No disponible";
                }

                if (lblNacionalidad != null && idNacionalidad != DBNull.Value)
                {
                    string descripcionNacionalidad = negn.getDescripcionNacionalidad(Convert.ToInt32(idNacionalidad));

                    lblNacionalidad.Text = !string.IsNullOrEmpty(descripcionNacionalidad) ? descripcionNacionalidad : "No especificada";
                }
                else
                {
                    lblNacionalidad.Text = "No Disponible";
                }

                if (lblProvincia != null && idLocalidad != DBNull.Value)
                {
                    int idProvincia = negL.getIdProvincia(Convert.ToInt32(idLocalidad));

                    string descripcionProvincia = NegProv.getDescripcionProvincia(idProvincia);
                    descripcionProvincia = System.Text.RegularExpressions.Regex.Replace(descripcionProvincia, "([a-z])([A-Z])", "$1 $2");

                    lblProvincia.Text = !string.IsNullOrEmpty(descripcionProvincia) ? descripcionProvincia : "No especificada";

                }
                else
                {
                    lblProvincia.Text = "No Disponible";
                }

                if (lblLocalidad != null && idLocalidad != DBNull.Value)
                {
                    string descripcionLocalidad = negL.getDescripcionLocalidad(Convert.ToInt32(idLocalidad));

                    lblLocalidad.Text = !string.IsNullOrEmpty(descripcionLocalidad) ? descripcionLocalidad : "No especificada";
                }
                else
                {
                    lblLocalidad.Text = "No Disponible";
                }

                if (!chkEstado.Checked)
                {
                    btnEliminar.Enabled = false;
                }
            }
        }

        protected void gvMedicos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMedicos.PageIndex = e.NewPageIndex;
            if (Convert.ToBoolean(Session["contiene"]))
            {
                //filtra
                gvMedicos.DataSource = Session["filtra"];
            }
            else
            {
                //mostrar todos
                gvMedicos.DataSource = Negm.getMedicos();
            }
            gvMedicos.DataBind();
        }
    }
}





    









