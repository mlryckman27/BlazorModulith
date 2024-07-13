# Blazor Modulith

This is a feature module for the Blazor Modulith solution.

## Setup
To setup a new Feature Module in your Blazor Modulith solution, follow the steps below.

The setup assumes you have an existing Blazor WASM project inside your solution called MainShell.

1. Add a new project reference to the FeatureModule project in the MainShell project.
2. Update the MainShell project's App.razor file to include the FeatureModule Assembly:
	```csharp
	@using System.Reflection
	<Router AppAssembly="@typeof(App).Assembly" AdditionalAssemblies="@_additionalAssemblies">
		<Found Context="routeData">
			<RouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)" />
			<FocusOnNavigate RouteData="@routeData" Selector="h1" />
		</Found>
		<NotFound>
			<PageTitle>Not found</PageTitle>
			<LayoutView Layout="@typeof(MainLayout)">
				<p role="alert">Sorry, there's nothing at this address.</p>
			</LayoutView>
		</NotFound>
	</Router>

	@code {
		private Assembly[] _additionalAssemblies = new[]
			{
			typeof(FeatureModule._Imports).Assembly
		};
	}
	```
3. Add the following code to the `MainShell.Program` class:
	```csharp
	builder.Services.AddHttpClient<TodoItemService>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
	builder.Services.AddScoped<ExampleJsInteropFeatureModule>();
	```
	Make sure you have installed the Microsoft.Extensions.Http package in the MainShell project.

4. Add the following markup to the `MainShell/wwwroot/index.html` file:
	```html
	<head>
		<link rel="stylesheet" href="_content/FeatureModule/featureModule.css"/>
	</head>
	<body>
		<script src="_content/FeatureModule/exampleJsInteropFeatureModule.js"></script>
	</body>
	```
5. Copy the wwwroot/sample-data folder and its contents from the FeatureModule project to the MainShell project.


## License

The Blazor Modulith project is licensed under the [MIT License](LICENSE).
