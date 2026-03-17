using TeamViewer.Api.Models.Requests;

namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the OAuth2 API.
/// Note: These tests require OAuth2 management access which may require specific permissions.
/// </summary>
public class OAuth2ApiTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task GetClientsAsync_ReturnsClientList()
	{
		EnsureConfigured();

		// Act
		var result = await Client.OAuth2.GetClientsAsync(CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Clients.Should().NotBeNull();
	}

	[Fact]
	public async Task CreateUpdateDeleteClientAsync_FullCrudCycle()
	{
		EnsureConfigured();

		// Arrange
		var testClientName = $"ZZZ_Test_OAuth2Client_{DateTime.UtcNow:HHmmss}";

		// Act - Create
		var createRequest = new CreateOAuth2ClientRequest
		{
			Name = testClientName,
			Description = "Test OAuth2 client created by integration test",
			RedirectUris = ["https://example.com/callback"],
			Scopes = ["Account.read"],
			GrantTypes = ["authorization_code"]
		};

		var created = await Client.OAuth2.CreateClientAsync(createRequest, CancellationToken);

		// Assert - Create
		created.Should().NotBeNull();
		created.ClientId.Should().NotBeNullOrEmpty();
		created.Name.Should().Be(testClientName);

		try
		{
			// Act - Update
			var updateRequest = new UpdateOAuth2ClientRequest
			{
				Description = "Updated description"
			};

			var updated = await Client.OAuth2.UpdateClientAsync(created.ClientId, updateRequest, CancellationToken);

			// Assert - Update
			updated.Should().NotBeNull();
			updated.Description.Should().Be("Updated description");
		}
		finally
		{
			// Cleanup - Delete
			await Client.OAuth2.DeleteClientAsync(created.ClientId, CancellationToken);
		}
	}
}
