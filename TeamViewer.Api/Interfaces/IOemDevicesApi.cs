using Refit;
using TeamViewer.Api.Models.Requests;
using TeamViewer.Api.Models.Responses;

namespace TeamViewer.Api.Interfaces;

/// <summary>
/// Interface for OEM Device operations.
/// </summary>
public interface IOemDevicesApi
{
	/// <summary>
	/// Gets OEM devices.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>List of OEM devices.</returns>
	[Get("/oem/devices")]
	Task<OemDeviceListResponse> GetDevicesAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets an OEM device by ID.
	/// </summary>
	/// <param name="deviceId">The device ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The device details.</returns>
	[Get("/oem/devices/{deviceId}")]
	Task<OemDevice> GetDeviceAsync(
		string deviceId,
		CancellationToken cancellationToken);

	/// <summary>
	/// Updates an OEM device.
	/// </summary>
	/// <param name="deviceId">The device ID.</param>
	/// <param name="request">The update request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The updated device.</returns>
	[Put("/oem/devices/{deviceId}")]
	Task<OemDevice> UpdateDeviceAsync(
		string deviceId,
		[Body] UpdateOemDeviceRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Deletes an OEM device.
	/// </summary>
	/// <param name="deviceId">The device ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Delete("/oem/devices/{deviceId}")]
	Task DeleteDeviceAsync(
		string deviceId,
		CancellationToken cancellationToken);
}
