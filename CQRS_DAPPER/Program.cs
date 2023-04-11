using CQRS_DAPPER.Extension;
using DataAccess;
using DataAccess.Queries;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services.AddDependencies();
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    //Adding the Mediatr
    builder.Services.AddMediatR(options => options.RegisterServicesFromAssemblies(typeof(GetAllMoviesQuery).Assembly));
    //GetAllMoviesQuery is take as a location point 
}

var app = builder.Build();
{ 
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
