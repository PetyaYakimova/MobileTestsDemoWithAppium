using MobileTestsDemoWithAppium.Pages.Inspection.Scan;
using Reqnroll;

namespace MobileTestsDemoWithAppium.StepDefinitions.Inspection.Scan;

public class ScanStepDefinitions : BaseStepDefinitions
{
	private ScanPage scanPage;

	public ScanStepDefinitions(
	   ScanPage scanPage) : base()
	{
		this.scanPage = scanPage;
	}

	[StepDefinition(@"I select the option to grant permission for camera while using the app")]
	public void SelectOptionToGrantPermissionForCameraWhileUsingTheApp()
	{
		scanPage.ClickGrantPermissionWhileUsingTheAppButton();
	}

	[StepDefinition(@"I select the option to grant permission for camera only this time")]
	public void SelectOptionToGrantPermissionForCameraOnlyThisTime()
	{
		scanPage.ClickGrantPermissionOnlyThisTimeButton();
	}

	[StepDefinition(@"I click the scan icon button")]
	public void ClickTheScanIconButton()
	{
		scanPage.ClickScanIconButton();
	}

	[StepDefinition(@"I click the scan again button")]
	public void ClickTheScanAgainButton()
	{
		scanPage.ClickScanAgainButton();
	}
}
