using TeamViewer.Api.Exceptions;

namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the Company API.
/// </summary>
public class CompanyApiTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task GetCompanyAsync_ReturnsCompanyInfo()
	{
		try
		{
			// Act
			var result = await Client.Company.GetAsync(CancellationToken);

			// Assert
			result.Should().NotBeNull();
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission") || ex.Message.Contains("not_found") || ex.Message.Contains("unknown"))
		{
			Assert.Skip("Company API requires additional permissions or is not available.");
		}
	}
}
