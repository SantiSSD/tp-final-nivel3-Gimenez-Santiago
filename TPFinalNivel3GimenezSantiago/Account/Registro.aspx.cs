using CatalogoArticulos_AccesoDatos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3GimenezSantiago.Account
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtContraseña.Text != txtConfirmarContraseña.Text)
                {
                    MostrarError("Las contraseñas no coinciden");
                    return;
                }

                UsuarioNegocio negocio = new UsuarioNegocio();

                Usuario nuevoUsuario = new Usuario(
                  email: txtEmail.Text,
                  pass: txtContraseña.Text
                    );

                negocio.RegistrarUsuario(nuevoUsuario);
                Session["registroExitoso"] = true;
                Response.Redirect("~/Account/Login.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("~/Validaciones/Error.aspx", false);
            }
        }
        private void MostrarError(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "error",
                $"alert('{mensaje}');", true);
        }
    }
}