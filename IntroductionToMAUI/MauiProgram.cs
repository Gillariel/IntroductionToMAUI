using IntroductionToMAUI.Data;
using MudBlazor.Services;

namespace IntroductionToMAUI;

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

		// Register Blazor stuff (1 liner now !)
		builder.Services.AddMauiBlazorWebView();
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif

        builder.Services.RegisterPlatformSpecificComponents();
        builder.Services.AddHttpClient();

        // Register Essentials
        builder.Services.AddSingleton(Map.Default);
        builder.Services.AddSingleton(Sms.Default);
        builder.Services.AddSingleton(Flashlight.Default);
        builder.Services.AddSingleton(Battery.Default);
        builder.Services.AddSingleton(Preferences.Default);
        builder.Services.AddSingleton(Share.Default);

        // Register external packages
        builder.Services.AddMudServices();

        // Register Custom services
        builder.Services.AddScoped<JokeService>();

        return builder.Build();
	}
}
