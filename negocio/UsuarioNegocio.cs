using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class UsuarioNegocio
    {
        public int insertarNuevo(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("insertarNuevo");
                datos.setearParametros("@email", nuevo.Email);
                datos.setearParametros("pass", nuevo.Password);
                return datos.ejecutarAccionScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool Login(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select id, email, pass, admin, urlImagenPerfil, nombre, apellido from USERS where email = @email and pass = @pass");
                datos.setearParametros("@email", usuario.Email);
                datos.setearParametros("@pass", usuario.Password);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["id"];
                    usuario.Admin = (bool)datos.Lector["admin"];
                    if (!(datos.Lector["urlImagenPerfil"] is DBNull))
                        usuario.ImagenPefil = (string)datos.Lector["urlImagenPerfil"];
                    if (!(datos.Lector["nombre"] is DBNull))
                        usuario.Nombre = (string)datos.Lector["nombre"];
                    if (!(datos.Lector["apellido"] is DBNull))
                        usuario.Apellido = (string)datos.Lector["apellido"];
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void actualizar(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update USERS set urlImagenPerfil = @imagen, Nombre = @nombre, Apellido = @apellido where Id = @id");
                datos.setearParametros("@imagen", usuario.ImagenPefil != null ? usuario.ImagenPefil : (object)DBNull.Value);
                //Otra forma de hacerlo
                //datos.setearParametro("@imagen", (object)usuario.ImagenPerfil ?? DBNull.Value);
                datos.setearParametros("@nombre", usuario.Nombre);
                datos.setearParametros("@apellido", usuario.Apellido);
                datos.setearParametros("@id", usuario.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
