namespace TeamViewer.Api.Interfaces;

/// <summary>
/// Interface for the TeamViewer API client.
/// </summary>
public interface ITeamViewerClient : IDisposable
{
	/// <summary>
	/// Gets the Ping API for testing connectivity.
	/// </summary>
	IPingApi Ping { get; }

	/// <summary>
	/// Gets the Account API for managing account information.
	/// </summary>
	IAccountApi Account { get; }

	/// <summary>
	/// Gets the Users API for managing company users.
	/// </summary>
	IUsersApi Users { get; }

	/// <summary>
	/// Gets the Groups API for managing groups.
	/// </summary>
	IGroupsApi Groups { get; }
}
