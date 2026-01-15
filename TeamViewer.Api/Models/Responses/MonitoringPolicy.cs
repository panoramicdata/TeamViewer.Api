namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Represents a monitoring policy.
/// </summary>
public class MonitoringPolicy
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

	/// <summary>
	/// Gets or sets the policy settings.
	/// </summary>
	[JsonPropertyName("settings")]
	public MonitoringPolicySettings? Settings { get; set; }
}

/// <summary>
/// Represents monitoring policy settings.
/// </summary>
public class MonitoringPolicySettings
{
	/// <summary>
	/// Gets or sets a value indicating whether CPU monitoring is enabled.
	/// </summary>
	[JsonPropertyName("cpuMonitoring")]
	public bool CpuMonitoring { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether memory monitoring is enabled.
	/// </summary>
	[JsonPropertyName("memoryMonitoring")]
	public bool MemoryMonitoring { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether disk monitoring is enabled.
	/// </summary>
	[JsonPropertyName("diskMonitoring")]
	public bool DiskMonitoring { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether online state monitoring is enabled.
	/// </summary>
	[JsonPropertyName("onlineStateMonitoring")]
	public bool OnlineStateMonitoring { get; set; }
}

/// <summary>
/// Response containing a list of monitoring policies.
/// </summary>
public class MonitoringPolicyListResponse
{
	/// <summary>
	/// Gets or sets the list of policies.
	/// </summary>
	[JsonPropertyName("policies")]
	public List<MonitoringPolicy> Policies { get; set; } = [];
}
