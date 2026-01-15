namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the Endpoint Protection API.
/// </summary>
public class EndpointProtectionApiTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task GetEndpointsAsync_ReturnsEndpointList()
	{
		// Act
		var result = await Client.EndpointProtection.GetEndpointsAsync(CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Endpoints.Should().NotBeNull();
	}
}
