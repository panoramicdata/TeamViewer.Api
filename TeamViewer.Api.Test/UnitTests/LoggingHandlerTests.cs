using System.Net;
using Microsoft.Extensions.Logging;
using TeamViewer.Api.Handlers;

namespace TeamViewer.Api.Test.UnitTests;

/// <summary>
/// Unit tests for LoggingHandler.
/// </summary>
public class LoggingHandlerTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public void Constructor_WithoutLogger_CreatesHandler()
	{
		// Act
		var handler = new LoggingHandler();

		// Assert
		handler.Should().NotBeNull();
	}

	[Fact]
	public void Constructor_WithLogger_CreatesHandler()
	{
		// Arrange
		var logger = new TestLogger<LoggingHandler>();

		// Act
		var handler = new LoggingHandler(logger);

		// Assert
		handler.Should().NotBeNull();
	}

	[Fact]
	public async Task SendAsync_WithoutLogger_CompletesSuccessfully()
	{
		// Arrange
		var handler = new LoggingHandler()
		{
			InnerHandler = new TestHandler((_, _) =>
				Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)))
		};

		using var client = new HttpClient(handler);

		// Act
		var response = await client.GetAsync("https://example.com/test", CancellationToken);

		// Assert
		response.StatusCode.Should().Be(HttpStatusCode.OK);
	}

	[Fact]
	public async Task SendAsync_WithLogger_LogsRequestAndResponse()
	{
		// Arrange
		var logger = new TestLogger<LoggingHandler>();
		var handler = new LoggingHandler(logger)
		{
			InnerHandler = new TestHandler((_, _) =>
				Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)))
		};

		using var client = new HttpClient(handler);

		// Act
		await client.GetAsync("https://example.com/test", CancellationToken);

		// Assert
		logger.LogEntries.Should().HaveCount(2);
		logger.LogEntries[0].LogLevel.Should().Be(LogLevel.Debug);
		logger.LogEntries[0].Message.Should().Contain("HTTP");
		logger.LogEntries[0].Message.Should().Contain("GET");
		logger.LogEntries[1].LogLevel.Should().Be(LogLevel.Debug);
		logger.LogEntries[1].Message.Should().Contain("responded");
		logger.LogEntries[1].Message.Should().Contain("200");
	}

	[Fact]
	public async Task SendAsync_PassesRequestToInnerHandler()
	{
		// Arrange
		HttpRequestMessage? capturedRequest = null;
		var handler = new LoggingHandler()
		{
			InnerHandler = new TestHandler((request, _) =>
			{
				capturedRequest = request;
				return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
			})
		};

		using var client = new HttpClient(handler);
		var requestUri = "https://example.com/api/test";

		// Act
		await client.GetAsync(requestUri, CancellationToken);

		// Assert
		capturedRequest.Should().NotBeNull();
		capturedRequest!.RequestUri!.ToString().Should().Be(requestUri);
	}
}
