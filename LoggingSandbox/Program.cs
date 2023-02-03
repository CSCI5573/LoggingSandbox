// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Timers;

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
		StartTimer("Starting");
		Console.WriteLine("Console Writeline");
		logger.LogTrace("here is a TRACE log");
		logger.LogDebug("here is a DEBUG log");
		logger.LogInformation("here is a INFORMATION log");
		logger.LogWarning("here is a WARNING log");
		logger.LogError("here is a ERROR log");
		logger.LogCritical("here is a CRITICAL log");
		StopTimer();
		Console.ReadLine();
	}
	#region timer
	private static System.Timers.Timer aTimer;
	public DateTime startTime;
	private void StartTimer(string message)
	{
		startTime = DateTime.Now;
		Console.WriteLine($"\n{message}");
		// Create a timer with a two second interval.
		aTimer = new System.Timers.Timer(1000);
		// Hook up the Elapsed event for the timer. 
		aTimer.Elapsed += OnTimedEvent;
		aTimer.AutoReset = true;
		aTimer.Enabled = true;
	}
	private void StopTimer()
	{
		aTimer.Stop();
		aTimer.Dispose();
	}
	private void OnTimedEvent(Object source, ElapsedEventArgs e)
	{
		var diff = e.SignalTime - startTime;
		Console.Write($"\rElapsed time {Math.Round(diff.TotalSeconds)}");
	}
	#endregion
}