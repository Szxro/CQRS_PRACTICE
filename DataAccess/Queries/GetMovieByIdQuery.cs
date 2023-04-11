using Dapper;
using DataAccess.DataConnection;
using DataAccess.Utilities;
using DTOS;
using Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Queries
{
    //Query
    public record GetMovieByIdQuery(int Id):IRequest<MoviesDTO>;

    //Handler
    public class GetMovieByIdHandler : IRequestHandler<GetMovieByIdQuery, MoviesDTO>
    {
        private readonly ISqlConnectionFactory _connection;

        public GetMovieByIdHandler(ISqlConnectionFactory connection)
        {
            _connection = connection;
        }

        public async Task<MoviesDTO> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            await using var sql = _connection.GetConnection();

            Movies movies = await sql.QueryFirstOrDefaultAsync<Movies>(@"SELECT * FROM Movies M Where M.Id = @Id", new {request.Id});

            return movies is null ? throw new Exception($"The Movies with the id of {request.Id} was not found") : movies.ToMovieDto();
        }
    }
}
