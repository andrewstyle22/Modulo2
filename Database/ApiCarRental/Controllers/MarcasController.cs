using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Services;

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
            Db.Desconectar();
            return resultado;
        }
        /* Esto funciona pero es antiguo ahora se utiliza HttpPost
        // POST: api/Marcas
        [WebMethod]
        public string Post([FromBody] Marca marca)
        {
            string denominacion1 = marca.denominacion;
            string respuesta = "";
            try {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta()) {
                     respuesta = Db.InsertarMarcas1(denominacion1);
                }
            } catch (Exception e) {
                respuesta = "Error al conectar con la base de datos "+e.ToString();
            }
            Db.Desconectar();
            return respuesta;
        }
        */

        [HttpPost]
        public IHttpActionResult Post([FromBody] Marca marca)
        {
            RespuestaApi<Marca> respuesta = new RespuestaApi<Marca>();
            respuesta.datos = marca.denominacion;
            string mensaje = "";
            int filaAfectadas;
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    //mensaje = Db.InsertarMarcas1(marca);
                    filaAfectadas = Db.InsertarMarcas1(marca);
                }
            }
            catch (Exception e)
            {
                respuesta.error = "Error al conectar con la base de datos " + e.ToString();
            }
            Db.Desconectar();
            //return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, mensaje)); ;
            return Ok(respuesta);
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