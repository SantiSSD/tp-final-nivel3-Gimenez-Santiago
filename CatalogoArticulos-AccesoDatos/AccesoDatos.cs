using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Configuration;
using System.Web.Configuration;

namespace CatalogoArticulos.AccesoDatos
{
    public class AccesoDatos : IDisposable
    {
        private SqlConnection _conexion;
        private SqlCommand _comando;
        private SqlDataReader _lector;
        public SqlDataReader Lector
        {
            get { return _lector; }

        }

        public AccesoDatos()
        {
            _conexion = new SqlConnection(ConfigurationManager.AppSettings["cadenaConexion"]);
            _comando = new SqlCommand();

            //_conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_WEB_DB; integrated security=true;");
        }
        public void setearConsulta(string consulta)
        {
            _comando.CommandType = System.Data.CommandType.Text;
            _comando.Parameters.Clear();
            _comando.CommandText = consulta;
        }

        public void setearConsultaSP(string sp)
        {
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.Clear();
            _comando.CommandText = sp;

        }
        public void ejecutarLectura()
        {
            _comando.Connection = _conexion;
            try
            {
                _conexion.Open();
                _lector = _comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar la consulta del lectura", ex);
            }


        }

        public void ejecutarAccion()
        {
            _comando.Connection = _conexion;
            try
            {
                _conexion.Open();
                _comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public void setearParametro(string nombre, object valor)
        {
            _comando.Parameters.AddWithValue(nombre, valor);

        }

        public void CerrarConexion()
        {

            if (_lector != null)
            {
                _lector.Close();
            }
            _conexion.Close();

        }

        public void Dispose()
        {
            CerrarConexion();
            _comando?.Dispose();
            _conexion?.Dispose();
        }
    }
}