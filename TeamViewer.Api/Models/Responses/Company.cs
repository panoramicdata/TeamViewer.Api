using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Represents company information.
/// </summary>
public class Company
{
	/// <summary>
	/// Gets or sets the company ID.
	/// </summary>
	[JsonPropertyName("company_id")]
	public string? CompanyId { get; set; }

	/// <summary>
	/// Gets or sets the company name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the company address.
	/// </summary>
	[JsonPropertyName("address")]
	public string? Address { get; set; }

	/// <summary>
	/// Gets or sets the company city.
	/// </summary>
	[JsonPropertyName("city")]
	public string? City { get; set; }

	/// <summary>
	/// Gets or sets the company country.
	/// </summary>
	[JsonPropertyName("country")]
	public string? Country { get; set; }

	/// <summary>
	/// Gets or sets the company postal code.
	/// </summary>
	[JsonPropertyName("postal_code")]
	public string? PostalCode { get; set; }

	/// <summary>
	/// Gets or sets the company phone number.
	/// </summary>
	[JsonPropertyName("phone")]
	public string? Phone { get; set; }

	/// <summary>
	/// Gets or sets the company email.
	/// </summary>
	[JsonPropertyName("email")]
	public string? Email { get; set; }

	/// <summary>
	/// Gets or sets the number of users.
	/// </summary>
	[JsonPropertyName("user_count")]
	public int UserCount { get; set; }
}
