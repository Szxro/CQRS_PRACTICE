using DTOS;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Utilities
{
    internal static class MapTo
    {
        public static MoviesDTO ToMovieDto(this Movies movies)
        {
            return new MoviesDTO()
            {
                Name = movies.Name,
                isLive = movies.isLive,
                ReleaseDate = movies.ReleaseDate
            };
        }
    }
}
