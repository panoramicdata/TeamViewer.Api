using Refit;
using TeamViewer.Api.Models.Requests;
using TeamViewer.Api.Models.Responses;

namespace TeamViewer.Api.Interfaces;

/// <summary>
/// API interface for endpoint protection management.
/// </summary>
public interface IEndpointProtectionApi
{
	/// <summary>
	/// Gets a list of endpoints with protection status.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of endpoints.</returns>
	[Get("/endpointprotectionv2/endpoints")]
	Task<EndpointProtectionListResponse> GetEndpointsAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Installs endpoint protection on devices.
	/// </summary>
	/// <param name="request">The install request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Post("/endpointprotectionv2/install")]
	Task InstallAsync(
		[Body] InstallEndpointProtectionRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Links devices to endpoint protection.
	/// </summary>
	/// <param name="request">The link request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Post("/endpointprotectionv2/linkdevices")]
	Task LinkDevicesAsync(
		[Body] LinkDevicesRequest request,
		CancellationToken cancellationToken);
}
