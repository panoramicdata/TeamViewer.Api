using System.Net;
using TeamViewer.Api.Handlers;

namespace TeamViewer.Api.Test.UnitTests;

/// <summary>
/// Unit tests for AuthenticationHandler.
/// </summary>
public class AuthenticationHandlerTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public void Constructor_WithValidToken_CreatesHandler()
	{
		// Act
		using var handler = new AuthenticationHandler("test-token");

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
		var handler = CreateHandler(token, request =>
		{
			// Verify the Authorization header was added
			request.Headers.Authorization.Should().NotBeNull();
			request.Headers.Authorization!.Scheme.Should().Be("Bearer");
			request.Headers.Authorization.Parameter.Should().Be(token);
		});

		// Act
		var response = await HandlerTestHarness.SendAsync(handler);

		// Assert
		response.StatusCode.Should().Be(HttpStatusCode.OK);
	}

	[Fact]
	public async Task SendAsync_PreservesExistingHeaders()
	{
		// Arrange
		var handler = CreateHandler("test-token", request =>
		{
			request.Headers.TryGetValues("X-Custom-Header", out var values).Should().BeTrue();
			values.Should().Contain("custom-value");
		});

		// Act
		var response = await HandlerTestHarness.SendAsync(
			handler,
			request => request.Headers.Add("X-Custom-Header", "custom-value"));

		// Assert
		response.StatusCode.Should().Be(HttpStatusCode.OK);
	}

	/// <summary>
	/// Builds an <see cref="AuthenticationHandler"/> whose inner handler inspects the request the
	/// handler produced, then answers OK.
	/// </summary>
	private static AuthenticationHandler CreateHandler(string token, Action<HttpRequestMessage> assertRequest)
		=> new(token)
		{
			InnerHandler = new TestHandler((request, _) =>
			{
				assertRequest(request);
				return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
			})
		};
}
