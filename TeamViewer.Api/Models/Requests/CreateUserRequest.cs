using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Requests;

/// <summary>
/// Request to create a new user.
/// </summary>
public class CreateUserRequest
{
	/// <summary>
	/// Gets or sets the user's email address. Required.
	/// </summary>
	[JsonPropertyName("email")]
	public required string Email { get; set; }

	/// <summary>
	/// Gets or sets the user's name. Required.
	/// </summary>
	[JsonPropertyName("name")]
	public required string Name { get; set; }

	/// <summary>
	/// Gets or sets the user's password. Required for non-SSO users.
	/// </summary>
	[JsonPropertyName("password")]
	public string? Password { get; set; }

	/// <summary>
	/// Gets or sets the language for emails (e.g., "en", "de").
	/// </summary>
	[JsonPropertyName("language")]
	public string? Language { get; set; }

	/// <summary>
	/// Gets or sets the user's permissions as a comma-separated string.
	/// </summary>
	[JsonPropertyName("permissions")]
	public string? Permissions { get; set; }

	/// <summary>
	/// Gets or sets the SSO customer ID if using single sign-on.
	/// </summary>
	[JsonPropertyName("sso_customer_id")]
	public string? SsoCustomerId { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the user should be active.
	/// </summary>
	[JsonPropertyName("active")]
	public bool? Active { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether to log sessions.
	/// </summary>
	[JsonPropertyName("log_sessions")]
	public bool? LogSessions { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether to show comment window.
	/// </summary>
	[JsonPropertyName("show_comment_window")]
	public bool? ShowCommentWindow { get; set; }

	/// <summary>
	/// Gets or sets the custom Quick Support ID.
	/// </summary>
	[JsonPropertyName("custom_quicksupport_id")]
	public string? CustomQuickSupportId { get; set; }

	/// <summary>
	/// Gets or sets the custom Quick Join ID.
	/// </summary>
	[JsonPropertyName("custom_quickjoin_id")]
	public string? CustomQuickJoinId { get; set; }
}
