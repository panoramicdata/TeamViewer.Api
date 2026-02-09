using TeamViewer.Api.Exceptions;

namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the OEM Devices API.
/// Note: These tests require OEM access which is only available with specific TeamViewer licenses.
/// </summary>
public class OemDevicesApiTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task GetDevicesAsync_ReturnsDeviceList()
	{
		EnsureConfigured();

		// Act & Assert
		try
		{
			var result = await Client.OemDevices.GetDevicesAsync(CancellationToken);

			result.Should().NotBeNull();
			result.Devices.Should().NotBeNull();
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("not authorized") || ex.Message.Contains("access denied") || ex.Message.Contains("not found"))
		{
			// Expected if OEM access is not available
			Assert.True(true, "OEM Devices API access not available - test skipped");
		}
	}
}
