using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Represents a monitored device.
/// </summary>
public class MonitoredDevice
{
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
	/// Gets or sets the online state.
	/// </summary>
	[JsonPropertyName("onlineState")]
	public string? OnlineState { get; set; }

	/// <summary>
	/// Gets or sets the last seen timestamp.
	/// </summary>
	[JsonPropertyName("lastSeen")]
	public DateTime? LastSeen { get; set; }

	/// <summary>
	/// Gets or sets the operating system.
	/// </summary>
	[JsonPropertyName("operatingSystem")]
	public string? OperatingSystem { get; set; }
}

/// <summary>
/// Response containing a list of monitored devices.
/// </summary>
public class MonitoredDeviceListResponse
{
	/// <summary>
	/// Gets or sets the list of devices.
	/// </summary>
	[JsonPropertyName("devices")]
	public List<MonitoredDevice> Devices { get; set; } = [];
}

/// <summary>
/// Represents device information from monitoring.
/// </summary>
public class MonitoredDeviceInfo
{
	/// <summary>
	/// Gets or sets the device ID.
	/// </summary>
	[JsonPropertyName("deviceId")]
	public string? DeviceId { get; set; }

	/// <summary>
	/// Gets or sets the hostname.
	/// </summary>
	[JsonPropertyName("hostname")]
	public string? Hostname { get; set; }

	/// <summary>
	/// Gets or sets the IP address.
	/// </summary>
	[JsonPropertyName("ipAddress")]
	public string? IpAddress { get; set; }

	/// <summary>
	/// Gets or sets the operating system.
	/// </summary>
	[JsonPropertyName("operatingSystem")]
	public string? OperatingSystem { get; set; }

	/// <summary>
	/// Gets or sets the operating system version.
	/// </summary>
	[JsonPropertyName("osVersion")]
	public string? OsVersion { get; set; }

	/// <summary>
	/// Gets or sets the TeamViewer version.
	/// </summary>
	[JsonPropertyName("teamviewerVersion")]
	public string? TeamViewerVersion { get; set; }
}

/// <summary>
/// Represents device hardware information.
/// </summary>
public class MonitoredDeviceHardware
{
	/// <summary>
	/// Gets or sets the CPU information.
	/// </summary>
	[JsonPropertyName("cpu")]
	public string? Cpu { get; set; }

	/// <summary>
	/// Gets or sets the total RAM in bytes.
	/// </summary>
	[JsonPropertyName("totalRam")]
	public long TotalRam { get; set; }

	/// <summary>
	/// Gets or sets the available RAM in bytes.
	/// </summary>
	[JsonPropertyName("availableRam")]
	public long AvailableRam { get; set; }

	/// <summary>
	/// Gets or sets the disk information.
	/// </summary>
	[JsonPropertyName("disks")]
	public List<DiskInfo> Disks { get; set; } = [];
}

/// <summary>
/// Represents disk information.
/// </summary>
public class DiskInfo
{
	/// <summary>
	/// Gets or sets the disk name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the total size in bytes.
	/// </summary>
	[JsonPropertyName("totalSize")]
	public long TotalSize { get; set; }

	/// <summary>
	/// Gets or sets the free space in bytes.
	/// </summary>
	[JsonPropertyName("freeSpace")]
	public long FreeSpace { get; set; }
}

/// <summary>
/// Represents device software information.
/// </summary>
public class MonitoredDeviceSoftware
{
	/// <summary>
	/// Gets or sets the installed software list.
	/// </summary>
	[JsonPropertyName("software")]
	public List<InstalledSoftware> Software { get; set; } = [];
}

/// <summary>
/// Represents installed software.
/// </summary>
public class InstalledSoftware
{
	/// <summary>
	/// Gets or sets the software name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the software version.
	/// </summary>
	[JsonPropertyName("version")]
	public string? Version { get; set; }

	/// <summary>
	/// Gets or sets the publisher.
	/// </summary>
	[JsonPropertyName("publisher")]
	public string? Publisher { get; set; }

	/// <summary>
	/// Gets or sets the install date.
	/// </summary>
	[JsonPropertyName("installDate")]
	public DateTime? InstallDate { get; set; }
}
