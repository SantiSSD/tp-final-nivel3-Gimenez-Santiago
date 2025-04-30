using CatalogoArticulos_AccesoDatos;
using Dominio;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;

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
                ActualizarImagenPerfil();
            }


        }
        private void ActualizarImagenPerfil()
        {

            if (Session["usuario"] != null)
            {
                Usuario usuario = (Usuario)Session["usuario"];
                imgPerfil.ImageUrl = !string.IsNullOrEmpty(usuario.ImagenPerfil)
             ? "~/Recursos/Images/" + usuario.ImagenPerfil
             : "https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_960_720.png";
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