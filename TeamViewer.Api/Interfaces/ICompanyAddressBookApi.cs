namespace TeamViewer.Api.Interfaces;

/// <summary>
/// API interface for company address book management.
/// </summary>
public interface ICompanyAddressBookApi
{
	/// <summary>
	/// Gets the company address book.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The company address book.</returns>
	[Get("/companyaddressbook")]
	Task<CompanyAddressBook> GetAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets hidden members from the address book.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of hidden members.</returns>
	[Get("/companyaddressbook/hiddenmembers")]
	Task<HiddenMemberListResponse> GetHiddenMembersAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Adds a member to the hidden list.
	/// </summary>
	/// <param name="request">The add hidden member request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Post("/companyaddressbook/hiddenmembers")]
	Task AddHiddenMemberAsync(
		[Body] AddHiddenMemberRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Removes a member from the hidden list.
	/// </summary>
	/// <param name="accountId">The account ID to unhide.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Delete("/companyaddressbook/hiddenmembers/{accountId}")]
	Task RemoveHiddenMemberAsync(
		string accountId,
		CancellationToken cancellationToken);
}
