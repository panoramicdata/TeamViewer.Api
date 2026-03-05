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
			Assert.Skip("No account user ID available for testing.");
			return;
		}

		// Act
		var result = await Client.Oem.ResolveTenantsAsync(
			account.UserId,
			CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Tenants.Should().NotBeNull();
	}

	[Fact]
	public async Task GetLicensingCustomersAsync_ReturnsCustomerList()
	{
		EnsureConfigured();

		// Act
		var result = await Client.Oem.GetLicensingCustomersAsync(
			null,
			CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Customers.Should().NotBeNull();
	}

	[Fact]
	public async Task GetConnectionReportsAsync_ReturnsReportList()
	{
		EnsureConfigured();

		// Arrange
		var fromDate = DateTime.UtcNow.AddDays(-30);
		var toDate = DateTime.UtcNow;

		// Act
		var result = await Client.Oem.GetConnectionReportsAsync(
			fromDate,
			toDate,
			null,
			CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Reports.Should().NotBeNull();
	}
}
