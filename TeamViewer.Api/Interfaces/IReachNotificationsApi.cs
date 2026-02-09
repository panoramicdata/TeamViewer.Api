using Refit;
using TeamViewer.Api.Models.Requests;
using TeamViewer.Api.Models.Responses;

namespace TeamViewer.Api.Interfaces;

/// <summary>
/// Interface for Reach Notifications operations.
/// Provides real-time notification features.
/// </summary>
public interface IReachNotificationsApi
{
	/// <summary>
	/// Gets notification subscriptions.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>List of notification subscriptions.</returns>
	[Get("/notifications/subscriptions")]
	Task<NotificationSubscriptionListResponse> GetSubscriptionsAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Creates a notification subscription.
	/// </summary>
	/// <param name="request">The subscription creation request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The created subscription.</returns>
	[Post("/notifications/subscriptions")]
	Task<NotificationSubscription> CreateSubscriptionAsync(
		[Body] CreateNotificationSubscriptionRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets a notification subscription by ID.
	/// </summary>
	/// <param name="subscriptionId">The subscription ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The subscription details.</returns>
	[Get("/notifications/subscriptions/{subscriptionId}")]
	Task<NotificationSubscription> GetSubscriptionAsync(
		string subscriptionId,
		CancellationToken cancellationToken);

	/// <summary>
	/// Updates a notification subscription.
	/// </summary>
	/// <param name="subscriptionId">The subscription ID.</param>
	/// <param name="request">The update request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The updated subscription.</returns>
	[Put("/notifications/subscriptions/{subscriptionId}")]
	Task<NotificationSubscription> UpdateSubscriptionAsync(
		string subscriptionId,
		[Body] UpdateNotificationSubscriptionRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Deletes a notification subscription.
	/// </summary>
	/// <param name="subscriptionId">The subscription ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Delete("/notifications/subscriptions/{subscriptionId}")]
	Task DeleteSubscriptionAsync(
		string subscriptionId,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets notification events for a subscription.
	/// </summary>
	/// <param name="subscriptionId">The subscription ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>List of notification events.</returns>
	[Get("/notifications/subscriptions/{subscriptionId}/events")]
	Task<NotificationEventListResponse> GetEventsAsync(
		string subscriptionId,
		CancellationToken cancellationToken);
}
