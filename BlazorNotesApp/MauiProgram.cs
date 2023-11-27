using BlazorNotesApp.Code.Databases;
using Microsoft.Extensions.Logging;

namespace BlazorNotesApp
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
                });

            builder.Services.AddMauiBlazorWebView();

            #if DEBUG
		        builder.Services.AddBlazorWebViewDeveloperTools();
		        builder.Logging.AddDebug();
            #endif

            // database

            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "NotesDatabase.db3");

            NotesDb notesDb = new NotesDb(path);

            builder.Services.AddSingleton<NotesDb>(notesDb);

            // database

            return builder.Build();
        }
    }
}