using System.Net;
using System.Text;
using TeamViewer.Api.Exceptions;
using TeamViewer.Api.Handlers;

namespace TeamViewer.Api.Test.UnitTests;

/// <summary>
/// Unit tests for ErrorHandler.
/// </summary>
public class ErrorHandlerTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task SendAsync_SuccessResponse_ReturnsResponse()
	{
		// Arrange
		var handler = new ErrorHandler
		{
			InnerHandler = new TestHandler((_, _) =>
				Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent("{\"data\":\"test\"}", Encoding.UTF8, "application/json")
				}))
		};

		using var client = new HttpClient(handler);

		// Act
		var response = await client.GetAsync("https://example.com/test", CancellationToken);

		// Assert
		response.StatusCode.Should().Be(HttpStatusCode.OK);
	}

	[Fact]
	public async Task SendAsync_ErrorWithErrorProperty_ThrowsWithErrorMessage()
	{
		// Arrange
		var handler = new ErrorHandler
		{
			InnerHandler = new TestHandler((_, _) =>
				Task.FromResult(new HttpResponseMessage(HttpStatusCode.BadRequest)
				{
					Content = new StringContent("{\"error\":\"Invalid request\"}", Encoding.UTF8, "application/json")
				}))
		};

		using var client = new HttpClient(handler);

		// Act
		var act = () => client.GetAsync("https://example.com/test");

		// Assert
		var exception = await act.Should().ThrowAsync<TeamViewerApiException>();
		exception.Which.Message.Should().Be("Invalid request");
		exception.Which.StatusCode.Should().Be(HttpStatusCode.BadRequest);
	}

	[Fact]
	public async Task SendAsync_ErrorWithErrorDescription_ThrowsWithDescription()
	{
		// Arrange
		var handler = new ErrorHandler
		{
			InnerHandler = new TestHandler((_, _) =>
				Task.FromResult(new HttpResponseMessage(HttpStatusCode.Unauthorized)
				{
					Content = new StringContent("{\"error_description\":\"Token expired\"}", Encoding.UTF8, "application/json")
				}))
		};

		using var client = new HttpClient(handler);

		// Act
		var act = () => client.GetAsync("https://example.com/test");

		// Assert
		var exception = await act.Should().ThrowAsync<TeamViewerApiException>();
		exception.Which.Message.Should().Be("Token expired");
		exception.Which.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
	}

	[Fact]
	public async Task SendAsync_ErrorWithInvalidJson_UsesRawContent()
	{
		// Arrange
		var rawContent = "Not a JSON response";
		var handler = new ErrorHandler
		{
			InnerHandler = new TestHandler((_, _) =>
				Task.FromResult(new HttpResponseMessage(HttpStatusCode.InternalServerError)
				{
					Content = new StringContent(rawContent, Encoding.UTF8, "text/plain")
				}))
		};

		using var client = new HttpClient(handler);

		// Act
		var act = () => client.GetAsync("https://example.com/test");

		// Assert
		var exception = await act.Should().ThrowAsync<TeamViewerApiException>();
		exception.Which.Message.Should().Be(rawContent);
		exception.Which.ResponseContent.Should().Be(rawContent);
	}

	[Fact]
	public async Task SendAsync_ErrorWithNoKnownProperties_UsesUnknownError()
	{
		// Arrange
		var handler = new ErrorHandler
		{
			InnerHandler = new TestHandler((_, _) =>
				Task.FromResult(new HttpResponseMessage(HttpStatusCode.NotFound)
				{
					Content = new StringContent("{\"code\":404}", Encoding.UTF8, "application/json")
				}))
		};

		using var client = new HttpClient(handler);

		// Act
		var act = () => client.GetAsync("https://example.com/test");

		// Assert
		var exception = await act.Should().ThrowAsync<TeamViewerApiException>();
		exception.Which.Message.Should().Be("An unknown error occurred");
		exception.Which.StatusCode.Should().Be(HttpStatusCode.NotFound);
	}

	[Fact]
	public async Task SendAsync_PreservesResponseContent()
	{
		// Arrange
		var responseContent = "{\"error\":\"Bad\",\"details\":\"More info\"}";
		var handler = new ErrorHandler
		{
			InnerHandler = new TestHandler((_, _) =>
				Task.FromResult(new HttpResponseMessage(HttpStatusCode.BadRequest)
				{
					Content = new StringContent(responseContent, Encoding.UTF8, "application/json")
				}))
		};

		using var client = new HttpClient(handler);

		// Act
		var act = () => client.GetAsync("https://example.com/test");

		// Assert
		var exception = await act.Should().ThrowAsync<TeamViewerApiException>();
		exception.Which.ResponseContent.Should().Be(responseContent);
	}
}
