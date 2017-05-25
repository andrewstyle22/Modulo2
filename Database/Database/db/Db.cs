using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Db
    {
        public void Conectar()
        {
            SqlConnection conexion = new SqlConnection();
            try
            {
                string cadenaConexion = @"Server=.\SQLEXPRESS;
                                        Database=testdb;
                                        User Id=testuser;
                                        Password = !Curso@2017; ";

                conexion.ConnectionString = cadenaConexion;
                conexion.Open();

                //pregunto por el estado de la conexión
                if (conexion.State == ConnectionState.Open)
                {
                    Console.WriteLine("Conexión abierta con éxito");
                    conexion.Close();
                }
                else
                {
                    Console.WriteLine("No se pudo abrir");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Sql exception " + ex.ToString());
            }
            catch (Exception ex2)
            {
                Console.WriteLine("Exception " + ex2.ToString());
            }
            finally
            {
                Console.WriteLine("Nombre de la base de datos " + conexion.Database.ToString());
                if (conexion != null)
                {
                    conexion.Dispose();
                    conexion = null;
                }
            }
        }
    }
}
