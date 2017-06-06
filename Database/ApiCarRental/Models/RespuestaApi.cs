using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiCarRental
{
    public class RespuestaApi <T>
    {
        public int totalElementos { get; set; }
        public string error { get; set; }
        //public List<Coche> data { get; set; }
        public List<T> data { get; set; }
    }
}