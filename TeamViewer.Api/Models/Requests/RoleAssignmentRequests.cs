namespace TeamViewer.Api.Models.Requests;

/// <summary>
/// Request to assign a role to an account.
/// </summary>
public class AssignRoleToAccountRequest
{
	/// <summary>
	/// Gets or sets the role ID. Required.
	/// </summary>
	[JsonPropertyName("roleId")]
	public required string RoleId { get; set; }

	/// <summary>
	/// Gets or sets the account ID. Required.
	/// </summary>
	[JsonPropertyName("accountId")]
	public required string AccountId { get; set; }
}

/// <summary>
/// Request to unassign a role from an account.
/// </summary>
public class UnassignRoleFromAccountRequest
{
	/// <summary>
	/// Gets or sets the role ID. Required.
	/// </summary>
	[JsonPropertyName("roleId")]
	public required string RoleId { get; set; }

	/// <summary>
	/// Gets or sets the account ID. Required.
	/// </summary>
	[JsonPropertyName("accountId")]
	public required string AccountId { get; set; }
}

/// <summary>
/// Request to assign a role to a user group.
/// </summary>
public class AssignRoleToUserGroupRequest
{
	/// <summary>
	/// Gets or sets the role ID. Required.
	/// </summary>
	[JsonPropertyName("roleId")]
	public required string RoleId { get; set; }

	/// <summary>
	/// Gets or sets the user group ID. Required.
	/// </summary>
	[JsonPropertyName("userGroupId")]
	public required string UserGroupId { get; set; }
}

/// <summary>
/// Request to unassign a role from a user group.
/// </summary>
public class UnassignRoleFromUserGroupRequest
{
	/// <summary>
	/// Gets or sets the role ID. Required.
	/// </summary>
	[JsonPropertyName("roleId")]
	public required string RoleId { get; set; }

	/// <summary>
	/// Gets or sets the user group ID. Required.
	/// </summary>
	[JsonPropertyName("userGroupId")]
	public required string UserGroupId { get; set; }
}
