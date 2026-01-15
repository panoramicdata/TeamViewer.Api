namespace TeamViewer.Api.Interfaces;

/// <summary>
/// API interface for meeting management.
/// </summary>
public interface IMeetingsApi
{
	/// <summary>
	/// Gets a list of scheduled meetings.
	/// </summary>
	/// <param name="request">The request parameters.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of meetings.</returns>
	[Get("/meetings")]
	Task<MeetingListResponse> GetAsync(
		[Query] GetMeetingsRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets a specific meeting by ID.
	/// </summary>
	/// <param name="meetingId">The meeting ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The meeting.</returns>
	[Get("/meetings/{meetingId}")]
	Task<Meeting> GetAsync(
		string meetingId,
		CancellationToken cancellationToken);

	/// <summary>
	/// Creates a new meeting.
	/// </summary>
	/// <param name="request">The create meeting request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The created meeting.</returns>
	[Post("/meetings")]
	Task<Meeting> CreateAsync(
		[Body] CreateMeetingRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Updates an existing meeting.
	/// </summary>
	/// <param name="meetingId">The meeting ID.</param>
	/// <param name="request">The update meeting request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Put("/meetings/{meetingId}")]
	Task UpdateAsync(
		string meetingId,
		[Body] UpdateMeetingRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Deletes a meeting.
	/// </summary>
	/// <param name="meetingId">The meeting ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Delete("/meetings/{meetingId}")]
	Task DeleteAsync(
		string meetingId,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets the invitation email content for a meeting.
	/// </summary>
	/// <param name="meetingId">The meeting ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The meeting invitation.</returns>
	[Get("/meetings/{meetingId}/invitation")]
	Task<MeetingInvitation> GetInvitationAsync(
		string meetingId,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets the participants of a meeting.
	/// </summary>
	/// <param name="meetingId">The meeting ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of meeting participants.</returns>
	[Get("/meetings/{meetingId}/participants")]
	Task<MeetingParticipantListResponse> GetParticipantsAsync(
		string meetingId,
		CancellationToken cancellationToken);
}
