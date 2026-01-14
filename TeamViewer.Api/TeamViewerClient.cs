using System.Text.Json;
using Microsoft.Extensions.Logging;
using Refit;
using TeamViewer.Api.Handlers;
using TeamViewer.Api.Interfaces;

namespace TeamViewer.Api;

/// <summary>
/// Client for interacting with the TeamViewer REST API.
/// </summary>
public class TeamViewerClient : ITeamViewerClient
{
	private readonly HttpClient _httpClient;
	private bool _disposed;

	/// <inheritdoc/>
	public IPingApi Ping { get; }

	/// <inheritdoc/>
	public IAccountApi Account { get; }

	/// <inheritdoc/>
	public IUsersApi Users { get; }

	/// <inheritdoc/>
	public IGroupsApi Groups { get; }

	/// <summary>
	/// Initializes a new instance of the <see cref="TeamViewerClient"/> class.
	/// </summary>
	/// <param name="options">The client options.</param>
	/// <param name="loggerFactory">Optional logger factory.</param>
	public TeamViewerClient(TeamViewerClientOptions options, ILoggerFactory? loggerFactory = null)
	{
		ArgumentNullException.ThrowIfNull(options);

		var refitSettings = new RefitSettings
		{
			ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions
			{
				PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
				DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
			})
		};

		// Build handler chain
		var authHandler = new AuthenticationHandler(options.ScriptToken);
		var retryHandler = new RetryHandler(options.MaxRetryAttempts, options.RetryDelayMilliseconds, loggerFactory?.CreateLogger<RetryHandler>());
		var loggingHandler = new LoggingHandler(loggerFactory?.CreateLogger<LoggingHandler>());
		var errorHandler = new ErrorHandler();

		// Chain handlers: Logging -> Auth -> Retry -> Error -> HttpClientHandler
		errorHandler.InnerHandler = new HttpClientHandler();
		retryHandler.InnerHandler = errorHandler;
		authHandler.InnerHandler = retryHandler;
		loggingHandler.InnerHandler = authHandler;

		_httpClient = new HttpClient(loggingHandler)
		{
			BaseAddress = new Uri(options.BaseUrl),
			Timeout = options.Timeout
		};

		// Create Refit interfaces
		Ping = RestService.For<IPingApi>(_httpClient, refitSettings);
		Account = RestService.For<IAccountApi>(_httpClient, refitSettings);
		Users = RestService.For<IUsersApi>(_httpClient, refitSettings);
		Groups = RestService.For<IGroupsApi>(_httpClient, refitSettings);
	}

	/// <inheritdoc/>
	public void Dispose()
	{
		if (_disposed)
			return;

		_httpClient.Dispose();
		_disposed = true;
		GC.SuppressFinalize(this);
	}
}
