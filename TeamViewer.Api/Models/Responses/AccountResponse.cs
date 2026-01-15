namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Response containing account information.
/// </summary>
public class AccountResponse
{
	/// <summary>
	/// Gets or sets the account user ID.
	/// </summary>
	[JsonPropertyName("userid")]
	public string? UserId { get; set; }

	/// <summary>
	/// Gets or sets the account name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the account email.
	/// </summary>
	[JsonPropertyName("email")]
	public string? Email { get; set; }

	/// <summary>
	/// Gets or sets the company name.
	/// </summary>
	[JsonPropertyName("company_name")]
	public string? CompanyName { get; set; }

	/// <summary>
	/// Gets or sets the email language.
	/// </summary>
	[JsonPropertyName("email_language")]
	public string? EmailLanguage { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the email is validated.
	/// </summary>
	[JsonPropertyName("email_validated")]
	public bool EmailValidated { get; set; }
}
