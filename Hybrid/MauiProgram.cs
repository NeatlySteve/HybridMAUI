using Microsoft.Extensions.Logging;
using Hybrid.Data;
using SharedResources;

namespace Hybrid;

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

		builder.Services.AddSingleton<WeatherForecastService>();

		//Our services.
		builder.Services.AddSingleton<SharedResources.Services.IDataService, SharedResources.Services.DataService>();
		builder.Services.AddSingleton<SharedResources.Services.IGeoService, Hybrid.Services.AppGeoService>();
		builder.Services.AddSingleton<SharedResources.Services.IAuthService, SharedResources.Services.AuthService>();

		return builder.Build();
	}
}
