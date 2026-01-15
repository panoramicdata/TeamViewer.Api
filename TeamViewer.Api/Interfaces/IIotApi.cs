using Refit;
using TeamViewer.Api.Models.Requests;
using TeamViewer.Api.Models.Responses;

namespace TeamViewer.Api.Interfaces;

/// <summary>
/// API interface for IoT management.
/// </summary>
public interface IIotApi
{
	/// <summary>
	/// Gets a list of IoT dashboards.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of dashboards.</returns>
	[Get("/iot/dashboards")]
	Task<IotDashboardListResponse> GetDashboardsAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Creates a new IoT dashboard.
	/// </summary>
	/// <param name="request">The create request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The created dashboard.</returns>
	[Post("/iot/dashboards")]
	Task<IotDashboard> CreateDashboardAsync(
		[Body] CreateIotDashboardRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets a specific IoT dashboard by ID.
	/// </summary>
	/// <param name="dashboardId">The dashboard ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The dashboard.</returns>
	[Get("/iot/dashboards/{dashboardId}")]
	Task<IotDashboard> GetDashboardAsync(
		string dashboardId,
		CancellationToken cancellationToken);

	/// <summary>
	/// Updates an IoT dashboard.
	/// </summary>
	/// <param name="dashboardId">The dashboard ID.</param>
	/// <param name="request">The update request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Put("/iot/dashboards/{dashboardId}")]
	Task UpdateDashboardAsync(
		string dashboardId,
		[Body] UpdateIotDashboardRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Deletes an IoT dashboard.
	/// </summary>
	/// <param name="dashboardId">The dashboard ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Delete("/iot/dashboards/{dashboardId}")]
	Task DeleteDashboardAsync(
		string dashboardId,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets widgets for a dashboard.
	/// </summary>
	/// <param name="dashboardId">The dashboard ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of widgets.</returns>
	[Get("/iot/dashboards/{dashboardId}/widgets")]
	Task<IotWidgetListResponse> GetWidgetsAsync(
		string dashboardId,
		CancellationToken cancellationToken);

	/// <summary>
	/// Creates a widget on a dashboard.
	/// </summary>
	/// <param name="dashboardId">The dashboard ID.</param>
	/// <param name="request">The create request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The created widget.</returns>
	[Post("/iot/dashboards/{dashboardId}/widgets")]
	Task<IotWidget> CreateWidgetAsync(
		string dashboardId,
		[Body] CreateIotWidgetRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets device configurations.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of device configurations.</returns>
	[Get("/iot/device-configurations")]
	Task<IotDeviceConfigurationListResponse> GetDeviceConfigurationsAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Creates a device configuration.
	/// </summary>
	/// <param name="request">The create request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The created configuration.</returns>
	[Post("/iot/device-configurations")]
	Task<IotDeviceConfiguration> CreateDeviceConfigurationAsync(
		[Body] CreateIotDeviceConfigurationRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets edge modules.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of edge modules.</returns>
	[Get("/iot/edge-modules")]
	Task<IotEdgeModuleListResponse> GetEdgeModulesAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets the latest IoT data.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The latest IoT data.</returns>
	[Get("/iot/LatestData")]
	Task<IotLatestData> GetLatestDataAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Pushes IoT data.
	/// </summary>
	/// <param name="request">The data to push.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Post("/iot/data/push")]
	Task PushDataAsync(
		[Body] IotPushDataRequest request,
		CancellationToken cancellationToken);
}
