using System.Net;
using TeamViewer.Api.Handlers;

namespace TeamViewer.Api.Test.UnitTests;

/// <summary>
/// Unit tests for ErrorHandler.
/// </summary>
public class ErrorHandlerTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	private const string JsonMediaType = "application/json";

	[Fact]
	public async Task SendAsync_SuccessResponse_ReturnsResponse()
	{
		// Arrange
		var handler = CreateHandler(HttpStatusCode.OK, "{\"data\":\"test\"}", JsonMediaType);

		// Act
		var response = await HandlerTestHarness.SendAsync(handler);

		// Assert
		response.StatusCode.Should().Be(HttpStatusCode.OK);
	}

	// One row per shape of error body the API returns: an 'error' property, an OAuth-style
	// 'error_description', and a body carrying neither.
	[Theory]
	[InlineData(HttpStatusCode.BadRequest, "{\"error\":\"Invalid request\"}", "Invalid request")]
	[InlineData(HttpStatusCode.Unauthorized, "{\"error_description\":\"Token expired\"}", "Token expired")]
	[InlineData(HttpStatusCode.NotFound, "{\"code\":404}", "An unknown error occurred")]
	public async Task SendAsync_ErrorResponse_ThrowsWithMessageAndStatusCode(
		HttpStatusCode statusCode,
		string content,
		string expectedMessage)
	{
		// Act
		var exception = await CaptureThrownAsync(statusCode, content);

		// Assert
		exception.Message.Should().Be(expectedMessage);
		exception.StatusCode.Should().Be(statusCode);
	}

	[Fact]
	public async Task SendAsync_ErrorWithInvalidJson_UsesRawContent()
	{
		// Arrange
		const string rawContent = "Not a JSON response";

		// Act
		var exception = await CaptureThrownAsync(HttpStatusCode.InternalServerError, rawContent, "text/plain");

		// Assert
		exception.Message.Should().Be(rawContent);
		exception.ResponseContent.Should().Be(rawContent);
	}

	[Fact]
	public async Task SendAsync_PreservesResponseContent()
	{
		// Arrange
		const string responseContent = "{\"error\":\"Bad\",\"details\":\"More info\"}";

		// Act
		var exception = await CaptureThrownAsync(HttpStatusCode.BadRequest, responseContent);

		// Assert
		exception.ResponseContent.Should().Be(responseContent);
	}

	private static ErrorHandler CreateHandler(HttpStatusCode statusCode, string content, string mediaType)
		=> new()
		{
			InnerHandler = HandlerTestHarness.RespondWith(statusCode, content, mediaType)
		};

	/// <summary>
	/// Sends the given response through <see cref="ErrorHandler"/> and returns the exception it raised.
	/// </summary>
	private static async Task<TeamViewerApiException> CaptureThrownAsync(
		HttpStatusCode statusCode,
		string content,
		string mediaType = JsonMediaType)
	{
		var act = async () => await HandlerTestHarness.SendAsync(CreateHandler(statusCode, content, mediaType));

		var exception = await act.Should().ThrowAsync<TeamViewerApiException>();
		return exception.Which;
	}
}
