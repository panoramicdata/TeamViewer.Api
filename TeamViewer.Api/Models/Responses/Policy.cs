namespace TeamViewer.Api.Models.Responses;

/// <summary>
	/// Represents a TeamViewer policy.
	/// </summary>
public class Policy
{
	/// <summary>
	/// Gets or sets the policy ID.
	/// </summary>
	[JsonPropertyName("policy_id")]
	public string? PolicyId { get; set; }

	/// <summary>
	/// Gets or sets the policy name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the policy settings.
	/// </summary>
	[JsonPropertyName("settings")]
	public List<PolicySetting> Settings { get; set; } = [];
}

/// <summary>
/// Represents a single TeamViewer policy setting.
/// </summary>
public class PolicySetting
{
	/// <summary>
	/// Gets or sets the setting key.
	/// </summary>
	[JsonPropertyName("Key")]
	public string? Key { get; set; }

	/// <summary>
	/// Gets or sets the setting value.
	/// </summary>
	[JsonPropertyName("Value")]
	public JsonElement? Value { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the setting is enforced.
	/// </summary>
	[JsonPropertyName("Enforce")]
	public bool Enforce { get; set; }
}
