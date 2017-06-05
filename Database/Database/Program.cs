using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace Database
{
    public class Program
    {
        public static object AEnvironment { get; private set; }

        static void Main(string[] args)
        {
            Console.WriteLine("Conectado a al base de datos");

            Db.Conectar();

            //conectar.Conectar();
            Usuario nuevoUsuario = null;
            if (Db.EstaLaConexionAbierta()) {
                ejecutarCoches();
                nuevoUsuario = new Usuario()
                {
                    //hiddenId = 0,
                    //id = "23j3232",
                    email = "pedroleon@hotmail.com",
                    password = "123334",
                    firstName = "pdro",
                    lastName = "leon",
                    photoUrl = "www.pepitofilm3.com",
                    searchPreferences = "",
                    status = false,
                    deleted = false,
                    isAdmin = false
                };
                //conectar.InsertarUsuario(nuevoUsuario);
                List<Usuario> usuarios = Db.DamelosUsuarios();
                usuarios.ForEach(usuario =>
                {
                    Console.WriteLine("Nombre: " + usuario.firstName + " " + usuario.lastName + 
                                      "   Email: "   + usuario.email + "   status: " + usuario.status +
                                      "   hiddenId: " + usuario.hiddenId
                    );
                });
                foreach (var usuario in usuarios)
                {
                    Console.WriteLine("Nombre: " + usuario.firstName + " " + usuario.lastName);
                }
            }
            //conectar.eliminarUsuario(178);
            //conectar.eliminarUsuarioPorEmail(nuevoUsuario.email);
            Usuario nuevoUsuario2 = new Usuario()
            {
                //hiddenId = 0,
                //id = "23j3232",
                email = "lopezsss@hotmail.com",
                password = "555555",
                firstName = "Aaron",
                lastName = "andrade",
                photoUrl = "wwww.facebook.com",
                searchPreferences = "",
                status = true,
                deleted = true,
                isAdmin = true
            };
            //nuevoUsuario2.firstName = "nuevo nombre"; otra forma de añadir
            Db.actualizarUsuarios(nuevoUsuario2);
            Db.Desconectar();
            Console.ReadKey();
        }
        /****************************************************   COCHES   ****************************************************/

        private static void ejecutarCoches() {
            List<MarcasNCoches> lista = Db.DameListaMarcasNCoches();
            lista.ForEach(elemento => {
                Console.WriteLine(
                        " Marca: " + elemento.marca
                        +
                        " Nº de coches: " + elemento.nCoches
                        );
            });
            
            List<Coche> listaCoches = Db.DameListaCochesConProcedimientoAlmacenado();
            listaCoches.ForEach(coche =>
            {
                Console.WriteLine(
                    @"Matrícula: " + coche.matricula +
                    " Marca: " + coche.marca.denominacion +
                    " Combustible: " + coche.tipoCombustible.denominacion
                    );
            });
            List<Coche> listaCoches2 = Db.GET_COCHE_POR_MARCA_MATRICULA_PLAZAS();
            listaCoches2.ForEach(coche =>
            {
                Console.WriteLine(
                    @"Matrícula: " + coche.matricula +
                    " Marca: " + coche.marca.denominacion +
                    " NPlazas: " + coche.nPlazas
                    );
            });
            Console.WriteLine("GET_COCHE_POR_MARCA_MATRICULA_PLAZAS()");
            List<Coche> listaCocheMarca = Db.GET_COCHE_POR_MARCA_MATRICULA_PLAZAS();
            listaCocheMarca.ForEach(coche =>
            {
                Console.WriteLine(
                    @"Matrícula: " + coche.matricula +
                    " Marca: " + coche.marca.denominacion +
                    " NPlazas: " + coche.nPlazas
                    );
            });
            Db.Desconectar();
            Console.ReadKey();
            Environment.Exit(0);
        }

        /****************************************************   COCHES   ****************************************************/


    }
}