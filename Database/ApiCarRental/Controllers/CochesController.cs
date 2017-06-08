using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiCarRental.Controllers
{
    public class CochesController : ApiController
    {
        //// GET: api/Coches
        //public IEnumerable<string> Get()
        //{
        //    // return new string[] { "value1", "value2" };
        //}

        // GET: api/Coches/5
        public RespuestaApi<Coche> Get(int id)
        {
            RespuestaApi<Coche> resultado = new RespuestaApi<Coche>();
            List<Coche> data = new List<Coche>();
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    data = Db.DameListaCochesConProcedimientoAlmacenadoPorId(id);
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

        // GET: api/Coches/5
        //public IEnumerable<Coche> Get()
        //{

        //    IEnumerable<Coche> resultado = new List<Coche>();
        //    try
        //    {
        //        Db.Conectar();
        //        if (Db.EstaLaConexionAbierta())
        //        {
        //            resultado = Db.DameListaCochesConProcedimientoAlmacenado();
        //        }

        //    }
        //    catch (Exception)
        //    {
        //        string error = "";
        //    }
        //    return resultado;
        //}

        public RespuestaApi<Coche> Get()
        {
            RespuestaApi<Coche> resultado = new RespuestaApi<Coche>();
            List<Coche> data = new List<Coche>();
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    data = Db.DameListaCochesConProcedimientoAlmacenado();
                    resultado.error = "";
                }
            }
            catch (Exception)
            {
                resultado.error = "Error";
            }
            resultado.totalElementos = data.Count;
            resultado.data = data;
            Db.Desconectar();
            return resultado;
        }

        /*
        // POST: api/Coches
        public RespuestaApi<Coche> Post([FromBody]string value)
        {
            RespuestaApi<Coche> resultado = new RespuestaApi<Coche>();
            List<Coche> data = new List<Coche>();
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    data = Db.DameListaCochesConProcedimientoAlmacenado();
                    resultado.error = "";
                }
            }
            catch (Exception)
            {
                resultado.error = "Error";
            }
            resultado.totalElementos = data.Count;
            resultado.data = data;
            Db.Desconectar();
            return resultado;
        }*/

        // PUT: api/Coches/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Coches/5
        public void Delete(int id)
        {
        }
    }
}
