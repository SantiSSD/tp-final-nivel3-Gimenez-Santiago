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

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioArticulos.aspx?" + id);
        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataBind();

        }
    }
}