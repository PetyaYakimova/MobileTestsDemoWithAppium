using MobileTestsDemoWithAppium.Helpers;
using MobileTestsDemoWithAppium.Setup;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;

namespace MobileTestsDemoWithAppium.Pages.More;

public class MorePage : BasePage
{
	public MorePage(
	AppiumDriver driver,
	WebDriverWait wait)
	: base(driver, wait)
	{
	}

	private IWebElement ChangeLanguage_BulgarianLanguageRadioButton => this.Driver.FindElement(ChangeLanguage_BulgarianLanguageRadioButtonBy);
	private By ChangeLanguage_BulgarianLanguageRadioButtonBy => Variables.targetOSName == GlobalConstants.AndroidName ?
		By.XPath($"//android.widget.TextView[@text='{GlobalConstants.BulgarianLanguageText}']") : MobileBy.AccessibilityId(GlobalConstants.BulgarianLanguageText);

	private IWebElement ChangeLanguage_EnglishLanguageRadioButton => this.Driver.FindElement(ChangeLanguage_EnglishLanguageRadioButtonBy);
	private By ChangeLanguage_EnglishLanguageRadioButtonBy => Variables.targetOSName == GlobalConstants.AndroidName ?
		By.XPath($"//android.widget.TextView[@text='{GlobalConstants.EnglishLanguageText}']") : MobileBy.AccessibilityId(GlobalConstants.EnglishLanguageText);

	private IWebElement LogoutButton => this.Driver.FindElement(LogoutButtonBy);
	private By LogoutButtonBy => Variables.targetOSName == GlobalConstants.AndroidName ?
		By.XPath("//android.widget.TextView[@text='Log out']") : MobileBy.AccessibilityId(" Log out");

	public void ClickOnOption(string optionName)
	{
		By path = Variables.targetOSName == GlobalConstants.AndroidName ?
			By.XPath($"//android.widget.TextView[@text='{optionName}']") : By.XPath($"(//XCUIElementTypeOther[contains(@label, '{optionName}')])[last()]");

		Driver.FindElement(path).Click();
		Thread.Sleep(200);
	}

	public void ClickLanguageRadioButton(string language)
	{
		if (language.ToLower() == GlobalConstants.BulgarianLanguageText)
		{
			ChangeLanguage_BulgarianLanguageRadioButton.Click();
		}
		else
		{
			ChangeLanguage_EnglishLanguageRadioButton.Click();
		}

		Thread.Sleep(200);
	}

	public void ClickLogoutButton()
	{
		LogoutButton.Click();

		if (Variables.targetOSName == GlobalConstants.IOSName)
		{
			AcceptExternalLoginPopUp_ContinueButton.Click();
			Thread.Sleep(1000);
		}

		Thread.Sleep(1000);
	}
}
