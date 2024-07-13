namespace BlazorModulith.CoreLibrary.Services
{
	public class LoggingService : ILoggingService
	{
		public void LogMessage(Exception ex)
		{
			Console.WriteLine(ex.Message);
			Console.WriteLine(ex.StackTrace);
		}
	}
}
