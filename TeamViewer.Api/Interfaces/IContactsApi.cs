namespace TeamViewer.Api.Interfaces;

/// <summary>
/// API interface for contacts management.
/// </summary>
public interface IContactsApi
{
	/// <summary>
	/// Gets a list of contacts.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of contacts.</returns>
	[Get("/contacts")]
	Task<ContactListResponse> GetAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets a specific contact by ID.
	/// </summary>
	/// <param name="contactId">The contact ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The contact.</returns>
	[Get("/contacts/{contactId}")]
	Task<Contact> GetAsync(
		string contactId,
		CancellationToken cancellationToken);

	/// <summary>
	/// Invites a contact by email.
	/// </summary>
	/// <param name="request">The invite contact request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The created contact.</returns>
	[Post("/contacts")]
	Task<Contact> InviteAsync(
		[Body] InviteContactRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Deletes a contact.
	/// </summary>
	/// <param name="contactId">The contact ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Delete("/contacts/{contactId}")]
	Task DeleteAsync(
		string contactId,
		CancellationToken cancellationToken);
}
