using ASI.Basecode.Data;
using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Repositories;
using ASI.Basecode.Services.Interfaces;
using ASI.Basecode.Services.ServiceModels;
using ASI.Basecode.Services.Services;
using ASI.Basecode.WebApp.Authentication;
using ASI.Basecode.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ASI.Basecode.WebApp
{
    // Other services configuration
    internal partial class StartupConfigurer
    {
        /// <summary>
        /// Configures the other services.
        /// </summary>
        private void ConfigureOtherServices()
        {
            // Framework
            this._services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            this._services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();

            // Common
            this._services.AddScoped<TokenProvider>();
            this._services.TryAddSingleton<TokenProviderOptionsFactory>();
            this._services.TryAddSingleton<TokenValidationParametersFactory>();
            this._services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Services
            this._services.TryAddSingleton<TokenValidationParametersFactory>();
            this._services.AddScoped<IUserService, UserService>();
            this._services.AddScoped<IBookService, BookService>();
<<<<<<< HEAD:ASIBasecode - Books/ASI.Basecode.WebApp/Startup.DI.cs
            this._services.AddScoped<IDonationService, DonationService>();
=======
            this._services.AddScoped<ISongService, SongService>();
>>>>>>> 598a7d1ab28bc66d929db423fa8d69d5378235f5:ASI.Basecode.WebApp/Startup.DI.cs



            // Repositories
            this._services.AddScoped<IUserRepository, UserRepository>();
            this._services.AddScoped<IBookRepository, BookRepository>();
<<<<<<< HEAD:ASIBasecode - Books/ASI.Basecode.WebApp/Startup.DI.cs
            this._services.AddScoped<IDonationRepository, DonationRepository>();
=======
            this._services.AddScoped<ISongRepository, SongRepository>();
>>>>>>> 598a7d1ab28bc66d929db423fa8d69d5378235f5:ASI.Basecode.WebApp/Startup.DI.cs

            // Manager Class
            this._services.AddScoped<SignInManager>();

            this._services.AddHttpClient();
        }
    }
}
