using System.Text.Json;
using TeamViewer.Api.Models.Responses;

namespace TeamViewer.Api.Test.UnitTests;

/// <summary>
/// Unit tests for OAuth2 model serialization and deserialization.
/// </summary>
public class OAuth2ModelsTests
{
	private static readonly JsonSerializerOptions JsonOptions = new()
	{
		PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
	};

	[Fact]
	public void OAuth2Client_Serialization_RoundTrips()
	{
		// Arrange
		var client = new OAuth2Client
		{
			ClientId = "client-123",
			Name = "Test Client",
			Description = "A test OAuth2 client",
			RedirectUris = ["https://example.com/callback", "https://example.com/callback2"],
			Scopes = ["Account.read", "Users.read"],
			GrantTypes = ["authorization_code", "refresh_token"],
			Enabled = true,
			CreatedAt = DateTime.UtcNow.AddDays(-30),
			UpdatedAt = DateTime.UtcNow
		};

		// Act
		var json = JsonSerializer.Serialize(client, JsonOptions);
		var deserialized = JsonSerializer.Deserialize<OAuth2Client>(json, JsonOptions);

		// Assert
		deserialized.Should().NotBeNull();
		deserialized!.ClientId.Should().Be(client.ClientId);
		deserialized.Name.Should().Be(client.Name);
		deserialized.Description.Should().Be(client.Description);
		deserialized.RedirectUris.Should().HaveCount(2);
		deserialized.Scopes.Should().Contain("Account.read");
		deserialized.GrantTypes.Should().Contain("authorization_code");
		deserialized.Enabled.Should().BeTrue();
	}

	[Fact]
	public void OAuth2ClientWithSecret_IncludesSecret()
	{
		// Arrange
		var client = new OAuth2ClientWithSecret
		{
			ClientId = "client-123",
			Name = "Test Client",
			ClientSecret = "super-secret-123"
		};

		// Act
		var json = JsonSerializer.Serialize(client, JsonOptions);
		var deserialized = JsonSerializer.Deserialize<OAuth2ClientWithSecret>(json, JsonOptions);

		// Assert
		deserialized.Should().NotBeNull();
		deserialized!.ClientSecret.Should().Be(client.ClientSecret);
	}

	[Fact]
	public void OAuth2ClientListResponse_WithEmptyClients_Initializes()
	{
		// Arrange & Act
		var response = new OAuth2ClientListResponse();

		// Assert
		response.Clients.Should().NotBeNull();
		response.Clients.Should().BeEmpty();
	}

	[Fact]
	public void OAuth2Client_WithNullOptionalProperties_Deserializes()
	{
		// Arrange
		var json = """
		{
			"client_id": "test-id",
			"name": "Test"
		}
		""";

		// Act
		var client = JsonSerializer.Deserialize<OAuth2Client>(json, JsonOptions);

		// Assert
		client.Should().NotBeNull();
		client!.ClientId.Should().Be("test-id");
		client.Name.Should().Be("Test");
		client.RedirectUris.Should().BeNull();
		client.Scopes.Should().BeNull();
		client.GrantTypes.Should().BeNull();
	}
}
