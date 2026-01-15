using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Represents a role assignment.
/// </summary>
public class RoleAssignment
{
	/// <summary>
	/// Gets or sets the role ID.
	/// </summary>
	[JsonPropertyName("roleId")]
	public string? RoleId { get; set; }

	/// <summary>
	/// Gets or sets the role name.
	/// </summary>
	[JsonPropertyName("roleName")]
	public string? RoleName { get; set; }

	/// <summary>
	/// Gets or sets the assignee ID (account or user group).
	/// </summary>
	[JsonPropertyName("assigneeId")]
	public string? AssigneeId { get; set; }

	/// <summary>
	/// Gets or sets the assignee name.
	/// </summary>
	[JsonPropertyName("assigneeName")]
	public string? AssigneeName { get; set; }
}

/// <summary>
/// Response containing a list of role assignments.
/// </summary>
public class RoleAssignmentListResponse
{
	/// <summary>
	/// Gets or sets the list of role assignments.
	/// </summary>
	[JsonPropertyName("resources")]
	public List<RoleAssignment> Assignments { get; set; } = [];
}
