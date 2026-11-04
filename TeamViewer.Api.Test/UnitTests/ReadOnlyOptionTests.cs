using System.Net;

namespace TeamViewer.Api.Test.UnitTests;

/// <summary>
/// Credential-free tests: a refused write throws before any request is sent.
/// </summary>
public class ReadOnlyOptionTests
{
	private const string FakeToken = "fake-token";

	[Fact]
	public void IsReadOnly_DefaultsToFalse()
		=> new TeamViewerClientOptions { ScriptToken = FakeToken }.IsReadOnly.Should().BeFalse();

	[Fact]
	public async Task WriteIsRefused_WhenIsReadOnly()
	{
		var sent = false;
		var options = new TeamViewerClientOptions { ScriptToken = FakeToken, IsReadOnly = true };
		using var client = new HttpClient(new Handlers.ReadOnlyHandler(options)
		{
			InnerHandler = new TestHandler((_, _) =>
			{
				sent = true;
				return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
			})
		});

		var act = () => client.PostAsync("https://example.com/x", new StringContent("{}"), TestContext.Current.CancellationToken);

		await act.Should().ThrowAsync<InvalidOperationException>();
		sent.Should().BeFalse();
	}

	[Fact]
	public async Task WriteApiCall_IsRefused_WhenIsReadOnly()
	{
		using var client = new TeamViewerClient(new TeamViewerClientOptions { ScriptToken = FakeToken, IsReadOnly = true, MaxRetryAttempts = 0 });

		var act = () => client.Chat.MarkMessageAsReadAsync(new MarkMessageAsReadRequest { MessageId = "1" }, TestContext.Current.CancellationToken);

		await act.Should().ThrowAsync<InvalidOperationException>();
	}

	[Fact]
	public async Task ReadIsAllowed_WhenIsReadOnly()
	{
		var options = new TeamViewerClientOptions { ScriptToken = FakeToken, IsReadOnly = true };
		using var response = await HandlerTestHarness.SendAsync(new Handlers.ReadOnlyHandler(options)
		{
			InnerHandler = HandlerTestHarness.RespondWith(HttpStatusCode.OK, "{}", "application/json")
		});

		response.StatusCode.Should().Be(HttpStatusCode.OK);
	}
}
