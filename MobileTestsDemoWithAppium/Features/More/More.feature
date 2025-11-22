Feature: More
Users should be able to see their profile, change the language, see usefull links and log out.

Background:
	Given I have logged in as TestUser1
	And I click on More tab

@positive
Scenario: View my profile
	When I click on My Profile option on More screen
	Then assert that I do see element with text My Profile
	And assert that I do see my email as a text on the screen

@positive
Scenario: Change my language
	When I click on Change Language option on More screen
	Then assert that I do see element with text Language
	And assert that I do see element with text Български
	And assert that I do see element with text English
	When I click Bulgarian language radio button
	Then assert that I do see element with text Език
	And assert that I do see element with text Проверка
	And assert that I do see element with text Повече
	When I click the go back button
	Then assert that I do see element with text Моят профил
	And assert that I do see element with text Смяна на език
	And assert that I do see element with text Тема
	And assert that I do see element with text Информация за приложението
	And assert that I do see element with text Изход
	When I click on Проверка tab
	Then assert that I do see element with text Сканиране
	When I click on Повече tab
	And I click on Смяна на език option on More screen
	And I click English language radio button
	Then assert that I do see element with text Language
	And assert that I do see element with text Inspection
	And assert that I do see element with text More
	When I click the go back button
	Then assert that I do see element with text My Profile
	And assert that I do see element with text Change Language
	And assert that I do see element with text Theme
	And assert that I do see element with text App Information
	And assert that I do see element with text Log out
	When I click on Inspection tab
	Then assert that I do see element with text Scan

@positive
Scenario: View app information
	When I click on App Information option on More screen
	Then assert that I do see element with text App Information
	And assert that I do see element containing text Some app info

@positive
Scenario: Logout
	When I click on Log out button
	Then assert that I do see element with text Log in with E-mail
	And assert that I do see element with text Landing page text