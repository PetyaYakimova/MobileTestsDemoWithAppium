Feature: Scan
Users should be able to use the camera to scan if they have given the permission.

Background:
	Given I have logged in as TestUser1

@positive
Scenario: Allow using the camera to do a scan
	When I click grant permission button
	And I select the option to grant permission for camera while using the app
	Then assert that I do see element with text Press to scan
	When I click the scan icon button
	Then assert that I do not see element with text Press to scan

@negative
Scenario: Deny using camera to do a scan
	When I click grant permission button
	And I select the option to not allow permission
	Then assert that I do see element with text The permission to use the camera is denied. Please, change your device settings.
	And assert that I do see element with text Open settings
