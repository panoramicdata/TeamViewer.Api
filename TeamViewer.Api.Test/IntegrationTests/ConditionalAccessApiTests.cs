using TeamViewer.Api.Exceptions;

namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the Conditional Access API.
/// </summary>
public class ConditionalAccessApiTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task GetDirectoryGroupsAsync_ReturnsGroupList()
	{
		try
		{
			// Act
			var result = await Client.ConditionalAccess.GetDirectoryGroupsAsync(CancellationToken);

			// Assert
			result.Should().NotBeNull();
			result.Groups.Should().NotBeNull();
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission") || ex.Message.Contains("not_found") || ex.Message.Contains("unknown"))
		{
			Assert.Skip("Conditional Access API requires additional permissions or is not available.");
		}
	}

	[Fact]
	public async Task GetRulesAsync_ReturnsRuleList()
	{
		try
		{
			// Act
			var result = await Client.ConditionalAccess.GetRulesAsync(CancellationToken);

			// Assert
			result.Should().NotBeNull();
			result.Rules.Should().NotBeNull();
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission") || ex.Message.Contains("not_found") || ex.Message.Contains("unknown"))
		{
			Assert.Skip("Conditional Access API requires additional permissions or is not available.");
		}
	}

	[Fact]
	public async Task GetApprovalOptionsAsync_ReturnsOptions()
	{
		try
		{
			// Act
			var result = await Client.ConditionalAccess.GetApprovalOptionsAsync(CancellationToken);

			// Assert
			result.Should().NotBeNull();
			result.Options.Should().NotBeNull();
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission") || ex.Message.Contains("not_found") || ex.Message.Contains("unknown"))
		{
			Assert.Skip("Conditional Access API requires additional permissions or is not available.");
		}
	}

	[Fact]
	public async Task GetFeatureOptionsAsync_ReturnsOptions()
	{
		try
		{
			// Act
			var result = await Client.ConditionalAccess.GetFeatureOptionsAsync(CancellationToken);

			// Assert
			result.Should().NotBeNull();
			result.Options.Should().NotBeNull();
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission") || ex.Message.Contains("not_found") || ex.Message.Contains("unknown"))
		{
			Assert.Skip("Conditional Access API requires additional permissions or is not available.");
		}
	}

	[Fact]
	public async Task GetTimeOptionsAsync_ReturnsOptions()
	{
		try
		{
			// Act
			var result = await Client.ConditionalAccess.GetTimeOptionsAsync(CancellationToken);

			// Assert
			result.Should().NotBeNull();
			result.Options.Should().NotBeNull();
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission") || ex.Message.Contains("not_found") || ex.Message.Contains("unknown"))
		{
			Assert.Skip("Conditional Access API requires additional permissions or is not available.");
		}
	}

	[Fact]
	public async Task CreateUpdateDeleteDirectoryGroupAsync_FullCrudCycle()
	{
		var testName = $"{TestPrefix}DirGroup_{DateTime.UtcNow:HHmmss}";

		try
		{
			// Create
			var created = await Client.ConditionalAccess.CreateDirectoryGroupAsync(
				new CreateDirectoryGroupRequest { Name = testName, Description = "Test directory group" },
				CancellationToken);

			created.Should().NotBeNull();
			created.Id.Should().NotBeNullOrEmpty();
			created.Name.Should().Be(testName);

			// Read
			var retrieved = await Client.ConditionalAccess.GetDirectoryGroupAsync(created.Id!, CancellationToken);
			retrieved.Should().NotBeNull();
			retrieved.Name.Should().Be(testName);

			// Update
			var updatedName = $"{testName}_Updated";
			await Client.ConditionalAccess.UpdateDirectoryGroupAsync(
				created.Id!,
				new UpdateDirectoryGroupRequest { Name = updatedName },
				CancellationToken);

			var afterUpdate = await Client.ConditionalAccess.GetDirectoryGroupAsync(created.Id!, CancellationToken);
			afterUpdate.Name.Should().Be(updatedName);

			// Delete
			await Client.ConditionalAccess.DeleteDirectoryGroupAsync(created.Id!, CancellationToken);
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission") || ex.Message.Contains("not_found") || ex.Message.Contains("unknown"))
		{
			Assert.Skip("Conditional Access API requires additional permissions or is not available.");
		}
	}

	[Fact]
	public async Task CreateUpdateDeleteRuleAsync_FullCrudCycle()
	{
		var testName = $"{TestPrefix}CARule_{DateTime.UtcNow:HHmmss}";

		try
		{
			// Create
			var created = await Client.ConditionalAccess.CreateRuleAsync(
				new CreateConditionalAccessRuleRequest { Name = testName, Description = "Test rule" },
				CancellationToken);

			created.Should().NotBeNull();
			created.Id.Should().NotBeNullOrEmpty();
			created.Name.Should().Be(testName);

			// Read
			var retrieved = await Client.ConditionalAccess.GetRuleAsync(created.Id!, CancellationToken);
			retrieved.Should().NotBeNull();
			retrieved.Name.Should().Be(testName);

			// Update
			var updatedName = $"{testName}_Updated";
			await Client.ConditionalAccess.UpdateRuleAsync(
				created.Id!,
				new UpdateConditionalAccessRuleRequest { Name = updatedName },
				CancellationToken);

			var afterUpdate = await Client.ConditionalAccess.GetRuleAsync(created.Id!, CancellationToken);
			afterUpdate.Name.Should().Be(updatedName);

			// Delete
			await Client.ConditionalAccess.DeleteRuleAsync(created.Id!, CancellationToken);
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission") || ex.Message.Contains("not_found") || ex.Message.Contains("unknown"))
		{
			Assert.Skip("Conditional Access API requires additional permissions or is not available.");
		}
	}
}
