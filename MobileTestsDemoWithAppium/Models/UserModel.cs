namespace MobileTestsDemoWithAppium.Models;

public class UserModel
{
    public Guid? UserId { get; set; }

    public Guid? ExternalUserId { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }
}
