using Refit;
using TeamViewer.Api.Models.Requests;
using TeamViewer.Api.Models.Responses;

namespace TeamViewer.Api.Interfaces;

/// <summary>
/// API interface for monitoring policy management.
/// </summary>
public interface IMonitoringPolicyApi
{
	/// <summary>
	/// Gets a list of monitoring policies.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of monitoring policies.</returns>
	[Get("/Monitoring/Policy")]
	Task<MonitoringPolicyListResponse> GetAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Creates a new monitoring policy.
	/// </summary>
	/// <param name="request">The create request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The created monitoring policy.</returns>
	[Post("/Monitoring/Policy")]
	Task<MonitoringPolicy> CreateAsync(
		[Body] CreateMonitoringPolicyRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets a specific monitoring policy by ID.
	/// </summary>
	/// <param name="policyId">The policy ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The monitoring policy.</returns>
	[Get("/Monitoring/Policy/{policyId}")]
	Task<MonitoringPolicy> GetAsync(
		string policyId,
		CancellationToken cancellationToken);

	/// <summary>
	/// Updates a monitoring policy.
	/// </summary>
	/// <param name="policyId">The policy ID.</param>
	/// <param name="request">The update request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Put("/Monitoring/Policy/{policyId}")]
	Task UpdateAsync(
		string policyId,
		[Body] UpdateMonitoringPolicyRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Deletes a monitoring policy.
	/// </summary>
	/// <param name="policyId">The policy ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Delete("/Monitoring/Policy/{policyId}")]
	Task DeleteAsync(
		string policyId,
		CancellationToken cancellationToken);

	/// <summary>
	/// Assigns a monitoring policy to devices.
	/// </summary>
	/// <param name="request">The assignment request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Post("/Monitoring/Policy/Assign")]
	Task AssignAsync(
		[Body] AssignMonitoringPolicyRequest request,
		CancellationToken cancellationToken);
}
