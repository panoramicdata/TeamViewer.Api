namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the Socket Authentication API.
/// Note: These tests require Socket Authentication access which may require specific permissions.
/// </summary>
public class SocketAuthenticationApiTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task AuthenticateAsync_ReturnsToken()
	{
		EnsureConfigured();

		// Act
		var result = await Client.SocketAuthentication.AuthenticateAsync(CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Token.Should().NotBeNullOrEmpty();
	}

	[Fact]
	public async Task ValidateTokenAsync_WithValidToken_ReturnsValid()
	{
		EnsureConfigured();

		// Arrange - Get a token first
		var authResult = await Client.SocketAuthentication.AuthenticateAsync(CancellationToken);

		if (string.IsNullOrEmpty(authResult.Token))
		{
			Assert.Skip("No socket authentication token available for testing.");
			return;
		}

		// Act
		var validateRequest = new ValidateSocketTokenRequest
		{
			Token = authResult.Token
		};

		var result = await Client.SocketAuthentication.ValidateTokenAsync(validateRequest, CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Valid.Should().BeTrue();
	}
}
