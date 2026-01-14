using TeamViewer.Api.Test.Infrastructure;

namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the Groups API.
/// </summary>
public class GroupsApiTests : IntegrationTestBase
{
	[Fact]
	public async Task GetGroupsAsync_ReturnsGroupList()
	{
		EnsureConfigured();

		// Act
		var result = await Client!.Groups.GetGroupsAsync(new GetGroupsRequest(), TestContext.Current.CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Groups.Should().NotBeNull();
	}

	[Fact]
	public async Task GetGroupsAsync_WithNameFilter_ReturnsFilteredGroups()
	{
		EnsureConfigured();

		// First get a list of groups to find a valid name
		var groups = await Client!.Groups.GetGroupsAsync(new GetGroupsRequest(), TestContext.Current.CancellationToken);

		if (groups.Groups.Count == 0 || string.IsNullOrEmpty(groups.Groups[0].Name))
		{
			Assert.Skip("No groups with name available for testing.");
			return;
		}

		var name = groups.Groups[0].Name;

		// Act
		var result = await Client!.Groups.GetGroupsAsync(new GetGroupsRequest { Name = name }, TestContext.Current.CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Groups.Should().NotBeNull();
		result.Groups.Should().Contain(g => g.Name == name);
	}

	[Fact]
	public async Task GetGroupAsync_WithValidGroupId_ReturnsGroup()
	{
		EnsureConfigured();

		// First get a list of groups to find a valid ID
		var groups = await Client!.Groups.GetGroupsAsync(new GetGroupsRequest(), TestContext.Current.CancellationToken);

		if (groups.Groups.Count == 0)
		{
			Assert.Skip("No groups available for testing.");
			return;
		}

		var groupId = groups.Groups[0].Id!;

		// Act
		var result = await Client!.Groups.GetGroupAsync(groupId, TestContext.Current.CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Id.Should().Be(groupId);
	}

	[Fact]
	public async Task CreateAndDeleteGroupAsync_CreatesAndDeletesGroup()
	{
		EnsureConfigured();

		var testGroupName = $"Test Group {DateTime.UtcNow:yyyyMMddHHmmss}";

		// Act - Create
		var createRequest = new CreateGroupRequest { Name = testGroupName };
		var createdGroup = await Client!.Groups.CreateGroupAsync(createRequest, TestContext.Current.CancellationToken);

		// Assert - Created
		createdGroup.Should().NotBeNull();
		createdGroup.Id.Should().NotBeNullOrEmpty();
		createdGroup.Name.Should().Be(testGroupName);

		try
		{
			// Act - Delete
			await Client!.Groups.DeleteGroupAsync(createdGroup.Id!, TestContext.Current.CancellationToken);

			// Verify deletion by trying to get the group (should fail)
			var groups = await Client!.Groups.GetGroupsAsync(new GetGroupsRequest { Name = testGroupName }, TestContext.Current.CancellationToken);
			groups.Groups.Should().NotContain(g => g.Id == createdGroup.Id);
		}
		catch
		{
			// Clean up if test fails
			try
			{
				await Client!.Groups.DeleteGroupAsync(createdGroup.Id!, TestContext.Current.CancellationToken);
			}
			catch
			{
				// Ignore cleanup errors
			}
			throw;
		}
	}

	[Fact]
	public async Task UpdateGroupAsync_UpdatesGroupName()
	{
		EnsureConfigured();

		var testGroupName = $"Test Group {DateTime.UtcNow:yyyyMMddHHmmss}";
		var updatedGroupName = $"Updated Group {DateTime.UtcNow:yyyyMMddHHmmss}";

		// Create a test group
		var createRequest = new CreateGroupRequest { Name = testGroupName };
		var createdGroup = await Client!.Groups.CreateGroupAsync(createRequest, TestContext.Current.CancellationToken);

		try
		{
			// Act - Update
			var updateRequest = new UpdateGroupRequest { Name = updatedGroupName };
			await Client!.Groups.UpdateGroupAsync(createdGroup.Id!, updateRequest, TestContext.Current.CancellationToken);

			// Verify update
			var updatedGroup = await Client!.Groups.GetGroupAsync(createdGroup.Id!, TestContext.Current.CancellationToken);
			updatedGroup.Name.Should().Be(updatedGroupName);
		}
		finally
		{
			// Clean up
			await Client!.Groups.DeleteGroupAsync(createdGroup.Id!, TestContext.Current.CancellationToken);
		}
	}
}
