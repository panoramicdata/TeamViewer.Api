using System.Text.Json;
using TeamViewer.Api.Models.Requests;

namespace TeamViewer.Api.Test.UnitTests;

/// <summary>
/// Unit tests for OAuth2 request model serialization.
/// </summary>
public class OAuth2RequestsTests
{
	private static readonly JsonSerializerOptions JsonOptions = new()
	{
		PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
		DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
	};

	[Fact]
	public void CreateOAuth2ClientRequest_Serialization_ProducesCorrectJson()
	{
		// Arrange
		var request = new CreateOAuth2ClientRequest
		{
			Name = "My OAuth2 App",
			Description = "A test OAuth2 application",
			RedirectUris = ["https://app.example.com/callback"],
			Scopes = ["Account.read", "Users.read", "Groups.read"],
			GrantTypes = ["authorization_code", "refresh_token"]
		};

		// Act
		var json = JsonSerializer.Serialize(request, JsonOptions);

		// Assert
		json.Should().Contain("\"name\":\"My OAuth2 App\"");
		json.Should().Contain("\"description\"");
		json.Should().Contain("\"redirect_uris\"");
		json.Should().Contain("\"scopes\"");
		json.Should().Contain("\"grant_types\"");
	}

	[Fact]
	public void UpdateOAuth2ClientRequest_PartialUpdate_SerializesOnlyProvidedFields()
	{
		// Arrange
		var request = new UpdateOAuth2ClientRequest
		{
			Name = "Updated App Name",
			Enabled = false
		};

		// Act
		var json = JsonSerializer.Serialize(request, JsonOptions);

		// Assert
		json.Should().Contain("\"name\":\"Updated App Name\"");
		json.Should().Contain("\"enabled\":false");
		json.Should().NotContain("\"redirect_uris\"");
		json.Should().NotContain("\"scopes\"");
	}

	[Fact]
	public void CreateOAuth2ClientRequest_WithMinimalData_Serializes()
	{
		// Arrange
		var request = new CreateOAuth2ClientRequest
		{
			Name = "Minimal Client"
		};

		// Act
		var json = JsonSerializer.Serialize(request, JsonOptions);

		// Assert
		json.Should().Contain("\"name\":\"Minimal Client\"");
		json.Should().NotContain("\"redirect_uris\"");
	}

	[Fact]
	public void UpdateOAuth2ClientRequest_EnableClient_Serializes()
	{
		// Arrange
		var request = new UpdateOAuth2ClientRequest
		{
			Enabled = true
		};

		// Act
		var json = JsonSerializer.Serialize(request, JsonOptions);

		// Assert
		json.Should().Contain("\"enabled\":true");
	}
}
