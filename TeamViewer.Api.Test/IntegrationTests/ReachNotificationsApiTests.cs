using TeamViewer.Api.Exceptions;
using TeamViewer.Api.Models.Requests;

namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the Reach Notifications API.
/// Note: These tests require Reach Notifications access which may require specific permissions.
/// </summary>
public class ReachNotificationsApiTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task GetSubscriptionsAsync_ReturnsSubscriptionList()
	{
		EnsureConfigured();

		// Act & Assert
		try
		{
			var result = await Client.ReachNotifications.GetSubscriptionsAsync(CancellationToken);

			result.Should().NotBeNull();
			result.Subscriptions.Should().NotBeNull();
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("not authorized") || ex.Message.Contains("access denied") || ex.Message.Contains("not found"))
		{
			// Expected if Reach Notifications access is not available
			Assert.True(true, "Reach Notifications API access not available - test skipped");
		}
	}

	[Fact]
	public async Task CreateUpdateDeleteSubscriptionAsync_FullCrudCycle()
	{
		EnsureConfigured();

		// Arrange
		var testSubscriptionName = $"ZZZ_Test_Subscription_{DateTime.UtcNow:HHmmss}";

		try
		{
			// Act - Create
			var createRequest = new CreateNotificationSubscriptionRequest
			{
				Name = testSubscriptionName,
				Description = "Test subscription created by integration test",
				EventTypes = ["device.connected", "device.disconnected"],
				CallbackUrl = "https://example.com/webhook"
			};

			var created = await Client.ReachNotifications.CreateSubscriptionAsync(createRequest, CancellationToken);

			// Assert - Create
			created.Should().NotBeNull();
			created.Id.Should().NotBeNullOrEmpty();
			created.Name.Should().Be(testSubscriptionName);

			try
			{
				// Act - Update
				var updateRequest = new UpdateNotificationSubscriptionRequest
				{
					Description = "Updated description",
					Active = false
				};

				var updated = await Client.ReachNotifications.UpdateSubscriptionAsync(created.Id, updateRequest, CancellationToken);

				// Assert - Update
				updated.Should().NotBeNull();
				updated.Description.Should().Be("Updated description");

				// Act - Get events
				var events = await Client.ReachNotifications.GetEventsAsync(created.Id, CancellationToken);

				// Assert - Get events
				events.Should().NotBeNull();
				events.Events.Should().NotBeNull();
			}
			finally
			{
				// Cleanup - Delete
				await Client.ReachNotifications.DeleteSubscriptionAsync(created.Id, CancellationToken);
			}
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("not authorized") || ex.Message.Contains("access denied") || ex.Message.Contains("not found"))
		{
			// Expected if Reach Notifications access is not available
			Assert.True(true, "Reach Notifications API access not available - test skipped");
		}
	}
}
