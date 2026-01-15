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

	/// <summary>
	/// Gets screenshots for a connection report.
	/// </summary>
	/// <param name="reportId">The report ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of screenshot metadata.</returns>
	[Get("/reports/connections/{reportId}/screenshots")]
	Task<ScreenshotListResponse> GetConnectionScreenshotsAsync(
		string reportId,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets a specific screenshot image.
	/// </summary>
	/// <param name="reportId">The report ID.</param>
	/// <param name="screenshotId">The screenshot ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The screenshot data.</returns>
	[Get("/reports/connections/{reportId}/{screenshotId}/screenshot")]
	Task<byte[]> GetConnectionScreenshotAsync(
		string reportId,
		string screenshotId,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets AI summary for a connection report.
	/// </summary>
	/// <param name="reportId">The report ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The AI summary.</returns>
	[Get("/reports/connections/{reportId}/ai-summary")]
	Task<ReportSummary> GetConnectionAiSummaryAsync(
		string reportId,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets chat transcript for a connection report.
	/// </summary>
	/// <param name="reportId">The report ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The chat transcript.</returns>
	[Get("/reports/connections/{reportId}/chat-transcript")]
	Task<ReportTranscript> GetConnectionChatTranscriptAsync(
		string reportId,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets voice transcript for a connection report.
	/// </summary>
	/// <param name="reportId">The report ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The voice transcript.</returns>
	[Get("/reports/connections/{reportId}/voice-transcript")]
	Task<ReportTranscript> GetConnectionVoiceTranscriptAsync(
		string reportId,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets a list of device reports.
	/// </summary>
	/// <param name="request">The request parameters.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of device reports.</returns>
	[Get("/reports/devices")]
	Task<DeviceReportListResponse> GetDeviceReportsAsync(
		[Query] GetDeviceReportsRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets AI summary for a device report.
	/// </summary>
	/// <param name="reportId">The report ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The AI summary.</returns>
	[Get("/reports/devices/{reportId}/ai-summary")]
	Task<ReportSummary> GetDeviceAiSummaryAsync(
		string reportId,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets chat transcript for a device report.
	/// </summary>
	/// <param name="reportId">The report ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The chat transcript.</returns>
	[Get("/reports/devices/{reportId}/chat-transcript")]
	Task<ReportTranscript> GetDeviceChatTranscriptAsync(
		string reportId,
		CancellationToken cancellationToken);
}
