using System.Text.Json;
using TeamViewer.Api.Models.Responses;

namespace TeamViewer.Api.Test.UnitTests;

/// <summary>
/// Unit tests for Notifications model serialization and deserialization.
/// </summary>
public class NotificationsModelsTests
{
	private static readonly JsonSerializerOptions JsonOptions = new()
	{
		PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
	};

	[Fact]
	public void NotificationSubscription_Serialization_RoundTrips()
	{
		// Arrange
		var subscription = new NotificationSubscription
		{
			Id = "sub-123",
			Name = "Test Subscription",
			Description = "A test notification subscription",
			EventTypes = ["device.connected", "device.disconnected", "session.started"],
			CallbackUrl = "https://example.com/webhook",
			Active = true,
			CreatedAt = DateTime.UtcNow.AddDays(-7),
			UpdatedAt = DateTime.UtcNow,
			Filters = new NotificationFilter
			{
				TenantIds = ["tenant-1", "tenant-2"],
				DeviceIds = ["device-1"],
				UserIds = ["user-1", "user-2", "user-3"]
			}
		};

		// Act
		var json = JsonSerializer.Serialize(subscription, JsonOptions);
		var deserialized = JsonSerializer.Deserialize<NotificationSubscription>(json, JsonOptions);

		// Assert
		deserialized.Should().NotBeNull();
		deserialized!.Id.Should().Be(subscription.Id);
		deserialized.Name.Should().Be(subscription.Name);
		deserialized.EventTypes.Should().HaveCount(3);
		deserialized.CallbackUrl.Should().Be(subscription.CallbackUrl);
		deserialized.Active.Should().BeTrue();
		deserialized.Filters.Should().NotBeNull();
		deserialized.Filters!.TenantIds.Should().HaveCount(2);
		deserialized.Filters.DeviceIds.Should().HaveCount(1);
		deserialized.Filters.UserIds.Should().HaveCount(3);
	}

	[Fact]
	public void NotificationEvent_Serialization_RoundTrips()
	{
		// Arrange
		var eventItem = new NotificationEvent
		{
			Id = "event-123",
			EventType = "device.connected",
			Timestamp = DateTime.UtcNow,
			Data = new Dictionary<string, object>
			{
				["device_id"] = "device-456",
				["online_state"] = "online"
			},
			DeliveryStatus = "delivered",
			DeliveryAttempts = 1
		};

		// Act
		var json = JsonSerializer.Serialize(eventItem, JsonOptions);
		var deserialized = JsonSerializer.Deserialize<NotificationEvent>(json, JsonOptions);

		// Assert
		deserialized.Should().NotBeNull();
		deserialized!.Id.Should().Be(eventItem.Id);
		deserialized.EventType.Should().Be(eventItem.EventType);
		deserialized.DeliveryStatus.Should().Be(eventItem.DeliveryStatus);
		deserialized.DeliveryAttempts.Should().Be(1);
	}

	[Fact]
	public void NotificationFilter_WithNullProperties_Initializes()
	{
		// Arrange & Act
		var filter = new NotificationFilter();

		// Assert
		filter.TenantIds.Should().BeNull();
		filter.DeviceIds.Should().BeNull();
		filter.UserIds.Should().BeNull();
	}

	[Fact]
	public void NotificationSubscriptionListResponse_WithEmptySubscriptions_Initializes()
	{
		// Arrange & Act
		var response = new NotificationSubscriptionListResponse();

		// Assert
		response.Subscriptions.Should().NotBeNull();
		response.Subscriptions.Should().BeEmpty();
		response.ContinuationToken.Should().BeNull();
	}

	[Fact]
	public void NotificationEventListResponse_WithEmptyEvents_Initializes()
	{
		// Arrange & Act
		var response = new NotificationEventListResponse();

		// Assert
		response.Events.Should().NotBeNull();
		response.Events.Should().BeEmpty();
		response.ContinuationToken.Should().BeNull();
	}

	[Fact]
	public void NotificationSubscription_WithoutFilters_Deserializes()
	{
		// Arrange
		var json = """
		{
			"id": "sub-123",
			"name": "Test",
			"event_types": ["device.connected"]
		}
		""";

		// Act
		var subscription = JsonSerializer.Deserialize<NotificationSubscription>(json, JsonOptions);

		// Assert
		subscription.Should().NotBeNull();
		subscription!.Id.Should().Be("sub-123");
		subscription.Name.Should().Be("Test");
		subscription.Filters.Should().BeNull();
	}
}
