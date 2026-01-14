using TeamViewer.Api.Test.Infrastructure;

namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the Account API.
/// </summary>
public class AccountApiTests : IntegrationTestBase
{
	[Fact]
	public async Task GetAccountAsync_ReturnsAccountInfo()
	{
		EnsureConfigured();

		// Act
		var result = await Client!.Account.GetAccountAsync(TestContext.Current.CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.UserId.Should().NotBeNullOrEmpty();
		result.Email.Should().NotBeNullOrEmpty();
	}
}
