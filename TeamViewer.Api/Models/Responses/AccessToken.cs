namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Represents an API access token.
/// </summary>
public class AccessToken
{
	/// <summary>
	/// Gets or sets the token ID.
	/// </summary>
	[JsonPropertyName("token_id")]
	public string? TokenId { get; set; }

	/// <summary>
	/// Gets or sets the token name/description.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the token value (only available on creation).
	/// </summary>
	[JsonPropertyName("token")]
	public string? Token { get; set; }

	/// <summary>
	/// Gets or sets the token scopes.
	/// </summary>
	[JsonPropertyName("scopes")]
	public List<string> Scopes { get; set; } = [];

	/// <summary>
	/// Gets or sets the creation date.
	/// </summary>
	[JsonPropertyName("created_at")]
	public DateTime? CreatedAt { get; set; }

	/// <summary>
	/// Gets or sets the expiration date.
	/// </summary>
	[JsonPropertyName("expires_at")]
	public DateTime? ExpiresAt { get; set; }

	/// <summary>
	/// Gets or sets the last used date.
	/// </summary>
	[JsonPropertyName("last_used_at")]
	public DateTime? LastUsedAt { get; set; }
}
