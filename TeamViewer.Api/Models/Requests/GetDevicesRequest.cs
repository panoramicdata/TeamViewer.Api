namespace TeamViewer.Api.Models.Requests;

/// <summary>
/// Request parameters for getting devices.
/// </summary>
public class GetDevicesRequest
{
	/// <summary>
	/// Gets or sets the remote control ID filter.
	/// </summary>
	[AliasAs("remotecontrol_id")]
	public string? RemoteControlId { get; set; }

	/// <summary>
	/// Gets or sets the group ID filter.
	/// </summary>
	[AliasAs("groupid")]
	public string? GroupId { get; set; }

	/// <summary>
	/// Gets or sets the online state filter (online, offline, busy).
	/// </summary>
	[AliasAs("online_state")]
	public string? OnlineState { get; set; }
}
