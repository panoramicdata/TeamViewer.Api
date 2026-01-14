using System.Text.Json.Serialization;

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
	public PolicySettings? Settings { get; set; }
}

/// <summary>
/// Represents TeamViewer policy settings.
/// </summary>
public class PolicySettings
{
	/// <summary>
	/// Gets or sets a value indicating whether to allow incoming connections.
	/// </summary>
	[JsonPropertyName("allow_incoming_connections")]
	public bool? AllowIncomingConnections { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether to allow outgoing connections.
	/// </summary>
	[JsonPropertyName("allow_outgoing_connections")]
	public bool? AllowOutgoingConnections { get; set; }

	/// <summary>
	/// Gets or sets the access control mode.
	/// </summary>
	[JsonPropertyName("access_control")]
	public string? AccessControl { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether to require password.
	/// </summary>
	[JsonPropertyName("require_password")]
	public bool? RequirePassword { get; set; }

	/// <summary>
	/// Gets or sets the password strength requirement.
	/// </summary>
	[JsonPropertyName("password_strength")]
	public int? PasswordStrength { get; set; }
}
