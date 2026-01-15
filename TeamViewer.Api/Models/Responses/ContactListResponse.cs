namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Response containing a list of contacts.
/// </summary>
public class ContactListResponse
{
	/// <summary>
	/// Gets or sets the list of contacts.
	/// </summary>
	[JsonPropertyName("contacts")]
	public List<Contact> Contacts { get; set; } = [];
}
