using TeamViewer.Api.Exceptions;
using TeamViewer.Api.Test.Infrastructure;

namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the Sessions API.
/// </summary>
public class SessionsApiTests : IntegrationTestBase
{
	[Fact]
	public async Task GetSessionsAsync_ReturnsSessionList()
	{
		EnsureConfigured();

		// Act
		var result = await Client!.Sessions.GetSessionsAsync(TestContext.Current.CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Sessions.Should().NotBeNull();
	}

	[Fact]
	public async Task GetSessionAsync_WithValidSessionCode_ReturnsSession()
	{
		EnsureConfigured();

		// First get a list of sessions to find a valid code
		var sessions = await Client!.Sessions.GetSessionsAsync(TestContext.Current.CancellationToken);

		if (sessions.Sessions.Count == 0)
		{
			Assert.Skip("No sessions available for testing.");
			return;
		}

		var sessionCode = sessions.Sessions[0].Code!;

		// Act
		var result = await Client!.Sessions.GetSessionAsync(sessionCode, TestContext.Current.CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Code.Should().Be(sessionCode);
	}

	[Fact]
	public async Task CreateSessionAsync_WithValidRequest_CreatesSession()
	{
		EnsureConfigured();

		// First get a group to assign the session to
		var groups = await Client!.Groups.GetGroupsAsync(new GetGroupsRequest(), TestContext.Current.CancellationToken);

		if (groups.Groups.Count == 0)
		{
			Assert.Skip("No groups available for session testing.");
			return;
		}

		var groupId = groups.Groups[0].Id!;

		try
		{
			// Act - Create
			var createRequest = new CreateSessionRequest
			{
				GroupId = groupId,
				Description = $"Test Session {DateTime.UtcNow:yyyyMMddHHmmss}",
				EndCustomer = "Test Customer"
			};

			var createdSession = await Client!.Sessions.CreateSessionAsync(createRequest, TestContext.Current.CancellationToken);

			// Assert - Created
			createdSession.Should().NotBeNull();
			createdSession.Code.Should().NotBeNullOrEmpty();

			// Clean up
			await Client!.Sessions.DeleteSessionAsync(createdSession.Code!, TestContext.Current.CancellationToken);
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_request") || ex.Message.Contains("permission"))
		{
			Assert.Skip("Session creation requires additional API permissions.");
		}
	}
}
