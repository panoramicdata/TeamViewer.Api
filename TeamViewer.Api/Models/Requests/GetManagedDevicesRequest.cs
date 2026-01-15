namespace TeamViewer.Api.Models.Requests;

/// <summary>
/// Request parameters for getting managed devices.
/// </summary>
public class GetManagedDevicesRequest
{
	/// <summary>
	/// Gets or sets the group ID filter.
	/// </summary>
	[AliasAs("groupid")]
	public string? GroupId { get; set; }

	/// <summary>
	/// Gets or sets the online state filter.
	/// </summary>
	[AliasAs("online_state")]
	public string? OnlineState { get; set; }

	/// <summary>
	/// Gets or sets the policy ID filter.
	/// </summary>
	[AliasAs("policy_id")]
	public string? PolicyId { get; set; }
}
