using System.Text.Json;
using TeamViewer.Api.Models.Requests;

namespace TeamViewer.Api.Test.UnitTests;

/// <summary>
/// Unit tests for OEM request model serialization.
/// </summary>
public class OemRequestsTests
{
	private static readonly JsonSerializerOptions JsonOptions = new()
	{
		PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
		DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
	};

	[Fact]
	public void CreateOemTenantRequest_Serialization_ProducesCorrectJson()
	{
		// Arrange
		var request = new CreateOemTenantRequest
		{
			Name = "New Tenant",
			Description = "A new tenant",
			Properties = new Dictionary<string, string>
			{
				["industry"] = "technology",
				["region"] = "europe"
			}
		};

		// Act
		var json = JsonSerializer.Serialize(request, JsonOptions);

		// Assert
		json.Should().Contain("\"name\":\"New Tenant\"");
		json.Should().Contain("\"description\":\"A new tenant\"");
		json.Should().Contain("\"properties\"");
	}

	[Fact]
	public void UpdateOemTenantRequest_WithPartialUpdate_SerializesOnlyProvidedFields()
	{
		// Arrange
		var request = new UpdateOemTenantRequest
		{
			Name = "Updated Name"
			// Other fields are null
		};

		// Act
		var json = JsonSerializer.Serialize(request, JsonOptions);

		// Assert
		json.Should().Contain("\"name\":\"Updated Name\"");
		json.Should().NotContain("\"description\"");
		json.Should().NotContain("\"status\"");
	}

	[Fact]
	public void GetOemTenantDevicesRequest_Serialization_Works()
	{
		// Arrange
		var request = new GetOemTenantDevicesRequest
		{
			DeviceIds = ["device-1", "device-2"],
			OnlineState = "online",
			ContinuationToken = "token-123"
		};

		// Act
		var json = JsonSerializer.Serialize(request, JsonOptions);

		// Assert
		json.Should().Contain("\"device_ids\"");
		json.Should().Contain("\"online_state\":\"online\"");
		json.Should().Contain("\"continuation_token\":\"token-123\"");
	}

	[Fact]
	public void CreateOemLicensingCustomerRequest_RequiredFields_Serialize()
	{
		// Arrange
		var request = new CreateOemLicensingCustomerRequest
		{
			Name = "Customer Name",
			Email = "customer@example.com",
			LicenseType = "premium",
			LicenseCount = 5
		};

		// Act
		var json = JsonSerializer.Serialize(request, JsonOptions);

		// Assert
		json.Should().Contain("\"name\":\"Customer Name\"");
		json.Should().Contain("\"email\":\"customer@example.com\"");
		json.Should().Contain("\"license_type\":\"premium\"");
		json.Should().Contain("\"license_count\":5");
	}

	[Fact]
	public void DeleteOemLicensingCustomersRequest_Serialization_Works()
	{
		// Arrange
		var request = new DeleteOemLicensingCustomersRequest
		{
			CustomerIds = ["cust-1", "cust-2", "cust-3"]
		};

		// Act
		var json = JsonSerializer.Serialize(request, JsonOptions);

		// Assert
		json.Should().Contain("\"customer_ids\"");
		json.Should().Contain("\"cust-1\"");
		json.Should().Contain("\"cust-2\"");
		json.Should().Contain("\"cust-3\"");
	}

	[Fact]
	public void RegisterOemUserRequest_Serialization_Works()
	{
		// Arrange
		var request = new RegisterOemUserRequest
		{
			Email = "newuser@example.com",
			Name = "New User",
			Password = "SecurePass123!",
			TenantId = "tenant-123",
			GenerateToken = true
		};

		// Act
		var json = JsonSerializer.Serialize(request, JsonOptions);

		// Assert
		json.Should().Contain("\"email\":\"newuser@example.com\"");
		json.Should().Contain("\"name\":\"New User\"");
		json.Should().Contain("\"generate_token\":true");
	}

	[Fact]
	public void UpdateOemDeviceRequest_Serialization_Works()
	{
		// Arrange
		var request = new UpdateOemDeviceRequest
		{
			Alias = "New Alias",
			Description = "Updated description"
		};

		// Act
		var json = JsonSerializer.Serialize(request, JsonOptions);

		// Assert
		json.Should().Contain("\"alias\":\"New Alias\"");
		json.Should().Contain("\"description\":\"Updated description\"");
	}
}
