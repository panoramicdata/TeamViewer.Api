namespace TeamViewer.Api.Test.UnitTests;

internal class TestHandler(Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> handler) : HttpMessageHandler
{
	protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		=> handler(request, cancellationToken);
}
