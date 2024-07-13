using System.Net.Http.Json;

namespace CoreLibrary.Services
{
	public class LoggingService
	{
		private readonly HttpClient _httpClient;

		public LoggingService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task LogToServerAsync(LogMessage message)
		{
			await _httpClient.PostAsJsonAsync("", message);
		}

		public void LogToConsole(string message)
		{
			Console.WriteLine(message);
		}
	}

	public class LogMessage
	{
		public DateTime Timestamp { get; set; }
		public LogMessageLevel Level { get; set; }
		public string Message { get; set; }
	}

	public enum LogMessageLevel
	{
		Error,
		Warning,
		Information
	}
}
