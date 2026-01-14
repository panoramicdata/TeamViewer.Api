namespace TeamViewer.Api.Test.UnitTests;

public abstract class BaseTest(ITestOutputHelper testOutputHelper)
{
	protected static CancellationToken CancellationToken => TestContext.Current.CancellationToken;
}
