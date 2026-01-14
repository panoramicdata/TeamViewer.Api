using System.Net;
using TeamViewer.Api.Handlers;

namespace TeamViewer.Api.Test.UnitTests;

/// <summary>
/// Unit tests for AuthenticationHandler.
/// </summary>
public class AuthenticationHandlerTests
{
	[Fact]
	public void Constructor_WithValidToken_CreatesHandler()
	{
		// Act
		var handler = new AuthenticationHandler("test-token");

		// Assert
		handler.Should().NotBeNull();
	}

	[Fact]
	public void Constructor_WithNullToken_ThrowsArgumentNullException()
	{
		// Act & Assert
		var act = () => new AuthenticationHandler(null!);
		act.Should().Throw<ArgumentNullException>()
			.WithParameterName("scriptToken");
	}

	[Fact]
	public async Task SendAsync_AddsAuthorizationHeader()
	{
		// Arrange
		const string token = "my-script-token";
		var handler = new AuthenticationHandler(token)
		{
			InnerHandler = new TestHandler((request, _) =>
			{
				// Verify the Authorization header was added
				request.Headers.Authorization.Should().NotBeNull();
				request.Headers.Authorization!.Scheme.Should().Be("Bearer");
				request.Headers.Authorization.Parameter.Should().Be(token);
				return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
			})
		};

		using var client = new HttpClient(handler);

		// Act
		var response = await client.GetAsync("https://example.com/test");

		// Assert
		response.StatusCode.Should().Be(HttpStatusCode.OK);
	}

	[Fact]
	public async Task SendAsync_PreservesExistingHeaders()
	{
		// Arrange
		var handler = new AuthenticationHandler("test-token")
		{
			InnerHandler = new TestHandler((request, _) =>
			{
				request.Headers.TryGetValues("X-Custom-Header", out var values).Should().BeTrue();
				values.Should().Contain("custom-value");
				return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
			})
		};

		using var client = new HttpClient(handler);
		using var request = new HttpRequestMessage(HttpMethod.Get, "https://example.com/test");
		request.Headers.Add("X-Custom-Header", "custom-value");

		// Act
		var response = await client.SendAsync(request);

		// Assert
		response.StatusCode.Should().Be(HttpStatusCode.OK);
	}

	/// <summary>
	/// Test handler that allows custom request inspection.
	/// </summary>
	private class TestHandler : HttpMessageHandler
	{
		private readonly Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> _handler;

		public TestHandler(Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> handler)
		{
			_handler = handler;
		}

		protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
			=> _handler(request, cancellationToken);
	}
}
