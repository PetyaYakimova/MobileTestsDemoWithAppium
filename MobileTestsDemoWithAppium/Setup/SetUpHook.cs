using Microsoft.Extensions.Configuration;
using MobileTestsDemoWithAppium.Helpers;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Support.UI;
using Reqnroll;
using Reqnroll.BoDi;

namespace MobileTestsDemoWithAppium.Setup;

[Binding]
public class SetUpHook
{
	private const string AppiumIPAddress = "127.0.0.1";
	private const int AppiumPort = 4723;

	private static IConfigurationRoot configuration;
	private static AppSettings settings;
	private WebDriverWait wait;
	private static AppiumLocalService appiumLocalService;

	public SetUpHook(IObjectContainer objectContainer)
	{
		if (configuration == null)
		{
			configuration = BuildConfiguration();
			settings = configuration.Get<AppSettings>() ?? throw new ArgumentNullException("AppSettings section is missing in the configuration.");
        }
	}

	[BeforeTestRun]
	public static void BeforeTestRun()
	{
		Variables.targetOSName = Environment.GetEnvironmentVariable("targetOS")?.ToLower() ?? GlobalConstants.AndroidName;

		appiumLocalService = new AppiumServiceBuilder().WithIPAddress(AppiumIPAddress).UsingPort(AppiumPort).Build();
		appiumLocalService.Start();

		if (configuration == null)
		{
			configuration = BuildConfiguration();
            settings = configuration.Get<AppSettings>() ?? throw new ArgumentNullException("AppSettings section is missing in the configuration.");
        }
	}

	[BeforeScenario]
	public void Setup(IObjectContainer objectContainer, ScenarioContext scenarioContext)
	{
		AppiumDriver driver = GetDriver();

		this.wait = new WebDriverWait(driver, new TimeSpan(0, 0, 12));

		objectContainer.RegisterInstanceAs(driver);
		objectContainer.RegisterInstanceAs(wait);

		if (scenarioContext.ScenarioInfo.Tags.Contains("ignoreOnIOS") && Variables.targetOSName == GlobalConstants.IOSName)
		{
			Assert.Ignore("Skipping this test due to not being able to complete it on iOS.");
		}
	}

	[AfterScenario]
	public void TearDown(IObjectContainer objectContainer)
	{
		AppiumDriver driver = objectContainer.Resolve<AppiumDriver>();
		WebDriverWait wait = objectContainer.Resolve<WebDriverWait>();
		AppSettings settings = objectContainer.Resolve<AppSettings>();

        driver.RemoveApp("app_package_name");
		driver.Dispose();

		Variables.currentUser = null;
	}

	[AfterTestRun]
	public static void AfterTestRun()
	{
		appiumLocalService.Dispose();

		Variables.targetOSName = null;
	}

	private static IConfigurationRoot BuildConfiguration()
	{
		ConfigurationBuilder builder = new();

		builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
		//builder.AddUserSecrets<AppSettings>();
		//builder.AddEnvironmentVariables();

		return builder.Build();
	}

	private AppiumDriver GetDriver()
	{
		var serverUri = new Uri($"http://{AppiumIPAddress}:{AppiumPort}/");

		switch (Variables.targetOSName)
		{
			case GlobalConstants.AndroidName:

				var driverOptions = new AppiumOptions()
				{
					AutomationName = AutomationName.AndroidUIAutomator2,
					PlatformName = "Android",
					App = "C:\\app_name.apk"
				};

				AndroidDriver driver = new AndroidDriver(serverUri, driverOptions, TimeSpan.FromSeconds(180));
				driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

				return driver;

			case GlobalConstants.IOSName:
				var appiumOptions = new AppiumOptions()
				{
					PlatformName = "iOS",
					DeviceName = "iPhone 13 mini",
					AutomationName = "XCUITest"
				};
				appiumOptions.AddAdditionalAppiumOption("udid", "some-number");

				IOSDriver iosDriver = new IOSDriver(serverUri, appiumOptions, TimeSpan.FromSeconds(180));
				iosDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
				//The app is opened after the driver is created so that we can interact with other things in the iOS device such as permissions pop-ups
				iosDriver.InstallApp("/app_location/app_name.app");
				Thread.Sleep(200);
				iosDriver.ActivateApp("app_package_name");
				return iosDriver;

			default:
				throw new ArgumentException($"OS {Variables.targetOSName} is not supported.");
		}
	}
}
