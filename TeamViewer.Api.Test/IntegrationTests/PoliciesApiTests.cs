using TeamViewer.Api.Exceptions;

namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the Policies API.
/// </summary>
public class PoliciesApiTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task GetPoliciesAsync_ReturnsPolicyList()
	{
		try
		{
			// Act
			var result = await Client.Policies.GetAsync(CancellationToken);

			// Assert
			result.Should().NotBeNull();
			result.Policies.Should().NotBeNull();
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission"))
		{
			Assert.Skip("Policies API requires additional permissions not available with current token.");
		}
	}

	[Fact]
	public async Task GetPolicyAsync_WithValidPolicyId_ReturnsPolicy()
	{
		try
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
			result.PolicyId.Should().Be(policyId);
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission"))
		{
			Assert.Skip("Policies API requires additional permissions not available with current token.");
		}
	}
}
