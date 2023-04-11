using DataAccess.DataConnection;

namespace CQRS_DAPPER.Extension
{
    public static class ServiceExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddTransient<ISqlConnectionFactory, SqlConnectionFactory>();
        }
    }
}
