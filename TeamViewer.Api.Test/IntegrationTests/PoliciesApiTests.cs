namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the Policies API.
/// </summary>
public class PoliciesApiTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task GetPoliciesAsync_ReturnsPolicyList()
	{
		// Act
		var result = await Client.Policies.GetAsync(CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Policies.Should().NotBeNull();
	}

	[Fact]
	public async Task GetPolicyAsync_WithValidPolicyId_ReturnsPolicy()
	{
		// First get a list of policies to find a valid ID
		var policies = await Client.Policies.GetAsync(CancellationToken);

		if (policies.Policies.Count == 0)
		{
			Assert.Skip("No policies available for testing. Policies must be created in the TeamViewer Management Console.");
			return;
		}

		var policyId = policies.Policies[0].PolicyId!;

		// Act
		var result = await Client.Policies.GetAsync(policyId, CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Policies.Should().NotBeNull();
		result.Policies.Should().ContainSingle();
		result.Policies[0].PolicyId.Should().Be(policyId);
	}
}
