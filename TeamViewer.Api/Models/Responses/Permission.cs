using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Represents a permission.
/// </summary>
public class Permission
{
	/// <summary>
	/// Gets or sets the permission ID.
	/// </summary>
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	/// <summary>
	/// Gets or sets the permission name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the permission description.
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// Gets or sets the permission category.
	/// </summary>
	[JsonPropertyName("category")]
	public string? Category { get; set; }
}

/// <summary>
/// Response containing a list of permissions.
/// </summary>
public class PermissionListResponse
{
	/// <summary>
	/// Gets or sets the list of permissions.
	/// </summary>
	[JsonPropertyName("resources")]
	public List<Permission> Permissions { get; set; } = [];
}
