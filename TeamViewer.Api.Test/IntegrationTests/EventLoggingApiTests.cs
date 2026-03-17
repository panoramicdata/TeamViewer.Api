namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the Event Logging API.
/// </summary>
public class EventLoggingApiTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task GetEventsAsync_ReturnsEventList()
	{
		EnsureConfigured();

		// Get events from the last 30 days
		var request = new EventLoggingRequest
		{
			StartDate = DateTime.UtcNow.AddDays(-30).ToString("yyyy-MM-ddTHH:mm:ssZ"),
			EndDate = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"),
			Limit = 10
		};

		// Act
		var result = await Client.EventLogging.GetAsync(request, CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.AuditEvents.Should().NotBeNull();
	}

	[Fact]
	public async Task GetEventsAsync_WithEventTypeFilter_ReturnsFilteredEvents()
	{
		EnsureConfigured();

		var request = new EventLoggingRequest
		{
			StartDate = DateTime.UtcNow.AddDays(-30).ToString("yyyy-MM-ddTHH:mm:ssZ"),
			EndDate = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"),
			EventTypes = ["UserLoggedIn"],
			Limit = 10
		};

		// Act
		var result = await Client.EventLogging.GetAsync(request, CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.AuditEvents.Should().NotBeNull();
	}
}
