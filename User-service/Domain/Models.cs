namespace UserMicroService.Domain;

public class UserInfo
{
    public int Id { get; set; }
    public string Uuid { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

// Subject should be user uuid and must NOT be allowed to be set directly from user input
public record AccessTokenInfo(string audience, string subject);
