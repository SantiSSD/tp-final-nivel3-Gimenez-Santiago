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
        public bool FiltroAvanzado { get; set; }
        public List<Articulo> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            ArticulosNegocio negocio = new ArticulosNegocio(new AccesoDatos());
            if (!IsPostBack)
            {
                ListaArticulos = negocio.ObtenerArticulosConSP();
                Session["listaArticulos"] = ListaArticulos;
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
            string id = ((Button)sender).CommandArgument;
            Response.Redirect($"DetalleProducto.aspx?Id={id}");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticulosNegocio negocio = new ArticulosNegocio(new AccesoDatos());
                repArticulos.DataSource = negocio.filtrar(ddlCampo.SelectedItem.Text,
                ddlCriterio.SelectedItem.Text, txtFiltroAvanzado.Text);
                repArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            if (ddlCampo.SelectedItem.Text == "Nombre")
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Terminar con");
            }
            else if (ddlCampo.SelectedItem.Text == "Marca")
            {

                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Terminar con");
            }

            else 
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Terminar con");
            }
        }
        

        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = chkAvanzado.Checked;
            txtfiltro.Enabled = !FiltroAvanzado;

        }

        protected void txtfiltro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> lista = (List<Articulo>)Session["listaArticulos"];
            List<Articulo> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtfiltro.Text.ToUpper()));
            repArticulos.DataSource = listaFiltrada;
            repArticulos.DataBind();

        }
    }
}