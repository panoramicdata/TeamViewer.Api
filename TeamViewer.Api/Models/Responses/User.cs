namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Represents a TeamViewer user.
/// </summary>
public class User
{
	/// <summary>
	/// Gets or sets the user ID (prefixed with 'u').
	/// </summary>
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	/// <summary>
	/// Gets or sets the user's name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the user's email address.
	/// </summary>
	[JsonPropertyName("email")]
	public string? Email { get; set; }

	/// <summary>
	/// Gets or sets the user's permissions as a comma-separated string.
	/// </summary>
	[JsonPropertyName("permissions")]
	public string? Permissions { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the user is active.
	/// </summary>
	[JsonPropertyName("active")]
	public bool Active { get; set; }

	/// <summary>
	/// Gets or sets the log sessions setting.
	/// </summary>
	[JsonPropertyName("log_sessions")]
	public bool LogSessions { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether to show a comment window.
	/// </summary>
	[JsonPropertyName("show_comment_window")]
	public bool ShowCommentWindow { get; set; }

	/// <summary>
	/// Gets or sets the language used for emails.
	/// </summary>
	[JsonPropertyName("email_language")]
	public string? EmailLanguage { get; set; }

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

	/// <summary>
	/// Gets or sets the license type (e.g., "free", "premium").
	/// </summary>
	[JsonPropertyName("license")]
	public string? License { get; set; }

	/// <summary>
	/// Gets or sets the SSO customer ID.
	/// </summary>
	[JsonPropertyName("sso_customer_id")]
	public string? SsoCustomerId { get; set; }

	/// <summary>
	/// Gets or sets the last access date/time in ISO 8601 format.
	/// </summary>
	[JsonPropertyName("last_access_date")]
	public DateTime? LastAccessDate { get; set; }

	/// <summary>
	/// Gets or sets the activated license ID.
	/// </summary>
	[JsonPropertyName("activated_license_id")]
	public string? ActivatedLicenseId { get; set; }

	/// <summary>
	/// Gets or sets the activated license version.
	/// </summary>
	[JsonPropertyName("activated_license_version")]
	public string? ActivatedLicenseVersion { get; set; }

	/// <summary>
	/// Gets or sets the activated meeting license key.
	/// </summary>
	[JsonPropertyName("activated_meeting_license_key")]
	public string? ActivatedMeetingLicenseKey { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the user has a password.
	/// </summary>
	[JsonPropertyName("has_password")]
	public bool? HasPassword { get; set; }
}
