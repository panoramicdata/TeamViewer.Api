namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the SSO Domain API.
/// </summary>
public class SsoDomainApiTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task GetSsoDomainsAsync_ReturnsDomainList()
	{
		// Act
		var result = await Client.SsoDomain.GetAsync(CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Domains.Should().NotBeNull();
	}

	[Fact]
	public async Task CreateAndDeleteSsoDomainAsync_CreatesAndDeletesDomain()
	{
		// Use a test domain that's unlikely to conflict
		var testDomain = $"{TestPrefix.ToLowerInvariant().Replace("_", "")}{DateTime.UtcNow:HHmmss}.test.invalid";

		// Act - Create
		var createdDomain = await Client.SsoDomain.CreateAsync(
			new CreateSsoDomainRequest { DomainName = testDomain },
			CancellationToken);

		// Assert - Created
		createdDomain.Should().NotBeNull();
		createdDomain.DomainId.Should().NotBeNullOrEmpty();
		createdDomain.DomainName.Should().Be(testDomain);

		// Clean up
		await Client.SsoDomain.DeleteAsync(createdDomain.DomainId!, CancellationToken);

		// Verify deletion
		var domains = await Client.SsoDomain.GetAsync(CancellationToken);
		domains.Domains.Should().NotContain(d => d.DomainId == createdDomain.DomainId);
	}
}
