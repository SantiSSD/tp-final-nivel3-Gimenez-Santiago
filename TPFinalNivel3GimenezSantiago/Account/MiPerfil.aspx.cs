using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3GimenezSantiago.Account
{
	public partial class MiPerfil : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes loguearte para pasar");
                Response.Redirect("~/Validaciones/Error.aspx", false);
            }
        }
	}
}