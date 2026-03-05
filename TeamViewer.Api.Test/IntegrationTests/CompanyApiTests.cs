namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the Company API.
/// </summary>
public class CompanyApiTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task GetCompanyAsync_ReturnsCompanyInfo()
	{
		// Act
		var result = await Client.Company.GetAsync(CancellationToken);

		// Assert
		result.Should().NotBeNull();
	}
}
