using System.Net;
using TeamViewer.Api.Exceptions;

namespace TeamViewer.Api.Test.UnitTests;

/// <summary>
/// Unit tests for TeamViewerApiException.
/// </summary>
public class TeamViewerApiExceptionTests
{
	[Fact]
	public void Constructor_WithStatusCodeAndMessage_SetsProperties()
	{
		// Arrange
		var statusCode = HttpStatusCode.BadRequest;
		var message = "Invalid request";

		// Act
		var exception = new TeamViewerApiException(statusCode, message);

		// Assert
		exception.StatusCode.Should().Be(statusCode);
		exception.Message.Should().Be(message);
		exception.ResponseContent.Should().BeNull();
	}

	[Fact]
	public void Constructor_WithResponseContent_SetsAllProperties()
	{
		// Arrange
		var statusCode = HttpStatusCode.NotFound;
		var message = "Resource not found";
		var responseContent = "{\"error\":\"not_found\"}";

		// Act
		var exception = new TeamViewerApiException(statusCode, message, responseContent);

		// Assert
		exception.StatusCode.Should().Be(statusCode);
		exception.Message.Should().Be(message);
		exception.ResponseContent.Should().Be(responseContent);
	}

	[Fact]
	public void Constructor_WithInnerException_SetsInnerException()
	{
		// Arrange
		var statusCode = HttpStatusCode.InternalServerError;
		var message = "Server error";
		var innerException = new InvalidOperationException("Inner error");

		// Act
		var exception = new TeamViewerApiException(statusCode, message, innerException);

		// Assert
		exception.StatusCode.Should().Be(statusCode);
		exception.Message.Should().Be(message);
		exception.InnerException.Should().Be(innerException);
	}

	[Theory]
	[InlineData(HttpStatusCode.BadRequest)]
	[InlineData(HttpStatusCode.Unauthorized)]
	[InlineData(HttpStatusCode.Forbidden)]
	[InlineData(HttpStatusCode.NotFound)]
	[InlineData(HttpStatusCode.TooManyRequests)]
	[InlineData(HttpStatusCode.InternalServerError)]
	public void StatusCode_VariousValues_PreservesCorrectly(HttpStatusCode statusCode)
	{
		// Act
		var exception = new TeamViewerApiException(statusCode, "Test message");

		// Assert
		exception.StatusCode.Should().Be(statusCode);
	}

	[Fact]
	public void Exception_IsException_InheritsFromException()
	{
		// Act
		var exception = new TeamViewerApiException(HttpStatusCode.BadRequest, "Test");

		// Assert
		exception.Should().BeAssignableTo<Exception>();
	}
}
