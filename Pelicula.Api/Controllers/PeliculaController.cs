using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pelicula.Infraestructure.Repositories;
using Pelicula.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Pelicula.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeliculaController : ControllerBase
    {
        [HttpGet]
        [Route("ObtenerPelicula")]

        public IActionResult ObtenerPelicula()
        {
            PeliculaSqlRepositorie pelis = new PeliculaSqlRepositorie();
            return Ok(pelis.ObtenerPelicula());
        }

        [HttpGet]
        [Route("Buscar")]

        public IActionResult ObtenerId(int id)
        {
            PeliculaSqlRepositorie pelis = new PeliculaSqlRepositorie();
            var peli = pelis.ObtenerId(id);
            if (peli == null)
            {
                return NotFound($"El id {id} no existe de la pelicula");

            } 
            return Ok (peli);
            
        }

         [HttpPost]
        [Route("Crear")]

        public IActionResult CrearPelicula (Movie peliculaNueva)
        {
            PeliculaSqlRepositorie pelis = new PeliculaSqlRepositorie();

            try
            {
                 pelis.CrearPelicula(peliculaNueva);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "¡ERROR!, no se pudo realizar el registro");
            }
           
            return Ok("Pelicula agregada");
        }

        
          [HttpPut]
        [Route("Modificar")]

        
        public IActionResult ModificarPelicula (int id, Movie modificarPeli)
        {
            PeliculaSqlRepositorie pelis = new PeliculaSqlRepositorie();
            var actualizar = pelis.ObtenerId(id);
            if (actualizar == null)
            {
                return NotFound($"Ingresaste el Id {id}, no existe la pelicula");

            }

            pelis.ModificarPelicula(id, modificarPeli);
            return Ok("Se actualizo correctamente la pelicula");

        }
        

          [HttpDelete]
        [Route("Borrar")]

        public IActionResult BorrarPelicula (int id)
        {
            PeliculaSqlRepositorie pelis = new PeliculaSqlRepositorie();
            var actuali = pelis.ObtenerId(id);
            if (actuali == null)
            {
                return NotFound($"Ingresaste el Id {id}, no existe la pelicula");
            }
            pelis.BorrarPelicula(id);
            return Ok($"La pelicula con Id {id}, se ha eliminado correctamente");
        }

        
        [HttpGet]
        [Route("BuscarDirector")]

        public IActionResult ObtenerDirect (string direc)
        {
            PeliculaSqlRepositorie pelis = new PeliculaSqlRepositorie();
            var peli = pelis.ObtenerDirector(direc);
            if (peli.Count() == 0)
            {
                return NotFound($"El director {direc}, no existe");
            }
            return Ok(peli);

        }
        

    }
}