using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Represents a user role.
/// </summary>
public class UserRole
{
	/// <summary>
	/// Gets or sets the role ID.
	/// </summary>
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	/// <summary>
	/// Gets or sets the role name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the role description.
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether this is a predefined role.
	/// </summary>
	[JsonPropertyName("isPredefined")]
	public bool IsPredefined { get; set; }

	/// <summary>
	/// Gets or sets the permissions assigned to this role.
	/// </summary>
	[JsonPropertyName("permissions")]
	public List<string> Permissions { get; set; } = [];
}
