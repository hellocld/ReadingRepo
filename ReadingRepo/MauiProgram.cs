using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReadingRepo.DAL.Entities;
using ReadingRepo.Data;
using Serilog;

namespace ReadingRepo;

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

		var logger = new LoggerConfiguration()
			.Enrich.FromLogContext()
			.CreateLogger();

		builder.Logging.ClearProviders();
		builder.Logging.AddSerilog(logger);

		builder.Services.AddMauiBlazorWebView();
		builder.Services.AddDbContextFactory<ReadingRepoContext>();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<WeatherForecastService>();

		return builder.Build();
	}
}
