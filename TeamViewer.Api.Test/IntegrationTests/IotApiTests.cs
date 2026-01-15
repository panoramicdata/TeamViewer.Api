namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the IoT API.
/// </summary>
public class IotApiTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task GetDashboardsAsync_ReturnsDashboardList()
	{
		// Act
		var result = await Client.Iot.GetDashboardsAsync(CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Dashboards.Should().NotBeNull();
	}

	[Fact]
	public async Task GetDeviceConfigurationsAsync_ReturnsConfigList()
	{
		// Act
		var result = await Client.Iot.GetDeviceConfigurationsAsync(CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Configurations.Should().NotBeNull();
	}

	[Fact]
	public async Task GetEdgeModulesAsync_ReturnsModuleList()
	{
		// Act
		var result = await Client.Iot.GetEdgeModulesAsync(CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Modules.Should().NotBeNull();
	}

	[Fact]
	public async Task GetLatestDataAsync_ReturnsData()
	{
		// Act
		var result = await Client.Iot.GetLatestDataAsync(CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.DataPoints.Should().NotBeNull();
	}

	[Fact]
	public async Task CreateUpdateDeleteDashboardAsync_FullCrudCycle()
	{
		var testName = $"{TestPrefix}Dashboard_{DateTime.UtcNow:HHmmss}";

		// Create
		var created = await Client.Iot.CreateDashboardAsync(
			new CreateIotDashboardRequest { Name = testName, Description = "Test IoT dashboard" },
			CancellationToken);

		created.Should().NotBeNull();
		created.Id.Should().NotBeNullOrEmpty();
		created.Name.Should().Be(testName);

		// Read - GetDashboardAsync returns a list response
		var retrievedResponse = await Client.Iot.GetDashboardAsync(created.Id!, CancellationToken);
		retrievedResponse.Should().NotBeNull();
		retrievedResponse.Dashboards.Should().ContainSingle();
		retrievedResponse.Dashboards[0].Name.Should().Be(testName);

		// Update
		var updatedName = $"{testName}_Updated";
		await Client.Iot.UpdateDashboardAsync(
			created.Id!,
			new UpdateIotDashboardRequest { Name = updatedName },
			CancellationToken);

		var afterUpdateResponse = await Client.Iot.GetDashboardAsync(created.Id!, CancellationToken);
		afterUpdateResponse.Dashboards[0].Name.Should().Be(updatedName);

		// Delete
		await Client.Iot.DeleteDashboardAsync(created.Id!, CancellationToken);
	}

	[Fact]
	public async Task GetWidgetsAsync_WithValidDashboard_ReturnsWidgets()
	{
		var dashboards = await Client.Iot.GetDashboardsAsync(CancellationToken);
		if (dashboards.Dashboards.Count == 0)
		{
			Assert.Skip("No IoT dashboards available for testing.");
			return;
		}

		// Act
		var result = await Client.Iot.GetWidgetsAsync(
			dashboards.Dashboards[0].Id!,
			CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Widgets.Should().NotBeNull();
	}
}
