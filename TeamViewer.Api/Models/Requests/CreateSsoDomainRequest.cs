namespace TeamViewer.Api.Models.Requests;

/// <summary>
/// Request to create an SSO domain.
/// </summary>
public class CreateSsoDomainRequest
{
	/// <summary>
	/// Gets or sets the domain name. Required.
	/// </summary>
	[JsonPropertyName("DomainName")]
	public required string DomainName { get; set; }

	/// <summary>
	/// Gets or sets the identity provider ID.
	/// </summary>
	[JsonPropertyName("IdentityProviderId")]
	public string? IdentityProviderId { get; set; }
}
