using Refit;
using TeamViewer.Api.Models.Requests;
using TeamViewer.Api.Models.Responses;

namespace TeamViewer.Api.Interfaces;

/// <summary>
/// API interface for device management in Computers &amp; Contacts.
/// </summary>
public interface IDevicesApi
{
	/// <summary>
	/// Gets a list of devices.
	/// </summary>
	/// <param name="request">The request parameters.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of devices.</returns>
	[Get("/devices")]
	Task<DeviceListResponse> GetDevicesAsync([Query] GetDevicesRequest request, CancellationToken cancellationToken);

	/// <summary>
	/// Gets a specific device by ID.
	/// </summary>
	/// <param name="deviceId">The device ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The device.</returns>
	[Get("/devices/{deviceId}")]
	Task<Device> GetDeviceAsync(string deviceId, CancellationToken cancellationToken);

	/// <summary>
	/// Updates an existing device.
	/// </summary>
	/// <param name="deviceId">The device ID.</param>
	/// <param name="request">The update device request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Put("/devices/{deviceId}")]
	Task UpdateDeviceAsync(string deviceId, [Body] UpdateDeviceRequest request, CancellationToken cancellationToken);

	/// <summary>
	/// Deletes a device from Computers &amp; Contacts.
	/// </summary>
	/// <param name="deviceId">The device ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Delete("/devices/{deviceId}")]
	Task DeleteDeviceAsync(string deviceId, CancellationToken cancellationToken);
}
