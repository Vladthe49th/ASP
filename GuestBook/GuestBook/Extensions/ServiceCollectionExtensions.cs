using GuestBook.Services;
using GuestBook.Services.Interfaces;

namespace GuestBook.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGuestBookServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
