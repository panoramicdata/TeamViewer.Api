using TeamViewer.Api.Test.Infrastructure;

namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the Meetings API.
/// </summary>
public class MeetingsApiTests : IntegrationTestBase
{
	[Fact]
	public async Task GetMeetingsAsync_ReturnsMeetingList()
	{
		EnsureConfigured();

		// Act
		var result = await Client!.Meetings.GetMeetingsAsync(new GetMeetingsRequest(), TestContext.Current.CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Meetings.Should().NotBeNull();
	}

	[Fact]
	public async Task GetMeetingAsync_WithValidMeetingId_ReturnsMeeting()
	{
		EnsureConfigured();

		// First get a list of meetings to find a valid ID
		var meetings = await Client!.Meetings.GetMeetingsAsync(new GetMeetingsRequest(), TestContext.Current.CancellationToken);

		if (meetings.Meetings.Count == 0)
		{
			Assert.Skip("No meetings available for testing.");
			return;
		}

		var meetingId = meetings.Meetings[0].MeetingId!;

		// Act
		var result = await Client!.Meetings.GetMeetingAsync(meetingId, TestContext.Current.CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.MeetingId.Should().Be(meetingId);
	}
}
