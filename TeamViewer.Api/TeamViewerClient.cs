using System.Text.Json;
using System.Text.Json.Serialization;
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

	/// <inheritdoc/>
	public ISessionsApi Sessions { get; }

	/// <inheritdoc/>
	public IDevicesApi Devices { get; }

	/// <inheritdoc/>
	public IContactsApi Contacts { get; }

	/// <inheritdoc/>
	public IReportsApi Reports { get; }

	/// <inheritdoc/>
	public IMeetingsApi Meetings { get; }

	/// <inheritdoc/>
	public IEventLoggingApi EventLogging { get; }

	/// <inheritdoc/>
	public IPoliciesApi Policies { get; }

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
				DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
			})
		};

		// Build handler chain
		var authHandler = new AuthenticationHandler(options.ScriptToken);
		var retryHandler = new RetryHandler(options.MaxRetryAttempts, options.RetryDelayMilliseconds, loggerFactory?.CreateLogger<RetryHandler>());
		var loggingHandler = new LoggingHandler(loggerFactory?.CreateLogger<LoggingHandler>());
		var errorHandler = new ErrorHandler
		{
			// Chain handlers: Logging -> Auth -> Retry -> Error -> HttpClientHandler
			InnerHandler = new HttpClientHandler()
		};
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
		Sessions = RestService.For<ISessionsApi>(_httpClient, refitSettings);
		Devices = RestService.For<IDevicesApi>(_httpClient, refitSettings);
		Contacts = RestService.For<IContactsApi>(_httpClient, refitSettings);
		Reports = RestService.For<IReportsApi>(_httpClient, refitSettings);
		Meetings = RestService.For<IMeetingsApi>(_httpClient, refitSettings);
		EventLogging = RestService.For<IEventLoggingApi>(_httpClient, refitSettings);
		Policies = RestService.For<IPoliciesApi>(_httpClient, refitSettings);
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
