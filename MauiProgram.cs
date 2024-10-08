﻿using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using Firebase.Auth;
using Microsoft.Extensions.Logging;
using TravelBuddy.ViewModel;
using TravelBuddy.Service;
using TravelBuddy.Views;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;
using Twilio;

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
            TwilioClient.Init("ACb8a18eeb1bd174bfdd2df741f542e2d4", "ce2c0dce7eb59a4320c124a09bb71a4d");

            builder.Services.AddSingleton<FirebaseAuthentication>();
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<HomePageViewModel>();
            builder.Services.AddTransient<ChecklistViewModel>();
            builder.Services.AddTransient<ExistingChecklistVIewModel>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<HomePage>(); // Register HomePage
            builder.Services.AddTransient<ChecklistPage>();
            builder.Services.AddTransient<ExistingChecklistPage>();

           builder.Services.AddSingleton<FirestoreService>();
            return builder.Build();
        }
    }
}
