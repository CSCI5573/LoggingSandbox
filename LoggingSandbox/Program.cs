// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

Console.WriteLine("Hello, World!");

var services = new ServiceCollection();
services.AddLogging(config =>
{
	config.AddConsole();
	config.SetMinimumLevel(LogLevel.Trace);
});

services.AddSingleton<Blah>();
ServiceProvider serviceProvider = services.BuildServiceProvider();

var logger = serviceProvider.GetService<ILogger<Blah>>();
serviceProvider.GetService<Blah>().Run(logger);

public class Blah
{
	public void Run(ILogger<Blah> logger)
	{
		Console.WriteLine("Console Writeline");
		logger.LogTrace("here is a TRACE log");
		logger.LogDebug("here is a DEBUG log");
		logger.LogInformation("here is a INFORMATION log");
		logger.LogWarning("here is a WARNING log");
		logger.LogError("here is a ERROR log");
		logger.LogCritical("here is a CRITICAL log");
		Console.ReadLine();
	}
}