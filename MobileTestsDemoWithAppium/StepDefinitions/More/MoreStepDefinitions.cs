using MobileTestsDemoWithAppium.Pages.More;
using MobileTestsDemoWithAppium.Setup;
using Reqnroll;

namespace MobileTestsDemoWithAppium.StepDefinitions.More;

public class MoreStepDefinitions : BaseStepDefinitions
{
	private MorePage morePage;

	public MoreStepDefinitions(
	   MorePage morePage) : base()
	{
		this.morePage = morePage;
	}

	[StepDefinition(@"I click (.*) language radio button")]
	public void IClickLanguageRadioButton(string language)
	{
		morePage.ClickLanguageRadioButton(language);
	}

	[StepDefinition(@"I click on Log out button")]
	public void IClickOnLogOutButton()
	{
		morePage.ClickLogoutButton();
	}

	[StepDefinition(@"I click on (.*) option on More screen")]
	public void IClickOnOptionOnMoreScreen(string optionName)
	{
		morePage.ClickOnOption(optionName);
	}

	[Then(@"assert that I (.*) see my email as a text on the screen")]
	public void AssertThatISeeElementWithMyEmailAsText(string expectedSeeString)
	{
		bool expectedSee = GetBooleanFromString(expectedSeeString);
		bool actualSee = morePage.TextElementIsDisplayed(Variables.currentUser.Email);

		Assert.That(actualSee, Is.EqualTo(expectedSee));
	}
}
