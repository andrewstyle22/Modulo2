using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiCarRental.Controllers
{
    public class MarcasController : ApiController
    {
        // GET: api/Marcas
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Marcas
        public RespuestaApi<Marca> Get()
        {
            RespuestaApi<Marca> resultado = new RespuestaApi<Marca>();
            List<Marca> data = new List<Marca>();
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    data = Db.DameListaMarcas();
                    resultado.error = "";
                }
            }
            catch (Exception)
            {
                resultado.totalElementos = 0;
                resultado.error = "Error";
            }
            resultado.totalElementos = data.Count;
            resultado.data = data;
            Db.Desconectar();
            return resultado;
        }

        // GET: api/Marcas/5
        public RespuestaApi<Marca> Get(int id)
        {
            RespuestaApi<Marca> resultado = new RespuestaApi<Marca>();
            List<Marca> data = new List<Marca>();
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    data = Db.DameListaMarcasPorId(id);
                    resultado.error = "";
                }
            }
            catch (Exception)
            {
                resultado.error = "Error";
            }
            resultado.totalElementos = data.Count;
            resultado.data = data;
            // Db.Desconectar();
            return resultado;
        }

        // POST: api/Marcas
        public void Post([FromBody]string value,[FromBody] string value2)
        {
            string valor1 = value;
            string valor2 = value2;
            Console.WriteLine("Valores " + valor1 + "  " + valor2);
            Console.ReadKey();
        }

        // PUT: api/Marcas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Marcas/5
        public void Delete(int id)
        {
        }
    }
}