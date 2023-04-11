using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DTOS;
using DataAccess.DataConnection;
using DataAccess.Utilities;
using Dapper;

namespace DataAccess.Queries
{
    //IRequest<out IEnumerable<Movies>> => is going to return a list of movies
    public record GetAllMoviesQuery(): IRequest<IEnumerable<MoviesDTO>>;

    //The queries are just for Read actions

    public class GetAllMoviesHandler : IRequestHandler<GetAllMoviesQuery, IEnumerable<MoviesDTO>> // IRequestHandler<out Query,out Result>
    {
        private readonly ISqlConnectionFactory _connection;

        public GetAllMoviesHandler(ISqlConnectionFactory connection)
        {
            _connection = connection;
        }
        public async Task<IEnumerable<MoviesDTO>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
        {
            await using var sql = _connection.GetConnection();

            IEnumerable<Movies> allMovies = await sql.QueryAsync<Movies>(@"SELECT * FROM MOVIES");

            return allMovies.Select(x => x.ToMovieDto()).ToList();
        }
    }
}
