using CatalogoArticulos.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CatalogoArticulos_AccesoDatos;
using Dominio;
using System.Globalization;

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
                    txtId.Enabled = false;
                    ddlCategoria.DataSource = ObtenerMarcasCategorias.ObtenerCategorias();
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataBind();


                    ddlMarca.DataSource = ObtenerMarcasCategorias.ObtenerMarcas();
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataBind();

                }
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex);
                throw;
            }
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgProducto.ImageUrl = txtImagenUrl.Text;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo nuevo = new Articulo();
                ArticulosNegocio negocio = new ArticulosNegocio(new AccesoDatos());
                string precioTexto = txtPrecio.Text.Replace(".", "").Replace(",", ".");
                decimal precio = decimal.Parse(precioTexto, CultureInfo.InvariantCulture);

                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Precio = precio;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.ImagenUrl = txtImagenUrl.Text;

                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);

                negocio.InsertarArticuloConSP(nuevo);
                Response.Redirect("GestionArticulos.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }
        }
    }
}
