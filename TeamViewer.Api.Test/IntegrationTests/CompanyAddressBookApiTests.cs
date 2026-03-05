namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the Company Address Book API.
/// </summary>
public class CompanyAddressBookApiTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task GetAddressBookAsync_ReturnsAddressBook()
	{
		// Act
		var result = await Client.CompanyAddressBook.GetAsync(CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Members.Should().NotBeNull();
	}

	[Fact]
	public async Task GetHiddenMembersAsync_ReturnsHiddenMemberList()
	{
		// Act
		var result = await Client.CompanyAddressBook.GetHiddenMembersAsync(CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Members.Should().NotBeNull();
	}
}
