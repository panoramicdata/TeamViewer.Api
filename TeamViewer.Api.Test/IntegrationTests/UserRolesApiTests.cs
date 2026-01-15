namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the User Roles API.
/// </summary>
public class UserRolesApiTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task GetUserRolesAsync_ReturnsRoleList()
	{
		// Act
		var result = await Client.UserRoles.GetAsync(CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Roles.Should().NotBeNull();
	}

	[Fact]
	public async Task GetPredefinedRolesAsync_ReturnsPredefinedRoles()
	{
		// Act
		var result = await Client.UserRoles.GetPredefinedAsync(CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Roles.Should().NotBeNull();
	}

	[Fact]
	public async Task GetPermissionsAsync_ReturnsPermissionList()
	{
		// Act
		var result = await Client.UserRoles.GetPermissionsAsync(CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Should().NotBeEmpty();
	}

	[Fact]
	public async Task GetAccountAssignmentsAsync_ReturnsAssignments()
	{
		// Act
		var result = await Client.UserRoles.GetAccountAssignmentsAsync(CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Assignments.Should().NotBeNull();
	}

	[Fact]
	public async Task GetUserGroupAssignmentsAsync_ReturnsAssignments()
	{
		// Act
		var result = await Client.UserRoles.GetUserGroupAssignmentsAsync(CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Assignments.Should().NotBeNull();
	}
}
