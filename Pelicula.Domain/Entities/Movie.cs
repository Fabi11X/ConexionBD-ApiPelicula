using System;
using System.Collections.Generic;

#nullable disable

namespace Pelicula.Domain.Entities
{
    public partial class Movie
    {
        public int IdPelicula { get; set; }
        public string TituloPelicula { get; set; }
        public string DirectorPelicula { get; set; }
        public string GeneroPelicula { get; set; }
        public int? PuntuacionPelicula { get; set; }
        public int? RatingPelicula { get; set; }
        public string PubliPelicula { get; set; }
    }
}
