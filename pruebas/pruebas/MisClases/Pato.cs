using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas
{
    public class Pato:FaunaTerrestre
    {
        public bool EsCarnivoro;

        public Pato()
        {

        }

        public Pato(bool esCarnivoro)
        {
            this.EsCarnivoro = esCarnivoro;
        }

        //public void setEscarnivoro(bool EsCarnivoro)
        //{
        //    this.EsCarnivoro = EsCarnivoro;
        //}
    }
}
