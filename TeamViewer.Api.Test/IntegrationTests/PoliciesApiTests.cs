using TeamViewer.Api.Test.Infrastructure;

namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the Policies API.
/// </summary>
public class PoliciesApiTests : IntegrationTestBase
{
	[Fact]
	public async Task GetPoliciesAsync_ReturnsPolicyList()
	{
		EnsureConfigured();

		// Act
		var result = await Client!.Policies.GetPoliciesAsync(TestContext.Current.CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Policies.Should().NotBeNull();
	}

	[Fact]
	public async Task GetPolicyAsync_WithValidPolicyId_ReturnsPolicy()
	{
		EnsureConfigured();

		// First get a list of policies to find a valid ID
		var policies = await Client!.Policies.GetPoliciesAsync(TestContext.Current.CancellationToken);

		if (policies.Policies.Count == 0)
		{
			Assert.Skip("No policies available for testing.");
			return;
		}

		var policyId = policies.Policies[0].PolicyId!;

		// Act
		var result = await Client!.Policies.GetPolicyAsync(policyId, TestContext.Current.CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.PolicyId.Should().Be(policyId);
	}
}
