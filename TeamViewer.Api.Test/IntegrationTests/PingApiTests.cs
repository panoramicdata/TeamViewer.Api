using TeamViewer.Api.Test.Infrastructure;

namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the Ping API.
/// </summary>
public class PingApiTests : IntegrationTestBase
{
	[Fact]
	public async Task PingAsync_ReturnsTokenValid()
	{
		EnsureConfigured();

		// Act
		var result = await Client!.Ping.PingAsync(TestContext.Current.CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.TokenValid.Should().BeTrue();
	}
}
