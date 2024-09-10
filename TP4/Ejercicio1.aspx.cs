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

            // Cargar el resto de DDLs
            // ...
        }
    }
}