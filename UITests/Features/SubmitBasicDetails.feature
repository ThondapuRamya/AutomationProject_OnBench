Feature: SubmitBasicDetails

submit basic details to get start

@SubmitDetails @UI
Scenario: Submit basic details
	Given Launch brandshark application
	When Click on Design Websites link
	And Click on Visit website button
	Then Validate new window is opened with url contains in it as website-design-and-development-services and switch To That Window
	And Validate Let's get started session is displayed
	When Enter name value as abcd
	And Enter Company value as efgh
	And Enter Phone value as 23456
	And Enter Email value as abc@gmail.com
	And Click on submit button and validate Thankyou page is displayed	
