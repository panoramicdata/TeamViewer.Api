namespace TeamViewer.Api.Models.Requests;

/// <summary>
/// Request to get device reports.
/// </summary>
public class GetDeviceReportsRequest
{
	/// <summary>
	/// Gets or sets the start date filter.
	/// </summary>
	[AliasAs("from_date")]
	public DateTime? FromDate { get; set; }

	/// <summary>
	/// Gets or sets the end date filter.
	/// </summary>
	[AliasAs("to_date")]
	public DateTime? ToDate { get; set; }

	/// <summary>
	/// Gets or sets the device ID filter.
	/// </summary>
	[AliasAs("deviceId")]
	public string? DeviceId { get; set; }

	/// <summary>
	/// Gets or sets the offset token for pagination.
	/// </summary>
	[AliasAs("offset_id")]
	public string? OffsetId { get; set; }

	/// <summary>
	/// Gets or sets the maximum number of results.
	/// </summary>
	[AliasAs("limit")]
	public int? Limit { get; set; }
}
