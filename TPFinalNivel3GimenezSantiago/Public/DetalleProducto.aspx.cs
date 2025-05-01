using CatalogoArticulos.AccesoDatos;
using CatalogoArticulos_AccesoDatos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3GimenezSantiago.Public
{
    public partial class DetalleProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    CargarListasDesplegables();
                    if (Request.QueryString["Id"] != null)
                    {
                        int idArticulo = int.Parse(Request.QueryString["Id"]);
                        CargarProducto(idArticulo);
                        
                    }
                    else
                    {
                        Response.Redirect("Catalogo.aspx");
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        private void CargarListasDesplegables()
        {
            MarcasCategorias marcaNegocio = new MarcasCategorias();
            ddlMarca.DataSource = marcaNegocio.ObtenerMarcas();
            ddlMarca.DataTextField = "Descripcion";
            ddlMarca.DataValueField = "Id";
            ddlMarca.DataBind();

            MarcasCategorias CategoriaNegocio = new MarcasCategorias();
            ddlCategoria.DataSource = CategoriaNegocio.ObtenerCategorias();
            ddlCategoria.DataTextField = "Descripcion";
            ddlCategoria.DataValueField = "Id";
            ddlCategoria.DataBind();
        }

        private void CargarProducto(int id)
        {
            Articulo seleccionado = null;

            if (Session["ListaArticulos"] != null)
            {
                List<Articulo> lista = (List<Articulo>)Session["ListaArticulos"];
                seleccionado = lista.Find(x => x.Id == id);
            }
            if (seleccionado != null)
            {
                txtCodigo.Text = seleccionado.Codigo;
                txtNombre.Text = seleccionado.Nombre;
                txtDescripcion.Text = seleccionado.Descripcion;
                txtPrecio.Text = seleccionado.Precio.ToString("N2");
                string urlImagen = string.IsNullOrWhiteSpace(seleccionado.ImagenUrl) ?
                    "https://images.wondershare.com/repairit/aticle/2021/07/resolve-images-not-showing-problem-1.jpg" :
                    seleccionado.ImagenUrl;

                imgArticulo.ImageUrl = urlImagen;



                ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                DeshabilitarControles();
            }
            else
            {
                Response.Redirect("Catalogo.aspx");
            }
        }
        private void DeshabilitarControles()
        {
            txtCodigo.Enabled = false;
            txtNombre.Enabled = false;
            txtDescripcion.Enabled = false;
            txtPrecio.Enabled = false;
            ddlMarca.Enabled = false;
            ddlCategoria.Enabled = false;
        }
    }

}
