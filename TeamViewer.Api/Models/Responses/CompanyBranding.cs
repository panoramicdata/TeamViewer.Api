namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Represents company branding settings.
/// </summary>
public class CompanyBranding
{
	/// <summary>
	/// Gets or sets the company logo URL.
	/// </summary>
	[JsonPropertyName("logo_url")]
	public string? LogoUrl { get; set; }

	/// <summary>
	/// Gets or sets the company name displayed in branding.
	/// </summary>
	[JsonPropertyName("company_name")]
	public string? CompanyName { get; set; }

	/// <summary>
	/// Gets or sets the support text.
	/// </summary>
	[JsonPropertyName("support_text")]
	public string? SupportText { get; set; }

	/// <summary>
	/// Gets or sets the support URL.
	/// </summary>
	[JsonPropertyName("support_url")]
	public string? SupportUrl { get; set; }

	/// <summary>
	/// Gets or sets the support email.
	/// </summary>
	[JsonPropertyName("support_email")]
	public string? SupportEmail { get; set; }

	/// <summary>
	/// Gets or sets the support phone number.
	/// </summary>
	[JsonPropertyName("support_phone")]
	public string? SupportPhone { get; set; }

	/// <summary>
	/// Gets or sets the primary color (hex format).
	/// </summary>
	[JsonPropertyName("primary_color")]
	public string? PrimaryColor { get; set; }

	/// <summary>
	/// Gets or sets the secondary color (hex format).
	/// </summary>
	[JsonPropertyName("secondary_color")]
	public string? SecondaryColor { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether branding is enabled.
	/// </summary>
	[JsonPropertyName("branding_enabled")]
	public bool BrandingEnabled { get; set; }
}
