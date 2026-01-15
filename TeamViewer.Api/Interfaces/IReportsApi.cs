using Refit;
using TeamViewer.Api.Models.Requests;
using TeamViewer.Api.Models.Responses;

namespace TeamViewer.Api.Interfaces;

/// <summary>
/// API interface for accessing connection and device reports.
/// </summary>
public interface IReportsApi
{
	/// <summary>
	/// Gets a list of connection reports.
	/// </summary>
	/// <param name="request">The request parameters.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of connection reports.</returns>
	[Get("/reports/connections")]
	Task<ConnectionReportListResponse> GetConnectionReportsAsync(
		[Query] GetConnectionReportsRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets a specific connection report by ID.
	/// </summary>
	/// <param name="reportId">The report ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The connection report.</returns>
	[Get("/reports/connections/{reportId}")]
	Task<ConnectionReport> GetConnectionReportAsync(
		string reportId,
		CancellationToken cancellationToken);
}
