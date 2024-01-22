using ClassesApp.Data;
using ClassesApp.Models;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace ClassesApp
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

            ApplicationDbContext Db = new();

            bool firstTime = Db.Database.EnsureCreated();
            Debug.WriteLine($"FIRSTTIME={firstTime}");

            if ( firstTime )
            {
                Db.Classes.Add(new ClassModel
                {
                    Foto = "icons8_music_24"
                });

                Db.Classes.Add(new ClassModel
                {
                    Foto = "icons8_insert_equation_24"
                });

                Db.Classes.Add(new ClassModel
                {
                    Foto = "icons8_trojan_horse_24"
                });
            }

            Db.Dispose();
            return builder.Build();
        }
    }
}
