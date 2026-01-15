namespace TeamViewer.Api.Models.Requests;

/// <summary>
/// Request to get chat messages.
/// </summary>
public class GetChatMessagesRequest
{
	/// <summary>
	/// Gets or sets the room ID.
	/// </summary>
	[AliasAs("roomId")]
	public string? RoomId { get; set; }

	/// <summary>
	/// Gets or sets the maximum number of messages to return.
	/// </summary>
	[AliasAs("limit")]
	public int? Limit { get; set; }

	/// <summary>
	/// Gets or sets the offset for pagination.
	/// </summary>
	[AliasAs("offset")]
	public int? Offset { get; set; }
}

/// <summary>
/// Request to send a chat message.
/// </summary>
public class SendChatMessageRequest
{
	/// <summary>
	/// Gets or sets the room ID. Required.
	/// </summary>
	[JsonPropertyName("roomId")]
	public required string RoomId { get; set; }

	/// <summary>
	/// Gets or sets the message content. Required.
	/// </summary>
	[JsonPropertyName("content")]
	public required string Content { get; set; }
}

/// <summary>
/// Request to mark a message as read.
/// </summary>
public class MarkMessageAsReadRequest
{
	/// <summary>
	/// Gets or sets the message ID. Required.
	/// </summary>
	[JsonPropertyName("messageId")]
	public required string MessageId { get; set; }
}
