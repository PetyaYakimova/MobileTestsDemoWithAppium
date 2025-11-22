using MobileTestsDemoWithAppium.Pages.Login;
using Reqnroll;

namespace MobileTestsDemoWithAppium.StepDefinitions.Login;

public class LoginStepDefinitions : BaseStepDefinitions
{
	private LoginPage loginPage;

	public LoginStepDefinitions(
	   LoginPage loginPage) : base()
	{
		this.loginPage = loginPage;
	}

	[StepDefinition(@"I have logged in as (.*)")]
	public void IHaveLoggedInAs(string userName)
	{
		loginPage.LogInAsUser(userName);
	}
}
