using System.Net.Http.Json;

namespace FeatureModule.Services
{
	public class TodoItemService
	{
		private readonly HttpClient _httpClient;

		public TodoItemService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<TodoItem[]?> GetTodoItems()
		{
			TodoItem[]? response = await _httpClient.GetFromJsonAsync<TodoItem[]>("sample-data/todo-items.json");
			return response;
		}
	}

	/// <summary>
	/// Model of a TodoItem representing a task to be completed.
	/// Examples include "Buy groceries", "Clean the house", "Do laundry", etc.
	/// </summary>
    public class TodoItem
    {
		public string? Title { get; set; }
		public string? Description { get; set; }
		public DateTime DueDate { get; set; }
		public bool IsCompleted { get; set; }
    }
}
