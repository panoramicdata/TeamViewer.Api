using Refit;
using TeamViewer.Api.Models.Requests;
using TeamViewer.Api.Models.Responses;

namespace TeamViewer.Api.Interfaces;

/// <summary>
/// API interface for event logging (audit log access).
/// </summary>
public interface IEventLoggingApi
{
	/// <summary>
	/// Gets audit events based on the specified request parameters.
	/// </summary>
	/// <param name="request">The event logging request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of audit events.</returns>
	[Post("/EventLogging")]
	Task<EventLoggingResponse> GetEventsAsync([Body] EventLoggingRequest request, CancellationToken cancellationToken);
}
