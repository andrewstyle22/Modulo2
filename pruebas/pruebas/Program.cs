
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
            #region
            //int[] listaNumeros = new int[10];
            //listaNumeros[0] = 345;
            //listaNumeros[listaNumeros.Length -1] = 1000;
            //Console.WriteLine("Array posición 10 " + listaNumeros[9]);
            //Console.ReadKey();
            //string[] listaTexto = new string[10];
            //for (int i = 0; i < listaTexto.Length; i++)
            //{
            //    listaTexto[i] = "" + i;
            //}
            //for (int i = 0; i < listaTexto.Length; i++)
            //{
            //    Console.WriteLine(listaTexto[i]);
            //}
            //Console.ReadKey();

            //listar por consola los números pares entre 0 y 30
            //int[] listaNumerosPares = new int[30];
            //for (int i = 0; i < listaNumerosPares.Length; i++)
            //{
            //    listaNumerosPares[i] = i;
            //}
            //for (int i = 0; i < listaNumerosPares.Length; i++)
            //{
            //    if (i % 2 == 0)
            //    {
            //        Console.WriteLine("Número par " + listaNumerosPares[i]);
            //    }
            //}
            //Console.ReadKey();
            #endregion

            int numero = 45,numero2 = 20;
            mostrarPares(numero,numero2);
            int[] listaNumerosImpares = getImpares(numero, numero2);
        }

        private static int[] getImpares(int limiteSuperior, int limiteInferior)
        {
            int[] listaNumerosImpares = new int[limiteSuperior];
            for (int i = 0; i < listaNumerosImpares.Length; i++)
            {
                listaNumerosImpares[i] = i;
            }
            for (int i = limiteInferior; i < listaNumerosImpares.Length; i++)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine("Número impar " + listaNumerosImpares[i]);
                }
            }
            Console.ReadKey();
            return listaNumerosImpares;
        }

        private static void mostrarPares(int limiteSuperior, int limiteInferior)
        {
            int[] listaNumerosPares = new int[limiteSuperior];
            for (int i = 0; i < listaNumerosPares.Length; i++)
            {
                listaNumerosPares[i] = i;
            }
            for (int i = limiteInferior; i < listaNumerosPares.Length; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine("Número par " + listaNumerosPares[i]);
                }
            }
            Console.ReadKey();
        }

        static void Test3(string []args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine("Parámetro nº " + (i + 1) + " " + args[i]);
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