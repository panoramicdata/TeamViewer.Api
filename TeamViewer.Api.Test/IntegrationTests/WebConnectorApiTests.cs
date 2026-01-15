using TeamViewer.Api.Exceptions;

namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the WebConnector API.
/// </summary>
public class WebConnectorApiTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task GetSessionsAsync_ReturnsSessionList()
	{
		try
		{
			// Act
			var result = await Client.WebConnector.GetSessionsAsync(CancellationToken);

			// Assert
			result.Should().NotBeNull();
			result.Sessions.Should().NotBeNull();
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission") || ex.Message.Contains("not_found") || ex.Message.Contains("unknown"))
		{
			Assert.Skip("WebConnector API requires additional permissions or is not available.");
		}
	}
}
