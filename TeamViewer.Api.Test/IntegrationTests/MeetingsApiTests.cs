namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the Meetings API.
/// </summary>
public class MeetingsApiTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task GetMeetingsAsync_ReturnsMeetingList()
	{
		// Act
		var result = await Client.Meetings.GetAsync(new GetMeetingsRequest(), CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Meetings.Should().NotBeNull();
	}

	[Fact]
	public async Task CreateAndDeleteMeetingAsync_CreatesAndDeletesMeeting()
	{
		var testSubject = $"{TestPrefix}Meeting_{DateTime.UtcNow:HHmmss}";
		var startTime = DateTime.UtcNow.AddHours(1);
		var endTime = DateTime.UtcNow.AddHours(2);

		// Act - Create
		var createRequest = new CreateMeetingRequest
		{
			Subject = testSubject,
			Start = startTime,
			End = endTime
		};

		var createdMeeting = await Client.Meetings.CreateAsync(createRequest, CancellationToken);

		// Assert - Created
		createdMeeting.Should().NotBeNull();
		createdMeeting.MeetingId.Should().NotBeNullOrEmpty();
		createdMeeting.Subject.Should().Be(testSubject);

		// Get meeting to verify
		var meeting = await Client.Meetings.GetAsync(createdMeeting.MeetingId!, CancellationToken);
		meeting.Should().NotBeNull();
		meeting.MeetingId.Should().Be(createdMeeting.MeetingId);

		// Clean up
		await Client.Meetings.DeleteAsync(createdMeeting.MeetingId!, CancellationToken);

		// Verify deletion
		var meetings = await Client.Meetings.GetAsync(new GetMeetingsRequest(), CancellationToken);
		meetings.Meetings.Should().NotContain(m => m.MeetingId == createdMeeting.MeetingId);
	}

	[Fact]
	public async Task UpdateMeetingAsync_UpdatesMeetingSubject()
	{
		var testSubject = $"{TestPrefix}OrigMeeting_{DateTime.UtcNow:HHmmss}";
		var updatedSubject = $"{TestPrefix}UpdatedMeeting_{DateTime.UtcNow:HHmmss}";
		var startTime = DateTime.UtcNow.AddHours(1);
		var endTime = DateTime.UtcNow.AddHours(2);

		// Create meeting
		var createdMeeting = await Client.Meetings.CreateAsync(
			new CreateMeetingRequest
			{
				Subject = testSubject,
				Start = startTime,
				End = endTime
			},
			CancellationToken);

		try
		{
			// Act - Update
			await Client.Meetings.UpdateAsync(
				createdMeeting.MeetingId!,
				new UpdateMeetingRequest { Subject = updatedSubject },
				CancellationToken);

			// Verify update
			var meeting = await Client.Meetings.GetAsync(createdMeeting.MeetingId!, CancellationToken);
			meeting.Subject.Should().Be(updatedSubject);
		}
		finally
		{
			await Client.Meetings.DeleteAsync(createdMeeting.MeetingId!, CancellationToken);
		}
	}
}
