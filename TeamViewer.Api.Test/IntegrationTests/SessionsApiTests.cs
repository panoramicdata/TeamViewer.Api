namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the Sessions API.
/// </summary>
public class SessionsApiTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task GetSessionsAsync_ReturnsSessionList()
	{
		// Act
		var result = await Client.Sessions.GetAsync(CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Sessions.Should().NotBeNull();
	}

	[Fact]
	public async Task CreateAndDeleteSessionAsync_CreatesAndDeletesSession()
	{
		// First get a group to assign the session to
		var testGroupName = $"{TestPrefix}SessionGroup_{DateTime.UtcNow:HHmmss}";
		var group = await Client.Groups.CreateAsync(
			new CreateGroupRequest { Name = testGroupName },
			CancellationToken);

		try
		{
			// Act - Create
			var createRequest = new CreateSessionRequest
			{
				GroupId = group.Id,
				Description = $"{TestPrefix}Session_{DateTime.UtcNow:HHmmss}",
				EndCustomer = "Test Customer"
			};

			var createdSession = await Client.Sessions.CreateAsync(createRequest, CancellationToken);

			// Assert - Created
			createdSession.Should().NotBeNull();
			createdSession.Code.Should().NotBeNullOrEmpty();

			// Get session to verify
			var session = await Client.Sessions.GetAsync(createdSession.Code!, CancellationToken);
			session.Should().NotBeNull();
			session.Code.Should().Be(createdSession.Code);

			// Clean up session
			await Client.Sessions.DeleteAsync(createdSession.Code!, CancellationToken);
		}
		finally
		{
			await Client.Groups.DeleteAsync(group.Id!, CancellationToken);
		}
	}

	[Fact]
	public async Task UpdateSessionAsync_UpdatesSessionDescription()
	{
		// First get a group to assign the session to
		var testGroupName = $"{TestPrefix}SessionUpdateGroup_{DateTime.UtcNow:HHmmss}";
		var group = await Client.Groups.CreateAsync(
			new CreateGroupRequest { Name = testGroupName },
			CancellationToken);

		try
		{
			// Create session
			var createRequest = new CreateSessionRequest
			{
				GroupId = group.Id,
				Description = $"{TestPrefix}OriginalDesc_{DateTime.UtcNow:HHmmss}",
				EndCustomer = "Test Customer"
			};

			var createdSession = await Client.Sessions.CreateAsync(createRequest, CancellationToken);
			var updatedDescription = $"{TestPrefix}UpdatedDesc_{DateTime.UtcNow:HHmmss}";

			try
			{
				// Act - Update
				await Client.Sessions.UpdateAsync(
					createdSession.Code!,
					new UpdateSessionRequest { Description = updatedDescription },
					CancellationToken);

				// Verify update
				var session = await Client.Sessions.GetAsync(createdSession.Code!, CancellationToken);
				session.Description.Should().Be(updatedDescription);
			}
			finally
			{
				await Client.Sessions.DeleteAsync(createdSession.Code!, CancellationToken);
			}
		}
		finally
		{
			await Client.Groups.DeleteAsync(group.Id!, CancellationToken);
		}
	}
}
