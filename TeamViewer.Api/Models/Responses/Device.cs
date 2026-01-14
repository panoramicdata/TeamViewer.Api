using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Represents a TeamViewer device in Computers &amp; Contacts.
/// </summary>
public class Device
{
	/// <summary>
	/// Gets or sets the device ID (prefixed with 'd').
	/// </summary>
	[JsonPropertyName("device_id")]
	public string? DeviceId { get; set; }

	/// <summary>
	/// Gets or sets the remote control ID (prefixed with 'r').
	/// </summary>
	[JsonPropertyName("remotecontrol_id")]
	public string? RemoteControlId { get; set; }

	/// <summary>
	/// Gets or sets the group ID this device belongs to.
	/// </summary>
	[JsonPropertyName("groupid")]
	public string? GroupId { get; set; }

	/// <summary>
	/// Gets or sets the device alias/name.
	/// </summary>
	[JsonPropertyName("alias")]
	public string? Alias { get; set; }

	/// <summary>
	/// Gets or sets the device description.
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// Gets or sets the online state: online, offline, or busy.
	/// </summary>
	[JsonPropertyName("online_state")]
	public string? OnlineState { get; set; }

	/// <summary>
	/// Gets or sets the assigned user ID, or false if not assigned.
	/// </summary>
	[JsonPropertyName("assigned_to")]
	public object? AssignedTo { get; set; }

	/// <summary>
	/// Gets the assigned user ID if assigned, otherwise null.
	/// </summary>
	[JsonIgnore]
	public string? AssignedToUserId => AssignedTo is string s ? s : null;

	/// <summary>
	/// Gets or sets the supported features.
	/// </summary>
	[JsonPropertyName("supported_features")]
	public string? SupportedFeatures { get; set; }

	/// <summary>
	/// Gets or sets the policy ID assigned to this device.
	/// </summary>
	[JsonPropertyName("policy_id")]
	public string? PolicyId { get; set; }

	/// <summary>
	/// Gets or sets the last seen date/time.
	/// </summary>
	[JsonPropertyName("last_seen")]
	public DateTime? LastSeen { get; set; }
}
