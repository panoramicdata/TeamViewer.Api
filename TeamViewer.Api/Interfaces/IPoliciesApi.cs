using Refit;
using TeamViewer.Api.Models.Requests;
using TeamViewer.Api.Models.Responses;

namespace TeamViewer.Api.Interfaces;

/// <summary>
/// API interface for TeamViewer policy management.
/// </summary>
public interface IPoliciesApi
{
	/// <summary>
	/// Gets a list of TeamViewer policies.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of policies.</returns>
	[Get("/teamviewerpolicies")]
	Task<PolicyListResponse> GetAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets a specific policy by ID.
	/// </summary>
	/// <param name="policyId">The policy ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The policy.</returns>
	[Get("/teamviewerpolicies/{policyId}")]
	Task<Policy> GetAsync(
		string policyId,
		CancellationToken cancellationToken);
}
