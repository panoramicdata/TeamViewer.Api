namespace TeamViewer.Api.Test.UnitTests;

/// <summary>
/// Unit tests for TeamViewerClientOptions.
/// </summary>
public class TeamViewerClientOptionsTests
{
	[Fact]
	public void DefaultValues_AreSetCorrectly()
	{
		// Act
		var options = new TeamViewerClientOptions
		{
			ScriptToken = "test-token"
		};

		// Assert
		options.BaseUrl.Should().Be("https://webapi.teamviewer.com/api/v1/");
		options.MaxRetryAttempts.Should().Be(3);
		options.RetryDelayMilliseconds.Should().Be(1000);
		options.Timeout.Should().Be(TimeSpan.FromSeconds(30));
	}

	[Fact]
	public void ScriptToken_Required_CanBeSet()
	{
		// Arrange
		const string token = "my-script-token";

		// Act
		var options = new TeamViewerClientOptions
		{
			ScriptToken = token
		};

		// Assert
		options.ScriptToken.Should().Be(token);
	}

	[Fact]
	public void BaseUrl_CanBeOverridden()
	{
		// Arrange
		const string customUrl = "https://custom.api.example.com/";

		// Act
		var options = new TeamViewerClientOptions
		{
			ScriptToken = "test",
			BaseUrl = customUrl
		};

		// Assert
		options.BaseUrl.Should().Be(customUrl);
	}

	[Fact]
	public void MaxRetryAttempts_CanBeOverridden()
	{
		// Act
		var options = new TeamViewerClientOptions
		{
			ScriptToken = "test",
			MaxRetryAttempts = 5
		};

		// Assert
		options.MaxRetryAttempts.Should().Be(5);
	}

	[Fact]
	public void RetryDelayMilliseconds_CanBeOverridden()
	{
		// Act
		var options = new TeamViewerClientOptions
		{
			ScriptToken = "test",
			RetryDelayMilliseconds = 2000
		};

		// Assert
		options.RetryDelayMilliseconds.Should().Be(2000);
	}

	[Fact]
	public void Timeout_CanBeOverridden()
	{
		// Act
		var options = new TeamViewerClientOptions
		{
			ScriptToken = "test",
			Timeout = TimeSpan.FromMinutes(2)
		};

		// Assert
		options.Timeout.Should().Be(TimeSpan.FromMinutes(2));
	}
}
