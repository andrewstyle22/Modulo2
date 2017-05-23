using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas
{
    class Humano
    {
        private int altura = 100;/*valor en cms*/
        private double peso = 100.5;
        private string nombre = "";
        private char genero = 'M';
        private bool vivo = true;

        #region
        //public double Peso
        //{
        //    get
        //    {
        //        return peso;
        //    }

        //    set
        //    {
        //        peso = value;
        //    }
        //}

        //public string Nombre
        //{
        //    get
        //    {
        //        return nombre;
        //    }

        //    set
        //    {
        //        nombre = value;
        //    }
        //}

        //public char Genero
        //{
        //    get
        //    {
        //        return genero;
        //    }

        //    set
        //    {
        //        genero = value;
        //    }
        //}

        //public bool Vivo
        //{
        //    get
        //    {
        //        return vivo;
        //    }

        //    set
        //    {
        //        vivo = value;
        //    }
        //}
        #endregion

        public int getAltura()
        {
            return altura;
        }

        public void setAltura(int altura)
        {
            this.altura = altura;
        }

        public double getPeso()
        {
            return peso;
        }

        public void setPeso(double peso)
        {
            this.peso = peso;
        }

        public string getNombre()
        {
            return nombre;
        }

        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public char getGenero()
        {
            return genero;
        }

        public void setGenero(char genero)
        {
            this.genero = genero;
        }

        public bool getVivo()
        {
            return vivo;
        }

        public void setVivo(bool valorVivo)
        {
            vivo = valorVivo;
        }
    }
}
