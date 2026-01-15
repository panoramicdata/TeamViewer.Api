namespace TeamViewer.Api.Interfaces;

/// <summary>
/// API interface for remote management features including monitoring, patch management, and endpoint protection.
/// </summary>
public interface IRemoteManagementApi
{
	/// <summary>
	/// Gets a list of managed devices.
	/// </summary>
	/// <param name="request">The request parameters.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of managed devices.</returns>
	[Get("/managed/devices")]
	Task<ManagedDeviceListResponse> GetManagedDevicesAsync(
		[Query] GetManagedDevicesRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets a specific managed device by ID.
	/// </summary>
	/// <param name="deviceId">The device ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The managed device.</returns>
	[Get("/managed/devices/{deviceId}")]
	Task<ManagedDevice> GetManagedDeviceAsync(
		string deviceId,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets a list of managed groups.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of managed groups.</returns>
	[Get("/managed/groups")]
	Task<ManagedGroupListResponse> GetManagedGroupsAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets a specific managed group by ID.
	/// </summary>
	/// <param name="groupId">The group ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The managed group.</returns>
	[Get("/managed/groups/{groupId}")]
	Task<ManagedGroup> GetManagedGroupAsync(
		string groupId,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets devices in a managed group.
	/// </summary>
	/// <param name="groupId">The group ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of devices in the group.</returns>
	[Get("/managed/groups/{groupId}/devices")]
	Task<ManagedDeviceListResponse> GetManagedGroupDevicesAsync(
		string groupId,
		CancellationToken cancellationToken);

	/// <summary>
	/// Adds a device to a managed group.
	/// </summary>
	/// <param name="groupId">The group ID.</param>
	/// <param name="request">The add device request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Post("/managed/groups/{groupId}/devices")]
	Task AddDeviceToManagedGroupAsync(
		string groupId,
		[Body] AddManagedDeviceRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Removes a device from a managed group.
	/// </summary>
	/// <param name="groupId">The group ID.</param>
	/// <param name="deviceId">The device ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Delete("/managed/groups/{groupId}/devices/{deviceId}")]
	Task RemoveDeviceFromManagedGroupAsync(
		string groupId,
		string deviceId,
		CancellationToken cancellationToken);
}
