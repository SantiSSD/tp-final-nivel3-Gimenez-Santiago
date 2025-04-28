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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                Usuario usuario = negocio.Loguear(txtEmail.Text, txtContraseña.Text);
                if (usuario != null)
                {
                    //Login Exitoso
                    Session.Add("usuario", usuario);
                    Response.Redirect("~/Account/MiPerfil.aspx", false);
                }
                else
                {
                    Session.Add("error", "Usuario o Contraseña Incorrectos");
                    Response.Redirect("~/Validaciones/Error.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("~/Validaciones/Error.aspx", false);
            }

        }
    }
}