using TeamViewer.Api.Exceptions;

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

		try
		{
			// Act
			var result = await Client.EventLogging.GetEventsAsync(request, CancellationToken);

			// Assert
			result.Should().NotBeNull();
			result.AuditEvents.Should().NotBeNull();
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission"))
		{
			Assert.Skip("Event Logging API requires additional permissions not available with current token.");
		}
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

		try
		{
			// Act
			var result = await Client.EventLogging.GetEventsAsync(request, CancellationToken);

			// Assert
			result.Should().NotBeNull();
			result.AuditEvents.Should().NotBeNull();
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission"))
		{
			Assert.Skip("Event Logging API requires additional permissions not available with current token.");
		}
	}
}
