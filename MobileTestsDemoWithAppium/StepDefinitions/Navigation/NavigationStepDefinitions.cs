using MobileTestsDemoWithAppium.Pages;
using Reqnroll;

namespace MobileTestsDemoWithAppium.StepDefinitions.Navigation;

public class NavigationStepDefinitions : BaseStepDefinitions
{
	private BasePage basePage;

	public NavigationStepDefinitions(
	   BasePage basePage) : base()
	{
		this.basePage = basePage;
	}

	[StepDefinition(@"I click on (.*) tab")]
	public void IClickOnTab(string tabName)
	{
		basePage.ClickOnTab(tabName);
	}

	[StepDefinition(@"I click the go back button")]
	public void IClickTheGoBackButton()
	{
		basePage.ClickGoBackButton();
	}

	[StepDefinition(@"I wait for element with text (.*) to disappear")]
	public void IWaitForElementWithTextToDisappear(string text)
	{
		basePage.WaitForElementWithTextToDisappear(text);
	}

	[Then(@"assert that I (.*) see element with text (.*)")]
	public void AssertThatISeeElementWithText(string expectedSeeString, string text)
	{
		bool expectedSee = GetBooleanFromString(expectedSeeString);
		bool actualSee = basePage.TextElementIsDisplayed(text);

		Assert.That(actualSee, Is.EqualTo(expectedSee), $"Expected element with text {text} to be {(expectedSee ? "visible" : "not visible")}, but it wasn't.");
	}

	[Then(@"assert that I (.*) see element containing text (.*)")]
	public void AssertThatISeeElementContainingText(string expectedSeeString, string text)
	{
		bool expectedSee = GetBooleanFromString(expectedSeeString);
		bool actualSee = basePage.ElementContainingTextIsDisplayed(text);

		Assert.That(actualSee, Is.EqualTo(expectedSee), $"Expected element containing text {text} to be {(expectedSee ? "visible" : "not visible")}, but it wasn't.");
	}
}
