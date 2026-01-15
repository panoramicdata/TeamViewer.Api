using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Represents a directory group for conditional access.
/// </summary>
public class DirectoryGroup
{
	/// <summary>
	/// Gets or sets the group ID.
	/// </summary>
	[JsonPropertyName("id")]
	public string? Id { get; set; }

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

	/// <summary>
	/// Gets or sets the member count.
	/// </summary>
	[JsonPropertyName("memberCount")]
	public int MemberCount { get; set; }
}

/// <summary>
/// Response containing a list of directory groups.
/// </summary>
public class DirectoryGroupListResponse
{
	/// <summary>
	/// Gets or sets the list of directory groups.
	/// </summary>
	[JsonPropertyName("resources")]
	public List<DirectoryGroup> Groups { get; set; } = [];
}

/// <summary>
/// Represents a directory group member.
/// </summary>
public class DirectoryGroupMember
{
	/// <summary>
	/// Gets or sets the member ID.
	/// </summary>
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	/// <summary>
	/// Gets or sets the member type.
	/// </summary>
	[JsonPropertyName("type")]
	public string? Type { get; set; }

	/// <summary>
	/// Gets or sets the member name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }
}

/// <summary>
/// Response containing a list of directory group members.
/// </summary>
public class DirectoryGroupMemberListResponse
{
	/// <summary>
	/// Gets or sets the list of members.
	/// </summary>
	[JsonPropertyName("resources")]
	public List<DirectoryGroupMember> Members { get; set; } = [];
}

/// <summary>
/// Represents a conditional access rule.
/// </summary>
public class ConditionalAccessRule
{
	/// <summary>
	/// Gets or sets the rule ID.
	/// </summary>
	[JsonPropertyName("id")]
	public string? Id { get; set; }

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
	public bool Enabled { get; set; }

	/// <summary>
	/// Gets or sets the rule priority.
	/// </summary>
	[JsonPropertyName("priority")]
	public int Priority { get; set; }
}

/// <summary>
/// Response containing a list of conditional access rules.
/// </summary>
public class ConditionalAccessRuleListResponse
{
	/// <summary>
	/// Gets or sets the list of rules.
	/// </summary>
	[JsonPropertyName("resources")]
	public List<ConditionalAccessRule> Rules { get; set; } = [];
}

/// <summary>
/// Represents a conditional access option.
/// </summary>
public class ConditionalAccessOption
{
	/// <summary>
	/// Gets or sets the option ID.
	/// </summary>
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	/// <summary>
	/// Gets or sets the option name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the option description.
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }
}

/// <summary>
/// Response containing a list of conditional access options.
/// </summary>
public class ConditionalAccessOptionListResponse
{
	/// <summary>
	/// Gets or sets the list of options.
	/// </summary>
	[JsonPropertyName("resources")]
	public List<ConditionalAccessOption> Options { get; set; } = [];
}
