using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Represents a chat room.
/// </summary>
public class ChatRoom
{
	/// <summary>
	/// Gets or sets the room ID.
	/// </summary>
	[JsonPropertyName("roomId")]
	public string? RoomId { get; set; }

	/// <summary>
	/// Gets or sets the room name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the room type.
	/// </summary>
	[JsonPropertyName("type")]
	public string? Type { get; set; }

	/// <summary>
	/// Gets or sets the last message timestamp.
	/// </summary>
	[JsonPropertyName("lastMessageAt")]
	public DateTime? LastMessageAt { get; set; }

	/// <summary>
	/// Gets or sets the unread message count.
	/// </summary>
	[JsonPropertyName("unreadCount")]
	public int UnreadCount { get; set; }
}

/// <summary>
/// Response containing a list of chat rooms.
/// </summary>
public class ChatRoomListResponse
{
	/// <summary>
	/// Gets or sets the list of chat rooms.
	/// </summary>
	[JsonPropertyName("rooms")]
	public List<ChatRoom> Rooms { get; set; } = [];
}

/// <summary>
/// Represents a chat message.
/// </summary>
public class ChatMessage
{
	/// <summary>
	/// Gets or sets the message ID.
	/// </summary>
	[JsonPropertyName("messageId")]
	public string? MessageId { get; set; }

	/// <summary>
	/// Gets or sets the room ID.
	/// </summary>
	[JsonPropertyName("roomId")]
	public string? RoomId { get; set; }

	/// <summary>
	/// Gets or sets the sender ID.
	/// </summary>
	[JsonPropertyName("senderId")]
	public string? SenderId { get; set; }

	/// <summary>
	/// Gets or sets the sender name.
	/// </summary>
	[JsonPropertyName("senderName")]
	public string? SenderName { get; set; }

	/// <summary>
	/// Gets or sets the message content.
	/// </summary>
	[JsonPropertyName("content")]
	public string? Content { get; set; }

	/// <summary>
	/// Gets or sets the timestamp.
	/// </summary>
	[JsonPropertyName("timestamp")]
	public DateTime? Timestamp { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the message has been read.
	/// </summary>
	[JsonPropertyName("isRead")]
	public bool IsRead { get; set; }
}

/// <summary>
/// Response containing a list of chat messages.
/// </summary>
public class ChatMessageListResponse
{
	/// <summary>
	/// Gets or sets the list of chat messages.
	/// </summary>
	[JsonPropertyName("messages")]
	public List<ChatMessage> Messages { get; set; } = [];
}
