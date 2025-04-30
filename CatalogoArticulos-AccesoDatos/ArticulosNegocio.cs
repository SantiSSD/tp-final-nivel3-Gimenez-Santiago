using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;
using System.Drawing;
using Dominio;


namespace CatalogoArticulos.AccesoDatos
{
    public class ArticulosNegocio
    {
        private readonly AccesoDatos _datos;

        public ArticulosNegocio(AccesoDatos datos)
        {
            _datos = datos;
        }

        public List<Articulo> ObtenerArticulos(string id = "")
        {
            List<Articulo> articulos = new List<Articulo>();
            try
            {

                string consulta = "SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion, a.IdMarca, m.Descripcion AS Marca, a.IdCategoria, c.Descripcion AS Categoria, a.Precio, a.ImagenUrl FROM Articulos a JOIN Marcas m ON a.IdMarca = m.Id JOIN Categorias c ON a.IdCategoria = c.Id ";
                if (!string.IsNullOrEmpty(id))

                    consulta += "and a.Id = " + id;

                _datos.setearConsulta(consulta);


                _datos.ejecutarLectura();

                while (_datos.Lector.Read())
                {
                    Articulo articulo = new Articulo();

                    articulo.Id = _datos.Lector.GetInt32(0);
                    articulo.Codigo = _datos.Lector["Codigo"].ToString();
                    articulo.Nombre = _datos.Lector["Nombre"].ToString();
                    articulo.Descripcion = _datos.Lector["Descripcion"].ToString();


                    articulo.IdMarca = _datos.Lector.GetInt32(4);
                    articulo.IdCategoria = _datos.Lector.GetInt32(6);

                    articulo.Marca = new Marca
                    {
                        Id = articulo.IdMarca,
                        Descripcion = _datos.Lector["Marca"].ToString()
                    };

                    articulo.Categoria = new Categoria
                    {
                        Id = articulo.IdCategoria,
                        Descripcion = _datos.Lector["Categoria"].ToString()
                    };

                    articulo.Precio = _datos.Lector.GetDecimal(8);


                    if (!(_datos.Lector["ImagenUrl"] is DBNull))
                        articulo.ImagenUrl = _datos.Lector["ImagenUrl"].ToString();
                    articulos.Add(articulo);
                }


                _datos.CerrarConexion();
                return articulos;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al obtener los artículos de la base de datos.", ex);
            }
        }

        public List<Articulo> ObtenerArticulosConSP()
        {
            List<Articulo> lista = new List<Articulo>();


            try
            {

                _datos.setearConsultaSP("ObtenerArticulosConSP");
                _datos.ejecutarLectura();
                while (_datos.Lector.Read())
                {
                    Articulo articulo = new Articulo
                    {
                        Id = _datos.Lector.GetInt32(0),
                        Codigo = _datos.Lector["Codigo"].ToString(),
                        Nombre = _datos.Lector["Nombre"].ToString(),
                        Descripcion = _datos.Lector["Descripcion"].ToString(),
                        IdMarca = _datos.Lector.GetInt32(4),
                        IdCategoria = _datos.Lector.GetInt32(6),
                        Marca = new Marca
                        {
                            Id = _datos.Lector.GetInt32(4),
                            Descripcion = _datos.Lector["Marca"].ToString()
                        },
                        Categoria = new Categoria
                        {
                            Id = _datos.Lector.GetInt32(6),
                            Descripcion = _datos.Lector["Categoria"].ToString()
                        },
                        Precio = _datos.Lector.GetDecimal(8)
                    };


                    if (!_datos.Lector.IsDBNull(_datos.Lector.GetOrdinal("ImagenUrl")))
                    {
                        articulo.ImagenUrl = _datos.Lector["ImagenUrl"].ToString();
                    }

                    lista.Add(articulo);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al filtrar los artículos en la base de datos.", ex);
            }
            finally
            {

                _datos.CerrarConexion();
            }

        }
        public void InsertarArticulo(Articulo nuevo)
        {

            try
            {
                _datos.setearConsulta("INSERT INTO Articulos (Codigo, Nombre, Descripcion, IdMarca, IdCategoria,ImagenUrl, Precio) VALUES (@codigo, @nombre, @descripcion, @idMarca, @idCategoria,@Imagenurl, @precio)");


                _datos.setearParametro("@codigo", nuevo.Codigo);
                _datos.setearParametro("@nombre", nuevo.Nombre);
                _datos.setearParametro("@descripcion", nuevo.Descripcion);
                _datos.setearParametro("@idMarca", nuevo.Marca.Id);
                _datos.setearParametro("@idCategoria", nuevo.Categoria.Id);
                _datos.setearParametro("@Imagenurl", nuevo.ImagenUrl);
                _datos.setearParametro("@precio", nuevo.Precio);

                _datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                _datos.CerrarConexion();
            }


        }

        public void InsertarArticuloConSP(Articulo nuevo)
        {

            try
            {
                _datos.setearConsultaSP("AltaArticuloConSP ");


                _datos.setearParametro("@codigo", nuevo.Codigo);
                _datos.setearParametro("@nombre", nuevo.Nombre);
                _datos.setearParametro("@descripcion", nuevo.Descripcion);
                _datos.setearParametro("@idMarca", nuevo.Marca.Id);
                _datos.setearParametro("@idCategoria", nuevo.Categoria.Id);
                _datos.setearParametro("@Imagenurl", nuevo.ImagenUrl);
                _datos.setearParametro("@precio", nuevo.Precio);

                _datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                _datos.CerrarConexion();
            }
        }
        public void ModificarArticulo(Articulo articulo)
        {
            try
            {
                _datos.setearConsulta("UPDATE Articulos SET Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idMarca, IdCategoria = @idCategoria, ImagenUrl = @imagenUrl, Precio = @precio WHERE Id = @id");

                _datos.setearParametro("@codigo", articulo.Codigo);
                _datos.setearParametro("@nombre", articulo.Nombre);
                _datos.setearParametro("@descripcion", articulo.Descripcion);
                _datos.setearParametro("@idMarca", articulo.Marca.Id);
                _datos.setearParametro("@idCategoria", articulo.Categoria.Id);
                _datos.setearParametro("@imagenUrl", articulo.ImagenUrl);
                _datos.setearParametro("@precio", articulo.Precio);
                _datos.setearParametro("@id", articulo.Id);

                _datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el artículo en la base de datos.", ex);
            }
            finally
            {
                _datos.CerrarConexion();
            }
        }

        public void ModificarArticuloConSP(Articulo articulo)
        {
            try
            {
                _datos.setearConsultaSP("ModificarArticuloConSP");

                _datos.setearParametro("@codigo", articulo.Codigo);
                _datos.setearParametro("@nombre", articulo.Nombre);
                _datos.setearParametro("@descripcion", articulo.Descripcion);
                _datos.setearParametro("@idMarca", articulo.Marca.Id);
                _datos.setearParametro("@idCategoria", articulo.Categoria.Id);
                _datos.setearParametro("@imagenUrl", articulo.ImagenUrl);
                _datos.setearParametro("@precio", articulo.Precio);
                _datos.setearParametro("@id", articulo.Id);

                _datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el artículo en la base de datos.", ex);
            }
            finally
            {
                _datos.CerrarConexion();
            }
        }


        public void eliminar(int id)
        {
            try
            {
                _datos.setearConsulta("delete from ARTICULOS where id = @id");
                _datos.setearParametro("@id", id);
                _datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion, a.IdMarca, m.Descripcion AS Marca, a.IdCategoria, c.Descripcion AS Categoria, a.Precio, a.ImagenUrl FROM Articulos a JOIN Marcas m ON a.IdMarca = m.Id JOIN Categorias c ON a.IdCategoria = c.Id AND ";
                switch (campo)
                {
                    case "Codigo":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "a.Codigo LIKE @filtro + '%'";
                                break;
                            case "Termina con":
                                consulta += "a.Codigo LIKE '%' + @filtro";
                                break;
                            case "Contiene":
                                consulta += "a.Codigo LIKE '%' + @filtro + '%'";
                                break;
                        }
                        break;

                    case "Nombre":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "a.Nombre LIKE @filtro + '%'";
                                break;
                            case "Termina con":
                                consulta += "a.Nombre LIKE '%' + @filtro";
                                break;
                            case "Contiene":
                                consulta += "a.Nombre LIKE '%' + @filtro + '%'";
                                break;
                        }
                        break;

                    case "Descripción":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "a.Descripcion LIKE @filtro + '%'";
                                break;
                            case "Termina con":
                                consulta += "a.Descripcion LIKE '%' + @filtro";
                                break;
                            case "Contiene":
                                consulta += "a.Descripcion LIKE '%' + @filtro + '%'";
                                break;
                        }
                        break;

                    case "Marca":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "m.Descripcion LIKE @filtro + '%'";
                                break;
                            case "Termina con":
                                consulta += "m.Descripcion LIKE '%' + @filtro";
                                break;
                            case "Contiene":
                                consulta += "m.Descripcion LIKE '%' + @filtro + '%'";
                                break;
                        }
                        break;

                    case "Categoria":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "c.Descripcion LIKE @filtro + '%'";
                                break;
                            case "Termina con":
                                consulta += "c.Descripcion LIKE '%' + @filtro";
                                break;
                            case "Contiene":
                                consulta += "c.Descripcion LIKE '%' + @filtro + '%'";
                                break;
                        }
                        break;

                    default:
                        throw new Exception("Campo de búsqueda no reconocido");
                }

                _datos.setearConsulta(consulta);
                _datos.setearParametro("@filtro", filtro);
                _datos.ejecutarLectura();

                while (_datos.Lector.Read())
                {
                    Articulo articulo = new Articulo
                    {
                        Id = _datos.Lector.GetInt32(0),
                        Codigo = _datos.Lector["Codigo"].ToString(),
                        Nombre = _datos.Lector["Nombre"].ToString(),
                        Descripcion = _datos.Lector["Descripcion"].ToString(),
                        IdMarca = _datos.Lector.GetInt32(4),
                        IdCategoria = _datos.Lector.GetInt32(6),
                        Marca = new Marca
                        {
                            Id = _datos.Lector.GetInt32(4),
                            Descripcion = _datos.Lector["Marca"].ToString()
                        },
                        Categoria = new Categoria
                        {
                            Id = _datos.Lector.GetInt32(6),
                            Descripcion = _datos.Lector["Categoria"].ToString()
                        },
                        Precio = _datos.Lector.GetDecimal(8)
                    };


                    if (!_datos.Lector.IsDBNull(_datos.Lector.GetOrdinal("ImagenUrl")))
                    {
                        articulo.ImagenUrl = _datos.Lector["ImagenUrl"].ToString();
                    }

                    lista.Add(articulo);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al filtrar los artículos en la base de datos.", ex);
            }
        }

        public void Actualizar(Usuario usuario)
        {
            try
            {
                _datos.setearConsulta("UPDATE USERS SET urlImagenPerfil = @imagen, Nombre = @nombre, Apellido = @apellido WHERE Id = @id");
                _datos.setearParametro("@id", usuario.Id);
                _datos.setearParametro("@nombre", usuario.Nombre);
                _datos.setearParametro("@apellido", usuario.Apellido);
                _datos.setearParametro("@imagen", usuario.ImagenPerfil);
                _datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                _datos.CerrarConexion();
            }
        }
    }
}