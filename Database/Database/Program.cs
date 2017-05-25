using System;
using System.Collections.Generic;

namespace Database
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Conectado a al base de datos");

            Db conectar = new Db();
            //conectar.Conectar();
            List <Usuario> usuarios = conectar.DamelosUsuarios();
            usuarios.ForEach( usuario =>
            {
                Console.WriteLine("Nombre: " + usuario.firstName + " " + usuario.lastName);
            });
            foreach (var usuario in usuarios)
            {
                Console.WriteLine("Nombre: " + usuario.firstName + " " + usuario.lastName);
            }
            Console.ReadKey();

            conectar.Desconectar();
        }
    }
}