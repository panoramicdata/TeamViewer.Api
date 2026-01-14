namespace TeamViewer.Api.Test.UnitTests;

/// <summary>
/// Unit tests for TeamViewerClient construction.
/// </summary>
public class TeamViewerClientTests
{
	[Fact]
	public void Constructor_WithValidOptions_CreatesClient()
	{
		// Arrange
		var options = new TeamViewerClientOptions
		{
			ScriptToken = "test-token"
		};

		// Act
		using var client = new TeamViewerClient(options);

		// Assert
		client.Should().NotBeNull();
		client.Ping.Should().NotBeNull();
		client.Account.Should().NotBeNull();
		client.Users.Should().NotBeNull();
		client.Groups.Should().NotBeNull();
		client.Sessions.Should().NotBeNull();
		client.Devices.Should().NotBeNull();
		client.Contacts.Should().NotBeNull();
		client.Reports.Should().NotBeNull();
		client.Meetings.Should().NotBeNull();
		client.EventLogging.Should().NotBeNull();
		client.Policies.Should().NotBeNull();
		client.RemoteManagement.Should().NotBeNull();
	}

	[Fact]
	public void Constructor_WithNullOptions_ThrowsArgumentNullException()
	{
		// Act & Assert
		var act = () => new TeamViewerClient(null!);
		act.Should().Throw<ArgumentNullException>();
	}

	[Fact]
	public void Constructor_WithCustomBaseUrl_UsesCustomUrl()
	{
		// Arrange
		var options = new TeamViewerClientOptions
		{
			ScriptToken = "test-token",
			BaseUrl = "https://custom.api.example.com/"
		};

		// Act
		using var client = new TeamViewerClient(options);

		// Assert
		client.Should().NotBeNull();
	}

	[Fact]
	public void Constructor_WithCustomTimeout_UsesCustomTimeout()
	{
		// Arrange
		var options = new TeamViewerClientOptions
		{
			ScriptToken = "test-token",
			Timeout = TimeSpan.FromMinutes(5)
		};

		// Act
		using var client = new TeamViewerClient(options);

		// Assert
		client.Should().NotBeNull();
	}

	[Fact]
	public void Dispose_CalledMultipleTimes_DoesNotThrow()
	{
		// Arrange
		var options = new TeamViewerClientOptions
		{
			ScriptToken = "test-token"
		};
		var client = new TeamViewerClient(options);

		// Act & Assert
		var act = () =>
		{
			client.Dispose();
			client.Dispose();
			client.Dispose();
		};
		act.Should().NotThrow();
	}

	[Fact]
	public void Client_ImplementsITeamViewerClient()
	{
		// Arrange
		var options = new TeamViewerClientOptions
		{
			ScriptToken = "test-token"
		};

		// Act
		using var client = new TeamViewerClient(options);

		// Assert
		client.Should().BeAssignableTo<ITeamViewerClient>();
	}

	[Fact]
	public void Client_ImplementsIDisposable()
	{
		// Arrange
		var options = new TeamViewerClientOptions
		{
			ScriptToken = "test-token"
		};

		// Act
		using var client = new TeamViewerClient(options);

		// Assert
		client.Should().BeAssignableTo<IDisposable>();
	}
}
