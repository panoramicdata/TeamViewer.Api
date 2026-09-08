using TeamViewer.Api.Models.Common;

namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Represents company branding settings.
/// </summary>
public class CompanyBranding : CompanyBrandingBase
{
	/// <summary>
	/// Gets or sets the company logo URL.
	/// </summary>
	[JsonPropertyName("logo_url")]
	public string? LogoUrl { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether branding is enabled.
	/// </summary>
	[JsonPropertyName("branding_enabled")]
	public bool BrandingEnabled { get; set; }
}
