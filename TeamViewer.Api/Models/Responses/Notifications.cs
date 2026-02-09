using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Response containing a list of notification subscriptions.
/// </summary>
public class NotificationSubscriptionListResponse
{
	/// <summary>
	/// Gets or sets the list of subscriptions.
	/// </summary>
	[JsonPropertyName("subscriptions")]
	public List<NotificationSubscription> Subscriptions { get; set; } = [];

	/// <summary>
	/// Gets or sets the continuation token for pagination.
	/// </summary>
	[JsonPropertyName("continuation_token")]
	public string? ContinuationToken { get; set; }
}

/// <summary>
/// Represents a notification subscription.
/// </summary>
public class NotificationSubscription
{
	/// <summary>
	/// Gets or sets the subscription ID.
	/// </summary>
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;

	/// <summary>
	/// Gets or sets the subscription name.
	/// </summary>
	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;

	/// <summary>
	/// Gets or sets the subscription description.
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// Gets or sets the event types to subscribe to.
	/// </summary>
	[JsonPropertyName("event_types")]
	public List<string>? EventTypes { get; set; }

	/// <summary>
	/// Gets or sets the callback URL for webhook notifications.
	/// </summary>
	[JsonPropertyName("callback_url")]
	public string? CallbackUrl { get; set; }

	/// <summary>
	/// Gets or sets whether the subscription is active.
	/// </summary>
	[JsonPropertyName("active")]
	public bool? Active { get; set; }

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
	/// Gets or sets filter criteria for the subscription.
	/// </summary>
	[JsonPropertyName("filters")]
	public NotificationFilter? Filters { get; set; }
}

/// <summary>
/// Filter criteria for notification subscriptions.
/// </summary>
public class NotificationFilter
{
	/// <summary>
	/// Gets or sets the tenant IDs to filter by.
	/// </summary>
	[JsonPropertyName("tenant_ids")]
	public List<string>? TenantIds { get; set; }

	/// <summary>
	/// Gets or sets the device IDs to filter by.
	/// </summary>
	[JsonPropertyName("device_ids")]
	public List<string>? DeviceIds { get; set; }

	/// <summary>
	/// Gets or sets the user IDs to filter by.
	/// </summary>
	[JsonPropertyName("user_ids")]
	public List<string>? UserIds { get; set; }
}

/// <summary>
/// Response containing a list of notification events.
/// </summary>
public class NotificationEventListResponse
{
	/// <summary>
	/// Gets or sets the list of events.
	/// </summary>
	[JsonPropertyName("events")]
	public List<NotificationEvent> Events { get; set; } = [];

	/// <summary>
	/// Gets or sets the continuation token for pagination.
	/// </summary>
	[JsonPropertyName("continuation_token")]
	public string? ContinuationToken { get; set; }
}

/// <summary>
/// Represents a notification event.
/// </summary>
public class NotificationEvent
{
	/// <summary>
	/// Gets or sets the event ID.
	/// </summary>
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;

	/// <summary>
	/// Gets or sets the event type.
	/// </summary>
	[JsonPropertyName("event_type")]
	public string EventType { get; set; } = string.Empty;

	/// <summary>
	/// Gets or sets the event timestamp.
	/// </summary>
	[JsonPropertyName("timestamp")]
	public DateTime Timestamp { get; set; }

	/// <summary>
	/// Gets or sets the event data payload.
	/// </summary>
	[JsonPropertyName("data")]
	public Dictionary<string, object>? Data { get; set; }

	/// <summary>
	/// Gets or sets the delivery status.
	/// </summary>
	[JsonPropertyName("delivery_status")]
	public string? DeliveryStatus { get; set; }

	/// <summary>
	/// Gets or sets the number of delivery attempts.
	/// </summary>
	[JsonPropertyName("delivery_attempts")]
	public int? DeliveryAttempts { get; set; }
}
