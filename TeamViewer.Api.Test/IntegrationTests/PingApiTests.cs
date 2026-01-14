namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the Ping API.
/// </summary>
public class PingApiTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task PingAsync_ReturnsTokenValid()
	{
		EnsureConfigured();

		// Act
		var result = await Client
			.Ping
			.PingAsync(CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.TokenValid.Should().BeTrue();
	}
}
