using Refit;
using TeamViewer.Api.Models.Requests;
using TeamViewer.Api.Models.Responses;

namespace TeamViewer.Api.Interfaces;

/// <summary>
/// API interface for SSO domain management.
/// </summary>
public interface ISsoDomainApi
{
	/// <summary>
	/// Gets the list of SSO domains.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of SSO domains.</returns>
	[Get("/ssoDomain")]
	Task<SsoDomainListResponse> GetAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Creates a new SSO domain.
	/// </summary>
	/// <param name="request">The create request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The created SSO domain.</returns>
	[Post("/ssoDomain")]
	Task<SsoDomain> CreateAsync(
		[Body] CreateSsoDomainRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Deletes an SSO domain.
	/// </summary>
	/// <param name="domainId">The domain ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Delete("/ssoDomain/{domainId}")]
	Task DeleteAsync(
		string domainId,
		CancellationToken cancellationToken);

	/// <summary>
	/// Verifies an SSO domain.
	/// </summary>
	/// <param name="domainId">The domain ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Post("/ssoDomain/{domainId}/verify")]
	Task VerifyAsync(
		string domainId,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets the exclusion list for an SSO domain.
	/// </summary>
	/// <param name="domainId">The domain ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The exclusion list.</returns>
	[Get("/ssoDomain/{domainId}/exclusion")]
	Task<SsoAccessListResponse> GetExclusionListAsync(
		string domainId,
		CancellationToken cancellationToken);

	/// <summary>
	/// Adds emails to the exclusion list for an SSO domain.
	/// </summary>
	/// <param name="domainId">The domain ID.</param>
	/// <param name="request">The request containing emails to add.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Post("/ssoDomain/{domainId}/exclusion")]
	Task AddToExclusionListAsync(
		string domainId,
		[Body] SsoAccessListRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Removes emails from the exclusion list for an SSO domain.
	/// </summary>
	/// <param name="domainId">The domain ID.</param>
	/// <param name="request">The request containing emails to remove.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Delete("/ssoDomain/{domainId}/exclusion")]
	Task RemoveFromExclusionListAsync(
		string domainId,
		[Body] SsoAccessListRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets the inclusion list for an SSO domain.
	/// </summary>
	/// <param name="domainId">The domain ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The inclusion list.</returns>
	[Get("/ssoDomain/{domainId}/inclusion")]
	Task<SsoAccessListResponse> GetInclusionListAsync(
		string domainId,
		CancellationToken cancellationToken);

	/// <summary>
	/// Adds emails to the inclusion list for an SSO domain.
	/// </summary>
	/// <param name="domainId">The domain ID.</param>
	/// <param name="request">The request containing emails to add.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Post("/ssoDomain/{domainId}/inclusion")]
	Task AddToInclusionListAsync(
		string domainId,
		[Body] SsoAccessListRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Removes emails from the inclusion list for an SSO domain.
	/// </summary>
	/// <param name="domainId">The domain ID.</param>
	/// <param name="request">The request containing emails to remove.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Delete("/ssoDomain/{domainId}/inclusion")]
	Task RemoveFromInclusionListAsync(
		string domainId,
		[Body] SsoAccessListRequest request,
		CancellationToken cancellationToken);
}
