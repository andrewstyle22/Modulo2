using System;

namespace Database
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Conectado a al base de datos");

            Db conectar = new Db();
            conectar.Conectar();

            Console.ReadKey();
        }
    }
}