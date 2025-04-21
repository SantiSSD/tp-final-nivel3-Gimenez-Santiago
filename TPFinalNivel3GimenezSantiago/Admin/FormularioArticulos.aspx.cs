using CatalogoArticulos.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CatalogoArticulos_AccesoDatos;

namespace TPFinalNivel3GimenezSantiago.Admin
{
    public partial class FormularioArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MarcasCategorias ObtenerMarcasCategorias = new MarcasCategorias();
            try
            {
                if (!IsPostBack)
                {
                    ddlCategoria.DataSource = ObtenerMarcasCategorias.ObtenerCategorias();
                    ddlMarca.DataSource = ObtenerMarcasCategorias.ObtenerMarcas();
                    ddlMarca.DataBind();
                    ddlCategoria.DataBind();

                }
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex);
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgProducto.ImageUrl = txtImagenUrl.Text;
        }
    }
}