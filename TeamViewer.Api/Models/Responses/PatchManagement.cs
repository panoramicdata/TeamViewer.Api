using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Represents a device in patch management.
/// </summary>
public class PatchManagementDevice
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
	/// Gets or sets the missing patch count.
	/// </summary>
	[JsonPropertyName("missingPatchCount")]
	public int MissingPatchCount { get; set; }

	/// <summary>
	/// Gets or sets the last scan date.
	/// </summary>
	[JsonPropertyName("lastScanDate")]
	public DateTime? LastScanDate { get; set; }
}

/// <summary>
/// Response containing a list of patch management devices.
/// </summary>
public class PatchManagementDeviceListResponse
{
	/// <summary>
	/// Gets or sets the list of devices.
	/// </summary>
	[JsonPropertyName("devices")]
	public List<PatchManagementDevice> Devices { get; set; } = [];
}

/// <summary>
/// Represents a missing patch.
/// </summary>
public class MissingPatch
{
	/// <summary>
	/// Gets or sets the patch ID.
	/// </summary>
	[JsonPropertyName("patchId")]
	public string? PatchId { get; set; }

	/// <summary>
	/// Gets or sets the patch name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the severity.
	/// </summary>
	[JsonPropertyName("severity")]
	public string? Severity { get; set; }

	/// <summary>
	/// Gets or sets the KB article ID.
	/// </summary>
	[JsonPropertyName("kbArticleId")]
	public string? KbArticleId { get; set; }

	/// <summary>
	/// Gets or sets the release date.
	/// </summary>
	[JsonPropertyName("releaseDate")]
	public DateTime? ReleaseDate { get; set; }
}

/// <summary>
/// Response containing a list of missing patches.
/// </summary>
public class MissingPatchListResponse
{
	/// <summary>
	/// Gets or sets the list of missing patches.
	/// </summary>
	[JsonPropertyName("patches")]
	public List<MissingPatch> Patches { get; set; } = [];
}

/// <summary>
/// Represents patch scan result counts.
/// </summary>
public class PatchScanResultCounts
{
	/// <summary>
	/// Gets or sets the total device count.
	/// </summary>
	[JsonPropertyName("totalDevices")]
	public int TotalDevices { get; set; }

	/// <summary>
	/// Gets or sets the devices with missing patches count.
	/// </summary>
	[JsonPropertyName("devicesWithMissingPatches")]
	public int DevicesWithMissingPatches { get; set; }

	/// <summary>
	/// Gets or sets the total missing patches count.
	/// </summary>
	[JsonPropertyName("totalMissingPatches")]
	public int TotalMissingPatches { get; set; }

	/// <summary>
	/// Gets or sets the critical patches count.
	/// </summary>
	[JsonPropertyName("criticalPatches")]
	public int CriticalPatches { get; set; }
}

/// <summary>
/// Represents a patch management policy.
/// </summary>
public class PatchPolicy
{
	/// <summary>
	/// Gets or sets the policy ID.
	/// </summary>
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	/// <summary>
	/// Gets or sets the policy name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the policy description.
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the policy is enabled.
	/// </summary>
	[JsonPropertyName("enabled")]
	public bool Enabled { get; set; }
}

/// <summary>
/// Response containing a list of patch policies.
/// </summary>
public class PatchPolicyListResponse
{
	/// <summary>
	/// Gets or sets the list of policies.
	/// </summary>
	[JsonPropertyName("policies")]
	public List<PatchPolicy> Policies { get; set; } = [];
}
