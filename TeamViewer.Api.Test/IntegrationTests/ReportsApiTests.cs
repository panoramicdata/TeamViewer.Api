namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the Reports API.
/// </summary>
public class ReportsApiTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task GetConnectionReportsAsync_ReturnsReportList()
	{
		EnsureConfigured();

		// Act
		var result = await Client
			.Reports
			.GetConnectionReportsAsync(new GetConnectionReportsRequest(), CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Records.Should().NotBeNull();
	}

	[Fact]
	public async Task GetConnectionReportsAsync_WithDateFilter_ReturnsFilteredReports()
	{
		EnsureConfigured();

		// Filter to last 30 days
		var fromDate = DateTime.UtcNow.AddDays(-30).ToString("yyyy-MM-dd");
		var toDate = DateTime.UtcNow.ToString("yyyy-MM-dd");

		// Act
		var result = await Client
			.Reports
			.GetConnectionReportsAsync(
			new GetConnectionReportsRequest { FromDate = fromDate, ToDate = toDate },
			CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Records.Should().NotBeNull();
	}
}
