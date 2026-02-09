using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Requests;

/// <summary>
/// Request to create an OEM tenant.
/// </summary>
public class CreateOemTenantRequest
{
	/// <summary>
	/// Gets or sets the tenant name.
	/// </summary>
	[JsonPropertyName("name")]
	public required string Name { get; set; }

	/// <summary>
	/// Gets or sets the tenant description.
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// Gets or sets custom properties for the tenant.
	/// </summary>
	[JsonPropertyName("properties")]
	public Dictionary<string, string>? Properties { get; set; }
}

/// <summary>
/// Request to update an OEM tenant.
/// </summary>
public class UpdateOemTenantRequest
{
	/// <summary>
	/// Gets or sets the tenant name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

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
	/// Gets or sets custom properties for the tenant.
	/// </summary>
	[JsonPropertyName("properties")]
	public Dictionary<string, string>? Properties { get; set; }
}

/// <summary>
/// Request to get devices for an OEM tenant.
/// </summary>
public class GetOemTenantDevicesRequest
{
	/// <summary>
	/// Gets or sets the device IDs to filter by.
	/// </summary>
	[JsonPropertyName("device_ids")]
	public List<string>? DeviceIds { get; set; }

	/// <summary>
	/// Gets or sets the online state filter.
	/// </summary>
	[JsonPropertyName("online_state")]
	public string? OnlineState { get; set; }

	/// <summary>
	/// Gets or sets the continuation token for pagination.
	/// </summary>
	[JsonPropertyName("continuation_token")]
	public string? ContinuationToken { get; set; }
}

/// <summary>
/// Request to create an OEM licensing customer.
/// </summary>
public class CreateOemLicensingCustomerRequest
{
	/// <summary>
	/// Gets or sets the customer name.
	/// </summary>
	[JsonPropertyName("name")]
	public required string Name { get; set; }

	/// <summary>
	/// Gets or sets the customer email.
	/// </summary>
	[JsonPropertyName("email")]
	public required string Email { get; set; }

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
}

/// <summary>
/// Request to delete OEM licensing customers.
/// </summary>
public class DeleteOemLicensingCustomersRequest
{
	/// <summary>
	/// Gets or sets the customer IDs to delete.
	/// </summary>
	[JsonPropertyName("customer_ids")]
	public required List<string> CustomerIds { get; set; }
}

/// <summary>
/// Request to register a user via OEM integration.
/// </summary>
public class RegisterOemUserRequest
{
	/// <summary>
	/// Gets or sets the user email.
	/// </summary>
	[JsonPropertyName("email")]
	public required string Email { get; set; }

	/// <summary>
	/// Gets or sets the user name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the user password.
	/// </summary>
	[JsonPropertyName("password")]
	public string? Password { get; set; }

	/// <summary>
	/// Gets or sets the tenant ID to associate the user with.
	/// </summary>
	[JsonPropertyName("tenant_id")]
	public string? TenantId { get; set; }

	/// <summary>
	/// Gets or sets whether to generate an access token.
	/// </summary>
	[JsonPropertyName("generate_token")]
	public bool? GenerateToken { get; set; }
}

/// <summary>
/// Request to update an OEM device.
/// </summary>
public class UpdateOemDeviceRequest
{
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
}
