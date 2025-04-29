using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;
using static System.Collections.Specialized.BitVector32;

namespace CatalogoArticulos_AccesoDatos
{
   public static class Seguridad
    {
        public static void ValidarSession()
        {
            var session = HttpContext.Current.Session;
            if (session["usuario"] == null)
            {
                session["error"] = "Acceso no autorizado debes loguearte";
                HttpContext.Current.Response.Redirect("~/Validaciones/Error.aspx", false);
            }
        }

        public static void ValidarAdmin()
        {
            var session = HttpContext.Current.Session;
            if (session["usuario"] == null)
            {
                session["error"] = "Debes iniciar sesión";
                HttpContext.Current.Response.Redirect("~/Account/Login.aspx");
                return;
            }
            var usuario = session["usuario"] as Dominio.Usuario;
            if (usuario == null || !usuario.EsAdmin)
            {
                session["error"] = "Se requieren privilegios de administrador";
                HttpContext.Current.Response.Redirect("~/Default.aspx");
            }
        }
        public static bool EsAdmin(HttpSessionState session)
        {
            return session["usuario"] is Dominio.Usuario usuario && usuario.EsAdmin;
        }

    }
}
