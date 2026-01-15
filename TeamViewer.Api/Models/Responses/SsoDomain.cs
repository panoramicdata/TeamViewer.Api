using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Represents an SSO domain.
/// </summary>
public class SsoDomain
{
	/// <summary>
	/// Gets or sets the domain ID.
	/// </summary>
	[JsonPropertyName("DomainId")]
	public string? DomainId { get; set; }

	/// <summary>
	/// Gets or sets the domain name.
	/// </summary>
	[JsonPropertyName("DomainName")]
	public string? DomainName { get; set; }

	/// <summary>
	/// Gets or sets the verification status.
	/// </summary>
	[JsonPropertyName("VerificationStatus")]
	public string? VerificationStatus { get; set; }

	/// <summary>
	/// Gets or sets the verification token.
	/// </summary>
	[JsonPropertyName("VerificationToken")]
	public string? VerificationToken { get; set; }

	/// <summary>
	/// Gets or sets the creation date.
	/// </summary>
	[JsonPropertyName("CreatedAt")]
	public DateTime? CreatedAt { get; set; }

	/// <summary>
	/// Gets or sets the verification date.
	/// </summary>
	[JsonPropertyName("VerifiedAt")]
	public DateTime? VerifiedAt { get; set; }

	/// <summary>
	/// Gets or sets the identity provider ID.
	/// </summary>
	[JsonPropertyName("IdentityProviderId")]
	public string? IdentityProviderId { get; set; }
}
