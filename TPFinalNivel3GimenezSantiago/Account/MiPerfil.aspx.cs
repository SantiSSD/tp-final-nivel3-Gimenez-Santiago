using CatalogoArticulos.AccesoDatos;
using CatalogoArticulos_AccesoDatos;
using Dominio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;

namespace TPFinalNivel3GimenezSantiago.Account
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.SessionActiva(Session))
            {
                Response.Redirect("~/Account/Login.aspx", false);
                return;
            }
            if (!IsPostBack)
            {
                Usuario usuario = (Usuario)Session["usuario"];
                if (usuario != null)
                {

                    txtEmail.Text = usuario.Email;
                    txtNombre.Text = usuario.Nombre;
                    txtApellido.Text = usuario.Apellido;
                    string imagenUrl = !string.IsNullOrEmpty(usuario.ImagenPerfil) ? "~/Recursos/Images/" + usuario.ImagenPerfil : "https://us.123rf.com/450wm/koblizeek/koblizeek2208/koblizeek220800128/190320173-sin-s%C3%ADmbolo-de-vector-de-imagen-falta-el-icono-disponible-no-hay-galer%C3%ADa-para-este-marcador-de.jpg";
                    imgNuevoPerfil.ImageUrl = imagenUrl;
                }

            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = (Usuario)Session["usuario"];

                if (txtImagen.PostedFile != null && txtImagen.PostedFile.ContentLength > 0)
                {
                    string ruta = Server.MapPath("~/Recursos/Images/");
                    string nombreArchivo = $"perfil-{usuario.Id}.jpg";

                    txtImagen.PostedFile.SaveAs(ruta + nombreArchivo);
                    usuario.ImagenPerfil = nombreArchivo;

                    new ArticulosNegocio(new AccesoDatos()).Actualizar(usuario);
                    Session["usuario"] = usuario;
                }

                ActualizarImagenMaster(usuario.ImagenPerfil);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message.ToString());
                throw;
            }
        }
        private void ActualizarImagenMaster(string imagen)
        {
            Image img = (Image)Master.FindControl("imgPerfil");
            if (img != null)
            {
                img.ImageUrl = !string.IsNullOrEmpty(imagen)
                    ? $"~/Recursos/Images/{imagen}?t={DateTime.Now.Ticks}"
                    : "https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_960_720.png";
            }
        }
    }
}

