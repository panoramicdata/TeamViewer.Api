namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the WebConnector API.
/// </summary>
public class WebConnectorApiTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task GetSessionsAsync_ReturnsSessionList()
	{
		// Act
		var result = await Client.WebConnector.GetSessionsAsync(CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Sessions.Should().NotBeNull();
	}
}
