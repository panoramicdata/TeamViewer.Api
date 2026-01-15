namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Response containing audit events.
/// </summary>
public class EventLoggingResponse
{
	/// <summary>
	/// Gets or sets the list of audit events.
	/// </summary>
	[JsonPropertyName("AuditEvents")]
	public List<AuditEvent> AuditEvents { get; set; } = [];

	/// <summary>
	/// Gets or sets the continuation token for pagination.
	/// </summary>
	[JsonPropertyName("ContinuationToken")]
	public string? ContinuationToken { get; set; }
}

/// <summary>
/// Represents an audit event.
/// </summary>
public class AuditEvent
{
	/// <summary>
	/// Gets or sets the event ID.
	/// </summary>
	[JsonPropertyName("Id")]
	public string? Id { get; set; }

	/// <summary>
	/// Gets or sets the timestamp of the event.
	/// </summary>
	[JsonPropertyName("Timestamp")]
	public DateTime? Timestamp { get; set; }

	/// <summary>
	/// Gets or sets the author of the event (user ID).
	/// </summary>
	[JsonPropertyName("Author")]
	public string? Author { get; set; }

	/// <summary>
	/// Gets or sets the event type.
	/// </summary>
	[JsonPropertyName("EventType")]
	public string? EventType { get; set; }

	/// <summary>
	/// Gets or sets the event description.
	/// </summary>
	[JsonPropertyName("EventDescription")]
	public string? EventDescription { get; set; }

	/// <summary>
	/// Gets or sets the affected item (e.g., user ID, device ID).
	/// </summary>
	[JsonPropertyName("AffectedItem")]
	public string? AffectedItem { get; set; }

	/// <summary>
	/// Gets or sets the IP address of the author.
	/// </summary>
	[JsonPropertyName("IPAddress")]
	public string? IPAddress { get; set; }

	/// <summary>
	/// Gets or sets additional event properties.
	/// </summary>
	[JsonPropertyName("PropertyChanges")]
	public List<PropertyChange>? PropertyChanges { get; set; }
}

/// <summary>
/// Represents a property change in an audit event.
/// </summary>
public class PropertyChange
{
	/// <summary>
	/// Gets or sets the property name.
	/// </summary>
	[JsonPropertyName("PropertyName")]
	public string? PropertyName { get; set; }

	/// <summary>
	/// Gets or sets the old value.
	/// </summary>
	[JsonPropertyName("OldValue")]
	public string? OldValue { get; set; }

	/// <summary>
	/// Gets or sets the new value.
	/// </summary>
	[JsonPropertyName("NewValue")]
	public string? NewValue { get; set; }
}
