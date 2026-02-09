using System.Text.Json;
using TeamViewer.Api.Models.Requests;

namespace TeamViewer.Api.Test.UnitTests;

/// <summary>
/// Unit tests for Notification request model serialization.
/// </summary>
public class NotificationRequestsTests
{
	private static readonly JsonSerializerOptions JsonOptions = new()
	{
		PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
		DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
	};

	[Fact]
	public void CreateNotificationSubscriptionRequest_Serialization_ProducesCorrectJson()
	{
		// Arrange
		var request = new CreateNotificationSubscriptionRequest
		{
			Name = "Device Events",
			Description = "Subscription for device events",
			EventTypes = ["device.connected", "device.disconnected"],
			CallbackUrl = "https://webhook.example.com/teamviewer",
			Filters = new NotificationFilterRequest
			{
				TenantIds = ["tenant-1"],
				DeviceIds = ["device-1", "device-2"]
			}
		};

		// Act
		var json = JsonSerializer.Serialize(request, JsonOptions);

		// Assert
		json.Should().Contain("\"name\":\"Device Events\"");
		json.Should().Contain("\"event_types\"");
		json.Should().Contain("\"callback_url\"");
		json.Should().Contain("\"filters\"");
		json.Should().Contain("\"tenant_ids\"");
		json.Should().Contain("\"device_ids\"");
	}

	[Fact]
	public void UpdateNotificationSubscriptionRequest_PartialUpdate_SerializesOnlyProvidedFields()
	{
		// Arrange
		var request = new UpdateNotificationSubscriptionRequest
		{
			Active = false,
			Description = "Updated description"
		};

		// Act
		var json = JsonSerializer.Serialize(request, JsonOptions);

		// Assert
		json.Should().Contain("\"active\":false");
		json.Should().Contain("\"description\":\"Updated description\"");
		json.Should().NotContain("\"name\"");
		json.Should().NotContain("\"event_types\"");
	}

	[Fact]
	public void NotificationFilterRequest_WithAllFields_Serializes()
	{
		// Arrange
		var filter = new NotificationFilterRequest
		{
			TenantIds = ["t1", "t2"],
			DeviceIds = ["d1", "d2", "d3"],
			UserIds = ["u1"]
		};

		// Act
		var json = JsonSerializer.Serialize(filter, JsonOptions);

		// Assert
		json.Should().Contain("\"tenant_ids\"");
		json.Should().Contain("\"device_ids\"");
		json.Should().Contain("\"user_ids\"");
	}

	[Fact]
	public void CreateNotificationSubscriptionRequest_WithoutFilters_Serializes()
	{
		// Arrange
		var request = new CreateNotificationSubscriptionRequest
		{
			Name = "Simple Subscription",
			EventTypes = ["session.started"],
			CallbackUrl = "https://example.com/hook"
		};

		// Act
		var json = JsonSerializer.Serialize(request, JsonOptions);

		// Assert
		json.Should().Contain("\"name\":\"Simple Subscription\"");
		json.Should().Contain("\"event_types\"");
		json.Should().Contain("\"callback_url\"");
		json.Should().NotContain("\"filters\"");
	}

	[Fact]
	public void UpdateNotificationSubscriptionRequest_ChangeEventTypes_Serializes()
	{
		// Arrange
		var request = new UpdateNotificationSubscriptionRequest
		{
			EventTypes = ["device.connected", "device.disconnected", "session.started", "session.ended"]
		};

		// Act
		var json = JsonSerializer.Serialize(request, JsonOptions);

		// Assert
		json.Should().Contain("\"event_types\"");
		json.Should().Contain("device.connected");
		json.Should().Contain("session.ended");
	}

	[Fact]
	public void UpdateNotificationSubscriptionRequest_UpdateCallbackUrl_Serializes()
	{
		// Arrange
		var request = new UpdateNotificationSubscriptionRequest
		{
			CallbackUrl = "https://new-webhook.example.com/teamviewer"
		};

		// Act
		var json = JsonSerializer.Serialize(request, JsonOptions);

		// Assert
		json.Should().Contain("\"callback_url\":\"https://new-webhook.example.com/teamviewer\"");
	}
}
