using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
  
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; } 
        public string Pass { get; set; }
        public string Nombre { get; set; } = "";
        public string Apellido { get; set; } ="";
        public string ImagenPerfil { get; set; }
        public bool EsAdmin { get; set; }  

        // Constructor opcional para facilitar creación
        public Usuario(int id, string email, string pass, string nombre, string apellido, string imagenPerfil, bool esAdmin)
        {
            Id = id;
            Email = email;
            Pass = pass;
            Nombre = nombre;
            Apellido = apellido;
            ImagenPerfil = imagenPerfil;
            EsAdmin = esAdmin;
        }

        // Constructor para registro (sin ID)
        public Usuario(string email, string pass)
        {
            Email = email;
            Pass = pass;
            Nombre = "";
            Apellido = "";
            ImagenPerfil = "/Recursos/Imagenes/Perfiles/default.png";
            EsAdmin = false;
        }
    }
}
