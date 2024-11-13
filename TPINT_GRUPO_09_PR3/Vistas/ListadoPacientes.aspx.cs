using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
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

            if (!IsPostBack)
            {
                CargarNacionalidad(ddlNacionalidad);
                CargarNacionalidad(ddlNacionalidad_M);
                CargarNacionalidad(ddlNacionalidad_E);
                CargarSexo(ddlSexo_M);
                CargarProvincia(ddlProvincia_M);
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

        public void CargarLocalidad(DropDownList ddl, DataRow paciente)
        {
            DataTable Localidad = negL.getTablaLocalidad(BuscarProvincia(paciente));
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

        public int BuscarSexo(DataRow paciente)
        {
            int idSexo = 0;

            foreach (ListItem item in ddlSexo_M.Items)
            {
                if (item.Text == paciente["Sexo"].ToString())
                {
                    idSexo = int.Parse(item.Value);
                    break;
                }
            }

            return idSexo;
        }

        public int BuscarProvincia(DataRow paciente)
        {
            int idProvincia = 0;

            foreach (ListItem item in ddlProvincia_M.Items)
            {
                if (item.Text == paciente["Provincia"].ToString())
                {
                    idProvincia = int.Parse(item.Value);
                    break;
                }
            }

            return idProvincia;
        }

        public int BuscarLocalidad(DataRow paciente)
        {
            int idLocalidad = 0;

            foreach (ListItem item in ddlLocalidad_M.Items)
            {
                if (item.Text == paciente["Localidad"].ToString())
                {
                    idLocalidad = int.Parse(item.Value);
                    break;
                }
            }

            return idLocalidad;
        }


        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string dni = txtDNI.Text;
            int idNacionalidad = int.Parse(ddlNacionalidad.SelectedValue);

            if (NegP.existePaciente(dni, idNacionalidad))
            {
                gvPacientes.DataSource = NegP.getPaciente(dni, idNacionalidad);
                gvPacientes.DataBind();

                txtDNI.Text = "";
                ddlNacionalidad.SelectedValue = "0";

            }
        }

        protected void btnMostrarTodo_Click(object sender, EventArgs e)
        {
            gvPacientes.DataSource = NegP.getPacientes();
            gvPacientes.DataBind();

            txtDNI.Text = "";
            ddlNacionalidad.SelectedValue = "0";
        }

        protected void btnModificar_Click(Object sender, EventArgs e)
        {
            
            Button btn = (Button)sender;

            string commandArgument = btn.CommandArgument;

            string[] values = commandArgument.Split(',');

            string dni = values[0];
            string nacionalidad = values[1];
            int idNacionalidad = 0;


            foreach (ListItem item in ddlNacionalidad.Items)
            {
                if (item.Text == nacionalidad)
                {
                    idNacionalidad = int.Parse(item.Value);
                    break;
                }
            }

            DataTable dtPaciente = NegP.getPaciente(dni, idNacionalidad);

            if(dtPaciente != null && dtPaciente.Rows.Count > 0)
            {
                DataRow paciente = dtPaciente.Rows[0];

                txtDNI_M.Text = paciente["DNI"].ToString();
                ddlNacionalidad_M.SelectedValue = idNacionalidad.ToString();
                txtNombre_M.Text = paciente["Nombre"].ToString();
                txtApellido_M.Text = paciente["Apellido"].ToString();
                ddlSexo_M.SelectedValue = BuscarSexo(paciente).ToString();

                DateTime fechaNacimiento = Convert.ToDateTime(paciente["Fecha_De_Nacimiento"]);
                txtFechaNacimiento_M.Text = fechaNacimiento.ToString("yyyy-MM-dd");
                ddlProvincia_M.SelectedValue = BuscarProvincia(paciente).ToString();

                CargarLocalidad(ddlLocalidad_M, paciente);
                ddlLocalidad_M.SelectedValue = BuscarLocalidad(paciente).ToString();

                txtDireccion_M.Text = paciente["Direccion"].ToString();
                txtEmail_M.Text = paciente["Email"].ToString();
                txtTelefono_M.Text = paciente["Telefono"].ToString();

                bool chequeado = Convert.ToBoolean(paciente["Estado"]);
                chkEstado_M.Checked = chequeado ? true : false;

            }
 
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showModal", "showModal();", true);
        }

        protected void ddlProvincia_M_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProvincia = int.Parse(ddlProvincia_M.SelectedValue);
            CargarLocalidades(idProvincia);
        }

        protected void btnEliminar_Click(Object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            string commandArgument = btn.CommandArgument;

            string[] values = commandArgument.Split(',');

            string dni = values[0];
            string nacionalidad = values[1];
            int idNacionalidad = 0;


            foreach (ListItem item in ddlNacionalidad.Items)
            {
                if (item.Text == nacionalidad)
                {
                    idNacionalidad = int.Parse(item.Value);
                    break;
                }
            }

            DataTable dtPaciente = NegP.getPaciente(dni, idNacionalidad);

            if (dtPaciente != null && dtPaciente.Rows.Count > 0)
            {
                DataRow paciente = dtPaciente.Rows[0];

                txtDNI_E.Text = paciente["DNI"].ToString();
                ddlNacionalidad_E.SelectedValue = idNacionalidad.ToString();

            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "showDeleteModal", "showDeleteModal();", true);
        }

        protected void btnConfirmDelete_Click(Object sender, EventArgs e)
        {
            bool borro = NegP.bajaPaciente(txtDNI_E.Text, int.Parse(ddlNacionalidad_E.SelectedValue));

            gvPacientes.DataSource = NegP.getPacientes();
            gvPacientes.DataBind();
        }

        protected void btnModificarM_Click(Object sender, EventArgs e)
        {
            bool modifico = NegP.ModificarPaciente(txtDNI_M.Text, txtNombre_M.Text, txtApellido_M.Text, int.Parse(ddlSexo_M.SelectedValue), Convert.ToDateTime(txtFechaNacimiento_M.Text),
                int.Parse(ddlNacionalidad_M.SelectedValue), int.Parse(ddlLocalidad_M.SelectedValue), txtDireccion_M.Text, txtEmail_M.Text, txtTelefono_M.Text, chkEstado_M.Checked);
    
            gvPacientes.DataSource = NegP.getPacientes();
            gvPacientes.DataBind();
        
        }
    }
}