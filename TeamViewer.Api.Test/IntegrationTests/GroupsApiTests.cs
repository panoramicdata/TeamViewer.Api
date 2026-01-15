namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the Groups API.
/// </summary>
public class GroupsApiTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task GetGroupsAsync_ReturnsGroupList()
	{
		// Create a test group first
		var testGroupName = $"{TestPrefix}GetGroups_{DateTime.UtcNow:HHmmss}";
		var createdGroup = await Client.Groups.CreateAsync(
			new CreateGroupRequest { Name = testGroupName },
			CancellationToken);

		try
		{
			// Act
			var result = await Client.Groups.GetAsync(new GetGroupsRequest(), CancellationToken);

			// Assert
			result.Should().NotBeNull();
			result.Groups.Should().NotBeNull();
			result.Groups.Should().Contain(g => g.Id == createdGroup.Id);
		}
		finally
		{
			await Client.Groups.DeleteAsync(createdGroup.Id!, CancellationToken);
		}
	}

	[Fact]
	public async Task GetGroupsAsync_WithNameFilter_ReturnsFilteredGroups()
	{
		// Create a test group first
		var testGroupName = $"{TestPrefix}NameFilter_{DateTime.UtcNow:HHmmss}";
		var createdGroup = await Client.Groups.CreateAsync(
			new CreateGroupRequest { Name = testGroupName },
			CancellationToken);

		try
		{
			// Act
			var result = await Client.Groups.GetAsync(
				new GetGroupsRequest { Name = testGroupName },
				CancellationToken);

			// Assert
			result.Should().NotBeNull();
			result.Groups.Should().NotBeNull();
			result.Groups.Should().Contain(g => g.Name == testGroupName);
		}
		finally
		{
			await Client.Groups.DeleteAsync(createdGroup.Id!, CancellationToken);
		}
	}

	[Fact]
	public async Task GetGroupAsync_WithValidGroupId_ReturnsGroup()
	{
		// Create a test group first
		var testGroupName = $"{TestPrefix}GetById_{DateTime.UtcNow:HHmmss}";
		var createdGroup = await Client.Groups.CreateAsync(
			new CreateGroupRequest { Name = testGroupName },
			CancellationToken);

		try
		{
			// Act
			var result = await Client.Groups.GetAsync(createdGroup.Id!, CancellationToken);

			// Assert
			result.Should().NotBeNull();
			result.Id.Should().Be(createdGroup.Id);
			result.Name.Should().Be(testGroupName);
		}
		finally
		{
			await Client.Groups.DeleteAsync(createdGroup.Id!, CancellationToken);
		}
	}

	[Fact]
	public async Task CreateAndDeleteGroupAsync_CreatesAndDeletesGroup()
	{
		var testGroupName = $"{TestPrefix}CRUD_{DateTime.UtcNow:HHmmss}";

		// Act - Create
		var createdGroup = await Client.Groups.CreateAsync(
			new CreateGroupRequest { Name = testGroupName },
			CancellationToken);

		// Assert - Created
		createdGroup.Should().NotBeNull();
		createdGroup.Id.Should().NotBeNullOrEmpty();
		createdGroup.Name.Should().Be(testGroupName);

		// Act - Delete
		await Client.Groups.DeleteAsync(createdGroup.Id!, CancellationToken);

		// Verify deletion
		var groups = await Client.Groups.GetAsync(
			new GetGroupsRequest { Name = testGroupName },
			CancellationToken);
		groups.Groups.Should().NotContain(g => g.Id == createdGroup.Id);
	}

	[Fact]
	public async Task UpdateGroupAsync_UpdatesGroupName()
	{
		var testGroupName = $"{TestPrefix}Update_{DateTime.UtcNow:HHmmss}";
		var updatedGroupName = $"{TestPrefix}Updated_{DateTime.UtcNow:HHmmss}";

		// Create a test group
		var createdGroup = await Client.Groups.CreateAsync(
			new CreateGroupRequest { Name = testGroupName },
			CancellationToken);

		try
		{
			// Act - Update
			await Client.Groups.UpdateAsync(
				createdGroup.Id!,
				new UpdateGroupRequest { Name = updatedGroupName },
				CancellationToken);

			// Verify update
			var updatedGroup = await Client.Groups.GetAsync(createdGroup.Id!, CancellationToken);
			updatedGroup.Name.Should().Be(updatedGroupName);
		}
		finally
		{
			await Client.Groups.DeleteAsync(createdGroup.Id!, CancellationToken);
		}
	}
}
