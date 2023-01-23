using TicketUpService.Domain.Repository;
using TicketUpService.Domain.Services;
using TicketUpService.Repository.Repositories;

namespace TicketUpService.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDepenceInjection(this IServiceCollection services)
        {
            services.AddTransient<IAuthService, AuthService>(); ;


            services.AddTransient<IStoreRepository, StoreRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserProfileRepository, UserProfileRepository>();


            return services;
        }
    }
}
