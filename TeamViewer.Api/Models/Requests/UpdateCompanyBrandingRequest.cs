using TeamViewer.Api.Models.Common;

namespace TeamViewer.Api.Models.Requests;

/// <summary>
/// Request to update company branding settings. Fields left unset are not changed.
/// </summary>
public class UpdateCompanyBrandingRequest : CompanyBrandingBase
{
	/// <summary>
	/// Gets or sets a value indicating whether branding is enabled. Left unset to keep the current setting.
	/// </summary>
	[JsonPropertyName("branding_enabled")]
	public bool? BrandingEnabled { get; set; }
}
