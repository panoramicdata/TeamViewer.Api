using TeamViewer.Api.Exceptions;

namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the User Roles API.
/// </summary>
public class UserRolesApiTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task GetUserRolesAsync_ReturnsRoleList()
	{
		try
		{
			// Act
			var result = await Client.UserRoles.GetAsync(CancellationToken);

			// Assert
			result.Should().NotBeNull();
			result.Roles.Should().NotBeNull();
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission") || ex.Message.Contains("not_found") || ex.Message.Contains("unknown"))
		{
			Assert.Skip("User Roles API requires additional permissions or is not available.");
		}
	}

	[Fact]
	public async Task GetPredefinedRolesAsync_ReturnsPredefinedRoles()
	{
		try
		{
			// Act
			var result = await Client.UserRoles.GetPredefinedAsync(CancellationToken);

			// Assert
			result.Should().NotBeNull();
			result.Roles.Should().NotBeNull();
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission") || ex.Message.Contains("not_found") || ex.Message.Contains("unknown"))
		{
			Assert.Skip("User Roles API requires additional permissions or is not available.");
		}
	}

	[Fact]
	public async Task GetPermissionsAsync_ReturnsPermissionList()
	{
		try
		{
			// Act
			var result = await Client.UserRoles.GetPermissionsAsync(CancellationToken);

			// Assert
			result.Should().NotBeNull();
			result.Permissions.Should().NotBeNull();
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission") || ex.Message.Contains("not_found") || ex.Message.Contains("unknown"))
		{
			Assert.Skip("User Roles API requires additional permissions or is not available.");
		}
	}

	[Fact]
	public async Task GetAccountAssignmentsAsync_ReturnsAssignments()
	{
		try
		{
			// Act
			var result = await Client.UserRoles.GetAccountAssignmentsAsync(CancellationToken);

			// Assert
			result.Should().NotBeNull();
			result.Assignments.Should().NotBeNull();
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission") || ex.Message.Contains("not_found") || ex.Message.Contains("unknown"))
		{
			Assert.Skip("User Roles API requires additional permissions or is not available.");
		}
	}

	[Fact]
	public async Task GetUserGroupAssignmentsAsync_ReturnsAssignments()
	{
		try
		{
			// Act
			var result = await Client.UserRoles.GetUserGroupAssignmentsAsync(CancellationToken);

			// Assert
			result.Should().NotBeNull();
			result.Assignments.Should().NotBeNull();
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission") || ex.Message.Contains("not_found") || ex.Message.Contains("unknown"))
		{
			Assert.Skip("User Roles API requires additional permissions or is not available.");
		}
	}
}
