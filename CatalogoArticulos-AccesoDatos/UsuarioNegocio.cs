using CatalogoArticulos.AccesoDatos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
namespace CatalogoArticulos_AccesoDatos
{
    public class UsuarioNegocio
    {
        public Usuario Loguear(string email, string pass)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT Id, email, pass, nombre, apellido, urlImagenPerfil, admin " +
                         "FROM USERS " +
                         "WHERE email = @email AND pass = @pass";
                datos.setearConsulta(consulta);
                datos.setearParametro("@email", email);
                datos.setearParametro("@pass", pass);

                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Usuario usuario = new Usuario(

                        id: Convert.ToInt32(datos.Lector["Id"]),
                        email: datos.Lector["email"].ToString(),
                        pass: datos.Lector["pass"].ToString(),
                        nombre: datos.Lector["nombre"]?.ToString(),
                        apellido: datos.Lector["apellido"]?.ToString(),
                        imagenPerfil: datos.Lector["urlImagenPerfil"]?.ToString(),
                        esAdmin: Convert.ToBoolean(datos.Lector["admin"])
                        );
                    return usuario;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al loguear: " + ex.Message);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}
