namespace TeamViewer.Api.Models.Requests;

/// <summary>
/// Request to create an API access token.
/// </summary>
public class CreateAccessTokenRequest
{
	/// <summary>
	/// Gets or sets the token name/description. Required.
	/// </summary>
	[JsonPropertyName("name")]
	public required string Name { get; set; }

	/// <summary>
	/// Gets or sets the token scopes.
	/// </summary>
	[JsonPropertyName("scopes")]
	public List<string> Scopes { get; set; } = [];

	/// <summary>
	/// Gets or sets the expiration date.
	/// </summary>
	[JsonPropertyName("expires_at")]
	public DateTime? ExpiresAt { get; set; }
}
