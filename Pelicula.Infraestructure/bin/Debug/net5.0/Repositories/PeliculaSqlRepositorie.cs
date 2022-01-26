using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pelicula.Domain.Entities;
using Pelicula.Infraestructure.Data;

namespace Pelicula.Infraestructure.Repositories
{
    public class PeliculaSqlRepositorie
    {
        private readonly PeliculasRiveroContext _context;
        public PeliculaSqlRepositorie()
        {
            _context = new PeliculasRiveroContext();
        }

        public IEnumerable<Movie> ObtenerPelicula()
        {
            return _context.Movies;

        }

        public Movie ObtenerId(int id)
        {
            var pelis = _context.Movies.Where(pelis => pelis.IdPelicula == id);
            return pelis.FirstOrDefault();

        }

        public void CrearPelicula (Movie PeliculaNueva)
        {
            var pelis = PeliculaNueva;
            _context.Movies.Add(pelis);
            var linea = _context.SaveChanges();
            if(linea <= 0)
            {
                throw new Exception("No se registro la pelicula");
            }
            
            return;
        }

        public void ModificarPelicula (int id, Movie peliculaActualizada)
        {
                if (id <= 0 || peliculaActualizada == null)
            {
                throw new ArgumentException("Falta informacion");

            }
            var actualizar = ObtenerId(id);

            actualizar.TituloPelicula = peliculaActualizada.TituloPelicula;
            actualizar.DirectorPelicula = peliculaActualizada.DirectorPelicula;
            actualizar.GeneroPelicula = peliculaActualizada.GeneroPelicula;
            actualizar.PuntuacionPelicula = peliculaActualizada.PuntuacionPelicula;
            actualizar.RatingPelicula = peliculaActualizada.RatingPelicula;
            actualizar.PubliPelicula = peliculaActualizada.PubliPelicula;

            _context.Update(actualizar);
            var linea = _context.SaveChanges();
            return;
        
        }

        public void BorrarPelicula (int id) 
            {
                if (id <= 0)
                {
                    throw new ArgumentException("No existe la pelicula");
                }
                var linea = ObtenerId(id);
                _context.Remove(linea);
                var result = _context.SaveChanges();
                return;
            }

          public IEnumerable<Movie> ObtenerDirector(string direc)
        {
            var pelis = _context.Movies.Where(peli => peli.DirectorPelicula == direc);
            return pelis;
        }
        
        
    }
}
