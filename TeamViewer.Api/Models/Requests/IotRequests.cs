namespace TeamViewer.Api.Models.Requests;

/// <summary>
/// Request to create an IoT dashboard.
/// </summary>
public class CreateIotDashboardRequest
{
	/// <summary>
	/// Gets or sets the dashboard name. Required.
	/// </summary>
	[JsonPropertyName("name")]
	public required string Name { get; set; }

	/// <summary>
	/// Gets or sets the dashboard description.
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }
}

/// <summary>
/// Request to update an IoT dashboard.
/// </summary>
public class UpdateIotDashboardRequest
{
	/// <summary>
	/// Gets or sets the dashboard name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the dashboard description.
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }
}

/// <summary>
/// Request to create an IoT widget.
/// </summary>
public class CreateIotWidgetRequest
{
	/// <summary>
	/// Gets or sets the widget name. Required.
	/// </summary>
	[JsonPropertyName("name")]
	public required string Name { get; set; }

	/// <summary>
	/// Gets or sets the widget type. Required.
	/// </summary>
	[JsonPropertyName("type")]
	public required string Type { get; set; }

	/// <summary>
	/// Gets or sets the widget configuration.
	/// </summary>
	[JsonPropertyName("configuration")]
	public object? Configuration { get; set; }
}

/// <summary>
/// Request to create an IoT device configuration.
/// </summary>
public class CreateIotDeviceConfigurationRequest
{
	/// <summary>
	/// Gets or sets the configuration name. Required.
	/// </summary>
	[JsonPropertyName("name")]
	public required string Name { get; set; }
}

/// <summary>
/// Request to push IoT data.
/// </summary>
public class IotPushDataRequest
{
	/// <summary>
	/// Gets or sets the data points to push. Required.
	/// </summary>
	[JsonPropertyName("dataPoints")]
	public required List<IotPushDataPoint> DataPoints { get; set; }
}

/// <summary>
/// Represents a data point to push.
/// </summary>
public class IotPushDataPoint
{
	/// <summary>
	/// Gets or sets the device ID. Required.
	/// </summary>
	[JsonPropertyName("deviceId")]
	public required string DeviceId { get; set; }

	/// <summary>
	/// Gets or sets the sensor ID. Required.
	/// </summary>
	[JsonPropertyName("sensorId")]
	public required string SensorId { get; set; }

	/// <summary>
	/// Gets or sets the value. Required.
	/// </summary>
	[JsonPropertyName("value")]
	public required object Value { get; set; }

	/// <summary>
	/// Gets or sets the timestamp.
	/// </summary>
	[JsonPropertyName("timestamp")]
	public DateTime? Timestamp { get; set; }
}
