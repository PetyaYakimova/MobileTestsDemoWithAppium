using MobileTestsDemoWithAppium.Helpers;
using MobileTestsDemoWithAppium.Setup;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;

namespace MobileTestsDemoWithAppium.Pages.Inspection.Scan;

public class ScanPage : BasePage
{
	public ScanPage(
	AppiumDriver driver,
	WebDriverWait wait)
	: base(driver, wait)
	{
	}

	private IWebElement GrantPermissionPopUp_WhileUsingTheAppButton => this.Driver.FindElement(GrantPermissionPopUp_WhileUsingTheAppButtonBy);
	private By GrantPermissionPopUp_WhileUsingTheAppButtonBy = Variables.targetOSName == GlobalConstants.AndroidName ?
		By.Id("com.android.permissioncontroller:id/permission_allow_foreground_only_button") : MobileBy.AccessibilityId("Allow");

	private IWebElement GrantPermissionPopUp_OnlyThisTimeButton => this.Driver.FindElement(GrantPermissionPopUp_OnlyThisTimeButtonBy);
	private By GrantPermissionPopUp_OnlyThisTimeButtonBy = Variables.targetOSName == GlobalConstants.AndroidName ?
		By.Id("com.android.permissioncontroller:id/permission_allow_one_time_button") : MobileBy.AccessibilityId("Allow");

	private IWebElement ScanIconButton => this.Driver.FindElement(ScanIconButtonBy);
	private By ScanIconButtonBy => GetButtonLocatorByAccessibilityId("Press to scan a product");

	private IWebElement ScanAgainButton => this.Driver.FindElement(ScanAgainButtonBy);
	private By ScanAgainButtonBy => GetButtonLocatorByAccessibilityId("Scan again");

	public void ClickGrantPermissionWhileUsingTheAppButton()
		=> GrantPermissionPopUp_WhileUsingTheAppButton.Click();

	public void ClickGrantPermissionOnlyThisTimeButton()
		=> GrantPermissionPopUp_OnlyThisTimeButton.Click();

	public void ClickScanIconButton()
		=> ScanIconButton.Click();

	public void ClickScanAgainButton()
		=> ScanAgainButton.Click();
}
