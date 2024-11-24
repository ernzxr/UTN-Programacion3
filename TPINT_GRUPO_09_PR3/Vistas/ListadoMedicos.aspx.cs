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

            if (!IsPostBack)
            {
                CargarNacionalidad(ddlNacionalidad_M);
                CargarSexo(ddlSexo_M);
                CargarProvincia(ddlProvincia_M);
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
        /* protected void CargarLocalidades(int idProvincia)
         {
             DataTable localidades = negL.getTablaLocalidad(idProvincia);

             ddlLocalidad_M.DataSource = localidades;
             ddlLocalidad_M.DataTextField = "Descripcion_Lo";
             ddlLocalidad_M.DataValueField = "Id_Localidad_Lo";
             ddlLocalidad_M.DataBind();

             ddlLocalidad_M.Items.Insert(0, new ListItem("Seleccionar...", "0"));
         }*/
        protected void CargarLocalidades(Provincia2 provincia)
        {
            DataTable localidades = negL.getTablaLocalidad(provincia);

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

        public void CargarProvincia(DropDownList ddl)
        {
            DataTable Provincia = NegProv.getTablaProvincia();
            ddl.DataSource = Provincia;
            ddl.DataTextField = "Descripcion_Pr";
            ddl.DataValueField = "Id_Provincia_Pr";
            ddl.DataBind();

            ddl.Items.Insert(0, new ListItem("Seleccionar...", "0"));
        }

        /* public void CargarLocalidad(DropDownList ddl, DataRow medico)
         {
             int idProvincia;
             if (int.TryParse(medico["Id_Provincia"].ToString(), out idProvincia))
             {

                 DataTable Localidad = negL.getTablaLocalidad(idProvincia);
                 ddl.DataSource = Localidad;
                 ddl.DataTextField = "Descripcion_Lo";
                 ddl.DataValueField = "Id_Localidad_Lo";
                 ddl.DataBind();

                 ddl.Items.Insert(0, new ListItem("Seleccionar...", "0"));
             }
         }*/
        public void CargarDdlProvincia(DropDownList ddl)
        {
            var provincias = Enum.GetValues(typeof(Provincia2))
                         .Cast<Provincia2>()
                         .Select(p => new
                         {
                             // Convierte el nombre del enum a uno amigable para el usuario
                             Text = string.Join(" ", Regex.Split(p.ToString(), @"(?<=[a-z])(?=[A-Z])")),
                             Value = ((int)p).ToString()
                         });

            ddl.Items.Clear();

            ddl.DataSource = provincias;
            ddl.DataTextField = "Text";
            ddl.DataValueField = "Value";
            ddl.DataBind();

            ddl.Items.Insert(0, new ListItem("Seleccionar...", "0"));
        }


        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string legajo = txtLegajo.Text;
            
            if (Negm.existeMedico(legajo))
            {
                gvMedicos.DataSource = Negm.getMedico(legajo);
                gvMedicos.DataBind();

                txtLegajo.Text = "";
                

            }
        }
        protected void btnMostrarTodo_Click(object sender, EventArgs e)
        {
            gvMedicos.DataSource = Negm.getMedico();
            gvMedicos.DataBind();

            txtLegajo.Text = "";
        }
            


        protected void btnModificar_Command1(object sender, CommandEventArgs e) 
        {
            if (e.CommandName == "Modificar")
            {
                string legajo = e.CommandArgument.ToString();
                                                                             
                DataTable dtMedico = Negm.getMedicoPorLegajo(legajo);

                if (dtMedico != null && dtMedico.Rows.Count > 0)
                {
                    DataRow medico = dtMedico.Rows[0];

                    ddlEspecialidad_M.SelectedValue = medico["Especialidad"].ToString();
                    txtDNI_M.Text = medico["DNI"].ToString();
                    ddlNacionalidad_M.SelectedValue = medico["Id_Nacionalidad"].ToString();
                    txtNombre_M.Text = medico["Nombre"].ToString();
                    txtApellido_M.Text = medico["Apellido"].ToString();
                    ddlSexo_M.SelectedValue = medico["Id_Genero"].ToString();

                    DateTime fechaNacimiento = Convert.ToDateTime(medico["Fecha_De_Nacimiento"]);
                    txtFechaNacimiento_M.Text = fechaNacimiento.ToString("yyyy-MM-dd");
                    ddlProvincia_M.SelectedValue = medico["Id_Provincia"].ToString();

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

        /*protected void ddlProvincia_M_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProvincia = int.Parse(ddlProvincia_M.SelectedValue);
            CargarLocalidades(idProvincia);
        }*/
        protected void ddlProvincia_M_SelectedIndexChanged(object sender, EventArgs e)
        {

            Provincia2 provinciaSeleccionada = (Provincia2)Enum.Parse(typeof(Provincia2), ddlProvincia_M.SelectedValue);
            CargarLocalidades(provinciaSeleccionada);

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

            if (borro)
            {
                gvMedicos.DataSource = Negm.getMedico();
                gvMedicos.DataBind();
            }
        }

        protected void btnModificarM_Click(Object sender, EventArgs e)
           {
               bool modifico = Negm.ModificarMedico(int.Parse(ddlEspecialidad_M.SelectedValue),txtDNI_M.Text, txtNombre_M.Text, txtApellido_M.Text, int.Parse(ddlSexo_M.SelectedValue), Convert.ToDateTime(txtFechaNacimiento_M.Text),
                   int.Parse(ddlNacionalidad_M.SelectedValue), int.Parse(ddlLocalidad_M.SelectedValue), txtDireccion_M.Text, txtEmail_M.Text, txtTelefono_M.Text, chkEstado_M.Checked);

            if (modifico)
            {
                gvMedicos.DataSource = Negm.getMedico();
                gvMedicos.DataBind();
            }
           }

        


    }
}





    









