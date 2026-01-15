namespace TeamViewer.Api.Models.Requests;

/// <summary>
/// Request parameters for getting connection reports.
/// </summary>
public class GetConnectionReportsRequest
{
	/// <summary>
	/// Gets or sets the from date filter (ISO 8601 format).
	/// </summary>
	[AliasAs("from_date")]
	public string? FromDate { get; set; }

	/// <summary>
	/// Gets or sets the to date filter (ISO 8601 format).
	/// </summary>
	[AliasAs("to_date")]
	public string? ToDate { get; set; }

	/// <summary>
	/// Gets or sets the user name filter.
	/// </summary>
	[AliasAs("username")]
	public string? UserName { get; set; }

	/// <summary>
	/// Gets or sets the user ID filter.
	/// </summary>
	[AliasAs("userid")]
	public string? UserId { get; set; }

	/// <summary>
	/// Gets or sets the group ID filter.
	/// </summary>
	[AliasAs("groupid")]
	public string? GroupId { get; set; }
}
