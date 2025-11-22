using OpenQA.Selenium.DevTools.V140.Schema;

namespace MobileTestsDemoWithAppium.Setup;

public class AppSettings
{
    public DomainSettings DomainSettings { get; set; } = null!;

    public ConnectionStrings ConnectionStrings { get; set; } = null!;
}

public class DomainSettings
{
    public string Domain { get; set; } = null!;
    public string Backend { get; set; } = null!;
}

public class ConnectionStrings
{
    public string E2EConnection { get; set; } = null!;
}
