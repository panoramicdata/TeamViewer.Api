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
	Task<SsoDomainListResponse> GetSsoDomainsAsync(CancellationToken cancellationToken);

	/// <summary>
	/// Creates a new SSO domain.
	/// </summary>
	/// <param name="request">The create request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The created SSO domain.</returns>
	[Post("/ssoDomain")]
	Task<SsoDomain> CreateSsoDomainAsync([Body] CreateSsoDomainRequest request, CancellationToken cancellationToken);

	/// <summary>
	/// Deletes an SSO domain.
	/// </summary>
	/// <param name="domainId">The domain ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Delete("/ssoDomain/{domainId}")]
	Task DeleteSsoDomainAsync(string domainId, CancellationToken cancellationToken);

	/// <summary>
	/// Verifies an SSO domain.
	/// </summary>
	/// <param name="domainId">The domain ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Post("/ssoDomain/{domainId}/verify")]
	Task VerifySsoDomainAsync(string domainId, CancellationToken cancellationToken);
}
