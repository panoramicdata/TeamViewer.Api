using TeamViewer.Api.Exceptions;

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
		var result = await Client.Contacts.GetContactsAsync(CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Contacts.Should().NotBeNull();
	}

	[Fact]
	public async Task InviteAndDeleteContactAsync_InvitesAndDeletesContact()
	{
		// Use a test email that's unlikely to exist
		var testEmail = $"{TestPrefix.ToLowerInvariant()}{DateTime.UtcNow:HHmmss}@test.invalid";

		try
		{
			// Act - Invite
			var inviteRequest = new InviteContactRequest
			{
				Email = testEmail
			};

			var createdContact = await Client.Contacts.InviteContactAsync(inviteRequest, CancellationToken);

			// Assert - Created
			createdContact.Should().NotBeNull();
			createdContact.ContactId.Should().NotBeNullOrEmpty();

			// Get contact to verify
			var contact = await Client.Contacts.GetContactAsync(createdContact.ContactId!, CancellationToken);
			contact.Should().NotBeNull();
			contact.ContactId.Should().Be(createdContact.ContactId);

			// Clean up
			await Client.Contacts.DeleteContactAsync(createdContact.ContactId!, CancellationToken);
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_request") || ex.Message.Contains("permission") || ex.Message.Contains("already"))
		{
			Assert.Skip("Contact invitation requires additional API permissions or email already exists.");
		}
	}
}
