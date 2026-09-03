using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Requests;

/// <summary>
/// The OAuth2 client fields that the create and update requests carry in common.
/// </summary>
public abstract class OAuth2ClientRequest
{
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
	/// Gets or sets the requested scopes.
	/// </summary>
	[JsonPropertyName("scopes")]
	public List<string>? Scopes { get; set; }

	/// <summary>
	/// Gets or sets the grant types.
	/// </summary>
	[JsonPropertyName("grant_types")]
	public List<string>? GrantTypes { get; set; }
}

/// <summary>
/// Request to create an OAuth2 client.
/// </summary>
public class CreateOAuth2ClientRequest : OAuth2ClientRequest
{
	/// <summary>
	/// Gets or sets the client name. Required when creating a client.
	/// </summary>
	[JsonPropertyName("name")]
	public required string Name { get; set; }
}

/// <summary>
/// Request to update an OAuth2 client.
/// </summary>
public class UpdateOAuth2ClientRequest : OAuth2ClientRequest
{
	/// <summary>
	/// Gets or sets the client name. Left unset to keep the existing name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets whether the client is enabled.
	/// </summary>
	[JsonPropertyName("enabled")]
	public bool? Enabled { get; set; }
}
