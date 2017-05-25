using Database;
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
        SqlConnection conexion = null;

        public Db()
        {
            conexion = new SqlConnection();
            try
            {
                string cadenaConexion = @"Server=.\SQLEXPRESS;
                                        Database=testdb;
                                        User Id=testuser;
                                        Password = !Curso@2017; ";

                conexion.ConnectionString = cadenaConexion;
                conexion.Open();
                Console.WriteLine("Estado de la conexión: " + conexion.State.ToString());
                EstaLaConexionAbierta();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Sql exception " + ex.ToString());
                Desconectar();
            }
            catch (Exception ex2)
            {
                Console.WriteLine("Exception " + ex2.ToString());
                Desconectar();
            }
        }

        //public void Conectar()
        //{
        //    conexion = new SqlConnection();
        //    try
        //    {
        //        string cadenaConexion = @"Server=.\SQLEXPRESS;
        //                                Database=testdb;
        //                                User Id=testuser;
        //                                Password = !Curso@2017; ";

        //        conexion.ConnectionString = cadenaConexion;
        //        conexion.Open();
        //        Console.WriteLine("Estado de la conexión: " + conexion.State.ToString());
        //        EstaLaConexionAbierta();
        //    }
        //    catch (SqlException ex)
        //    {
        //        Console.WriteLine("Sql exception " + ex.ToString());
        //        Desconectar();
        //    }
        //    catch (Exception ex2)
        //    {
        //        Console.WriteLine("Exception " + ex2.ToString());
        //        Desconectar();
        //    }
        //}

        public bool EstaLaConexionAbierta()
        {
            if(conexion.State == ConnectionState.Open)
            {
                return true;
            }else
            {
                return false;
            }
        }

        public void Desconectar()
        {
            Console.WriteLine("Nombre de la base de datos " + conexion.Database.ToString());
            if (conexion != null)
            {
                if (conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                    Console.WriteLine("Conexión cerrada con éxito");
                }
                conexion.Dispose();
                conexion = null;
            }
        }

        public List<Usuario> DamelosUsuarios()
        {
            // string[] usuarios = new string[45];
            List<Usuario> usuarios = null;
            string consultaSQL = "Select * from Users";
            SqlCommand comando = new SqlCommand(consultaSQL, conexion);
            SqlDataReader reader = comando.ExecuteReader();

            //usuarios = new Usuario[reader.RecordsAffected];
            usuarios = new List<Usuario>();

           // int numeroDeUsuarios = 0;
            while (reader.Read())
            {
                usuarios.Add(new Usuario()
                {
                    firstName = reader["firstName"].ToString(),
                    lastName = reader["lastName"].ToString()
                });
                //esto es igual
                //usuarios[numeroDeUsuarios] = new Usuario()
                //{
                //    firstName = reader["firstName"].ToString(),
                //    lastName = reader["lastName"].ToString()
                //};
                //usuarios.add(usuarios[numeroDeUsuarios]);
                //numeroDeUsuarios++;
                // Console.WriteLine("Nombre: " + reader["firstName"]);
            }
            return usuarios;
        }
    }
}
