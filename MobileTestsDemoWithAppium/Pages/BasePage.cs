using MobileTestsDemoWithAppium.Helpers;
using MobileTestsDemoWithAppium.Setup;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;


namespace MobileTestsDemoWithAppium.Pages;

public class BasePage
{
	public AppiumDriver Driver { get; set; }
	public WebDriverWait Wait { get; set; }

	public BasePage(
		AppiumDriver driver,
		WebDriverWait Wait)
	{
		this.Driver = driver;
		this.Wait = Wait;
	}

	protected IWebElement GoBackButton => this.Driver.FindElement(GoBackButtonBy);
	protected By GoBackButtonBy => Variables.targetOSName == GlobalConstants.AndroidName ?
		GetButtonLocatorByAccessibilityId("Navigate up") : By.XPath("//XCUIElementTypeNavigationBar/XCUIElementTypeButton");

	protected IWebElement GrantPermissionButton => this.Driver.FindElement(GrantPermissionButtonBy);
	protected By GrantPermissionButtonBy => GetButtonLocatorByAccessibilityId("Grant permission");

	protected IWebElement GrantPermissionPopUp_DontAllowButton => this.Driver.FindElement(GrantPermissionPopUp_DontAllowButtonBy);
	protected By GrantPermissionPopUp_DontAllowButtonBy = Variables.targetOSName == GlobalConstants.AndroidName ?
		By.Id("com.android.permissioncontroller:id/permission_deny_button") : MobileBy.AccessibilityId("Don’t Allow");

	protected IWebElement GrantPermissionPopUp_DenyAndDontAskAgainButton => this.Driver.FindElement(GrantPermissionPopUp_DenyAndDontAskAgainButtonBy);
	protected By GrantPermissionPopUp_DenyAndDontAskAgainButtonBy = By.Id("com.android.permissioncontroller:id/permission_deny_and_dont_ask_again_button");

	protected IWebElement AcceptExternalLoginPopUp_ContinueButton => this.Driver.FindElement(AcceptExternalLoginPopUp_ContinueButtonBy);
	protected By AcceptExternalLoginPopUp_ContinueButtonBy => MobileBy.AccessibilityId("Continue");

	protected By GetInputFieldLocatorByLabel(string label)
	=> Variables.targetOSName == GlobalConstants.AndroidName ?
	By.XPath($"//android.widget.TextView[@text='{label}']/following-sibling::android.widget.EditText") : By.XPath($"//XCUIElementTypeStaticText[@label='{label}']/following-sibling::XCUIElementTypeOther/XCUIElementTypeTextField");

	protected By GetButtonLocatorByAccessibilityId(string id)
		=> MobileBy.AccessibilityId(id);

	public bool TextElementIsDisplayed(string text)
	{
		string locator = Variables.targetOSName == GlobalConstants.AndroidName ? $"//*[@text='{text}']" : $"//*[contains(@label, '{text}')]";

		try
		{
			return Driver.FindElement(By.XPath(locator)).Displayed;
		}
		catch (NoSuchElementException)
		{
			return false;
		}
		catch (StaleElementReferenceException)
		{
			return false;
		}
	}

	public bool ElementContainingTextIsDisplayed(string text)
	{
		string locator = Variables.targetOSName == GlobalConstants.AndroidName ? $"//*[contains(@text, '{text}')]" : $"//*[contains(@label, '{text}')]";

		try
		{
			return Driver.FindElement(By.XPath(locator)).Displayed;
		}
		catch (NoSuchElementException)
		{
			return false;
		}
		catch (StaleElementReferenceException)
		{
			return false;
		}
	}

	public void ClickOnElementWithText(string text)
	{
		string locator = Variables.targetOSName == GlobalConstants.AndroidName ? $"//*[contains(@text, '{text}')]" : $"(//*[contains(@label, '{text}')])[last()]";

		Driver.FindElement(By.XPath(locator)).Click();
	}

	public void WaitForElementWithTextToDisappear(string text)
	{
		while (TextElementIsDisplayed(text))
		{
			Thread.Sleep(100);
		}
	}

	public void ClickOnTab(string tabName)
	{
		By path = Variables.targetOSName == GlobalConstants.AndroidName ?
			By.XPath($"//android.widget.TextView[@text='{tabName}']") : By.XPath($"(//*[starts-with(@name, '{tabName}')])[last()]");

		Driver.FindElement(path).Click();
		Thread.Sleep(300);
	}

	//Permissions
	#region
	public void ClickGrantPermissionButton()
		=> GrantPermissionButton.Click();

	public void ClickDontAllowPermissionButton()
	{
		GrantPermissionPopUp_DontAllowButton.Click();

		//For Android the permission must be denied two times in order to completely deny it
		if (Variables.targetOSName == GlobalConstants.AndroidName)
		{
			GrantPermissionButton.Click();
			GrantPermissionPopUp_DenyAndDontAskAgainButton.Click();
		}
	}

	public void ClickDenyAndDontAskAgainForPermissionButton()
		=> GrantPermissionPopUp_DenyAndDontAskAgainButton.Click();
	#endregion

	public void ClickGoBackButton()
		=> GoBackButton.Click();
}
