namespace TeamViewer.Api.Interfaces;

/// <summary>
/// Interface for the TeamViewer API client.
/// </summary>
public interface ITeamViewerClient : IDisposable
{
	/// <summary>
	/// Gets the Ping API for testing connectivity.
	/// </summary>
	IPingApi Ping { get; }

	/// <summary>
	/// Gets the Account API for managing account information.
	/// </summary>
	IAccountApi Account { get; }

	/// <summary>
	/// Gets the Users API for managing company users.
	/// </summary>
	IUsersApi Users { get; }

	/// <summary>
	/// Gets the Groups API for managing groups.
	/// </summary>
	IGroupsApi Groups { get; }

	/// <summary>
	/// Gets the Sessions API for managing session codes.
	/// </summary>
	ISessionsApi Sessions { get; }

	/// <summary>
	/// Gets the Devices API for managing devices in Computers &amp; Contacts.
	/// </summary>
	IDevicesApi Devices { get; }

	/// <summary>
	/// Gets the Contacts API for managing contacts.
	/// </summary>
	IContactsApi Contacts { get; }

	/// <summary>
	/// Gets the Reports API for accessing connection reports.
	/// </summary>
	IReportsApi Reports { get; }

	/// <summary>
	/// Gets the Meetings API for managing meetings.
	/// </summary>
	IMeetingsApi Meetings { get; }

	/// <summary>
	/// Gets the Event Logging API for accessing audit events.
	/// </summary>
	IEventLoggingApi EventLogging { get; }

	/// <summary>
	/// Gets the Policies API for managing TeamViewer policies.
	/// </summary>
	IPoliciesApi Policies { get; }

	/// <summary>
	/// Gets the Remote Management API for managed devices and groups.
	/// </summary>
	IRemoteManagementApi RemoteManagement { get; }

	/// <summary>
	/// Gets the Company Branding API for managing custom branding.
	/// </summary>
	ICompanyBrandingApi CompanyBranding { get; }

	/// <summary>
	/// Gets the SSO Domain API for managing SSO domains.
	/// </summary>
	ISsoDomainApi SsoDomain { get; }
}
