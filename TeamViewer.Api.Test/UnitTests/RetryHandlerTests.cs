using System.Net;
using TeamViewer.Api.Handlers;

namespace TeamViewer.Api.Test.UnitTests;

/// <summary>
/// Unit tests for RetryHandler.
/// </summary>
public class RetryHandlerTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	// Short enough that the retry tests do not spend real time backing off.
	private const int RetryDelayMilliseconds = 10;

	[Theory]
	[InlineData(3, 1000)]
	[InlineData(5, 500)]
	public void Constructor_CreatesHandler(int maxRetryAttempts, int retryDelayMilliseconds)
	{
		// Act
		using var handler = new RetryHandler(maxRetryAttempts, retryDelayMilliseconds, Logger);

		// Assert
		handler.Should().NotBeNull();
	}

	[Fact]
	public async Task SendAsync_SuccessfulRequest_ReturnsImmediately()
	{
		// Act
		var (response, callCount) = await SendThroughRetryAsync(3, Always(HttpStatusCode.OK));

		// Assert
		response.StatusCode.Should().Be(HttpStatusCode.OK);
		callCount.Should().Be(1);
	}

	[Fact]
	public async Task SendAsync_ClientError_DoesNotRetry()
	{
		// Act
		var (response, callCount) = await SendThroughRetryAsync(3, Always(HttpStatusCode.BadRequest));

		// Assert
		response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
		callCount.Should().Be(1);
	}

	[Fact]
	public async Task SendAsync_TooManyRequests_RetriesAndSucceeds()
	{
		// Act
		var (response, callCount) = await SendThroughRetryAsync(
			3,
			attempt => new HttpResponseMessage(attempt < 2 ? HttpStatusCode.TooManyRequests : HttpStatusCode.OK));

		// Assert
		response.StatusCode.Should().Be(HttpStatusCode.OK);
		callCount.Should().Be(2);
	}

	[Fact]
	public async Task SendAsync_ServerError_RetriesMaxTimes()
	{
		// Act
		var (response, callCount) = await SendThroughRetryAsync(2, Always(HttpStatusCode.InternalServerError));

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
		// Act
		var (_, callCount) = await SendThroughRetryAsync(1, Always(statusCode));

		// Assert
		callCount.Should().Be(2); // Initial + 1 retry
	}

	[Fact]
	public async Task SendAsync_HttpRequestException_Retries()
	{
		// Act
		var (response, callCount) = await SendThroughRetryAsync(
			2,
			attempt => attempt < 2
				? throw new HttpRequestException("Network error")
				: new HttpResponseMessage(HttpStatusCode.OK));

		// Assert
		response.StatusCode.Should().Be(HttpStatusCode.OK);
		callCount.Should().Be(2);
	}

	/// <summary>
	/// A response factory that answers every attempt with the same status code.
	/// </summary>
	private static Func<int, HttpResponseMessage> Always(HttpStatusCode statusCode)
		=> _ => new HttpResponseMessage(statusCode);

	/// <summary>
	/// Sends one request through a <see cref="RetryHandler"/> and reports how many attempts reached
	/// the inner handler.
	/// </summary>
	/// <param name="maxRetryAttempts">Retries the handler is allowed, over and above the first attempt.</param>
	/// <param name="respond">
	/// Produces the response for an attempt, numbered from 1. Throwing from it exercises the
	/// handler's exception retry path.
	/// </param>
	private async Task<(HttpResponseMessage Response, int CallCount)> SendThroughRetryAsync(
		int maxRetryAttempts,
		Func<int, HttpResponseMessage> respond)
	{
		var callCount = 0;
		var handler = new RetryHandler(maxRetryAttempts, RetryDelayMilliseconds, Logger)
		{
			InnerHandler = new TestHandler((_, _) =>
			{
				callCount++;
				return Task.FromResult(respond(callCount));
			})
		};

		var response = await HandlerTestHarness.SendAsync(handler);
		return (response, callCount);
	}
}
