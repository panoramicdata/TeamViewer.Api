namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the User Groups API.
/// </summary>
public class UserGroupsApiTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task GetUserGroupsAsync_ReturnsGroupList()
	{
		// Act
		var result = await Client.UserGroups.GetAsync(CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Groups.Should().NotBeNull();
	}

	[Fact]
	public async Task CreateUpdateDeleteUserGroupAsync_FullCrudCycle()
	{
		var testName = $"{TestPrefix}UserGroup_{DateTime.UtcNow:HHmmss}";

		// Create
		var created = await Client.UserGroups.CreateAsync(
			new CreateUserGroupRequest { Name = testName, Description = "Test user group" },
			CancellationToken);

		created.Should().NotBeNull();
		created.Id.Should().BeGreaterThan(0);
		created.Name.Should().Be(testName);

		// Read
		var retrieved = await Client.UserGroups.GetAsync(created.Id, CancellationToken);
		retrieved.Should().NotBeNull();
		retrieved.Name.Should().Be(testName);

		// Update
		var updatedName = $"{testName}_Updated";
		await Client.UserGroups.UpdateAsync(
			created.Id,
			new UpdateUserGroupRequest { Name = updatedName },
			CancellationToken);

		var afterUpdate = await Client.UserGroups.GetAsync(created.Id, CancellationToken);
		afterUpdate.Name.Should().Be(updatedName);

		// Delete
		await Client.UserGroups.DeleteAsync(created.Id, CancellationToken);

		// Verify deletion
		var groups = await Client.UserGroups.GetAsync(CancellationToken);
		groups.Groups.Should().NotContain(g => g.Id == created.Id);
	}

	[Fact]
	public async Task GetUserGroupMembersAsync_ReturnsMemberList()
	{
		var groups = await Client.UserGroups.GetAsync(CancellationToken);
		if (groups.Groups.Count == 0)
		{
			Assert.Skip("No user groups available for testing.");
			return;
		}

		var result = await Client.UserGroups.GetMembersAsync(groups.Groups[0].Id!, CancellationToken);
		result.Should().NotBeNull();
		result.Members.Should().NotBeNull();
	}

	[Fact]
	public async Task GetUserGroupRolesAsync_ReturnsRoleList()
	{
		var groups = await Client.UserGroups.GetAsync(CancellationToken);
		if (groups.Groups.Count == 0)
		{
			Assert.Skip("No user groups available for testing.");
			return;
		}

		var result = await Client.UserGroups.GetRolesAsync(groups.Groups[0].Id!, CancellationToken);
		result.Should().NotBeNull();
		result.Roles.Should().NotBeNull();
	}
}
