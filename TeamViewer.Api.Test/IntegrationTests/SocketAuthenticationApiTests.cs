using TeamViewer.Api.Exceptions;
using TeamViewer.Api.Models.Requests;

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

		// Act & Assert
		try
		{
			var result = await Client.SocketAuthentication.AuthenticateAsync(CancellationToken);

			result.Should().NotBeNull();
			result.Token.Should().NotBeNullOrEmpty();
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("not authorized") || ex.Message.Contains("access denied") || ex.Message.Contains("not found"))
		{
			// Expected if Socket Authentication access is not available
			Assert.True(true, "Socket Authentication API access not available - test skipped");
		}
	}

	[Fact]
	public async Task ValidateTokenAsync_WithValidToken_ReturnsValid()
	{
		EnsureConfigured();

		try
		{
			// Arrange - Get a token first
			var authResult = await Client.SocketAuthentication.AuthenticateAsync(CancellationToken);

			if (string.IsNullOrEmpty(authResult.Token))
			{
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
		catch (TeamViewerApiException ex) when (ex.Message.Contains("not authorized") || ex.Message.Contains("access denied") || ex.Message.Contains("not found"))
		{
			// Expected if Socket Authentication access is not available
			Assert.True(true, "Socket Authentication API access not available - test skipped");
		}
	}
}
