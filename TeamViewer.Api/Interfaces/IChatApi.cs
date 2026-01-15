using Refit;
using TeamViewer.Api.Models.Requests;
using TeamViewer.Api.Models.Responses;

namespace TeamViewer.Api.Interfaces;

/// <summary>
/// API interface for TeamViewer chat functionality.
/// </summary>
public interface IChatApi
{
	/// <summary>
	/// Gets a list of chat rooms.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of chat rooms.</returns>
	[Get("/chat/Rooms")]
	Task<ChatRoomListResponse> GetRoomsAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets messages from a chat room.
	/// </summary>
	/// <param name="request">The request parameters.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of chat messages.</returns>
	[Get("/chat/Messages")]
	Task<ChatMessageListResponse> GetMessagesAsync(
		[Query] GetChatMessagesRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Sends a chat message.
	/// </summary>
	/// <param name="request">The send message request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The sent message.</returns>
	[Post("/chat/SendMessage")]
	Task<ChatMessage> SendMessageAsync(
		[Body] SendChatMessageRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Marks a message as read.
	/// </summary>
	/// <param name="request">The mark as read request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Post("/chat/MarkMessageAsRead")]
	Task MarkMessageAsReadAsync(
		[Body] MarkMessageAsReadRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets unread messages.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of unread messages.</returns>
	[Get("/chat/UnreadMessages")]
	Task<ChatMessageListResponse> GetUnreadMessagesAsync(
		CancellationToken cancellationToken);
}
