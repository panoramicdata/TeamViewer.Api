namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the Contacts API.
/// </summary>
public class ContactsApiTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task GetContactsAsync_ReturnsContactList()
	{
		// Act
		var result = await Client.Contacts.GetAsync(CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Contacts.Should().NotBeNull();
	}

	[Fact]
	public async Task InviteAndDeleteContactAsync_InvitesAndDeletesContact()
	{
		// Use a test email that's unlikely to exist
		var testEmail = $"{TestPrefix.ToLowerInvariant()}{DateTime.UtcNow:HHmmss}@test.invalid";

		// Act - Invite
		var inviteRequest = new InviteContactRequest
		{
			Email = testEmail
		};

		var createdContact = await Client.Contacts.InviteAsync(inviteRequest, CancellationToken);

		// Assert - Created
		createdContact.Should().NotBeNull();
		createdContact.ContactId.Should().NotBeNullOrEmpty();

		// Get contact to verify
		var contact = await Client.Contacts.GetAsync(createdContact.ContactId!, CancellationToken);
		contact.Should().NotBeNull();
		contact.ContactId.Should().Be(createdContact.ContactId);

		// Clean up
		await Client.Contacts.DeleteAsync(createdContact.ContactId!, CancellationToken);
	}
}
