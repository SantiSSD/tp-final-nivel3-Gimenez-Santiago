using CatalogoArticulos.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3GimenezSantiago.Admin
{
	public partial class GestionProductos : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            ArticulosNegocio negocio = new ArticulosNegocio(new AccesoDatos());
            dgvArticulos.DataSource = negocio.ObtenerArticulosConSP();
            dgvArticulos.DataBind();
        }
	}
}