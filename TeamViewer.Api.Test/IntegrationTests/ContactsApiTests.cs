using TeamViewer.Api.Test.Infrastructure;

namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the Contacts API.
/// </summary>
public class ContactsApiTests : IntegrationTestBase
{
	[Fact]
	public async Task GetContactsAsync_ReturnsContactList()
	{
		EnsureConfigured();

		// Act
		var result = await Client!.Contacts.GetContactsAsync(TestContext.Current.CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Contacts.Should().NotBeNull();
	}

	[Fact]
	public async Task GetContactAsync_WithValidContactId_ReturnsContact()
	{
		EnsureConfigured();

		// First get a list of contacts to find a valid ID
		var contacts = await Client!.Contacts.GetContactsAsync(TestContext.Current.CancellationToken);

		if (contacts.Contacts.Count == 0)
		{
			Assert.Skip("No contacts available for testing.");
			return;
		}

		var contactId = contacts.Contacts[0].ContactId!;

		// Act
		var result = await Client!.Contacts.GetContactAsync(contactId, TestContext.Current.CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.ContactId.Should().Be(contactId);
	}
}
