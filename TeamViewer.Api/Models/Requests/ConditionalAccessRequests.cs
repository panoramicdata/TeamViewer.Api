using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Requests;

/// <summary>
/// Request to create a directory group.
/// </summary>
public class CreateDirectoryGroupRequest
{
	/// <summary>
	/// Gets or sets the group name. Required.
	/// </summary>
	[JsonPropertyName("name")]
	public required string Name { get; set; }

	/// <summary>
	/// Gets or sets the group description.
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }
}

/// <summary>
/// Request to update a directory group.
/// </summary>
public class UpdateDirectoryGroupRequest
{
	/// <summary>
	/// Gets or sets the group name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the group description.
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }
}

/// <summary>
/// Request to create a conditional access rule.
/// </summary>
public class CreateConditionalAccessRuleRequest
{
	/// <summary>
	/// Gets or sets the rule name. Required.
	/// </summary>
	[JsonPropertyName("name")]
	public required string Name { get; set; }

	/// <summary>
	/// Gets or sets the rule description.
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the rule is enabled.
	/// </summary>
	[JsonPropertyName("enabled")]
	public bool Enabled { get; set; } = true;

	/// <summary>
	/// Gets or sets the rule priority.
	/// </summary>
	[JsonPropertyName("priority")]
	public int Priority { get; set; }
}

/// <summary>
/// Request to update a conditional access rule.
/// </summary>
public class UpdateConditionalAccessRuleRequest
{
	/// <summary>
	/// Gets or sets the rule name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the rule description.
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the rule is enabled.
	/// </summary>
	[JsonPropertyName("enabled")]
	public bool? Enabled { get; set; }

	/// <summary>
	/// Gets or sets the rule priority.
	/// </summary>
	[JsonPropertyName("priority")]
	public int? Priority { get; set; }
}
