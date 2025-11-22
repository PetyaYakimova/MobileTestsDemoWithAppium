using MobileTestsDemoWithAppium.Models;

namespace MobileTestsDemoWithAppium.Setup;

public class Credentials
{
    public UserModel TestUser1()
    {
        UserModel user = new UserModel
        {
            UserId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            ExternalUserId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
            Email = "testuser1@test.com",
            Password = "SomePass"
        };
        return user;
    }

    public UserModel TestUser2()
    {
        UserModel user = new UserModel
        {
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            ExternalUserId = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
            Email = "testuser2@test.com",
            Password = "SomePass2"
        };
        return user;
    }

    public UserModel AdminUser1()
    {
        UserModel user = new UserModel
        {
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            ExternalUserId = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"),
            Email = "adminuser1@test.com",
            Password = "SomePassAdmin"
        };
        return user;
    }

    public List<Guid> AllAdminUsersIds()
    {
        return new List<Guid>
        {
            AdminUser1().UserId.Value
        };
    }
}
