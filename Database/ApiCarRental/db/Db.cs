using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCarRental
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

        internal static List<Coche> DameListaCochesConProcedimientoAlmacenadoPorId(int id)
        {
            // CREO EL OBJETO EN EL QUE SE DEVOLVERÁN LOS RESULTADOS
            List<Coche> resultados = new List<Coche>();

            string procedimientoAEjecutar = "dbo.GET_COCHE_POR_MARCA_ID";

            // PREPARAMOS EL COMANDO PARA EJECUTAR EL PROCEDIMIENTO ALMACENADO
            SqlCommand comando = new SqlCommand(procedimientoAEjecutar, conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter parametroId = new SqlParameter();
            parametroId.ParameterName = "id";
            parametroId.SqlDbType = SqlDbType.BigInt;
            parametroId.SqlValue = id;
            comando.Parameters.Add(parametroId);
            Console.WriteLine("Parámetro id:  " + id);
            // EJECUTO EL COMANDO
            SqlDataReader reader = comando.ExecuteReader();
            // RECORRO EL RESULTADO Y LO PASO A LA VARIABLE A DEVOLVER
            while (reader.Read())
            {
                // CREO EL COCHE
                Coche coche = new Coche();
                coche.id = (long)reader["id"];
                coche.matricula = reader["matricula"].ToString();
                coche.color = reader["color"].ToString();
                coche.cilindrada = (decimal)reader["cilindrada"];
                coche.nPlazas = (short)reader["nPlazas"];
                coche.fechaMatriculacion = (DateTime)reader["fechaMatriculacion"];
                coche.marca = new Marca();
                coche.marca.id = (long)reader["idMarca"];
                coche.marca.denominacion = reader["denominacionMarca"].ToString();
                coche.tipoCombustible = new TipoCombustible();
                coche.tipoCombustible.id = (long)reader["idTipoCombustible"];
                //  coche.tipoCombustible.denominacion = reader["denominacionTipoCombustible"].ToString();
                // AÑADO EL COCHE A LA LISTA DE RESULTADOS
                resultados.Add(coche);
            }
            reader.Close();
            return resultados;
        }

        public static List<Marca> DameListaMarcas()
        {
            List<Marca> resultados = new List<Marca>();
            string procedimientoAEjecutar = "dbo.Get_Marcas";
            SqlCommand comando = new SqlCommand(procedimientoAEjecutar, conexion);
            //O podemos hacer esto
            //comando.CommandText = procedimientoAEjecutar;
            //comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Marca marca = new Marca();
                marca.id = (long)reader["id"];
                marca.denominacion = reader["denominacion"].ToString();
                resultados.Add(marca);
            }
            reader.Close();
            return resultados;
        }


        public static List<Marca> DameListaMarcasPorId(int id)
        {
            // CREO EL OBJETO EN EL QUE SE DEVOLVERÁN LOS RESULTADOS
            List<Marca> resultados = new List<Marca>();

            string procedimientoAEjecutar = "dbo.Get_Marcas_ID";

            // PREPARAMOS EL COMANDO PARA EJECUTAR EL PROCEDIMIENTO ALMACENADO
            SqlCommand comando = new SqlCommand(procedimientoAEjecutar, conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter parametroId = new SqlParameter();
            parametroId.ParameterName = "id";
            parametroId.SqlDbType = SqlDbType.BigInt;
            parametroId.SqlValue = id;
            comando.Parameters.Add(parametroId);
            // EJECUTO EL COMANDO
            SqlDataReader reader = comando.ExecuteReader();
            // RECORRO EL RESULTADO Y LO PASO A LA VARIABLE A DEVOLVER
            while (reader.Read())
            {
                Marca marca = new Marca();
                marca.id = (long)reader["id"];
                marca.denominacion = reader["denominacion"].ToString();
                resultados.Add(marca);
            }
            reader.Close();
            return resultados;
        }


        internal static List<TipoCombustible> DameListaTipoCombustibles()
        {
            List<TipoCombustible> resultados = new List<TipoCombustible>();
            string procedimientoAEjecutar = "dbo.Get_TiposCombustible";
            SqlCommand comando = new SqlCommand(procedimientoAEjecutar, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                TipoCombustible tc = new TipoCombustible();
                tc.id = (long)reader["id"];
                tc.denominacion = reader["denominacion"].ToString();
                resultados.Add(tc);
            }
            reader.Close();
            return resultados;
        }

        internal static List<TipoCombustible> DameListaTipoCombustiblePorId(int id)
        {
            // CREO EL OBJETO EN EL QUE SE DEVOLVERÁN LOS RESULTADOS
            List<TipoCombustible> resultados = new List<TipoCombustible>();

            string procedimientoAEjecutar = "dbo.Get_TipoCombustible_ID";

            // PREPARAMOS EL COMANDO PARA EJECUTAR EL PROCEDIMIENTO ALMACENADO
            SqlCommand comando = new SqlCommand(procedimientoAEjecutar, conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter parametroId = new SqlParameter();
            parametroId.ParameterName = "id";
            parametroId.SqlDbType = SqlDbType.BigInt;
            parametroId.SqlValue = id;
            comando.Parameters.Add(parametroId);
            // EJECUTO EL COMANDO
            SqlDataReader reader = comando.ExecuteReader();
            // RECORRO EL RESULTADO Y LO PASO A LA VARIABLE A DEVOLVER
            while (reader.Read())
            {
                TipoCombustible tc = new TipoCombustible();
                tc.id = (long)reader["id"];
                tc.denominacion = reader["denominacion"].ToString();
                resultados.Add(tc);
            }
            reader.Close();
            return resultados;
        }
    }
}