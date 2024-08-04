using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using Firebase.Auth;
using Microsoft.Extensions.Logging;
using TravelBuddy.Login;

namespace TravelBuddy
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton(services => new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = "AIzaSyATTgpxEVHuFlcUDxlIHpapqm2yFnVbmeI",
                AuthDomain = "travelmate-7ee8e.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                },
                //UserRepository = services.GetRequiredService<IUserRepository>()
            }));
            builder.Services.AddSingleton<FirebaseAuthentication>();
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<LoginPage>();
            //builder.Services.AddTransient<HomePage>(); // Register HomePage




            return builder.Build();
        }
    }
}
