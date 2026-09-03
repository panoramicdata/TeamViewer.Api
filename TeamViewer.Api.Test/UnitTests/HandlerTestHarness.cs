using System.Net;
using System.Text;

namespace TeamViewer.Api.Test.UnitTests;

/// <summary>
/// An <see cref="HttpMessageHandler"/> whose response is supplied by a delegate, so a test can stand
/// in for the network at the end of a handler chain.
/// </summary>
internal class TestHandler(Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> handler) : HttpMessageHandler
{
	protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		=> handler(request, cancellationToken);
}

/// <summary>
/// Shared plumbing for the handler unit tests. Each of them builds a handler chain, sends a single
/// request through it and inspects the result, so that part lives here rather than in every test.
/// </summary>
internal static class HandlerTestHarness
{
	/// <summary>
	/// The URI the handler tests send to. Nothing resolves it: <see cref="TestHandler"/> answers first.
	/// </summary>
	public const string RequestUri = "https://example.com/test";

	/// <summary>
	/// Sends one GET through <paramref name="handler"/> and returns the response.
	/// </summary>
	/// <param name="handler">The handler chain under test. Disposed along with the client.</param>
	/// <param name="configureRequest">Optional hook for adding headers to the outgoing request.</param>
	public static async Task<HttpResponseMessage> SendAsync(
		HttpMessageHandler handler,
		Action<HttpRequestMessage>? configureRequest = null)
	{
		using var client = new HttpClient(handler);
		using var request = new HttpRequestMessage(HttpMethod.Get, RequestUri);
		configureRequest?.Invoke(request);
		return await client.SendAsync(request, TestContext.Current.CancellationToken);
	}

	/// <summary>
	/// Builds a <see cref="TestHandler"/> that always answers with the given status and body.
	/// </summary>
	public static TestHandler RespondWith(HttpStatusCode statusCode, string content, string mediaType)
		=> new((_, _) => Task.FromResult(new HttpResponseMessage(statusCode)
		{
			Content = new StringContent(content, Encoding.UTF8, mediaType)
		}));
}
