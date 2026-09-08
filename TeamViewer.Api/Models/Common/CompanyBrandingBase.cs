namespace TeamViewer.Api.Models.Common;

/// <summary>
/// The company branding fields that the branding response and the update request carry in common.
/// </summary>
/// <remarks>
/// Only the fields whose type is identical on both sides live here. Whether branding is enabled is
/// declared by each side separately, because the response always states it while the request treats
/// it as optional.
/// </remarks>
public abstract class CompanyBrandingBase
{
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
}
