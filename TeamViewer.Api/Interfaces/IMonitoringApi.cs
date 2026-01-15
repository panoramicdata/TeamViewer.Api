using Refit;
using TeamViewer.Api.Models.Responses;

namespace TeamViewer.Api.Interfaces;

/// <summary>
/// API interface for device monitoring.
/// </summary>
public interface IMonitoringApi
{
	/// <summary>
	/// Gets a list of monitoring alarms.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of monitoring alarms.</returns>
	[Get("/monitoring/alarms")]
	Task<MonitoringAlarmListResponse> GetAlarmsAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets a list of monitored devices.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of monitored devices.</returns>
	[Get("/monitoring/devices")]
	Task<List<MonitoredDevice>> GetDevicesAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets information for a specific monitored device.
	/// </summary>
	/// <param name="deviceId">The device ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The device information.</returns>
	[Get("/monitoring/devices/{deviceId}/information")]
	Task<MonitoredDeviceInfo> GetDeviceInformationAsync(
		string deviceId,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets hardware information for a specific monitored device.
	/// </summary>
	/// <param name="deviceId">The device ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The device hardware information.</returns>
	[Get("/monitoring/devices/{deviceId}/hardware")]
	Task<MonitoredDeviceHardware> GetDeviceHardwareAsync(
		string deviceId,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets software information for a specific monitored device.
	/// </summary>
	/// <param name="deviceId">The device ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The device software information.</returns>
	[Get("/monitoring/devices/{deviceId}/software")]
	Task<MonitoredDeviceSoftware> GetDeviceSoftwareAsync(
		string deviceId,
		CancellationToken cancellationToken);
}
