using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        string test = "";
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            test = txtPassword.Text;
            Session["TipoUsuario"] = txtPassword.Text;
            if (test == "")
            {
                Session.Clear();
            }

        }

        protected void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}