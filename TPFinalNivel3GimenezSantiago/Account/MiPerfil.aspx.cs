using CatalogoArticulos_AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3GimenezSantiago.Account
{
	public partial class MiPerfil : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            Seguridad.ValidarSession();

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}