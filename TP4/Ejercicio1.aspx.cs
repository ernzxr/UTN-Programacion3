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

            rfvProvinciaInicio.ForeColor = System.Drawing.Color.Red;
            rfvLocalidadInicio.ForeColor = System.Drawing.Color.Red;
            rfvProvinciaDestino.ForeColor = System.Drawing.Color.Red;
            rfvLocalidadDestino.ForeColor = System.Drawing.Color.Red;


            if (!IsPostBack)
            {
                DataSet ds = new DataSet();

                // Se establece conexion con base de datos
                SqlConnection cn = new SqlConnection(rutaDB);
                cn.Open();

                CargarDataSet(ds, cn);

                CargarDropDownLists(ds);

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

            adapt.SelectCommand = new SqlCommand("SELECT *FROM Localidades", cn);
            adapt.Fill(ds, "Localidades");

            // Consultar y cargar la tabla Localidades
            // Se puede utilizar SelectCommand.CommandText para cambiar la consulta
            // ...
        }

        void CargarDropDownLists(DataSet ds)
        {
            // Se carga el DropDownList de ProvinciasInicio
            ddlProvinciaInicio.DataSource = ds.Tables["Provincias"];
            ddlProvinciaInicio.DataTextField = "NombreProvincia";
            ddlProvinciaInicio.DataValueField = "IdProvincia";
            ddlProvinciaInicio.DataBind();

            // Agrego  un item para que el usuario seleccione una provincia
            ddlProvinciaInicio.Items.Insert(0, new ListItem("-Seleccione una opcion-", "0"));

            // Limpiar el DropDownList de localidades hasta que se seleccione una provincia
            ddlLocalidadInicio.Items.Clear();
            ddlLocalidadInicio.Items.Insert(0, new ListItem("-Debe seleccionar una provincia primero-", "0"));

            // Cargar el resto de DDLs
            // ...
        }
        protected void ddlProvinciaInicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            string rutaDB = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Viajes;Integrated Security=True";
            SqlConnection cn = new SqlConnection(rutaDB);

            try
            {
                cn.Open(); // intentar abrir la conexion

                // obtener el id de la provincia seleccionada
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

                    // Realiza la consulta para otras provincias
                    SqlCommand cmd2 = new SqlCommand("SELECT * FROM Provincias WHERE IdProvincia <> @IdProvincia", cn);
                    cmd2.Parameters.AddWithValue("@IdProvincia", idProvincia);

                    SqlDataAdapter adap2 = new SqlDataAdapter(cmd2);
                    DataSet ds2 = new DataSet();
                    adap2.Fill(ds2, "Provincias");

                    // Cargar el ddlProvinciaDestino con las otras provincias
                    ddlProvinciaDestino.DataSource = ds2.Tables["Provincias"];
                    ddlProvinciaDestino.DataTextField = "NombreProvincia";
                    ddlProvinciaDestino.DataValueField = "IdProvincia";
                    ddlProvinciaDestino.DataBind();

                    ddlProvinciaDestino.Items.Insert(0, new ListItem("Seleccione una provincia", "0"));
                }
                else
                {
                    // Si no hay una provincia seleccionada, limpiar las localidades
                    ddlLocalidadInicio.Items.Clear();
                    ddlLocalidadInicio.Items.Insert(0, new ListItem("Seleccione una provincia primero", "0"));

                    // Limpiar ddlProvinciaDestino
                    ddlProvinciaDestino.Items.Clear();
                    ddlProvinciaDestino.Items.Insert(0, new ListItem("Seleccione una provincia", "0"));
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
