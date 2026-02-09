using System.Text.Json;
using TeamViewer.Api.Models.Responses;

namespace TeamViewer.Api.Test.UnitTests;

/// <summary>
/// Unit tests for OEM model serialization and deserialization.
/// </summary>
public class OemModelsTests
{
	private static readonly JsonSerializerOptions JsonOptions = new()
	{
		PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
	};

	[Fact]
	public void OemTenant_Serialization_RoundTrips()
	{
		// Arrange
		var tenant = new OemTenant
		{
			Id = "tenant-123",
			Name = "Test Tenant",
			Description = "A test tenant",
			Status = "active",
			CreatedAt = new DateTime(2024, 1, 15, 10, 30, 0, DateTimeKind.Utc),
			OwnerAccountId = "owner-456",
			Properties = new Dictionary<string, string>
			{
				["key1"] = "value1",
				["key2"] = "value2"
			}
		};

		// Act
		var json = JsonSerializer.Serialize(tenant, JsonOptions);
		var deserialized = JsonSerializer.Deserialize<OemTenant>(json, JsonOptions);

		// Assert
		deserialized.Should().NotBeNull();
		deserialized!.Id.Should().Be(tenant.Id);
		deserialized.Name.Should().Be(tenant.Name);
		deserialized.Description.Should().Be(tenant.Description);
		deserialized.Status.Should().Be(tenant.Status);
		deserialized.OwnerAccountId.Should().Be(tenant.OwnerAccountId);
		deserialized.Properties.Should().ContainKey("key1");
		deserialized.Properties!["key1"].Should().Be("value1");
	}

	[Fact]
	public void OemDevice_Serialization_RoundTrips()
	{
		// Arrange
		var device = new OemDevice
		{
			DeviceId = "device-123",
			TeamViewerId = "tv-456",
			Alias = "My Device",
			Description = "Test device",
			TenantId = "tenant-789",
			OnlineState = "online",
			LastSeen = DateTime.UtcNow,
			Version = "15.0.0",
			OperatingSystem = "Windows 11"
		};

		// Act
		var json = JsonSerializer.Serialize(device, JsonOptions);
		var deserialized = JsonSerializer.Deserialize<OemDevice>(json, JsonOptions);

		// Assert
		deserialized.Should().NotBeNull();
		deserialized!.DeviceId.Should().Be(device.DeviceId);
		deserialized.TeamViewerId.Should().Be(device.TeamViewerId);
		deserialized.Alias.Should().Be(device.Alias);
		deserialized.OnlineState.Should().Be(device.OnlineState);
		deserialized.OperatingSystem.Should().Be(device.OperatingSystem);
	}

	[Fact]
	public void OemConnectionReport_Serialization_RoundTrips()
	{
		// Arrange
		var report = new OemConnectionReport
		{
			Id = "report-123",
			TenantId = "tenant-456",
			StartDate = DateTime.UtcNow.AddHours(-1),
			EndDate = DateTime.UtcNow,
			SourceTeamViewerId = "source-tv",
			TargetTeamViewerId = "target-tv",
			ConnectionType = "remote_control",
			Duration = 3600
		};

		// Act
		var json = JsonSerializer.Serialize(report, JsonOptions);
		var deserialized = JsonSerializer.Deserialize<OemConnectionReport>(json, JsonOptions);

		// Assert
		deserialized.Should().NotBeNull();
		deserialized!.Id.Should().Be(report.Id);
		deserialized.TenantId.Should().Be(report.TenantId);
		deserialized.ConnectionType.Should().Be(report.ConnectionType);
		deserialized.Duration.Should().Be(report.Duration);
	}

	[Fact]
	public void OemLicensingCustomer_Serialization_RoundTrips()
	{
		// Arrange
		var customer = new OemLicensingCustomer
		{
			Id = "cust-123",
			Name = "Test Customer",
			ResellerId = "reseller-456",
			LicenseType = "premium",
			LicenseCount = 10,
			ExpirationDate = DateTime.UtcNow.AddYears(1),
			Email = "customer@example.com"
		};

		// Act
		var json = JsonSerializer.Serialize(customer, JsonOptions);
		var deserialized = JsonSerializer.Deserialize<OemLicensingCustomer>(json, JsonOptions);

		// Assert
		deserialized.Should().NotBeNull();
		deserialized!.Id.Should().Be(customer.Id);
		deserialized.Name.Should().Be(customer.Name);
		deserialized.LicenseType.Should().Be(customer.LicenseType);
		deserialized.LicenseCount.Should().Be(customer.LicenseCount);
	}

	[Fact]
	public void TenantResolveResponse_WithEmptyTenants_Initializes()
	{
		// Arrange & Act
		var response = new TenantResolveResponse();

		// Assert
		response.Tenants.Should().NotBeNull();
		response.Tenants.Should().BeEmpty();
	}

	[Fact]
	public void OemDeviceListResponse_WithEmptyDevices_Initializes()
	{
		// Arrange & Act
		var response = new OemDeviceListResponse();

		// Assert
		response.Devices.Should().NotBeNull();
		response.Devices.Should().BeEmpty();
		response.ContinuationToken.Should().BeNull();
	}
}
