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
    public static class Db
    {
        static SqlConnection conexion = null;

        public static void Conectar()
        {
            conexion = new SqlConnection();
            try
            {
               /* string cadenaConexion = @"Server=.\SQLEXPRESS;
                                        Database=testdb;
                                        User Id=testuser;
                                        Password = !Curso@2017; ";
               */
                string cadenaConexion = @"Server=.\SQLEXPRESS;
                                        Database=carrental;
                                        User Id=testuser;
                                        Password = !Curso@2017; ";

                conexion.ConnectionString = cadenaConexion;
                conexion.Open();
                Console.WriteLine("Estado de la conexión: " + conexion.State.ToString());
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

        //public static void Conectar()
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

        public static bool EstaLaConexionAbierta()
        {
            return conexion.State == ConnectionState.Open;
        }

        public static void Desconectar()
        {
            if (conexion != null)
            {
                if (conexion.State != ConnectionState.Closed)
                {
                    Console.WriteLine("Nombre de la base de datos " + conexion.Database.ToString());
                    conexion.Close();
                    Console.WriteLine("Conexión cerrada con éxito");
                }
                conexion.Dispose();
                conexion = null;
            }
        }

        public static List<Usuario> DamelosUsuarios()
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
                    //int.TryParse(reader["hiddenId"].ToString(), out hiddenId),
                    hiddenId = int.Parse(reader["hiddenId"].ToString()),
                    id = reader["id"].ToString(),
                    email = reader["email"].ToString(),
                    password = reader["password"].ToString(),
                    firstName = reader["firstName"].ToString(),
                    lastName = reader["lastName"].ToString(),
                    photoUrl = reader["photoUrl"].ToString(),
                    searchPreferences = reader["searchPreferences"].ToString(),
                    status = bool.Parse(reader["status"].ToString()),
                    deleted = (bool)(reader["deleted"]),
                    isAdmin = Convert.ToBoolean(reader["isAdmin"])
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
            reader.Close();
            return usuarios;
        }

        public static void InsertarUsuario(Usuario usuario)
        {
            string consultaSQL = @"INSERT INTO Users (
                                                        email
                                                       ,password
                                                       ,firstName
                                                       ,lastName
                                                       ,photoUrl
                                                       ,searchPreferences
                                                       ,status
                                                       ,deleted
                                                       ,isAdmin
                                                       )
                                             VALUES (";
                                                consultaSQL += "'" + usuario.email + "'";
                                                consultaSQL += ",'" + usuario.password + "'";
                                                consultaSQL += ",'" + usuario.firstName + "'";
                                                consultaSQL += ",'" + usuario.lastName + "'";
                                                consultaSQL += ",'" + usuario.photoUrl + "'";
                                                consultaSQL += ",'" + usuario.searchPreferences + "'";
                                                consultaSQL += "," + (usuario.status ? "1" : "0");
                                                consultaSQL += "," + (usuario.deleted ? "1" : "0");
                                                consultaSQL += "," + (usuario.isAdmin ? "1" : "0");
                                                consultaSQL += ");";

            SqlCommand comando = new SqlCommand(consultaSQL, conexion);
            comando.ExecuteNonQuery();
        }

        public static void eliminarUsuario(int hiddenId)
        {
            string consultaSQL = @"DELETE FROM Users WHERE hiddenId="+hiddenId+";";
            SqlCommand comando = new SqlCommand(consultaSQL, conexion);
            if (comando.ExecuteNonQuery() > 0){
                Console.WriteLine("Fila borrada");
            }else
            {
                Console.WriteLine("Error al borrar");
            }
        }

        public static void eliminarUsuarioPorEmail(string email)
        {
            string consultaSQL = @"DELETE FROM Users WHERE email='" + email + "';";
            SqlCommand comando = new SqlCommand(consultaSQL, conexion);
            if (comando.ExecuteNonQuery() > 0)
            {
                Console.WriteLine("Fila borrada");
            }
            else
            {
                Console.WriteLine("Error al borrar");
            }
        }

        public static void actualizarUsuarios(Usuario usuario)
        {
            string consultaSQL = @"UPDATE dbo.Users SET ";
                                                consultaSQL += "password ='" + usuario.password + "'";
                                                consultaSQL += ",firstName ='" + usuario.firstName + "'";
                                                consultaSQL += ",lastName ='" + usuario.lastName + "'";
                                                consultaSQL += ",photoUrl ='" + usuario.photoUrl + "'";
                                                consultaSQL += ",searchPreferences ='" + usuario.searchPreferences + "'";
                                                consultaSQL += ",status =" + (usuario.status ? "1" : "0");
                                                consultaSQL += ",deleted =" + (usuario.deleted ? "1" : "0");
                                                consultaSQL += ",isAdmin =" + (usuario.isAdmin ? "1" : "0");
                                                consultaSQL += " WHERE email ='" + usuario.email + "';";

            SqlCommand comando = new SqlCommand(consultaSQL, conexion);
            if (comando.ExecuteNonQuery() > 0)
            {
                Console.WriteLine("Fila actualizada");
            }
            else
            {
                Console.WriteLine("Error al actualizar");
            }
        }

        /****************************************************   COCHES   ****************************************************/

        public static List<MarcasNCoches> DameListaMarcasNCoches() {
            List<MarcasNCoches> resultados = new List<MarcasNCoches>();
            // PREPARO LA CONSULTA SQL PARA OBTENER LOS USUARIOS
            /* SE HA CREADO ESTA VISTA EN LA BASE DE DATOS
                CREATE VIEW [dbo].[V_N_COCHES_POR_MARCA] AS
                SELECT M.denominacion as Marca, count(C.id) as nCoches
                FROM Marcas M
		                LEFT JOIN Coches C on M.id = C.idMarca
                GROUP BY M.denominacion
                GO
             */
            string consultaSQL = "SELECT * FROM V_N_COCHES_POR_MARCA";
            // PREPARO UN COMANDO PARA EJECUTAR A LA BASE DE DATOS
            SqlCommand comando2 = new SqlCommand(consultaSQL,conexion);
            // RECOJO LOS DATOS
            SqlDataReader reader = comando2.ExecuteReader();

            while (reader.Read()) {
                resultados.Add(new MarcasNCoches() {
                    marca = reader["Marca"].ToString(),
                    nCoches = (int) reader["nCoches"]
                });
            }

            // DEVUELVO LOS DATOS
            reader.Close();
            return resultados;
        }

        public static List<Coche> DameListaCochesConProcedimientoAlmacenado() {
            // CREO EL OBJETO EN EL QUE SE DEVOLVERÁN LOS RESULTADOS
            List<Coche> resultados = new List<Coche>();

            // PREPARO LA LLAMADA AL PROCEDIMIENTO ALMACENADO
            /* SE HA CREADO ESTE PROCEDIMIENTO EN LA BASE DE DATOS
                create PROCEDURE GET_COCHE_POR_MARCA
                AS
                BEGIN
	                SELECT Coches.*, Marcas.denominacion as denominacionMarca
	                FROM Marcas
		                INNER JOIN Coches on Marcas.id = Coches.idMarca
	                --PRINT 'MI PRIMER PROCEDIMIENTO ALMACENADO'
                END
            */
            string procedimientoAEjecutar = "dbo.GET_COCHE_POR_MARCA";

            // PREPARAMOS EL COMANDO PARA EJECUTAR EL PROCEDIMIENTO ALMACENADO
            SqlCommand comando = new SqlCommand(procedimientoAEjecutar,conexion);
            comando.CommandType = CommandType.StoredProcedure;
            // EJECUTO EL COMANDO
            SqlDataReader reader = comando.ExecuteReader();
            // RECORRO EL RESULTADO Y LO PASO A LA VARIABLE A DEVOLVER
            while (reader.Read()) {
                // CREO EL COCHE
                Coche coche = new Coche();
                coche.id = (long) reader["id"];
                coche.matricula = reader["matricula"].ToString();
                coche.color = reader["color"].ToString();
                coche.cilindrada = (decimal) reader["cilindrada"];
                coche.nPlazas = (short) reader["nPlazas"];
                coche.fechaMatriculacion = (DateTime) reader["fechaMatriculacion"];
                coche.marca = new Marca();
                coche.marca.id = (long) reader["idMarca"];
                coche.marca.denominacion = reader["denominacionMarca"].ToString();
                coche.tipoCombustible = new TipoCombustible();
                coche.tipoCombustible.id = (long) reader["idTipoCombustible"];
              //  coche.tipoCombustible.denominacion = reader["denominacionTipoCombustible"].ToString();
                // AÑADO EL COCHE A LA LISTA DE RESULTADOS
                resultados.Add(coche);

            }
            reader.Close();
            return resultados;
        }

        public static List<Coche> GET_COCHE_POR_MARCA_MATRICULA_PLAZAS()
        {
            // CREO EL OBJETO EN EL QUE SE DEVOLVERÁN LOS RESULTADOS
            List<Coche> resultados = new List<Coche>();

            // PREPARO LA LLAMADA AL PROCEDIMIENTO ALMACENADO
            string procedimientoAEjecutar = "dbo.GET_COCHE_POR_MARCA_MATRICULA_PLAZAS";

            // PREPARAMOS EL COMANDO PARA EJECUTAR EL PROCEDIMIENTO ALMACENADO
            SqlCommand comando = new SqlCommand(procedimientoAEjecutar, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            // EJECUTO EL COMANDO
            SqlDataReader reader = comando.ExecuteReader();
            // RECORRO EL RESULTADO Y LO PASO A LA VARIABLE A DEVOLVER
            while (reader.Read())
            {
                // CREO EL COCHE
                Coche coche = new Coche();
                coche.matricula = reader["matricula"].ToString();
                coche.nPlazas = (short)reader["nPlazas"];
                coche.marca = new Marca();
                coche.marca.denominacion = reader["Marca"].ToString();
                // AÑADO EL COCHE A LA LISTA DE RESULTADOS
                resultados.Add(coche);
            }
            reader.Close();
            return resultados;
        }

        public static List<Coche> GET_COCHE_POR_MARCA_MATRICULA_PLAZAS_2(string marca,int nPlazas)
        {
            // CREO EL OBJETO EN EL QUE SE DEVOLVERÁN LOS RESULTADOS
            List<Coche> resultados = new List<Coche>();

            // PREPARO LA LLAMADA AL PROCEDIMIENTO ALMACENADO
            string procedimientoAEjecutar = "dbo.GET_COCHE_POR_MARCA_MATRICULA_PLAZAS_2";

            // PREPARAMOS EL COMANDO PARA EJECUTAR EL PROCEDIMIENTO ALMACENADO
            SqlCommand comando = new SqlCommand(procedimientoAEjecutar, conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //Preparo los parámetros y les paso los valores
            SqlParameter parametroMarca = new SqlParameter();
            parametroMarca.ParameterName = "marca";
            parametroMarca.SqlDbType = SqlDbType.NVarChar;
            parametroMarca.SqlValue = marca;
            comando.Parameters.Add(parametroMarca);

            SqlParameter parametroNPlazas = new SqlParameter();
            parametroNPlazas.ParameterName = "nPlazas";
            parametroNPlazas.SqlDbType = SqlDbType.SmallInt;
            parametroNPlazas.SqlValue = nPlazas;
            comando.Parameters.Add(parametroNPlazas);

            // EJECUTO EL COMANDO
            SqlDataReader reader = comando.ExecuteReader();
            // RECORRO EL RESULTADO Y LO PASO A LA VARIABLE A DEVOLVER
            while (reader.Read())
            {
                // CREO EL COCHE
                Coche coche = new Coche();
                coche.matricula = reader["matricula"].ToString();
                coche.nPlazas = (short)reader["nPlazas"];
                coche.marca = new Marca();
                coche.marca.denominacion = reader["Marca"].ToString();
                // AÑADO EL COCHE A LA LISTA DE RESULTADOS
                resultados.Add(coche);
            }
            reader.Close();
            return resultados;
        }
    }
}
