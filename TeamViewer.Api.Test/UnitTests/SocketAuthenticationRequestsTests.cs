using System.Text.Json;
using TeamViewer.Api.Models.Requests;

namespace TeamViewer.Api.Test.UnitTests;

/// <summary>
/// Unit tests for SocketAuthentication request model serialization.
/// </summary>
public class SocketAuthenticationRequestsTests
{
	private static readonly JsonSerializerOptions JsonOptions = new()
	{
		PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
	};

	[Fact]
	public void ValidateSocketTokenRequest_Serialization_ProducesCorrectJson()
	{
		// Arrange
		var request = new ValidateSocketTokenRequest
		{
			Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.test"
		};

		// Act
		var json = JsonSerializer.Serialize(request, JsonOptions);

		// Assert
		json.Should().Contain("\"token\"");
		json.Should().Contain("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.test");
	}

	[Fact]
	public void RevokeSocketTokenRequest_Serialization_ProducesCorrectJson()
	{
		// Arrange
		var request = new RevokeSocketTokenRequest
		{
			Token = "token-to-revoke"
		};

		// Act
		var json = JsonSerializer.Serialize(request, JsonOptions);

		// Assert
		json.Should().Contain("\"token\":\"token-to-revoke\"");
	}

	[Fact]
	public void ValidateSocketTokenRequest_Deserialization_Works()
	{
		// Arrange
		var json = """{"token":"my-test-token"}""";

		// Act
		var request = JsonSerializer.Deserialize<ValidateSocketTokenRequest>(json, JsonOptions);

		// Assert
		request.Should().NotBeNull();
		request!.Token.Should().Be("my-test-token");
	}

	[Fact]
	public void RevokeSocketTokenRequest_Deserialization_Works()
	{
		// Arrange
		var json = """{"token":"revoke-this"}""";

		// Act
		var request = JsonSerializer.Deserialize<RevokeSocketTokenRequest>(json, JsonOptions);

		// Assert
		request.Should().NotBeNull();
		request!.Token.Should().Be("revoke-this");
	}
}
