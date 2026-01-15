namespace TeamViewer.Api.Interfaces;

/// <summary>
/// API interface for patch management.
/// </summary>
public interface IPatchManagementApi
{
	/// <summary>
	/// Gets a list of devices for patch management.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of devices.</returns>
	[Get("/patchmanagement/devices")]
	Task<PatchManagementDeviceListResponse> GetDevicesAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets missing patches for a specific device.
	/// </summary>
	/// <param name="deviceId">The device ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of missing patches.</returns>
	[Get("/patchmanagement/devices/{deviceId}/patches/missing")]
	Task<MissingPatchListResponse> GetMissingPatchesAsync(
		string deviceId,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets scan result counts.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The scan result counts.</returns>
	[Get("/patchmanagement/scanresultcounts")]
	Task<PatchScanResultCounts> GetScanResultCountsAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets a list of patch management policies.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of policies.</returns>
	[Get("/PatchManagement/Policy")]
	Task<PatchPolicyListResponse> GetPoliciesAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Creates a new patch management policy.
	/// </summary>
	/// <param name="request">The create request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The created policy.</returns>
	[Post("/PatchManagement/Policy")]
	Task<PatchPolicy> CreatePolicyAsync(
		[Body] CreatePatchPolicyRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets a specific patch management policy by ID.
	/// </summary>
	/// <param name="policyId">The policy ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The policy.</returns>
	[Get("/PatchManagement/Policy/{policyId}")]
	Task<PatchPolicy> GetPolicyAsync(
		string policyId,
		CancellationToken cancellationToken);

	/// <summary>
	/// Updates a patch management policy.
	/// </summary>
	/// <param name="policyId">The policy ID.</param>
	/// <param name="request">The update request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Put("/PatchManagement/Policy/{policyId}")]
	Task UpdatePolicyAsync(
		string policyId,
		[Body] UpdatePatchPolicyRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Deletes a patch management policy.
	/// </summary>
	/// <param name="policyId">The policy ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Delete("/PatchManagement/Policy/{policyId}")]
	Task DeletePolicyAsync(
		string policyId,
		CancellationToken cancellationToken);

	/// <summary>
	/// Assigns a patch management policy to devices.
	/// </summary>
	/// <param name="request">The assignment request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Post("/PatchManagement/Policy/Assign")]
	Task AssignPolicyAsync(
		[Body] AssignPatchPolicyRequest request,
		CancellationToken cancellationToken);
}
