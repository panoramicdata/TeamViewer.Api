using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Response containing a list of OAuth2 clients.
/// </summary>
public class OAuth2ClientListResponse
{
	/// <summary>
	/// Gets or sets the list of OAuth2 clients.
	/// </summary>
	[JsonPropertyName("clients")]
	public List<OAuth2Client> Clients { get; set; } = [];
}

/// <summary>
/// Represents an OAuth2 client.
/// </summary>
public class OAuth2Client
{
	/// <summary>
	/// Gets or sets the client ID.
	/// </summary>
	[JsonPropertyName("client_id")]
	public string ClientId { get; set; } = string.Empty;

	/// <summary>
	/// Gets or sets the client name.
	/// </summary>
	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;

	/// <summary>
	/// Gets or sets the client description.
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// Gets or sets the redirect URIs.
	/// </summary>
	[JsonPropertyName("redirect_uris")]
	public List<string>? RedirectUris { get; set; }

	/// <summary>
	/// Gets or sets the granted scopes.
	/// </summary>
	[JsonPropertyName("scopes")]
	public List<string>? Scopes { get; set; }

	/// <summary>
	/// Gets or sets the grant types.
	/// </summary>
	[JsonPropertyName("grant_types")]
	public List<string>? GrantTypes { get; set; }

	/// <summary>
	/// Gets or sets whether the client is enabled.
	/// </summary>
	[JsonPropertyName("enabled")]
	public bool? Enabled { get; set; }

	/// <summary>
	/// Gets or sets the creation date.
	/// </summary>
	[JsonPropertyName("created_at")]
	public DateTime? CreatedAt { get; set; }

	/// <summary>
	/// Gets or sets the last update date.
	/// </summary>
	[JsonPropertyName("updated_at")]
	public DateTime? UpdatedAt { get; set; }
}

/// <summary>
/// Represents an OAuth2 client with its secret.
/// </summary>
public class OAuth2ClientWithSecret : OAuth2Client
{
	/// <summary>
	/// Gets or sets the client secret.
	/// </summary>
	[JsonPropertyName("client_secret")]
	public string ClientSecret { get; set; } = string.Empty;
}
