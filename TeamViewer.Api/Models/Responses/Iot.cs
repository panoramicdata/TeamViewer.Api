namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Represents an IoT dashboard.
/// </summary>
public class IotDashboard
{
	/// <summary>
	/// Gets or sets the dashboard ID.
	/// </summary>
	[JsonPropertyName("id")]
	public string? Id { get; set; }

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

	/// <summary>
	/// Gets or sets the widget count.
	/// </summary>
	[JsonPropertyName("widgetCount")]
	public int WidgetCount { get; set; }
}

/// <summary>
/// Response containing a list of IoT dashboards.
/// </summary>
public class IotDashboardListResponse
{
	/// <summary>
	/// Gets or sets the current pagination token.
	/// </summary>
	[JsonPropertyName("currentPaginationToken")]
	public string? CurrentPaginationToken { get; set; }

	/// <summary>
	/// Gets or sets the next pagination token.
	/// </summary>
	[JsonPropertyName("nextPaginationToken")]
	public string? NextPaginationToken { get; set; }

	/// <summary>
	/// Gets or sets the list of dashboards.
	/// </summary>
	[JsonPropertyName("resources")]
	public List<IotDashboard> Dashboards { get; set; } = [];
}

/// <summary>
/// Represents an IoT widget.
/// </summary>
public class IotWidget
{
	/// <summary>
	/// Gets or sets the widget ID.
	/// </summary>
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	/// <summary>
	/// Gets or sets the widget name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the widget type.
	/// </summary>
	[JsonPropertyName("type")]
	public string? Type { get; set; }

	/// <summary>
	/// Gets or sets the widget configuration.
	/// </summary>
	[JsonPropertyName("configuration")]
	public object? Configuration { get; set; }
}

/// <summary>
/// Response containing a list of IoT widgets.
/// </summary>
public class IotWidgetListResponse
{
	/// <summary>
	/// Gets or sets the list of widgets.
	/// </summary>
	[JsonPropertyName("widgets")]
	public List<IotWidget> Widgets { get; set; } = [];
}

/// <summary>
/// Represents an IoT device configuration.
/// </summary>
public class IotDeviceConfiguration
{
	/// <summary>
	/// Gets or sets the configuration ID.
	/// </summary>
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	/// <summary>
	/// Gets or sets the configuration name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the device count.
	/// </summary>
	[JsonPropertyName("deviceCount")]
	public int DeviceCount { get; set; }
}

/// <summary>
/// Response containing a list of IoT device configurations.
/// </summary>
public class IotDeviceConfigurationListResponse
{
	/// <summary>
	/// Gets or sets the list of configurations.
	/// </summary>
	[JsonPropertyName("configurations")]
	public List<IotDeviceConfiguration> Configurations { get; set; } = [];
}

/// <summary>
/// Represents an IoT edge module.
/// </summary>
public class IotEdgeModule
{
	/// <summary>
	/// Gets or sets the module ID.
	/// </summary>
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	/// <summary>
	/// Gets or sets the module name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the module version.
	/// </summary>
	[JsonPropertyName("version")]
	public string? Version { get; set; }

	/// <summary>
	/// Gets or sets the module status.
	/// </summary>
	[JsonPropertyName("status")]
	public string? Status { get; set; }
}

/// <summary>
/// Response containing a list of IoT edge modules.
/// </summary>
public class IotEdgeModuleListResponse
{
	/// <summary>
	/// Gets or sets the list of edge modules.
	/// </summary>
	[JsonPropertyName("modules")]
	public List<IotEdgeModule> Modules { get; set; } = [];
}

/// <summary>
/// Represents the latest IoT data.
/// </summary>
public class IotLatestData
{
	/// <summary>
	/// Gets or sets the data points.
	/// </summary>
	[JsonPropertyName("dataPoints")]
	public List<IotDataPoint> DataPoints { get; set; } = [];
}

/// <summary>
/// Represents an IoT data point.
/// </summary>
public class IotDataPoint
{
	/// <summary>
	/// Gets or sets the device ID.
	/// </summary>
	[JsonPropertyName("deviceId")]
	public string? DeviceId { get; set; }

	/// <summary>
	/// Gets or sets the sensor ID.
	/// </summary>
	[JsonPropertyName("sensorId")]
	public string? SensorId { get; set; }

	/// <summary>
	/// Gets or sets the value.
	/// </summary>
	[JsonPropertyName("value")]
	public object? Value { get; set; }

	/// <summary>
	/// Gets or sets the timestamp.
	/// </summary>
	[JsonPropertyName("timestamp")]
	public DateTime? Timestamp { get; set; }
}
