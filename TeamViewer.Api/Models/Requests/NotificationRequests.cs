using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Requests;

/// <summary>
/// Request to create a notification subscription.
/// </summary>
public class CreateNotificationSubscriptionRequest
{
	/// <summary>
	/// Gets or sets the subscription name.
	/// </summary>
	[JsonPropertyName("name")]
	public required string Name { get; set; }

	/// <summary>
	/// Gets or sets the subscription description.
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// Gets or sets the event types to subscribe to.
	/// </summary>
	[JsonPropertyName("event_types")]
	public required List<string> EventTypes { get; set; }

	/// <summary>
	/// Gets or sets the callback URL for webhook notifications.
	/// </summary>
	[JsonPropertyName("callback_url")]
	public required string CallbackUrl { get; set; }

	/// <summary>
	/// Gets or sets filter criteria for the subscription.
	/// </summary>
	[JsonPropertyName("filters")]
	public NotificationFilterRequest? Filters { get; set; }
}

/// <summary>
/// Request to update a notification subscription.
/// </summary>
public class UpdateNotificationSubscriptionRequest
{
	/// <summary>
	/// Gets or sets the subscription name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

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
	/// Gets or sets filter criteria for the subscription.
	/// </summary>
	[JsonPropertyName("filters")]
	public NotificationFilterRequest? Filters { get; set; }
}

/// <summary>
/// Filter criteria for notification subscription requests.
/// </summary>
public class NotificationFilterRequest
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
