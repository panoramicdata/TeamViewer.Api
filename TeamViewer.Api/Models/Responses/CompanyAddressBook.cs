namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Represents the company address book.
/// </summary>
public class CompanyAddressBook
{
	/// <summary>
	/// Gets or sets the members in the address book.
	/// </summary>
	[JsonPropertyName("members")]
	public List<AddressBookMember> Members { get; set; } = [];
}

/// <summary>
/// Represents an address book member.
/// </summary>
public class AddressBookMember
{
	/// <summary>
	/// Gets or sets the account ID.
	/// </summary>
	[JsonPropertyName("accountId")]
	public string? AccountId { get; set; }

	/// <summary>
	/// Gets or sets the member name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the member email.
	/// </summary>
	[JsonPropertyName("email")]
	public string? Email { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the member is hidden.
	/// </summary>
	[JsonPropertyName("isHidden")]
	public bool IsHidden { get; set; }
}

/// <summary>
/// Represents a hidden member.
/// </summary>
public class HiddenMember
{
	/// <summary>
	/// Gets or sets the account ID.
	/// </summary>
	[JsonPropertyName("accountId")]
	public string? AccountId { get; set; }

	/// <summary>
	/// Gets or sets the member name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the member email.
	/// </summary>
	[JsonPropertyName("email")]
	public string? Email { get; set; }
}

/// <summary>
/// Response containing a list of hidden members.
/// </summary>
public class HiddenMemberListResponse
{
	/// <summary>
	/// Gets or sets the list of hidden members.
	/// </summary>
	[JsonPropertyName("members")]
	public List<HiddenMember> Members { get; set; } = [];
}
