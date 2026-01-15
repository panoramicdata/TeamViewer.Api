using System.Net;
using TeamViewer.Api.Handlers;

namespace TeamViewer.Api.Test.UnitTests;

/// <summary>
/// Unit tests for RetryHandler.
/// </summary>
public class RetryHandlerTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public void Constructor_WithDefaults_CreatesHandler()
	{
		// Act
		var handler = new RetryHandler(3, 1000, Logger);

		// Assert
		handler.Should().NotBeNull();
	}

	[Fact]
	public void Constructor_WithCustomValues_CreatesHandler()
	{
		// Act
		var handler = new RetryHandler(5, 500, Logger);

		// Assert
		handler.Should().NotBeNull();
	}

	[Fact]
	public async Task SendAsync_SuccessfulRequest_ReturnsImmediately()
	{
		// Arrange
		var callCount = 0;
		var handler = new RetryHandler(3, 10, Logger)
		{
			InnerHandler = new TestHandler((_, _) =>
			{
				callCount++;
				return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
			})
		};

		using var client = new HttpClient(handler);

		// Act
		var response = await client.GetAsync("https://example.com/test", CancellationToken);

		// Assert
		response.StatusCode.Should().Be(HttpStatusCode.OK);
		callCount.Should().Be(1);
	}

	[Fact]
	public async Task SendAsync_ClientError_DoesNotRetry()
	{
		// Arrange
		var callCount = 0;
		var handler = new RetryHandler(3, 10, Logger)
		{
			InnerHandler = new TestHandler((_, _) =>
			{
				callCount++;
				return Task.FromResult(new HttpResponseMessage(HttpStatusCode.BadRequest));
			})
		};

		using var client = new HttpClient(handler);

		// Act
		var response = await client.GetAsync("https://example.com/test", CancellationToken);

		// Assert
		response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
		callCount.Should().Be(1);
	}

	[Fact]
	public async Task SendAsync_TooManyRequests_RetriesAndSucceeds()
	{
		// Arrange
		var callCount = 0;
		var handler = new RetryHandler(3, 10, Logger)
		{
			InnerHandler = new TestHandler((_, _) =>
			{
				callCount++;
				if (callCount < 2)
				{
					return Task.FromResult(new HttpResponseMessage(HttpStatusCode.TooManyRequests));
				}

				return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
			})
		};

		using var client = new HttpClient(handler);

		// Act
		var response = await client.GetAsync("https://example.com/test", CancellationToken);

		// Assert
		response.StatusCode.Should().Be(HttpStatusCode.OK);
		callCount.Should().Be(2);
	}

	[Fact]
	public async Task SendAsync_ServerError_RetriesMaxTimes()
	{
		// Arrange
		var callCount = 0;
		var handler = new RetryHandler(2, 10, Logger)
		{
			InnerHandler = new TestHandler((_, _) =>
			{
				callCount++;
				return Task.FromResult(new HttpResponseMessage(HttpStatusCode.InternalServerError));
			})
		};

		using var client = new HttpClient(handler);

		// Act
		var response = await client.GetAsync("https://example.com/test", CancellationToken);

		// Assert
		response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
		callCount.Should().Be(3); // Initial + 2 retries
	}

	[Theory]
	[InlineData(HttpStatusCode.RequestTimeout)]
	[InlineData(HttpStatusCode.TooManyRequests)]
	[InlineData(HttpStatusCode.InternalServerError)]
	[InlineData(HttpStatusCode.BadGateway)]
	[InlineData(HttpStatusCode.ServiceUnavailable)]
	[InlineData(HttpStatusCode.GatewayTimeout)]
	public async Task SendAsync_RetryableStatusCode_Retries(HttpStatusCode statusCode)
	{
		// Arrange
		var callCount = 0;
		var handler = new RetryHandler(1, 10, Logger)
		{
			InnerHandler = new TestHandler((_, _) =>
			{
				callCount++;
				return Task.FromResult(new HttpResponseMessage(statusCode));
			})
		};

		using var client = new HttpClient(handler);

		// Act
		await client.GetAsync("https://example.com/test", CancellationToken);

		// Assert
		callCount.Should().Be(2); // Initial + 1 retry
	}

	[Fact]
	public async Task SendAsync_HttpRequestException_Retries()
	{
		// Arrange
		var callCount = 0;
		var handler = new RetryHandler(2, 10, Logger)
		{
			InnerHandler = new TestHandler((_, _) =>
			{
				callCount++;
				if (callCount < 2)
					throw new HttpRequestException("Network error");
				return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
			})
		};

		using var client = new HttpClient(handler);

		// Act
		var response = await client.GetAsync("https://example.com/test", CancellationToken);

		// Assert
		response.StatusCode.Should().Be(HttpStatusCode.OK);
		callCount.Should().Be(2);
	}
}
