using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CatalogoArticulos;
using CatalogoArticulos.AccesoDatos;
using Dominio;
namespace TPFinalNivel3GimenezSantiago.Public
{
    public partial class Catalogo : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
                ArticulosNegocio negocio = new ArticulosNegocio(new AccesoDatos());
                ListaArticulos = negocio.ObtenerArticulosConSP();
            if (!IsPostBack)
            {
                repArticulos.DataSource = ListaArticulos;
                repArticulos.DataBind();
            }
        }
        public string GetImageUrl(object imagenUrl)
        {
            if (imagenUrl == null || string.IsNullOrEmpty(imagenUrl.ToString()))
            {
                return "/images/placeholder.jpg";
            }

            if (!Uri.TryCreate(imagenUrl.ToString(), UriKind.Absolute, out Uri uriResult))
                return "/images/placeholder.jpg";

            return imagenUrl.ToString();
        }

        protected void btnDetalle_Click(object sender, EventArgs e)
        {
            string valor = ((Button)sender).CommandArgument;
        }
    }
}