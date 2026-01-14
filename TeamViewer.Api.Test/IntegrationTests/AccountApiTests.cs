namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the Account API.
/// </summary>
public class AccountApiTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task GetAccountAsync_ReturnsAccountInfo()
	{
		EnsureConfigured();

		// Act
		var result = await Client.Account.GetAccountAsync(CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.UserId.Should().NotBeNullOrEmpty();
		result.Email.Should().NotBeNullOrEmpty();
	}
}
