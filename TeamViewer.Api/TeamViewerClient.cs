namespace TeamViewer.Api;

/// <summary>
/// Client for interacting with the TeamViewer REST API.
/// </summary>
public class TeamViewerClient : ITeamViewerClient
{
	private readonly HttpClient _httpClient;
	private bool _disposed;

	/// <summary>
	/// Initializes a new instance of the <see cref="TeamViewerClient"/> class.
	/// </summary>
	/// <param name="options">The client options.</param>
	public TeamViewerClient(TeamViewerClientOptions options)
		: this(CreateHttpClient(options), CreateRefitSettings())
	{
	}

	// The API surface is created in its own constructor so that building the HTTP pipeline and
	// binding the Refit interfaces stay separately readable rather than one long constructor.
	private TeamViewerClient(HttpClient httpClient, RefitSettings refitSettings)
	{
		_httpClient = httpClient;

		Ping = RestService.For<IPingApi>(httpClient, refitSettings);
		Account = RestService.For<IAccountApi>(httpClient, refitSettings);
		Users = RestService.For<IUsersApi>(httpClient, refitSettings);
		Groups = RestService.For<IGroupsApi>(httpClient, refitSettings);
		Sessions = RestService.For<ISessionsApi>(httpClient, refitSettings);
		Devices = RestService.For<IDevicesApi>(httpClient, refitSettings);
		Contacts = RestService.For<IContactsApi>(httpClient, refitSettings);
		Reports = RestService.For<IReportsApi>(httpClient, refitSettings);
		Meetings = RestService.For<IMeetingsApi>(httpClient, refitSettings);
		EventLogging = RestService.For<IEventLoggingApi>(httpClient, refitSettings);
		Policies = RestService.For<IPoliciesApi>(httpClient, refitSettings);
		RemoteManagement = RestService.For<IRemoteManagementApi>(httpClient, refitSettings);
		CompanyBranding = RestService.For<ICompanyBrandingApi>(httpClient, refitSettings);
		SsoDomain = RestService.For<ISsoDomainApi>(httpClient, refitSettings);
		WebConnector = RestService.For<IWebConnectorApi>(httpClient, refitSettings);
		UserGroups = RestService.For<IUserGroupsApi>(httpClient, refitSettings);
		UserRoles = RestService.For<IUserRolesApi>(httpClient, refitSettings);
		Monitoring = RestService.For<IMonitoringApi>(httpClient, refitSettings);
		MonitoringPolicy = RestService.For<IMonitoringPolicyApi>(httpClient, refitSettings);
		PatchManagement = RestService.For<IPatchManagementApi>(httpClient, refitSettings);
		EndpointProtection = RestService.For<IEndpointProtectionApi>(httpClient, refitSettings);
		Chat = RestService.For<IChatApi>(httpClient, refitSettings);
		ConditionalAccess = RestService.For<IConditionalAccessApi>(httpClient, refitSettings);
		Company = RestService.For<ICompanyApi>(httpClient, refitSettings);
		CompanyAddressBook = RestService.For<ICompanyAddressBookApi>(httpClient, refitSettings);
		Iot = RestService.For<IIotApi>(httpClient, refitSettings);
		Oem = RestService.For<IOemApi>(httpClient, refitSettings);
		OemDevices = RestService.For<IOemDevicesApi>(httpClient, refitSettings);
		OAuth2 = RestService.For<IOAuth2Api>(httpClient, refitSettings);
		SocketAuthentication = RestService.For<ISocketAuthenticationApi>(httpClient, refitSettings);
		ReachNotifications = RestService.For<IReachNotificationsApi>(httpClient, refitSettings);
	}

	private static RefitSettings CreateRefitSettings()
		=> new()
		{
			ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions
			{
				PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
				DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
			})
		};

	private static HttpClient CreateHttpClient(TeamViewerClientOptions options)
	{
		ArgumentNullException.ThrowIfNull(options);

		// Chain handlers: Logging -> Auth -> Retry -> Error -> HttpClientHandler
		var authHandler = new AuthenticationHandler(options.ScriptToken);
		var retryHandler = new RetryHandler(
			options.MaxRetryAttempts,
			options.RetryDelayMilliseconds,
			options.Logger);
		var loggingHandler = new LoggingHandler(options.Logger);
		var errorHandler = new ErrorHandler
		{
			InnerHandler = new HttpClientHandler()
		};
		retryHandler.InnerHandler = errorHandler;
		authHandler.InnerHandler = retryHandler;
		loggingHandler.InnerHandler = authHandler;

		return new HttpClient(loggingHandler)
		{
			BaseAddress = new Uri(options.BaseUrl),
			Timeout = options.Timeout
		};
	}

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

	/// <inheritdoc/>
	public IRemoteManagementApi RemoteManagement { get; }

	/// <inheritdoc/>
	public ICompanyBrandingApi CompanyBranding { get; }

	/// <inheritdoc/>
	public ISsoDomainApi SsoDomain { get; }

	/// <inheritdoc/>
	public IWebConnectorApi WebConnector { get; }

	/// <inheritdoc/>
	public IUserGroupsApi UserGroups { get; }

	/// <inheritdoc/>
	public IUserRolesApi UserRoles { get; }

	/// <inheritdoc/>
	public IMonitoringApi Monitoring { get; }

	/// <inheritdoc/>
	public IMonitoringPolicyApi MonitoringPolicy { get; }

	/// <inheritdoc/>
	public IPatchManagementApi PatchManagement { get; }

	/// <inheritdoc/>
	public IEndpointProtectionApi EndpointProtection { get; }

	/// <inheritdoc/>
	public IChatApi Chat { get; }

	/// <inheritdoc/>
	public IConditionalAccessApi ConditionalAccess { get; }

	/// <inheritdoc/>
	public ICompanyApi Company { get; }

	/// <inheritdoc/>
	public ICompanyAddressBookApi CompanyAddressBook { get; }

	/// <inheritdoc/>
	public IIotApi Iot { get; }

	/// <inheritdoc/>
	public IOemApi Oem { get; }

	/// <inheritdoc/>
	public IOemDevicesApi OemDevices { get; }

	/// <inheritdoc/>
	public IOAuth2Api OAuth2 { get; }

	/// <inheritdoc/>
	public ISocketAuthenticationApi SocketAuthentication { get; }

	/// <inheritdoc/>
	public IReachNotificationsApi ReachNotifications { get; }

	/// <inheritdoc/>
	public void Dispose()
	{
		if (_disposed)
		{
			return;
		}

		_httpClient.Dispose();
		_disposed = true;
		GC.SuppressFinalize(this);
	}
}
