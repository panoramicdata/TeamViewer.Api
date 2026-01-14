namespace TeamViewer.Api.Models.Common;

/// <summary>
/// User permission flags for TeamViewer users.
/// </summary>
[Flags]
public enum UserPermissions
{
	/// <summary>
	/// No special permissions.
	/// </summary>
	None = 0,

	/// <summary>
	/// Can share their groups with other users.
	/// </summary>
	ShareOwnGroups = 1 << 0,

	/// <summary>
	/// Can edit the company's Computers &amp; Contacts list.
	/// </summary>
	EditConnections = 1 << 1,

	/// <summary>
	/// Can edit all meetings.
	/// </summary>
	EditFullProfile = 1 << 2,

	/// <summary>
	/// Can manage admins.
	/// </summary>
	ManageAdmins = 1 << 3,

	/// <summary>
	/// Can manage users.
	/// </summary>
	ManageUsers = 1 << 4,

	/// <summary>
	/// Can manage groups.
	/// </summary>
	ManageGroups = 1 << 5,

	/// <summary>
	/// Can manage policies.
	/// </summary>
	ManagePolicies = 1 << 6,

	/// <summary>
	/// Can assign policies.
	/// </summary>
	AssignPolicies = 1 << 7,

	/// <summary>
	/// Can view all connections.
	/// </summary>
	ViewAllConnections = 1 << 8,

	/// <summary>
	/// Can use web client.
	/// </summary>
	AcknowledgeAllAlerts = 1 << 9,

	/// <summary>
	/// Can acknowledge all alerts.
	/// </summary>
	AcknowledgeOwnAlerts = 1 << 10,

	/// <summary>
	/// Can edit custom modules.
	/// </summary>
	EditCustomModules = 1 << 11,

	/// <summary>
	/// Can modify monitoring settings.
	/// </summary>
	ModifyMonitoring = 1 << 12,

	/// <summary>
	/// Can access service camp.
	/// </summary>
	ServiceCampAccess = 1 << 13,

	/// <summary>
	/// Can access asset management.
	/// </summary>
	AssetManagementAccess = 1 << 14,

	/// <summary>
	/// Can access backup.
	/// </summary>
	BackupAccess = 1 << 15,

	/// <summary>
	/// Can access endpoint protection.
	/// </summary>
	EndpointProtectionAccess = 1 << 16,

	/// <summary>
	/// Administrator with all permissions.
	/// </summary>
	Admin = ManageAdmins | ManageUsers | ManageGroups | ManagePolicies | AssignPolicies | ViewAllConnections
}
