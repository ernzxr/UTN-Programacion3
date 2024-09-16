using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP4
{
    public partial class Ejercicio1 : System.Web.UI.Page
    {
        private static string rutaDB = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Viajes;Integrated Security=True";
        private SqlConnection cn = new SqlConnection(rutaDB);
        private DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            lblInicio.Font.Name = "Arial";
            lblInicio.Font.Size = FontUnit.Point(15);
            lblInicio.Font.Underline = true;

            lblProvInicio.Font.Name = "Arial";
            lblProvInicio.Font.Size = FontUnit.Point(10);
            lblProvInicio.Font.Bold = true;

            lblLocalidadInicio.Font.Name = "Arial";
            lblLocalidadInicio.Font.Size = FontUnit.Point(10);
            lblLocalidadInicio.Font.Bold = true;

            lblFinal.Font.Name = "Arial";
            lblFinal.Font.Size = FontUnit.Point(15);
            lblFinal.Font.Underline = true;

            lblProvFinal.Font.Name = "Arial";
            lblProvFinal.Font.Size = FontUnit.Point(10);
            lblProvFinal.Font.Bold = true;

            lblLocalidadFinal.Font.Name = "Arial";
            lblLocalidadFinal.Font.Size = FontUnit.Point(10);
            lblLocalidadFinal.Font.Bold = true;

            if (!IsPostBack)
            {

                // Se establece conexion con base de datos
                
                cn.Open();

                CargarDataSet(ds, cn, "SELECT * FROM Provincias", "Provincias");

                CargarDropDownLists(ds, ddlProvinciaInicio, "Provincias", "NombreProvincia", "IdProvincia");

                ddlProvinciaInicio.Items.Insert(0, new ListItem("Seleccione un inicio", "0"));
                ddlLocalidadInicio.Items.Insert(0, new ListItem("Debe seleccionar un inicio", "0"));
                ddlProvinciaDestino.Items.Insert(0, new ListItem("Primero seleccione un inicio", "0"));
                ddlLocalidadDestino.Items.Insert(0, new ListItem("Seleccione un destino", "0"));

                ViewState["DataSet"] = ds;

                // Se cierra la conexion
                cn.Close();
            }
        }

        void CargarDataSet(DataSet ds, SqlConnection cn, string cmd, string tabla)
        {
            SqlDataAdapter adapt = new SqlDataAdapter();

            adapt.SelectCommand = new SqlCommand(cmd, cn);
            adapt.Fill(ds, tabla);
        }

        void FiltrarCampos(DataSet ds, SqlConnection cn, string comando, int parametro, string tabla)
        {  
            SqlCommand cmd = new SqlCommand(comando, cn);
            cmd.Parameters.AddWithValue("@IdProvincia", parametro);

            // llenar un DataSet con los resultados
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            adapt.Fill(ds, tabla);
        }

        void CargarDropDownLists(DataSet ds, DropDownList ddl, string tabla, string item, string value)
        {
            ddl.DataSource = ds.Tables[tabla];
            ddl.DataTextField = item;
            ddl.DataValueField = value;
            ddl.DataBind();
        }

        protected void ddlProvinciaInicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cn.Open(); // intentar abrir la conexion

                // obtener el id de la provincia seleccionada de inicio
                int idProvincia = int.Parse(ddlProvinciaInicio.SelectedValue);

                if (idProvincia != 0) // solo cargar las localidades si se seleccionó una provincia
                {
                    // consulta SQL para obtener las localidades filtradas por provinci
                    FiltrarCampos(ds, cn, "SELECT * FROM Localidades WHERE IdProvincia = @IdProvincia", idProvincia, "Localidades");

                    // cargar el DropDownList con las localidades de inicio
                    CargarDropDownLists(ds, ddlLocalidadInicio, "Localidades", "NombreLocalidad", "IdLocalidad");

                    // agregar un item para seleccionar
                    ddlLocalidadInicio.Items.Insert(0, new ListItem("Seleccione una localidad", "0"));

                    // Realiza la consulta para provincias destino

                    FiltrarCampos(ds, cn, "SELECT * FROM Provincias WHERE IdProvincia <> @IdProvincia", idProvincia, "Provincias");

                    // Cargar el ddlProvinciaDestino con las otras provincias
                    CargarDropDownLists(ds, ddlProvinciaDestino, "Provincias", "NombreProvincia", "IdProvincia");

                    // Se cargan leyendas para los ddl de destino
                    ddlLocalidadDestino.Items.Clear();
                    ddlProvinciaDestino.Items.Insert(0, new ListItem("Seleccione un destino", "0"));
                    ddlLocalidadDestino.Items.Insert(0, new ListItem("Debe seleccionar un destino", "0"));

                    ddlProvinciaDestino.Enabled = true;
                }
                else
                {
                    ddlProvinciaDestino.Enabled = false;
                    ddlLocalidadDestino.Enabled = false;

                    // Si no hay una provincia seleccionada
                    // limpiar las localidades y provincias de destino y las localidades de inicio
                    ddlLocalidadInicio.Items.Clear();
                    ddlProvinciaDestino.Items.Clear();
                    ddlLocalidadDestino.Items.Clear();

                    ddlLocalidadInicio.Items.Insert(0, new ListItem("Debe seleccionar un inicio", "0"));
                    ddlProvinciaDestino.Items.Insert(0, new ListItem("Primero seleccione un inicio", "0"));
                    ddlLocalidadDestino.Items.Insert(0, new ListItem("Seleccione un destino", "0"));
                }
            }
            catch (SqlException sqlEx)
            {
                // manejo de errores especificos de SQL (como problemas de conexion o consultas)
                lblError.Text = "Ocurrió un problema con la base de datos: " + sqlEx.Message;
            }
            catch (FormatException formatEx)
            {
                // manejo de errores de formato (por ejemplo, si falla el Parse del ID)
                lblError.Text = "Error en el formato de los datos: " + formatEx.Message;
            }
            catch (Exception ex)
            {
                // manejo de cualquier otro tipo de error
                lblError.Text = "Ocurrió un error: " + ex.Message;
            }
            finally
            {
                // asegurarse de cerrar la conexion a la base de datos siempre, aunque ocurra un error
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
            }
        }

        protected void ddlProvinciaDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cn.Open(); // intentar abrir la conexion

                // obtener el id de la provincia seleccionada de destino
                int idProvincia = int.Parse(ddlProvinciaDestino.SelectedValue);

                if (idProvincia != 0)
                {
                    // consulta SQL para obtener las localidades filtradas por provincia
                
                    FiltrarCampos(ds, cn, "SELECT * FROM Localidades WHERE IdProvincia = @IdProvincia", idProvincia, "Localidades");

                    // cargar el DropDownList con las localidades de destino

                    CargarDropDownLists(ds, ddlLocalidadDestino, "Localidades", "NombreLocalidad", "IdLocalidad");

                    // agregar un item para seleccionar
                    ddlLocalidadDestino.Items.Insert(0, new ListItem("Seleccione una localidad", "0"));

                    ddlLocalidadDestino.Enabled = true;
                }
                else
                {
                    ddlLocalidadDestino.Enabled = false;

                    // Si no hay una provincia seleccionada
                    // limpiar las localidades de destino
                    ddlLocalidadDestino.Items.Clear();

                    ddlLocalidadDestino.Items.Insert(0, new ListItem("Debe seleccionar un destino", "0"));
                }
            }
            catch (SqlException sqlEx)
            {
                // manejo de errores especificos de SQL (como problemas de conexion o consultas)
                lblError.Text = "Ocurrió un problema con la base de datos: " + sqlEx.Message;
            }
            catch (FormatException formatEx)
            {
                // manejo de errores de formato (por ejemplo, si falla el Parse del ID)
                lblError.Text = "Error en el formato de los datos: " + formatEx.Message;
            }
            catch (Exception ex)
            {
                // manejo de cualquier otro tipo de error
                lblError.Text = "Ocurrió un error: " + ex.Message;
            }
            finally
            {
                // asegurarse de cerrar la conexion a la base de datos siempre, aunque ocurra un error
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
            }
        }
    }
}
