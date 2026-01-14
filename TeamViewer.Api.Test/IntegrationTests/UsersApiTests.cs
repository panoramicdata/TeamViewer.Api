namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the Users API.
/// </summary>
public class UsersApiTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task GetUsersAsync_ReturnsUserList()
	{
		EnsureConfigured();

		// Act
		var result = await Client
			.Users
			.GetUsersAsync(new GetUsersRequest(), CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Users.Should().NotBeNull();
	}

	[Fact]
	public async Task GetUsersAsync_WithFullList_ReturnsDetailedUsers()
	{
		EnsureConfigured();

		// Act
		var result = await Client
			.Users
			.GetUsersAsync(new GetUsersRequest { Full = true }, CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Users.Should().NotBeNull();
	}

	[Fact]
	public async Task GetUsersAsync_WithNameFilter_ReturnsFilteredUsers()
	{
		EnsureConfigured();

		// Act
		var result = await Client
			.Users
			.GetUsersAsync(new GetUsersRequest { Name = "test" }, CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Users.Should().NotBeNull();
	}

	[Fact]
	public async Task GetUsersAsync_WithEmailFilter_ReturnsFilteredUsers()
	{
		EnsureConfigured();

		// First get a list of users to find a valid email
		var users = await Client
			.Users
			.GetUsersAsync(new GetUsersRequest(), CancellationToken);

		if (users.Users.Count == 0 || string.IsNullOrEmpty(users.Users[0].Email))
		{
			Assert.Skip("No users with email available for testing.");
			return;
		}

		var email = users.Users[0].Email;

		// Act
		var result = await Client
			.Users
			.GetUsersAsync(new GetUsersRequest { Email = email }, CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Users.Should().NotBeNull();
		result.Users.Should().Contain(u => u.Email == email);
	}

	[Fact]
	public async Task GetUserAsync_WithValidUserId_ReturnsUser()
	{
		EnsureConfigured();

		// First get a list of users to find a valid ID
		var users = await Client
			.Users
			.GetUsersAsync(new GetUsersRequest(), CancellationToken);

		if (users.Users.Count == 0)
		{
			Assert.Skip("No users available for testing.");
			return;
		}

		var userId = users.Users[0].Id!;

		// Act
		var result = await Client
			.Users
			.GetUserAsync(userId, CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Id.Should().Be(userId);
	}
}
