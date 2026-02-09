using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Response for resolving tenants.
/// </summary>
public class TenantResolveResponse
{
	/// <summary>
	/// Gets or sets the list of resolved tenants.
	/// </summary>
	[JsonPropertyName("tenants")]
	public List<OemTenant> Tenants { get; set; } = [];
}

/// <summary>
/// Represents an OEM tenant.
/// </summary>
public class OemTenant
{
	/// <summary>
	/// Gets or sets the tenant ID.
	/// </summary>
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;

	/// <summary>
	/// Gets or sets the tenant name.
	/// </summary>
	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;

	/// <summary>
	/// Gets or sets the tenant description.
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// Gets or sets the tenant status.
	/// </summary>
	[JsonPropertyName("status")]
	public string? Status { get; set; }

	/// <summary>
	/// Gets or sets the creation date.
	/// </summary>
	[JsonPropertyName("created_at")]
	public DateTime? CreatedAt { get; set; }

	/// <summary>
	/// Gets or sets the last update date.
	/// </summary>
	[JsonPropertyName("updated_at")]
	public DateTime? UpdatedAt { get; set; }

	/// <summary>
	/// Gets or sets the tenant owner account ID.
	/// </summary>
	[JsonPropertyName("owner_account_id")]
	public string? OwnerAccountId { get; set; }

	/// <summary>
	/// Gets or sets custom properties for the tenant.
	/// </summary>
	[JsonPropertyName("properties")]
	public Dictionary<string, string>? Properties { get; set; }
}

/// <summary>
/// Response containing a list of OEM devices.
/// </summary>
public class OemDeviceListResponse
{
	/// <summary>
	/// Gets or sets the list of devices.
	/// </summary>
	[JsonPropertyName("devices")]
	public List<OemDevice> Devices { get; set; } = [];

	/// <summary>
	/// Gets or sets the continuation token for pagination.
	/// </summary>
	[JsonPropertyName("continuation_token")]
	public string? ContinuationToken { get; set; }
}

/// <summary>
/// Represents an OEM device.
/// </summary>
public class OemDevice
{
	/// <summary>
	/// Gets or sets the device ID.
	/// </summary>
	[JsonPropertyName("device_id")]
	public string DeviceId { get; set; } = string.Empty;

	/// <summary>
	/// Gets or sets the TeamViewer ID.
	/// </summary>
	[JsonPropertyName("teamviewer_id")]
	public string? TeamViewerId { get; set; }

	/// <summary>
	/// Gets or sets the device alias.
	/// </summary>
	[JsonPropertyName("alias")]
	public string? Alias { get; set; }

	/// <summary>
	/// Gets or sets the device description.
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// Gets or sets the tenant ID.
	/// </summary>
	[JsonPropertyName("tenant_id")]
	public string? TenantId { get; set; }

	/// <summary>
	/// Gets or sets the online status.
	/// </summary>
	[JsonPropertyName("online_state")]
	public string? OnlineState { get; set; }

	/// <summary>
	/// Gets or sets the last seen date.
	/// </summary>
	[JsonPropertyName("last_seen")]
	public DateTime? LastSeen { get; set; }

	/// <summary>
	/// Gets or sets the device version.
	/// </summary>
	[JsonPropertyName("version")]
	public string? Version { get; set; }

	/// <summary>
	/// Gets or sets the operating system.
	/// </summary>
	[JsonPropertyName("os")]
	public string? OperatingSystem { get; set; }
}

/// <summary>
/// Response containing a list of OEM connection reports.
/// </summary>
public class OemConnectionReportListResponse
{
	/// <summary>
	/// Gets or sets the list of connection reports.
	/// </summary>
	[JsonPropertyName("reports")]
	public List<OemConnectionReport> Reports { get; set; } = [];

	/// <summary>
	/// Gets or sets the continuation token for pagination.
	/// </summary>
	[JsonPropertyName("continuation_token")]
	public string? ContinuationToken { get; set; }
}

/// <summary>
/// Represents an OEM connection report.
/// </summary>
public class OemConnectionReport
{
	/// <summary>
	/// Gets or sets the connection ID.
	/// </summary>
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;

	/// <summary>
	/// Gets or sets the tenant ID.
	/// </summary>
	[JsonPropertyName("tenant_id")]
	public string? TenantId { get; set; }

	/// <summary>
	/// Gets or sets the connection start time.
	/// </summary>
	[JsonPropertyName("start_date")]
	public DateTime? StartDate { get; set; }

	/// <summary>
	/// Gets or sets the connection end time.
	/// </summary>
	[JsonPropertyName("end_date")]
	public DateTime? EndDate { get; set; }

	/// <summary>
	/// Gets or sets the source TeamViewer ID.
	/// </summary>
	[JsonPropertyName("source_teamviewer_id")]
	public string? SourceTeamViewerId { get; set; }

	/// <summary>
	/// Gets or sets the target TeamViewer ID.
	/// </summary>
	[JsonPropertyName("target_teamviewer_id")]
	public string? TargetTeamViewerId { get; set; }

	/// <summary>
	/// Gets or sets the connection type.
	/// </summary>
	[JsonPropertyName("connection_type")]
	public string? ConnectionType { get; set; }

	/// <summary>
	/// Gets or sets the duration in seconds.
	/// </summary>
	[JsonPropertyName("duration")]
	public int? Duration { get; set; }
}

/// <summary>
/// Response containing a list of OEM licensing customers.
/// </summary>
public class OemLicensingCustomerListResponse
{
	/// <summary>
	/// Gets or sets the list of customers.
	/// </summary>
	[JsonPropertyName("customers")]
	public List<OemLicensingCustomer> Customers { get; set; } = [];
}

/// <summary>
/// Represents an OEM licensing customer.
/// </summary>
public class OemLicensingCustomer
{
	/// <summary>
	/// Gets or sets the customer ID.
	/// </summary>
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;

	/// <summary>
	/// Gets or sets the customer name.
	/// </summary>
	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;

	/// <summary>
	/// Gets or sets the reseller ID.
	/// </summary>
	[JsonPropertyName("reseller_id")]
	public string? ResellerId { get; set; }

	/// <summary>
	/// Gets or sets the license type.
	/// </summary>
	[JsonPropertyName("license_type")]
	public string? LicenseType { get; set; }

	/// <summary>
	/// Gets or sets the number of licenses.
	/// </summary>
	[JsonPropertyName("license_count")]
	public int? LicenseCount { get; set; }

	/// <summary>
	/// Gets or sets the license expiration date.
	/// </summary>
	[JsonPropertyName("expiration_date")]
	public DateTime? ExpirationDate { get; set; }

	/// <summary>
	/// Gets or sets the customer email.
	/// </summary>
	[JsonPropertyName("email")]
	public string? Email { get; set; }
}

/// <summary>
/// Represents a user registered via OEM integration.
/// </summary>
public class OemRegisteredUser
{
	/// <summary>
	/// Gets or sets the user ID.
	/// </summary>
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;

	/// <summary>
	/// Gets or sets the user email.
	/// </summary>
	[JsonPropertyName("email")]
	public string Email { get; set; } = string.Empty;

	/// <summary>
	/// Gets or sets the user name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the registration status.
	/// </summary>
	[JsonPropertyName("status")]
	public string? Status { get; set; }

	/// <summary>
	/// Gets or sets the access token if generated.
	/// </summary>
	[JsonPropertyName("access_token")]
	public string? AccessToken { get; set; }
}
