using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Represents a TeamViewer group.
/// </summary>
public class Group
{
	/// <summary>
	/// Gets or sets the group ID (prefixed with 'g').
	/// </summary>
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	/// <summary>
	/// Gets or sets the group name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the owner user ID.
	/// </summary>
	[JsonPropertyName("owner")]
	public string? Owner { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether this is a shared group.
	/// </summary>
	[JsonPropertyName("shared")]
	public bool Shared { get; set; }

	/// <summary>
	/// Gets or sets the permissions for this group.
	/// </summary>
	[JsonPropertyName("permissions")]
	public string? Permissions { get; set; }

	/// <summary>
	/// Gets or sets the policy ID associated with this group.
	/// </summary>
	[JsonPropertyName("policy_id")]
	public string? PolicyId { get; set; }
}
