using DataAccess.DataConnection;
using DTOS;
using Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DataAccess.Commands
{
   //Void mode
   public record CreateMoviesCommand(string Name,bool IsLive,DateTime ReleaseDate):IRequest<Unit>;

    //The Commands are just for Create,Update and Delete actions

   public class CreateMovieHandler : IRequestHandler<CreateMoviesCommand, Unit>
    {
        //The Handlers are just for handling the request

        private readonly ISqlConnectionFactory _connection;

        public CreateMovieHandler(ISqlConnectionFactory connection)
        {
            _connection = connection;
        }

        public async Task<Unit> Handle(CreateMoviesCommand request, CancellationToken cancellationToken)
        {
            await using var sql = _connection.GetConnection();

            await sql.ExecuteAsync(@"INSERT INTO Movies (Name,IsLive,ReleaseDate) VALUES (@Name,@IsLive,@ReleaseDate)", new { request.Name, request.IsLive, request.ReleaseDate });

            return Unit.Value; // Unit is void represent value => {}
        }
    }
}
