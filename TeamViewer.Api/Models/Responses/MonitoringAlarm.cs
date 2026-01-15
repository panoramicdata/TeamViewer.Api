using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Represents a monitoring alarm.
/// </summary>
public class MonitoringAlarm
{
	/// <summary>
	/// Gets or sets the alarm ID.
	/// </summary>
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	/// <summary>
	/// Gets or sets the device ID.
	/// </summary>
	[JsonPropertyName("deviceId")]
	public string? DeviceId { get; set; }

	/// <summary>
	/// Gets or sets the device name.
	/// </summary>
	[JsonPropertyName("deviceName")]
	public string? DeviceName { get; set; }

	/// <summary>
	/// Gets or sets the alarm type.
	/// </summary>
	[JsonPropertyName("type")]
	public string? Type { get; set; }

	/// <summary>
	/// Gets or sets the alarm severity.
	/// </summary>
	[JsonPropertyName("severity")]
	public string? Severity { get; set; }

	/// <summary>
	/// Gets or sets the alarm message.
	/// </summary>
	[JsonPropertyName("message")]
	public string? Message { get; set; }

	/// <summary>
	/// Gets or sets the creation timestamp.
	/// </summary>
	[JsonPropertyName("createdAt")]
	public DateTime? CreatedAt { get; set; }

	/// <summary>
	/// Gets or sets the acknowledged timestamp.
	/// </summary>
	[JsonPropertyName("acknowledgedAt")]
	public DateTime? AcknowledgedAt { get; set; }
}

/// <summary>
/// Response containing a list of monitoring alarms.
/// </summary>
public class MonitoringAlarmListResponse
{
	/// <summary>
	/// Gets or sets the list of alarms.
	/// </summary>
	[JsonPropertyName("alarms")]
	public List<MonitoringAlarm> Alarms { get; set; } = [];
}
