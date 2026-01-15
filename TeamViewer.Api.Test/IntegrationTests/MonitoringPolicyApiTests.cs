using TeamViewer.Api.Exceptions;

namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the Monitoring Policy API.
/// </summary>
public class MonitoringPolicyApiTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task GetPoliciesAsync_ReturnsPolicyList()
	{
		try
		{
			// Act
			var result = await Client.MonitoringPolicy.GetAsync(CancellationToken);

			// Assert
			result.Should().NotBeNull();
			result.Policies.Should().NotBeNull();
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission") || ex.Message.Contains("not_found") || ex.Message.Contains("unknown"))
		{
			Assert.Skip("Monitoring Policy API requires additional permissions or is not available.");
		}
	}

	[Fact]
	public async Task GetPolicyAsync_WithValidPolicy_ReturnsPolicy()
	{
		try
		{
			var policies = await Client.MonitoringPolicy.GetAsync(CancellationToken);
			if (policies.Policies.Count == 0)
			{
				Assert.Skip("No monitoring policies available for testing.");
				return;
			}

			// Act
			var result = await Client.MonitoringPolicy.GetAsync(
				policies.Policies[0].Id!,
				CancellationToken);

			// Assert
			result.Should().NotBeNull();
			result.Id.Should().Be(policies.Policies[0].Id);
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission") || ex.Message.Contains("not_found") || ex.Message.Contains("unknown"))
		{
			Assert.Skip("Monitoring Policy API requires additional permissions or is not available.");
		}
	}

	[Fact]
	public async Task CreateUpdateDeletePolicyAsync_FullCrudCycle()
	{
		var testName = $"{TestPrefix}MonPolicy_{DateTime.UtcNow:HHmmss}";

		try
		{
			// Create
			var created = await Client.MonitoringPolicy.CreateAsync(
				new CreateMonitoringPolicyRequest { Name = testName, Description = "Test monitoring policy" },
				CancellationToken);

			created.Should().NotBeNull();
			created.Id.Should().NotBeNullOrEmpty();
			created.Name.Should().Be(testName);

			// Read
			var retrieved = await Client.MonitoringPolicy.GetAsync(created.Id!, CancellationToken);
			retrieved.Should().NotBeNull();
			retrieved.Name.Should().Be(testName);

			// Update
			var updatedName = $"{testName}_Updated";
			await Client.MonitoringPolicy.UpdateAsync(
				created.Id!,
				new UpdateMonitoringPolicyRequest { Name = updatedName },
				CancellationToken);

			var afterUpdate = await Client.MonitoringPolicy.GetAsync(created.Id!, CancellationToken);
			afterUpdate.Name.Should().Be(updatedName);

			// Delete
			await Client.MonitoringPolicy.DeleteAsync(created.Id!, CancellationToken);
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission") || ex.Message.Contains("not_found") || ex.Message.Contains("unknown"))
		{
			Assert.Skip("Monitoring Policy API requires additional permissions or is not available.");
		}
	}
}
