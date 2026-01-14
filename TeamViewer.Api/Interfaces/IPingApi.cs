using Refit;
using TeamViewer.Api.Models.Responses;

namespace TeamViewer.Api.Interfaces;

/// <summary>
/// API interface for ping/connectivity testing.
/// </summary>
public interface IPingApi
{
	/// <summary>
	/// Tests connectivity and token validity.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>Ping response indicating token validity.</returns>
	[Get("/ping")]
	Task<PingResponse> PingAsync(CancellationToken cancellationToken);
}
