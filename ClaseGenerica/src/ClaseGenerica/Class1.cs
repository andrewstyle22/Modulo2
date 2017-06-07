using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaseGenerica
{
    public class Class1
    {
        public void ProbarLista()
        {
            ContenedorLista lista = new ContenedorLista(new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 });

            foreach (int nro in lista)
            {
                Console.WriteLine(nro);
            }

            Console.ReadLine();
        }
    }

    public class ContenedorLista : IEnumerable
    {
        IEnumerator _istaPropia;

        public ContenedorLista(object[] lista)
        {
            _istaPropia = new ListaPropia(lista);
        }

        public IEnumerator GetEnumerator()
        {
            return _istaPropia;
        }
    }

    public class ListaPropia : IEnumerator
    {
        object[] _lista;
        int _posicion;

        public ListaPropia(object[] lista)
        {
            _lista = lista;
            this.Reset();
        }

        public object Current
        {
            get
            {
                return _lista[_posicion];
            }
        }

        public bool MoveNext()
        {
            if (++_posicion < _lista.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            _posicion = -1;
        }
    }
}