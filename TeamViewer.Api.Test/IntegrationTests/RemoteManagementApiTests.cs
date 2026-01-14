using TeamViewer.Api.Exceptions;
using TeamViewer.Api.Test.Infrastructure;

namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the Remote Management API.
/// </summary>
public class RemoteManagementApiTests : IntegrationTestBase
{
	[Fact]
	public async Task GetManagedDevicesAsync_ReturnsManagedDeviceList()
	{
		EnsureConfigured();

		try
		{
			// Act
			var result = await Client!.RemoteManagement.GetManagedDevicesAsync(
				new GetManagedDevicesRequest(),
				TestContext.Current.CancellationToken);

			// Assert
			result.Should().NotBeNull();
			result.Devices.Should().NotBeNull();
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission") || ex.Message.Contains("not_found"))
		{
			Assert.Skip("Remote Management API requires additional permissions or is not available.");
		}
	}

	[Fact]
	public async Task GetManagedGroupsAsync_ReturnsManagedGroupList()
	{
		EnsureConfigured();

		try
		{
			// Act
			var result = await Client!.RemoteManagement.GetManagedGroupsAsync(TestContext.Current.CancellationToken);

			// Assert
			result.Should().NotBeNull();
			result.Groups.Should().NotBeNull();
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission") || ex.Message.Contains("not_found"))
		{
			Assert.Skip("Remote Management API requires additional permissions or is not available.");
		}
	}
}
