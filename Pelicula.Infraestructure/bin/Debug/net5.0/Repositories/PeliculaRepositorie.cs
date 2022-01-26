using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pelicula.Domain.Entities;

namespace Pelicula.Infraestructure.Repositories
{
    public class PeliculaRepositorie
    {
        public static List<Movie> _pelis = new List<Movie>();

        public IEnumerable<Movie> ObtenerPelicula()
        {
            return _pelis;

        }

        public Movie ObtenerId(int id)
        {
            var pelis = _pelis.Where(pelis => pelis.IdPelicula == id);
            return pelis.FirstOrDefault();

        }

        public void CrearPelicula (Movie PeliculaNueva)
        {
            _pelis.Add(PeliculaNueva);
        }
        /*
        public void ModificarPelicula (int id, Movie modificarPeli)
        {
            if (id <= 0 || modificarPeli == null)
            {
                throw new ArgumentException("Falta informacion");

            }
            var actualizar = ObtenerId(id);

            actualizar.tituloPelicula = modificarPeli.tituloPelicula;
            actualizar.directorPelicula = modificarPeli.directorPelicula;
            actualizar.generoPelicula = modificarPeli.generoPelicula;
            actualizar.puntuacionPelicula = modificarPeli.puntuacionPelicula;
            actualizar.ratingPelicula = modificarPeli.ratingPelicula;
            actualizar.publiPelicula = modificarPeli.publiPelicula;

            _pelis.Remove(actualizar);
            _pelis.Add(actualizar);


        }
        */

        public void BorrarPelicula (int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Falta informacion");
                
            }
            var result = ObtenerId(id);
            _pelis.Remove(result);
        }

        /*
         public IEnumerable<Movie> ObtenerDirector(string direc)
        {
            var pelis = _pelis.Where(peli => peli.directorPelicula == direc);
            return pelis;
        }
        */
    }
}