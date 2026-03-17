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

		// Act
		var result = await Client.OemDevices.GetDevicesAsync(CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Devices.Should().NotBeNull();
	}

	[Fact]
	public async Task GetDeviceAsync_WithValidDevice_ReturnsDevice()
	{
		EnsureConfigured();

		// Arrange
		var devices = await Client.OemDevices.GetDevicesAsync(CancellationToken);
		if (devices.Devices.Count == 0)
		{
			Assert.Skip("No OEM devices available for testing.");
			return;
		}

		var deviceId = devices.Devices[0].DeviceId;

		// Act
		var result = await Client.OemDevices.GetDeviceAsync(deviceId, CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.DeviceId.Should().Be(deviceId);
	}
}

