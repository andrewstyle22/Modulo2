
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine("Parámetro nº " + (i+1) +" "+ args[i]);
            }
            Console.ReadKey();
        }

        static void Test2()
        {
            FaunaTerrestre fauna = new FaunaTerrestre();
            Pinguino pinguino = new Pinguino();
            Pato pato = new Pato();
            pato.EsCarnivoro = false;
            Console.WriteLine(pato.EsCarnivoro);

            Pato pato2 = new Pato(false);

            //llama al constructor vacío
            Pato pato3 = new Pato()
            {
                EsCarnivoro = false
            };

            Console.ReadKey();
        }

        static void Test1()
        {
            string saludo = "Hello World";
            Console.WriteLine();
            Console.WriteLine(saludo + " cruel");
            var tecla = Console.ReadKey();

            Humano humano1 = new Humano();

            humano1.setAltura(111);
            humano1.getNombre();
            var altura = humano1.getAltura();
            Console.WriteLine(altura);
            Console.ReadKey();
        }
    }
}