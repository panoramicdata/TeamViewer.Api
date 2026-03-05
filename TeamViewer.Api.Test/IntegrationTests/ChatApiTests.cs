namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the Chat API.
/// </summary>
public class ChatApiTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task GetRoomsAsync_ReturnsRoomList()
	{
		// Act
		var result = await Client.Chat.GetRoomsAsync(CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Rooms.Should().NotBeNull();
	}

	[Fact]
	public async Task GetUnreadMessagesAsync_ReturnsMessageList()
	{
		// Act
		var result = await Client.Chat.GetUnreadMessagesAsync(CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Messages.Should().NotBeNull();
	}

	[Fact]
	public async Task GetMessagesAsync_WithRoom_ReturnsMessageList()
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
}
