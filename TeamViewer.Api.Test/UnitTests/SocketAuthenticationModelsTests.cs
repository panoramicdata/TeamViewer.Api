using System.Text.Json;
using TeamViewer.Api.Models.Responses;

namespace TeamViewer.Api.Test.UnitTests;

/// <summary>
/// Unit tests for SocketAuthentication model serialization and deserialization.
/// </summary>
public class SocketAuthenticationModelsTests
{
	private static readonly JsonSerializerOptions JsonOptions = new()
	{
		PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
	};

	[Fact]
	public void SocketAuthenticationToken_Serialization_RoundTrips()
	{
		// Arrange
		var token = new SocketAuthenticationToken
		{
			Token = "jwt-token-here",
			ExpiresAt = DateTime.UtcNow.AddHours(1),
			WebSocketUrl = "wss://socket.teamviewer.com",
			TokenType = "Bearer"
		};

		// Act
		var json = JsonSerializer.Serialize(token, JsonOptions);
		var deserialized = JsonSerializer.Deserialize<SocketAuthenticationToken>(json, JsonOptions);

		// Assert
		deserialized.Should().NotBeNull();
		deserialized!.Token.Should().Be(token.Token);
		deserialized.WebSocketUrl.Should().Be(token.WebSocketUrl);
		deserialized.TokenType.Should().Be(token.TokenType);
	}

	[Fact]
	public void SocketTokenValidationResult_ValidToken_Deserializes()
	{
		// Arrange
		var result = new SocketTokenValidationResult
		{
			Valid = true,
			ExpiresAt = DateTime.UtcNow.AddHours(1),
			AccountId = "account-123",
			Error = null
		};

		// Act
		var json = JsonSerializer.Serialize(result, JsonOptions);
		var deserialized = JsonSerializer.Deserialize<SocketTokenValidationResult>(json, JsonOptions);

		// Assert
		deserialized.Should().NotBeNull();
		deserialized!.Valid.Should().BeTrue();
		deserialized.AccountId.Should().Be(result.AccountId);
		deserialized.Error.Should().BeNull();
	}

	[Fact]
	public void SocketTokenValidationResult_InvalidToken_Deserializes()
	{
		// Arrange
		var result = new SocketTokenValidationResult
		{
			Valid = false,
			ExpiresAt = null,
			AccountId = null,
			Error = "Token expired"
		};

		// Act
		var json = JsonSerializer.Serialize(result, JsonOptions);
		var deserialized = JsonSerializer.Deserialize<SocketTokenValidationResult>(json, JsonOptions);

		// Assert
		deserialized.Should().NotBeNull();
		deserialized!.Valid.Should().BeFalse();
		deserialized.Error.Should().Be("Token expired");
	}

	[Fact]
	public void SocketAuthenticationToken_DefaultValues_AreCorrect()
	{
		// Arrange & Act
		var token = new SocketAuthenticationToken();

		// Assert
		token.Token.Should().Be(string.Empty);
		token.ExpiresAt.Should().BeNull();
		token.WebSocketUrl.Should().BeNull();
		token.TokenType.Should().BeNull();
	}
}
