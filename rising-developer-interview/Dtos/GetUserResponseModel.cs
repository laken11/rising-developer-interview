namespace rising_developer_interview.Dtos;

public class GetUserResponseModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public int DiagnosticLevel { get; set; }
    public int CurrentLevel { get; set; }
    public DateTime FirstMessageTimestamp { get; set; }
    public DateTime LastMessageTimestamp { get; set; }
    public string[] MessageIds { get; set; }
}