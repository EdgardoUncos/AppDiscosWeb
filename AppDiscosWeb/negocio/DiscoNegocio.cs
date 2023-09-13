using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppDiscosWeb.dominio;
using System.Data.SqlClient;

namespace AppDiscosWeb.negocio
{
    public class DiscoNegocio
    {
         //Metodo que trae toda la tabla de discos y lo retorna en lista. El parametro opcional es para buscar
         // solo un registro
        public List<Disco> listar(string id ="")
        {
            List<Disco> lista = new List<Disco>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=DISCOS_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select D.Id, D.Titulo, D.FechaLanzamiento, D.CantidadCanciones, D.UrlImagenTapa, D.IdEstilo, E.Descripcion Estilo, D.IdTipoEdicion, T.Descripcion Edicion From DISCOS D, ESTILOS E, TIPOSEDICION T where D.IdEstilo = E.Id AND D.IdTipoEdicion = T.Id";
                
                //Si viene con el param opcional le agrego id a la consulta
                if (id != "")
                    comando.CommandText += " and D.Id = " + id;

                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Disco aux = new Disco();
                    aux.Id = (int)lector["Id"];
                    aux.Titulo = (string)lector["Titulo"];
                    aux.FechaLanzamiento = (DateTime)lector["FechaLanzamiento"];
                    aux.CantidadCanciones = (int)lector["CantidadCanciones"];
                    aux.UrlImagenTapa = (string)lector["UrlImagenTapa"];
                    aux.Estilo = new Tipo();
                    aux.Estilo.Id = (int)lector["IdEstilo"];
                    aux.Estilo.Descripcion = (string)lector["Estilo"];
                    aux.TipoEdicion = new Tipo();
                    aux.TipoEdicion.Id = (int)lector["IdTipoEdicion"];
                    aux.TipoEdicion.Descripcion = (string)lector["Edicion"];

                    lista.Add(aux);
                }

                conexion.Close();
                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void agregar(Disco nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            //nuevo.Titulo = "Pablo Honey";
            //nuevo.FechaLanzamiento = DateTime.Parse("1992-01-01 00:00:00");
            //nuevo.CantidadCanciones = 12;
            //nuevo.UrlImagenTapa = "https://cdns-images.dzcdn.net/images/cover/f08424290260e58c6d76275253b316fd/264x264.jpg";
            //nuevo.Estilo.Id = 2;
            //nuevo.TipoEdicion.Id = 1;
            try
            {
                datos.setearConsulta("Insert into DISCOS (Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, IdEstilo, IdTipoEdicion) values (@titulo, @fechaLanzamiento, @cantidadCanciones, @urlImagenTapa, @idEstilo, @idTipoEdicion)");
                datos.setearParametro("@titulo",nuevo.Titulo);
                datos.setearParametro("@fechaLanzamiento",nuevo.FechaLanzamiento);
                datos.setearParametro("@cantidadCanciones",nuevo.CantidadCanciones);
                datos.setearParametro("@urlImagenTapa", nuevo.UrlImagenTapa);
                datos.setearParametro("@idEstilo", nuevo.Estilo.Id);
                datos.setearParametro("@idTipoEdicion", nuevo.TipoEdicion.Id);
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

        public void agregarConSP(Disco nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("storedAltaDisco");
                datos.setearParametro("@titulo", nuevo.Titulo);
                datos.setearParametro("@fechaLanzamiento", nuevo.FechaLanzamiento);
                datos.setearParametro("@cantidadCanciones", nuevo.CantidadCanciones);
                datos.setearParametro("@urlImagenTapa", nuevo.UrlImagenTapa);
                datos.setearParametro("@idEstilo", nuevo.Estilo.Id);
                datos.setearParametro("@idTipoEdicion", nuevo.TipoEdicion.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void modificar(Disco disco)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Update Discos Set Titulo = @titulo, CantidadCanciones = @cantidadCanciones, UrlImagenTapa = @urlImagenTapa, IdEstilo = @idEstilo, IdTipoEdicion = @idTipoEdicion Where Id = @id");
                 
                datos.setearParametro("@titulo", disco.Titulo);
                //datos.setearParametro("@fechaLanzamiento", disco.FechaLanzamiento);
                datos.setearParametro("@cantidadCanciones", disco.CantidadCanciones);
                datos.setearParametro("@urlImagenTapa", disco.UrlImagenTapa);
                datos.setearParametro("@idEstilo", disco.Estilo.Id);
                datos.setearParametro("@idTipoEdicion", disco.TipoEdicion.Id);
                datos.setearParametro("@id", disco.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Delete from Discos where Id =  @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}