﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiCarRental.Controllers
{
    public class TipoCombustibleController : ApiController
    {
        // GET: api/TipoCombustible
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        public RespuestaApi<TipoCombustible> get()
        {
            RespuestaApi<TipoCombustible> resultado = new RespuestaApi<TipoCombustible>();
            List<TipoCombustible> data = new List<TipoCombustible>();
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    data = Db.DameListaTipoCombustibles();
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

        // GET: api/TipoCombustible/5
        public RespuestaApi<TipoCombustible> Get(int id)
        {
            RespuestaApi<TipoCombustible> resultado = new RespuestaApi<TipoCombustible>();
            List<TipoCombustible> data = new List<TipoCombustible>();
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    data = Db.DameListaTipoCombustiblePorId(id);
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

        // POST: api/TipoCombustible

        [HttpPost]
        public IHttpActionResult Post([FromBody] TipoCombustible tp)
        {
            RespuestaApi<TipoCombustible> respuesta = new RespuestaApi<TipoCombustible>();
            respuesta.datos = tp.denominacion;
            int filaAfectadas;
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    filaAfectadas = Db.InsertarTipocombustible(tp);
                }
            }
            catch (Exception e)
            {
                respuesta.error = "Error al conectar con la base de datos " + e.ToString();
            }
            Db.Desconectar();
            return Ok(respuesta);
        }

        // PUT: api/TipoCombustible/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TipoCombustible/5
        public void Delete(int id)
        {
        }
    }
}
