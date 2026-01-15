namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Represents screenshot metadata.
/// </summary>
public class Screenshot
{
	/// <summary>
	/// Gets or sets the screenshot ID.
	/// </summary>
	[JsonPropertyName("screenshotId")]
	public string? ScreenshotId { get; set; }

	/// <summary>
	/// Gets or sets the timestamp.
	/// </summary>
	[JsonPropertyName("timestamp")]
	public DateTime? Timestamp { get; set; }

	/// <summary>
	/// Gets or sets the file size in bytes.
	/// </summary>
	[JsonPropertyName("fileSize")]
	public long FileSize { get; set; }
}

/// <summary>
/// Response containing a list of screenshots.
/// </summary>
public class ScreenshotListResponse
{
	/// <summary>
	/// Gets or sets the list of screenshots.
	/// </summary>
	[JsonPropertyName("screenshots")]
	public List<Screenshot> Screenshots { get; set; } = [];
}

/// <summary>
/// Represents an AI-generated report summary.
/// </summary>
public class ReportSummary
{
	/// <summary>
	/// Gets or sets the summary text.
	/// </summary>
	[JsonPropertyName("summary")]
	public string? Summary { get; set; }

	/// <summary>
	/// Gets or sets the key points.
	/// </summary>
	[JsonPropertyName("keyPoints")]
	public List<string> KeyPoints { get; set; } = [];

	/// <summary>
	/// Gets or sets the generation timestamp.
	/// </summary>
	[JsonPropertyName("generatedAt")]
	public DateTime? GeneratedAt { get; set; }
}

/// <summary>
/// Represents a report transcript.
/// </summary>
public class ReportTranscript
{
	/// <summary>
	/// Gets or sets the transcript content.
	/// </summary>
	[JsonPropertyName("content")]
	public string? Content { get; set; }

	/// <summary>
	/// Gets or sets the transcript entries.
	/// </summary>
	[JsonPropertyName("entries")]
	public List<TranscriptEntry> Entries { get; set; } = [];
}

/// <summary>
/// Represents a transcript entry.
/// </summary>
public class TranscriptEntry
{
	/// <summary>
	/// Gets or sets the timestamp.
	/// </summary>
	[JsonPropertyName("timestamp")]
	public DateTime? Timestamp { get; set; }

	/// <summary>
	/// Gets or sets the speaker.
	/// </summary>
	[JsonPropertyName("speaker")]
	public string? Speaker { get; set; }

	/// <summary>
	/// Gets or sets the text content.
	/// </summary>
	[JsonPropertyName("text")]
	public string? Text { get; set; }
}

/// <summary>
/// Represents a device report.
/// </summary>
public class DeviceReport
{
	/// <summary>
	/// Gets or sets the report ID.
	/// </summary>
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	/// <summary>
	/// Gets or sets the device ID.
	/// </summary>
	[JsonPropertyName("deviceId")]
	public string? DeviceId { get; set; }

	/// <summary>
	/// Gets or sets the device name.
	/// </summary>
	[JsonPropertyName("deviceName")]
	public string? DeviceName { get; set; }

	/// <summary>
	/// Gets or sets the start time.
	/// </summary>
	[JsonPropertyName("startTime")]
	public DateTime? StartTime { get; set; }

	/// <summary>
	/// Gets or sets the end time.
	/// </summary>
	[JsonPropertyName("endTime")]
	public DateTime? EndTime { get; set; }
}

/// <summary>
/// Response containing a list of device reports.
/// </summary>
public class DeviceReportListResponse
{
	/// <summary>
	/// Gets or sets the list of device reports.
	/// </summary>
	[JsonPropertyName("records")]
	public List<DeviceReport> Records { get; set; } = [];
}
