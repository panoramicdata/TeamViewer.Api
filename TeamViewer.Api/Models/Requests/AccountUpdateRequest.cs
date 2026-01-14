using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Requests;

/// <summary>
/// Request to update account information.
/// </summary>
public class AccountUpdateRequest
{
	/// <summary>
	/// Gets or sets the account name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the email address.
	/// </summary>
	[JsonPropertyName("email")]
	public string? Email { get; set; }

	/// <summary>
	/// Gets or sets the email language.
	/// </summary>
	[JsonPropertyName("email_language")]
	public string? EmailLanguage { get; set; }
}
