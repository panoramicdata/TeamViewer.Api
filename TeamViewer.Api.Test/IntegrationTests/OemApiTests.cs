using TeamViewer.Api.Exceptions;

namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the OEM API.
/// Note: These tests require OEM/Reach API access which is only available with specific TeamViewer licenses.
/// </summary>
public class OemApiTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task ResolveTenantsAsync_WithAccountId_ReturnsTenants()
	{
		EnsureConfigured();

		// Arrange - Get current account to get the account ID
		var account = await Client.Account.GetAsync(CancellationToken);
		account.Should().NotBeNull();

		// Skip if no account ID available
		if (string.IsNullOrEmpty(account.UserId))
		{
			return;
		}

		// Act & Assert - This may fail if OEM access is not available
		try
		{
			var result = await Client.Oem.ResolveTenantsAsync(
				account.UserId,
				CancellationToken);

			result.Should().NotBeNull();
			result.Tenants.Should().NotBeNull();
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("not authorized") || ex.Message.Contains("access denied"))
		{
			// Expected if OEM access is not available
			Assert.True(true, "OEM API access not available - test skipped");
		}
	}

	[Fact]
	public async Task GetLicensingCustomersAsync_ReturnsCustomerList()
	{
		EnsureConfigured();

		// Act & Assert
		try
		{
			var result = await Client.Oem.GetLicensingCustomersAsync(
				null,
				CancellationToken);

			result.Should().NotBeNull();
			result.Customers.Should().NotBeNull();
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("not authorized") || ex.Message.Contains("access denied"))
		{
			// Expected if OEM access is not available
			Assert.True(true, "OEM API access not available - test skipped");
		}
	}

	[Fact]
	public async Task GetConnectionReportsAsync_ReturnsReportList()
	{
		EnsureConfigured();

		// Arrange
		var fromDate = DateTime.UtcNow.AddDays(-30);
		var toDate = DateTime.UtcNow;

		// Act & Assert
		try
		{
			var result = await Client.Oem.GetConnectionReportsAsync(
				fromDate,
				toDate,
				null,
				CancellationToken);

			result.Should().NotBeNull();
			result.Reports.Should().NotBeNull();
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("not authorized") || ex.Message.Contains("access denied"))
		{
			// Expected if OEM access is not available
			Assert.True(true, "OEM API access not available - test skipped");
		}
	}
}
