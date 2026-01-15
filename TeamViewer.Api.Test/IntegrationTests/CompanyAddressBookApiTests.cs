using TeamViewer.Api.Exceptions;

namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the Company Address Book API.
/// </summary>
public class CompanyAddressBookApiTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task GetAddressBookAsync_ReturnsAddressBook()
	{
		try
		{
			// Act
			var result = await Client.CompanyAddressBook.GetAsync(CancellationToken);

			// Assert
			result.Should().NotBeNull();
			result.Members.Should().NotBeNull();
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission") || ex.Message.Contains("not_found") || ex.Message.Contains("unknown"))
		{
			Assert.Skip("Company Address Book API requires additional permissions or is not available.");
		}
	}

	[Fact]
	public async Task GetHiddenMembersAsync_ReturnsHiddenMemberList()
	{
		try
		{
			// Act
			var result = await Client.CompanyAddressBook.GetHiddenMembersAsync(CancellationToken);

			// Assert
			result.Should().NotBeNull();
			result.Members.Should().NotBeNull();
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission") || ex.Message.Contains("not_found") || ex.Message.Contains("unknown"))
		{
			Assert.Skip("Company Address Book API requires additional permissions or is not available.");
		}
	}
}
