using CatalogoArticulos_AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3GimenezSantiago
{
	public partial class MiMaster : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{

            if (!IsPostBack)
			{
				VerificarEstadoUsuario();
				VerificarAdmin();
			}
		}
		private void VerificarAdmin() 
		{
			liGestionArticulos.Visible = Seguridad.EsAdmin(Session);
		}


		protected void btnSalir_Click(object sender, EventArgs e)
		{
			Session.Clear();
			Session.Abandon();
			Response.Redirect("~/Account/Login.aspx");
		}

		private void VerificarEstadoUsuario()
		{
			if (Session["usuario"] != null)
			{
				//usuario logueado
				pnlNoLogueado.Visible = false;
				pnlLogueado.Visible = true;
			}
			else
			{
				pnlNoLogueado.Visible = true;
				pnlLogueado.Visible = false;
			}
		}
	}
}