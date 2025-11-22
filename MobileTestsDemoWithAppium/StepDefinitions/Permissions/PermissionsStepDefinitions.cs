using MobileTestsDemoWithAppium.Pages;
using Reqnroll;

namespace MobileTestsDemoWithAppium.StepDefinitions.Permissions;

public class PermissionsStepDefinitions : BaseStepDefinitions
{
	private BasePage basePage;

	public PermissionsStepDefinitions(BasePage basePage) : base()
	{
		this.basePage = basePage;
	}

	[StepDefinition(@"I click grant permission button")]
	public void IClickGrantPermissionButton()
	{
		basePage.ClickGrantPermissionButton();
	}

	[StepDefinition(@"I select the option to not allow permission")]
	public void SelectOptionToNotAllowPermission()
	{
		basePage.ClickDontAllowPermissionButton();
	}

	[StepDefinition(@"I select the option to deny and not ask again for permission")]
	public void SelectOptionToDenyAndNotAskAgainFOrPermissionButton()
	{
		basePage.ClickDenyAndDontAskAgainForPermissionButton();
	}

}
