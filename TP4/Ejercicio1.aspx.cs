using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP4
{
    public partial class Ejercicio1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            string rutaDB = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Viajes;Integrated Security=True";

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
                DataSet ds = new DataSet();

                // Se establece conexion con base de datos
                SqlConnection cn = new SqlConnection(rutaDB);
                cn.Open();

                CargarDataSet(ds, cn);

                CargarDropDownLists(ds);

                ViewState["DataSet"] = ds;

                // Se cierra la conexion
                cn.Close();
            }
        }

        void CargarDataSet(DataSet ds, SqlConnection cn)
        {
            SqlDataAdapter adapt = new SqlDataAdapter();

            // Consultar y cargar la tabla Provincias
            adapt.SelectCommand = new SqlCommand("SELECT * FROM Provincias", cn);
            adapt.Fill(ds, "Provincias");

            adapt.SelectCommand.CommandText = "SELECT *FROM Localidades";
            adapt.Fill(ds, "Localidades");
        }

        void CargarDropDownLists(DataSet ds)
        {
            // Se carga el DropDownList de ProvinciasInicio
            ddlProvinciaInicio.DataSource = ds.Tables["Provincias"];
            ddlProvinciaInicio.DataTextField = "NombreProvincia";
            ddlProvinciaInicio.DataValueField = "IdProvincia";
            ddlProvinciaInicio.DataBind();

            // Leyendas para los ddl
            ddlProvinciaInicio.Items.Insert(0, new ListItem("Seleccione un inicio", "0"));
            ddlLocalidadInicio.Items.Insert(0, new ListItem("Debe seleccionar un inicio", "0"));
            ddlProvinciaDestino.Items.Insert(0, new ListItem("Primero seleccione un inicio", "0"));
            ddlLocalidadDestino.Items.Insert(0, new ListItem("Seleccione un destino", "0"));
        }

        protected void ddlProvinciaInicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            string rutaDB = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Viajes;Integrated Security=True";
            SqlConnection cn = new SqlConnection(rutaDB);

            try
            {
                cn.Open(); // intentar abrir la conexion

                // obtener el id de la provincia seleccionada de inicio
                int idProvincia = int.Parse(ddlProvinciaInicio.SelectedValue);

                if (idProvincia != 0) // solo cargar las localidades si se seleccionó una provincia
                {
                    // consulta SQL para obtener las localidades filtradas por provincia
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Localidades WHERE IdProvincia = @IdProvincia", cn);
                    cmd.Parameters.AddWithValue("@IdProvincia", idProvincia);

                    // llenar un DataSet con los resultados
                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapt.Fill(ds, "Localidades");

                    // cargar el DropDownList con las localidades de inicio
                    ddlLocalidadInicio.DataSource = ds.Tables["Localidades"];
                    ddlLocalidadInicio.DataTextField = "NombreLocalidad";
                    ddlLocalidadInicio.DataValueField = "IdLocalidad";
                    ddlLocalidadInicio.DataBind();

                    // agregar un item para seleccionar
                    ddlLocalidadInicio.Items.Insert(0, new ListItem("Seleccione una localidad", "0"));

                    // Realiza la consulta para provincias destino
                    adapt.SelectCommand.CommandText = "SELECT * FROM Provincias WHERE IdProvincia <> @IdProvincia";
                    adapt.Fill(ds, "Provincias");

                    // Cargar el ddlProvinciaDestino con las otras provincias
                    ddlProvinciaDestino.DataSource = ds.Tables["Provincias"];
                    ddlProvinciaDestino.DataTextField = "NombreProvincia";
                    ddlProvinciaDestino.DataValueField = "IdProvincia";
                    ddlProvinciaDestino.DataBind();

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
            string rutaDB = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Viajes;Integrated Security=True";
            SqlConnection cn = new SqlConnection(rutaDB);
            try
            {
                cn.Open(); // intentar abrir la conexion

                // obtener el id de la provincia seleccionada de destino
                int idProvincia =int.Parse(ddlProvinciaDestino.SelectedValue);

                if (idProvincia != 0) 
                {
                    // consulta SQL para obtener las localidades filtradas por provincia
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Localidades WHERE IdProvincia = @IdProvincia", cn);
                    cmd.Parameters.AddWithValue("@IdProvincia", idProvincia);

                    // llenar un DataSet con los resultados
                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapt.Fill(ds, "Localidades");

                    // cargar el DropDownList con las localidades de destino
                    ddlLocalidadDestino.DataSource = ds.Tables["Localidades"];
                    ddlLocalidadDestino.DataTextField = "NombreLocalidad";
                    ddlLocalidadDestino.DataValueField = "IdLocalidad";
                    ddlLocalidadDestino.DataBind();

                    // agregar un item para seleccionar
                    ddlLocalidadDestino.Items.Insert(0, new ListItem("Seleccione Localidad", "0"));

                   
                   ddlLocalidadDestino.Items.Insert(0, new ListItem("Debe seleccionar un destino", "0"));

                    
                    
                    
                                   




                    ddlLocalidadDestino.Enabled = true;
                }
                else
                {
                    ddlLocalidadDestino.Enabled = false;

                    // Si no hay una provincia seleccionada
                    // limpiar las localidades de destino

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
