using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database {
    public class Coche {
        public long id { get; set; }
        public string matricula { get; set; }
        public string color { get; set; }
        public decimal cilindrada { get; set; }
        public int nPlazas { get; set; }
        public DateTime fechaMatriculacion { get; set; }
        public Marca marca { get; set; }
        public TipoCombustible tipoCombustible { get; set; }
    }
}
