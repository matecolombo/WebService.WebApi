using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebService.Datos.Modelos;

namespace WebService.WebApi.Controllers
{
    public class CamionController : ApiController
    {
        BalanzaConection BD = new BalanzaConection();

        //Permite consultar la info de todas las patentes

        [HttpGet]
        public IEnumerable<Camion> Get()
        {
            var listado = BD.Camion.ToList();
            return listado;
        }

        [HttpGet]
        public Camion Get(string Patente)
        {
            var camion = BD.Camion.FirstOrDefault(x => x.PATENTE == Patente);
            return camion;
        }

        [HttpPost]
        public bool Post(Camion camion)
        {
            BD.Camion.Add(camion);
            return BD.SaveChanges() > 0;
        }

        [HttpPut]
        public bool Put(Camion camion)
        {
            var camionActualizar = BD.Camion.FirstOrDefault(x => x.PATENTE == camion.PATENTE);
            camionActualizar.EJES1 = camion.EJES1;
            camionActualizar.EJES2 = camion.EJES2;
            camionActualizar.ADVERTENCIAS = camion.ADVERTENCIAS;

            return BD.SaveChanges() > 0;
        }

        [HttpDelete]
        public bool Delete(string patente)
        {
            var camionEliminar = BD.Camion.FirstOrDefault(x => x.PATENTE == patente);
            BD.Camion.Remove(camionEliminar);
            return BD.SaveChanges() > 0;

        }
    }
}
