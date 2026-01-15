using TeamViewer.Api.Exceptions;

namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the Endpoint Protection API.
/// </summary>
public class EndpointProtectionApiTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task GetEndpointsAsync_ReturnsEndpointList()
	{
		try
		{
			// Act
			var result = await Client.EndpointProtection.GetEndpointsAsync(CancellationToken);

			// Assert
			result.Should().NotBeNull();
			result.Endpoints.Should().NotBeNull();
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission") || ex.Message.Contains("not_found") || ex.Message.Contains("unknown"))
		{
			Assert.Skip("Endpoint Protection API requires additional permissions or is not available.");
		}
	}
}
