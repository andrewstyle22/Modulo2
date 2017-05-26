using System;
using System.Collections.Generic;

namespace Database
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Conectado a al base de datos");

            Db.Conectar();
            //conectar.Conectar();
            Usuario nuevoUsuario = null;
            if (Db.EstaLaConexionAbierta())
            {
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
    }
}