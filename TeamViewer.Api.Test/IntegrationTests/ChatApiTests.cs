using TeamViewer.Api.Exceptions;

namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the Chat API.
/// </summary>
public class ChatApiTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task GetRoomsAsync_ReturnsRoomList()
	{
		try
		{
			// Act
			var result = await Client.Chat.GetRoomsAsync(CancellationToken);

			// Assert
			result.Should().NotBeNull();
			result.Rooms.Should().NotBeNull();
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission") || ex.Message.Contains("not_found") || ex.Message.Contains("unknown"))
		{
			Assert.Skip("Chat API requires additional permissions or is not available.");
		}
	}

	[Fact]
	public async Task GetUnreadMessagesAsync_ReturnsMessageList()
	{
		try
		{
			// Act
			var result = await Client.Chat.GetUnreadMessagesAsync(CancellationToken);

			// Assert
			result.Should().NotBeNull();
			result.Messages.Should().NotBeNull();
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission") || ex.Message.Contains("not_found") || ex.Message.Contains("unknown"))
		{
			Assert.Skip("Chat API requires additional permissions or is not available.");
		}
	}

	[Fact]
	public async Task GetMessagesAsync_WithRoom_ReturnsMessageList()
	{
		try
		{
			var rooms = await Client.Chat.GetRoomsAsync(CancellationToken);
			if (rooms.Rooms.Count == 0)
			{
				Assert.Skip("No chat rooms available for testing.");
				return;
			}

			// Act
			var result = await Client.Chat.GetMessagesAsync(
				new GetChatMessagesRequest { RoomId = rooms.Rooms[0].RoomId, Limit = 10 },
				CancellationToken);

			// Assert
			result.Should().NotBeNull();
			result.Messages.Should().NotBeNull();
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission") || ex.Message.Contains("not_found") || ex.Message.Contains("unknown"))
		{
			Assert.Skip("Chat API requires additional permissions or is not available.");
		}
	}
}
