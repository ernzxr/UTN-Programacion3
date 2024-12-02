using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class ListadoPacientes : System.Web.UI.Page
    {
        NegocioNacionalidad negn = new NegocioNacionalidad();
        NegocioPaciente NegP = new NegocioPaciente();
        NegocioSexo negS = new NegocioSexo();
        NegocioProvincia NegProv = new NegocioProvincia();
        NegocioLocalidad negL = new NegocioLocalidad();

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
                CargarNacionalidad(ddlNacionalidad);
                CargarNacionalidad(ddlNacionalidad_M);
                CargarNacionalidad(ddlNacionalidad_E);
                CargarDdlSexo(ddlSexo_M);
                CargarDdlProvincia(ddlProvincia_M);
            }

        }
        public void CargarDdlSexo(DropDownList ddl)
        {
            ddl.Items.Clear();
            ddl.Items.Insert(0, new ListItem("Seleccionar...", "0"));

            foreach (Genero genero in Enum.GetValues(typeof(Genero)))
            {
                ddl.Items.Add(new ListItem(genero.ToString(), ((int)genero).ToString()));
            }
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

        public void CargarNacionalidad(DropDownList ddl)
        {
            DataTable Nacionalidad = negn.getTablaNacionalidad();
            ddl.DataSource = Nacionalidad;
            ddl.DataTextField = "Descripcion_Na";
            ddl.DataValueField = "Id_Nacionalidad_Na";
            ddl.DataBind();

            ddl.Items.Insert(0, new ListItem("Seleccionar...", "0"));
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

        protected void CargarLocalidades(int idProvincia)
        {
            DataTable localidades = negL.getTablaLocalidad(idProvincia);

            ddlLocalidad_M.DataSource = localidades;
            ddlLocalidad_M.DataTextField = "Descripcion_Lo";
            ddlLocalidad_M.DataValueField = "Id_Localidad_Lo";
            ddlLocalidad_M.DataBind();

            ddlLocalidad_M.Items.Insert(0, new ListItem("Seleccionar...", "0"));
        }

        protected void btnFiltrarDNI_Click(object sender, EventArgs e)
        {
            rfvDNI.ValidationGroup = "filtrarDNI";
            revDNI.ValidationGroup = "filtrarDNI";

            Page.Validate("filtrarDNI");
            if (Page.IsValid)
            {
                if (NegP.existePacienteDni(txtDNI.Text))
                {
                    DataTable dt = NegP.getPacienteXDNI(txtDNI.Text);
                    Session["dtDNI"] = dt;
                    gvPacientes.DataSource = dt;
                    gvPacientes.DataBind();

                    Session["contiene"] = 1;

                    txtDNI.Text = "";
                    ddlNacionalidad.SelectedValue = "0";
                    lblError_Filtrar.Text = "";
                }
                else
                {
                    gvPacientes.DataSource = null;
                    gvPacientes.DataBind();
                    lblError_Filtrar.Text = "No existe un paciente con ese DNI.";
                }

            }

        }

        protected void btnFiltrarNacionalidad_Click(object sender, EventArgs e)
        {
            rfvNacionalidad.ValidationGroup = "filtrarNacionalidad";

            Page.Validate("filtrarNacionalidad");
            if (Page.IsValid)
            {
                int idNacionalidad = Convert.ToInt32(ddlNacionalidad.SelectedValue);
                if (NegP.existePacienteNacionalidad(idNacionalidad))
                {
                    DataTable dt = NegP.getPacienteXNacionalidad(idNacionalidad);
                    Session["dtNacionalidad"] = dt;
                    gvPacientes.DataSource = dt;
                    gvPacientes.DataBind();

                    Session["contiene"] = 2;

                    txtDNI.Text = "";
                    ddlNacionalidad.SelectedValue = "0";
                    lblError_Filtrar.Text = "";
                }
                else
                {
                    gvPacientes.DataSource = null;
                    gvPacientes.DataBind();
                    lblError_Filtrar.Text = "No existe un paciente que pertenezca a esa nacionalidad.";
                }

            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            rfvDNI.ValidationGroup = "filtrarAmbos";
            revDNI.ValidationGroup = "filtrarAmbos";
            rfvNacionalidad.ValidationGroup = "filtrarAmbos";
            Page.Validate("filtrarAmbos");
            if (Page.IsValid)
            {
                string dni = txtDNI.Text;
                int idNacionalidad = int.Parse(ddlNacionalidad.SelectedValue);

                if (NegP.existePaciente(dni, idNacionalidad))
                {
                    DataTable dt = NegP.getPaciente(dni, idNacionalidad);
                    Session["dtAmbos"] = dt;
                    gvPacientes.DataSource = dt;
                    gvPacientes.DataBind();
                    Session["contiene"] = 3;

                    txtDNI.Text = "";
                    ddlNacionalidad.SelectedValue = "0";
                    lblError_Filtrar.Text = "";

                }
                else
                {
                    gvPacientes.DataSource = null;
                    gvPacientes.DataBind();
                    lblError_Filtrar.Text = "No existe el paciente/fue dado de baja.";
                }
            }
        }

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            gvPacientes.DataSource = NegP.getPacientes();
            gvPacientes.DataBind();
            Session["contiene"] = 4;

            lblError_Filtrar.Text = "";

            txtDNI.Text = "";
            ddlNacionalidad.SelectedValue = "0";
        }
        protected void btnModificar_Command1(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Modificar")
            {
                string commandArgument = e.CommandArgument.ToString();
                string[] values = commandArgument.Split(',');

                string dni = values[0];
                int idNacionalidad = int.Parse(values[1]);

                Paciente paciente = NegP.getPacienteAModificar(dni, idNacionalidad);

                lblDNI2_M.Text = paciente.getDni().ToString();
                ddlNacionalidad_M.SelectedValue = idNacionalidad.ToString();
                txtNombre_M.Text = paciente.getNombre().ToString();
                txtApellido_M.Text = paciente.getApellido().ToString();
                ddlSexo_M.SelectedValue = paciente.getGenero().ToString();

                txtFechaNacimiento_M.Text = paciente.getFechaNacimiento().ToString("yyyy-MM-dd");

                int idProvincia = negL.getIdProvincia(Convert.ToInt32(paciente.getLocalidad().ToString()));
                ddlProvincia_M.SelectedValue = idProvincia.ToString();

                CargarLocalidad(ddlLocalidad_M, idProvincia);
                ddlLocalidad_M.SelectedValue = paciente.getLocalidad().ToString();

                txtDireccion_M.Text = paciente.getDireccion().ToString();
                txtEmail_M.Text = paciente.getEmail().ToString();
                txtTelefono_M.Text = paciente.getTelefono().ToString();

                chkEstado_M.Checked = paciente.getEstado() ? true : false;


                lblCatch.Text = "";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "showModal", "showModal();", true);
            }

        }

        protected void ddlProvincia_M_SelectedIndexChanged(object sender, EventArgs e)
        {

            int idProvinciaSeleccionada = int.Parse(ddlProvincia_M.SelectedValue);
            CargarLocalidades(idProvinciaSeleccionada);

        }

        protected void btnConfirmarEliminado_Click(Object sender, EventArgs e)
        {
            bool borro = NegP.bajaPaciente(txtDNI_E.Text, int.Parse(ddlNacionalidad_E.SelectedValue));

            gvPacientes.DataSource = NegP.getPacientes();
            gvPacientes.DataBind();

        }

        protected void btnModificarM_Click(Object sender, EventArgs e)
        {
            try
            {

                bool modifico = NegP.ModificarPaciente(lblDNI2_M.Text, txtNombre_M.Text, txtApellido_M.Text, int.Parse(ddlSexo_M.SelectedValue), Convert.ToDateTime(txtFechaNacimiento_M.Text),
                    int.Parse(ddlNacionalidad_M.SelectedValue), int.Parse(ddlLocalidad_M.SelectedValue), txtDireccion_M.Text, txtEmail_M.Text, txtTelefono_M.Text, chkEstado_M.Checked);

                lblCatch.Text = "";

                gvPacientes.DataSource = NegP.getPacientes();
                gvPacientes.DataBind();

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

        protected void btnEliminar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                string commandArgument = e.CommandArgument.ToString();
                string[] values = commandArgument.Split(',');

                string dni = values[0];
                int idNacionalidad = int.Parse(values[1]);

                Paciente paciente = NegP.getPacienteAModificar(dni, idNacionalidad);

                txtDNI_E.Text = paciente.getDni().ToString();
                ddlNacionalidad_E.SelectedValue = idNacionalidad.ToString();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "showDeleteModal", "showDeleteModal();", true);
            }
        }

        protected void gvPacientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int contiene = Convert.ToInt32(Session["contiene"]);
            gvPacientes.PageIndex = e.NewPageIndex;

            switch (contiene)
            {
                case 1:
                    //filtra por dni
                    gvPacientes.DataSource = Session["dtDNI"];
                    break;
                case 2:
                    //filtra por nacionalidad
                    gvPacientes.DataSource = Session["dtNacionalidad"];
                    break;
                case 3:
                    //filtra por dni y nacionalidad
                    gvPacientes.DataSource = Session["dtAmbos"];
                    break;
                case 4:
                    //filtra todos los pacientes
                    gvPacientes.DataSource = NegP.getPacientes();
                    break;
            }

            gvPacientes.DataBind();
        }

        protected void gvPacientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var idGenero = DataBinder.Eval(e.Row.DataItem, "Id_Genero");
                var idLocalidad = DataBinder.Eval(e.Row.DataItem, "Id_Localidad");
                var idNacionalidad = DataBinder.Eval(e.Row.DataItem, "Id_Nacionalidad");

                Label lblSexo = (Label)e.Row.FindControl("lblGenero");
                Label lblLocalidad = (Label)e.Row.FindControl("lblLocalidad");
                Label lblProvincia = (Label)e.Row.FindControl("lblProvincia");
                Label lblNacionalidad = (Label)e.Row.FindControl("lblNacionalidad");
                CheckBox chkEstado = (CheckBox)e.Row.FindControl("chkEstado");
                Button btnEliminar = (Button)e.Row.FindControl("btnEliminar");

                if (lblSexo != null && idGenero != DBNull.Value)
                {
                    // Convertir el valor de "Id_Genero" al enum Genero
                    if (Enum.IsDefined(typeof(Genero), idGenero))
                    {
                        // Convertimos el Id_Genero a su valor enum
                        Genero generoEnum = (Genero)Enum.ToObject(typeof(Genero), idGenero);
                        lblSexo.Text = generoEnum.ToString();
                    }
                    else
                    {
                        lblSexo.Text = "No especificado";
                    }
                }
                else
                {
                    lblSexo.Text = "No disponible";
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

                if (lblNacionalidad != null && idNacionalidad != DBNull.Value)
                {
                    string descripcionNacionalidad = negn.getDescripcionNacionalidad(Convert.ToInt32(idNacionalidad));

                    lblNacionalidad.Text = !string.IsNullOrEmpty(descripcionNacionalidad) ? descripcionNacionalidad : "No especificada";
                }
                else
                {
                    lblNacionalidad.Text = "No Disponible";
                }

                if(!chkEstado.Checked)
                {
                    btnEliminar.Enabled = false;
                }


            }

        }
    }
}