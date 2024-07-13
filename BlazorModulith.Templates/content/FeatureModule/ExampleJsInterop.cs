using Microsoft.JSInterop;

namespace FeatureModule
{
	// Register this class as a scoped service in the DI container.
	// Typically, you would register this class in the Main Shell project's Program.cs file.
	// 
	// Additional, make sure to import the exampleJsInteropFeatureModule.js file into the Main Shell project's index.html file.

	public class ExampleJsInterop : IAsyncDisposable
	{
		private readonly Lazy<Task<IJSObjectReference>> moduleTask;

		public ExampleJsInterop(IJSRuntime jsRuntime)
		{
			moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
				"import", "./_content/FeatureModule/exampleJsInterop.js").AsTask());
		}

		/// <summary>
		/// Copies the given text to the clipboard.
		/// </summary>
		/// <param name="text">string to be copied to clipboard</param>
		/// <returns></returns>
		public async Task CopyToClipBoard(string text)
		{
			var module = await moduleTask.Value;
			await module.InvokeVoidAsync("copyToClipBoard", text);
		}

		public async ValueTask DisposeAsync()
		{
			if (moduleTask.IsValueCreated)
			{
				var module = await moduleTask.Value;
				await module.DisposeAsync();
			}
		}
	}
}
