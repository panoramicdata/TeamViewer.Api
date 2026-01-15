namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Represents a TeamViewer contact.
/// </summary>
public class Contact
{
	/// <summary>
	/// Gets or sets the contact ID (prefixed with 'c').
	/// </summary>
	[JsonPropertyName("contact_id")]
	public string? ContactId { get; set; }

	/// <summary>
	/// Gets or sets the user ID of the contact.
	/// </summary>
	[JsonPropertyName("user_id")]
	public string? UserId { get; set; }

	/// <summary>
	/// Gets or sets the contact name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the contact description.
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// Gets or sets the online state: online, offline, or busy.
	/// </summary>
	[JsonPropertyName("online_state")]
	public string? OnlineState { get; set; }

	/// <summary>
	/// Gets or sets the profile picture URL.
	/// </summary>
	[JsonPropertyName("profilepicture_url")]
	public string? ProfilePictureUrl { get; set; }

	/// <summary>
	/// Gets or sets the supported features.
	/// </summary>
	[JsonPropertyName("supported_features")]
	public string? SupportedFeatures { get; set; }

	/// <summary>
	/// Gets or sets the group ID this contact belongs to.
	/// </summary>
	[JsonPropertyName("groupid")]
	public string? GroupId { get; set; }

	/// <summary>
	/// Gets or sets the invitation state: pending or accepted.
	/// </summary>
	[JsonPropertyName("invite_state")]
	public string? InviteState { get; set; }
}
