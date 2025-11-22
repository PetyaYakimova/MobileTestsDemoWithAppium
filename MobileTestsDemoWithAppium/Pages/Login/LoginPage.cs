using MobileTestsDemoWithAppium.Helpers;
using MobileTestsDemoWithAppium.Models;
using MobileTestsDemoWithAppium.Setup;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;

namespace MobileTestsDemoWithAppium.Pages.Login;

public class LoginPage : BasePage
{
    private Credentials credentials;

    public LoginPage(
    AppiumDriver driver,
    WebDriverWait wait,
    Credentials credentials)
    : base(driver, wait)
    {
        this.credentials = credentials;
    }

    private IWebElement NoAccessPopUp_CloseButton => this.Driver.FindElement(NoAccessPopUp_CloseButtonBy);
    private By NoAccessPopUp_CloseButtonBy => Variables.targetOSName == GlobalConstants.AndroidName ?
        By.XPath("//android.widget.TextView[@text='Close']") : By.XPath("//XCUIElementTypeOther[@name='Close']");

    private IWebElement AppInfoPopUp_CloseButton => this.Driver.FindElement(AppInfoPopUp_CloseButtonBy);
    private By AppInfoPopUp_CloseButtonBy => Variables.targetOSName == GlobalConstants.AndroidName ?
        By.XPath("//android.widget.TextView[@text='Close']") : By.XPath("//XCUIElementTypeOther[@name='Close']");

    private IWebElement LoginWithEmailButton => this.Driver.FindElement(LoginWithEmailButtonBy);
    private By LoginWithEmailButtonBy => Variables.targetOSName == GlobalConstants.AndroidName ?
        By.XPath("//android.widget.TextView[@text='Log in with E-mail']") : By.XPath("(//XCUIElementTypeOther[@name=' Log in with E-mail'])[2]");

    private IWebElement UsernameField => this.Driver.FindElement(UsernameFieldBy);
    private By UsernameFieldBy => Variables.targetOSName == GlobalConstants.AndroidName ?
        By.XPath("//android.view.View[@text='User Name *']/../android.widget.EditText") : By.XPath("//XCUIElementTypeOther[@name='User Name *']/../XCUIElementTypeTextField");

    private IWebElement PasswordField => this.Driver.FindElement(PasswordFieldBy);
    private By PasswordFieldBy => Variables.targetOSName == GlobalConstants.AndroidName ?
        By.XPath("//android.view.View[@text='Password *']/../android.widget.EditText") : By.XPath("//XCUIElementTypeOther[@name='Password *']/../XCUIElementTypeSecureTextField");

    private IWebElement LoginButton => this.Driver.FindElement(LoginButtonBy);
    private By LoginButtonBy => Variables.targetOSName == GlobalConstants.AndroidName ?
        By.XPath("//android.widget.Button[@text='Login']") : By.XPath("//XCUIElementTypeButton[@name='Login']");

    public void ClickLoginWithEmailButton()
    {
        LoginWithEmailButton.Click();
        Thread.Sleep(1000);

        if (Variables.targetOSName == GlobalConstants.IOSName)
        {
            AcceptExternalLoginPopUp_ContinueButton.Click();
        }

        Thread.Sleep(1000);
    }

    public void FillUsernameFieldWith(string value)
    {
        Thread.Sleep(300);
        UsernameField.Click();
        Thread.Sleep(300);
        UsernameField.SendKeys(value);
        if (Variables.targetOSName == GlobalConstants.AndroidName)
        {
            Driver.HideKeyboard();
        }
        else
        {
            UsernameField.SendKeys(Keys.Return);
        }
        Thread.Sleep(200);
    }

    public void FillPasswordFieldWith(string value)
    {
        PasswordField.Click();
        Thread.Sleep(300);
        if (Variables.targetOSName == GlobalConstants.AndroidName)
        {
            Driver.HideKeyboard();
            Thread.Sleep(300);
            PasswordField.SendKeys(value);
        }
        else
        {
            PasswordField.SendKeys(value);
            PasswordField.SendKeys(Keys.Return);
        }
        Thread.Sleep(200);
    }

    public void ClickLoginButton()
        => LoginButton.Click();

    public void LogInAsUser(string userName)
    {
        Variables.currentUser = GetUserData(userName);

        ClickLoginWithEmailButton();
        Thread.Sleep(200);

        FillUsernameFieldWith(userName);
        FillPasswordFieldWith(Variables.currentUser.Password);
        if (Variables.targetOSName == GlobalConstants.AndroidName)
        {
            ClickLoginButton();
        }
        Thread.Sleep(2000);
    }

    public UserModel GetUserData(string userName)
    {
        switch (userName)
        {
            case "TestUser1":
                return credentials.TestUser1();
            case "TestUser2":
                return credentials.TestUser2();
            case "AdminUser1":
                return credentials.AdminUser1();
            default:
                return credentials.TestUser1();
        }
    }
}
