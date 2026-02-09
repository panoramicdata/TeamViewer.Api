using System.Text.Json;
using TeamViewer.Api.Models.Requests;

namespace TeamViewer.Api.Test.UnitTests;

/// <summary>
/// Unit tests for core request model serialization.
/// </summary>
public class CoreRequestsTests
{
	private static readonly JsonSerializerOptions JsonOptions = new()
	{
		PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
		DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
	};

	#region User Requests

	[Fact]
	public void CreateUserRequest_Serialization_ProducesCorrectJson()
	{
		// Arrange
		var request = new CreateUserRequest
		{
			Email = "newuser@example.com",
			Name = "New User",
			Password = "SecurePassword123!"
		};

		// Act
		var json = JsonSerializer.Serialize(request, JsonOptions);

		// Assert
		json.Should().Contain("\"email\":\"newuser@example.com\"");
		json.Should().Contain("\"name\":\"New User\"");
		json.Should().Contain("\"password\":\"SecurePassword123!\"");
	}

	[Fact]
	public void UpdateUserRequest_PartialUpdate_SerializesOnlyProvidedFields()
	{
		// Arrange
		var request = new UpdateUserRequest
		{
			Name = "Updated Name"
		};

		// Act
		var json = JsonSerializer.Serialize(request, JsonOptions);

		// Assert
		json.Should().Contain("\"name\":\"Updated Name\"");
		json.Should().NotContain("\"email\"");
		json.Should().NotContain("\"password\"");
	}

	[Fact]
	public void GetUsersRequest_WithAllFilters_SerializesCorrectly()
	{
		// Arrange
		var request = new GetUsersRequest
		{
			Email = "filter@example.com",
			Name = "Filter Name",
			Full = true
		};

		// Act - Note: This uses Query attributes in the interface, not body serialization
		// We're just testing that the model can be created correctly
		request.Email.Should().Be("filter@example.com");
		request.Name.Should().Be("Filter Name");
		request.Full.Should().BeTrue();
	}

	#endregion

	#region Group Requests

	[Fact]
	public void CreateGroupRequest_Serialization_ProducesCorrectJson()
	{
		// Arrange
		var request = new CreateGroupRequest
		{
			Name = "New Group"
		};

		// Act
		var json = JsonSerializer.Serialize(request, JsonOptions);

		// Assert
		json.Should().Contain("\"name\":\"New Group\"");
	}

	[Fact]
	public void UpdateGroupRequest_Serialization_ProducesCorrectJson()
	{
		// Arrange
		var request = new UpdateGroupRequest
		{
			Name = "Updated Group Name"
		};

		// Act
		var json = JsonSerializer.Serialize(request, JsonOptions);

		// Assert
		json.Should().Contain("\"name\":\"Updated Group Name\"");
	}

	[Fact]
	public void ShareGroupRequest_Serialization_ProducesCorrectJson()
	{
		// Arrange
		var request = new ShareGroupRequest
		{
			Users = [new ShareGroupUser { UserId = "u123", Permissions = "read" }]
		};

		// Act
		var json = JsonSerializer.Serialize(request, JsonOptions);

		// Assert
		json.Should().Contain("\"users\"");
		json.Should().Contain("\"user_id\":\"u123\"");
		json.Should().Contain("\"permissions\":\"read\"");
	}

	#endregion

	#region Session Requests

	[Fact]
	public void CreateSessionRequest_Serialization_ProducesCorrectJson()
	{
		// Arrange
		var request = new CreateSessionRequest
		{
			GroupId = "g123",
			Description = "Support session",
			EndCustomer = "Customer Name"
		};

		// Act
		var json = JsonSerializer.Serialize(request, JsonOptions);

		// Assert
		json.Should().Contain("\"groupid\":\"g123\"");
		json.Should().Contain("\"description\":\"Support session\"");
		json.Should().Contain("\"end_customer\":\"Customer Name\"");
	}

	#endregion

	#region Meeting Requests

	[Fact]
	public void CreateMeetingRequest_Serialization_ProducesCorrectJson()
	{
		// Arrange
		var startTime = DateTime.UtcNow;
		var endTime = DateTime.UtcNow.AddHours(1);

		var request = new CreateMeetingRequest
		{
			Subject = "Team Standup",
			Start = startTime,
			End = endTime
		};

		// Act
		var json = JsonSerializer.Serialize(request, JsonOptions);

		// Assert
		json.Should().Contain("\"subject\":\"Team Standup\"");
		json.Should().Contain("\"start\"");
		json.Should().Contain("\"end\"");
	}

	[Fact]
	public void UpdateMeetingRequest_PartialUpdate_SerializesCorrectly()
	{
		// Arrange
		var request = new UpdateMeetingRequest
		{
			Subject = "Updated Subject"
		};

		// Act
		var json = JsonSerializer.Serialize(request, JsonOptions);

		// Assert
		json.Should().Contain("\"subject\":\"Updated Subject\"");
	}

	#endregion

	#region Access Token Requests

	[Fact]
	public void CreateAccessTokenRequest_Serialization_ProducesCorrectJson()
	{
		// Arrange
		var request = new CreateAccessTokenRequest
		{
			Name = "My API Token",
			Scopes = ["Account.read", "Users.read"]
		};

		// Act
		var json = JsonSerializer.Serialize(request, JsonOptions);

		// Assert
		json.Should().Contain("\"name\":\"My API Token\"");
		json.Should().Contain("\"scopes\"");
	}

	#endregion

	#region Event Logging Requests

	[Fact]
	public void EventLoggingRequest_WithDateRange_PropertiesAreSet()
	{
		// Arrange
		var request = new EventLoggingRequest
		{
			StartDate = "2024-01-01T00:00:00Z",
			EndDate = "2024-01-31T23:59:59Z",
			EventTypes = ["UserCreated", "UserDeleted"]
		};

		// Act & Assert
		request.StartDate.Should().Be("2024-01-01T00:00:00Z");
		request.EndDate.Should().Be("2024-01-31T23:59:59Z");
		request.EventTypes.Should().HaveCount(2);
	}

	#endregion
}
