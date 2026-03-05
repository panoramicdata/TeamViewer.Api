namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for Access Tokens API.
/// </summary>
public class AccessTokensApiTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task GetAccessTokensAsync_ReturnsTokenList()
	{
		// Act
		var result = await Client.Account.GetAccessTokensAsync(CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Tokens.Should().NotBeNull();
	}
}
