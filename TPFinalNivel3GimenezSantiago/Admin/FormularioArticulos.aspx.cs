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
        public bool ConfirmarEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            MarcasCategorias ObtenerMarcasCategorias = new MarcasCategorias();
            ConfirmarEliminacion = false;
            try
            {
                Seguridad.ValidarAdmin();
                //configuración inicial de la pantalla 
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

                //configuración si estamos modificando
                string id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    ArticulosNegocio negocio = new ArticulosNegocio(new AccesoDatos());
                    List<Articulo> lista = negocio.ObtenerArticulos(id);
                    Articulo seleccionado = lista[0];

                    //precargar todos los campos
                    txtId.Text = seleccionado.Id.ToString();
                    txtCodigo.Text = seleccionado.Codigo;
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtPrecio.Text = seleccionado.Precio.ToString("N2", CultureInfo.GetCultureInfo("es-AR"));
                    txtImagenUrl.Text = seleccionado.ImagenUrl;
                    if (!string.IsNullOrEmpty(seleccionado.ImagenUrl))
                    {
                        imgProducto.ImageUrl = seleccionado.ImagenUrl;
                    }
                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
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
                if (Request.QueryString["Id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text);
                }
                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.ImagenUrl = txtImagenUrl.Text;
                nuevo.Precio = Decimal.Parse(txtPrecio.Text.ToString());
                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);

                if (Request.QueryString["Id"] != null)
                {
                    negocio.ModificarArticuloConSP(nuevo);
                }
                else
                {
                    negocio.InsertarArticuloConSP(nuevo);
                }
                Response.Redirect("GestionArticulos.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmarEliminacion = true;
        }

        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmarEleminacion.Checked)
                {
                    ArticulosNegocio negocio = new ArticulosNegocio(new AccesoDatos());
                    negocio.eliminar(int.Parse(txtId.Text));
                    Response.Redirect("GestionArticulos.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }
        }
    }

}

