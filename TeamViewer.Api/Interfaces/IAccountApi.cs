using Refit;
using TeamViewer.Api.Models.Requests;
using TeamViewer.Api.Models.Responses;

namespace TeamViewer.Api.Interfaces;

/// <summary>
/// API interface for account management.
/// </summary>
public interface IAccountApi
{
	/// <summary>
	/// Gets the current account information.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The account information.</returns>
	[Get("/account")]
	Task<AccountResponse> GetAccountAsync(CancellationToken cancellationToken = default);

	/// <summary>
	/// Updates the current account information.
	/// </summary>
	/// <param name="request">The update request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The updated account information.</returns>
	[Put("/account")]
	Task<AccountResponse> UpdateAccountAsync([Body] AccountUpdateRequest request, CancellationToken cancellationToken = default);
}
