﻿using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace Maui_1_Application;
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
        builder.UseMauiApp<App>().UseMauiCommunityToolkit();
#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
