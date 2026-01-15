namespace TeamViewer.Api.Models.Requests;

/// <summary>
/// Request to update an existing user.
/// </summary>
public class UpdateUserRequest
{
	/// <summary>
	/// Gets or sets the user's email address.
	/// </summary>
	[JsonPropertyName("email")]
	public string? Email { get; set; }

	/// <summary>
	/// Gets or sets the user's name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the user's password.
	/// </summary>
	[JsonPropertyName("password")]
	public string? Password { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the user is active.
	/// </summary>
	[JsonPropertyName("active")]
	public bool? Active { get; set; }

	/// <summary>
	/// Gets or sets the user's permissions as a comma-separated string.
	/// </summary>
	[JsonPropertyName("permissions")]
	public string? Permissions { get; set; }

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
