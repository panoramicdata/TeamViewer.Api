namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the Company Branding API.
/// </summary>
public class CompanyBrandingApiTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task GetCompanyBrandingAsync_ReturnsBrandingSettings()
	{
		// Act
		var result = await Client.CompanyBranding.GetAsync(CancellationToken);

		// Assert
		result.Should().NotBeNull();
	}

	[Fact]
	public async Task UpdateCompanyBrandingAsync_UpdatesBrandingSettings()
	{
		// Get current branding to preserve values
		var currentBranding = await Client.CompanyBranding.GetAsync(CancellationToken);

		var testSupportText = $"{TestPrefix}Support_{DateTime.UtcNow:HHmmss}";

		// Act - Update
		await Client.CompanyBranding.UpdateAsync(
			new UpdateCompanyBrandingRequest
			{
				SupportText = testSupportText
			},
			CancellationToken);

		// Verify
		var updatedBranding = await Client.CompanyBranding.GetAsync(CancellationToken);
		updatedBranding.SupportText.Should().Be(testSupportText);

		// Restore original
		await Client.CompanyBranding.UpdateAsync(
			new UpdateCompanyBrandingRequest
			{
				SupportText = currentBranding.SupportText
			},
			CancellationToken);
	}
}
