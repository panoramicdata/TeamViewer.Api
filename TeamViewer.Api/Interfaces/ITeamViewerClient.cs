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

	/// <summary>
	/// Gets the WebConnector API for managing WebConnector sessions.
	/// </summary>
	IWebConnectorApi WebConnector { get; }

	/// <summary>
	/// Gets the User Groups API for managing user groups.
	/// </summary>
	IUserGroupsApi UserGroups { get; }

	/// <summary>
	/// Gets the User Roles API for managing user roles.
	/// </summary>
	IUserRolesApi UserRoles { get; }

	/// <summary>
	/// Gets the Monitoring API for device monitoring.
	/// </summary>
	IMonitoringApi Monitoring { get; }

	/// <summary>
	/// Gets the Monitoring Policy API for managing monitoring policies.
	/// </summary>
	IMonitoringPolicyApi MonitoringPolicy { get; }

	/// <summary>
	/// Gets the Patch Management API for patch management.
	/// </summary>
	IPatchManagementApi PatchManagement { get; }

	/// <summary>
	/// Gets the Endpoint Protection API for endpoint protection management.
	/// </summary>
	IEndpointProtectionApi EndpointProtection { get; }

	/// <summary>
	/// Gets the Chat API for TeamViewer chat functionality.
	/// </summary>
	IChatApi Chat { get; }

	/// <summary>
	/// Gets the Conditional Access API for conditional access management.
	/// </summary>
	IConditionalAccessApi ConditionalAccess { get; }

	/// <summary>
	/// Gets the Company API for company information.
	/// </summary>
	ICompanyApi Company { get; }

	/// <summary>
	/// Gets the Company Address Book API for address book management.
	/// </summary>
	ICompanyAddressBookApi CompanyAddressBook { get; }

	/// <summary>
	/// Gets the IoT API for IoT management.
	/// </summary>
	IIotApi Iot { get; }

	/// <summary>
	/// Gets the OEM API for OEM tenant and licensing management.
	/// </summary>
	IOemApi Oem { get; }

	/// <summary>
	/// Gets the OEM Devices API for OEM device management.
	/// </summary>
	IOemDevicesApi OemDevices { get; }

	/// <summary>
	/// Gets the OAuth2 API for OAuth2 client management.
	/// </summary>
	IOAuth2Api OAuth2 { get; }

	/// <summary>
	/// Gets the Socket Authentication API for WebSocket authentication.
	/// </summary>
	ISocketAuthenticationApi SocketAuthentication { get; }

	/// <summary>
	/// Gets the Reach Notifications API for real-time notification subscriptions.
	/// </summary>
	IReachNotificationsApi ReachNotifications { get; }
}
