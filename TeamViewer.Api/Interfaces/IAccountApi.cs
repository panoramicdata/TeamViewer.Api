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
	Task<AccountResponse> GetAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Updates the current account information.
	/// </summary>
	/// <param name="request">The update request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The updated account information.</returns>
	[Put("/account")]
	Task<AccountResponse> UpdateAsync(
		[Body] AccountUpdateRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets a list of API access tokens.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of access tokens.</returns>
	[Get("/account/accesstokens")]
	Task<AccessTokenListResponse> GetAccessTokensAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Creates a new API access token.
	/// </summary>
	/// <param name="request">The create access token request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The created access token.</returns>
	[Post("/account/accesstokens")]
	Task<AccessToken> CreateAccessTokenAsync(
		[Body] CreateAccessTokenRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Deletes an API access token.
	/// </summary>
	/// <param name="tokenId">The token ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Delete("/account/accesstokens/{tokenId}")]
	Task DeleteAccessTokenAsync(
		string tokenId,
		CancellationToken cancellationToken);
}
