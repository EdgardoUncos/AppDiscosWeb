using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppDiscosWeb.dominio;
using System.Data.SqlClient;

namespace AppDiscosWeb.negocio
{
    public class TipoNegocio
    {
        public List<Tipo> listar()
        {
            List<Tipo> lista = new List<Tipo>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=DISCOS_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select  Id, Descripcion from ESTILOS";
                comando.Connection = conexion;
                conexion.Open();

                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Tipo aux = new Tipo();
                    aux.Id = (int)lector["Id"];
                    aux.Descripcion = (string)lector["Descripcion"];

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

        public List<Tipo> ListarTipo()
        {
            List<Tipo> lista = new List<Tipo>();

            try
            {

                AccesoDatos negocio = new AccesoDatos();
                negocio.setearConsulta("select Id, Descripcion from TIPOSEDICION");
                negocio.ejecutarLectura();

                while (negocio.Lector.Read())
                {
                    Tipo aux = new Tipo();
                    aux.Id = (int)negocio.Lector["Id"];
                    aux.Descripcion = (string)negocio.Lector["Descripcion"];

                    lista.Add(aux);
                }

                negocio.cerrarConexion();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}