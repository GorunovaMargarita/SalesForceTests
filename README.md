# SalesForceTests
This solution is a test framework for product Sales Force. It has 3 layer architecture: business object of Sales Force, core with code that can be reused, and test for Sales Force. This solution was created by me during my C# automation testing learning in TeachMeSkills school.

There are 24 API and 15 UI test cases which check CRUD operation with accounts and contacts.

**UI:**
| Title | Summary |
|----------|----------|
|CreateNewAccount_FullAccountInformationPart_Created|The test checks succesfull creation account with full part of account iformation.|
|CreateNewAccount_OnlyRequiredAtts_Created|The test checks successfull account creation with only required attributes.|
|CreateNewContact_OnlyRequiredAtts_Created|The test checks successfull contact creation with only required attributes.| 
|CreateNewContact_WithFullName_Created|The test checks successfull contact creation with full name data.|
|CreateNewContact_WithMediumDescription_Created|The test checks successfull contact creation with description most common data.|
|CreateNewContact_WithPhones_Created|The test checks successfull contact creation with all phones information.|
|CreateNewContact_Cancel_NotCreated|The test checks opportunity cancel account creation.|
|changingAccount_AccountName_Ok|The test checks successfull account name changing.|
|changingAccount_ParentAccount_Ok|The test checks successfull account parent account changing.|
|changingAccount_Type_Ok|The test checks successfull account type changing.|
|changingContact_Description_Ok|The test checks successfull contact description changing.|
|changingContact_Level_Ok|The test checks successfull contact level changing.|
|changingContact_Phone_Ok|The test checks successfull contact phone changing.|
|DeleteAccount_Ok|The test checks successfull account deletion.|
|DeleteContact_Ok|The test checks successfull contact deletion.|

**API:**
| Title | Summary |
|----------|----------|
|Post_CreateContact_WithFullName_Created|The test checks contact creation with full name data.|
|Post_CreateContact_RequiredPropertyMiss_BadRequest|The test checks that creation contact without required property is not possible and system return response about bad request with error description.|
|Post_CreateContact_OnlyRequiredAttributes_Created|The test checks contact creation with only required attributes.|
|Post_CreateContact_IncorrectBirthdateFormat_BadRequest|The test checks  that creation contact with icorrect birthdate format is not possible and system return response about bad request with error description.|
|Post_CreateAccount_WithBillingAddress_Created|The test checks account creation with full information about billing address.|
|Post_CreateAccount_RequiredPropertyMiss_BadRequest|The test checks that creation account without required property is not possible and system return response about bad request with error description.|
|Post_CreateAccount_RequiredPropertyEmpty_BadRequest|The test checks that creation account with empty property is not possible and system return response about bad request with error description.|
|Post_CreateAccount_OnlyRequiredAttributes_Created|The test checks account creation with only required attributes.|
|Patch_ChangeContact_Phone_NoContent|The test checks successfull contact phone changing.|
|Patch_ChangeContact_LastName_NoContent|The test checks successfull contact last name changing.|
|Patch_ChangeContact_InvalidField_BadRequest|The test checks getting error when in request data incorrect property name set.|
|Patch_ChangeAccount_Phone_NoContent|The test checks successfull account phone changing.|
|Patch_ChangeAccount_LastName_NoContent|The test checks successfull account last name changing.|
|Patch_ChangeAccount_InvalidField_BadRequest|The test checks getting error when in request data incorrect property name set.|
|Get_ContactById_UnknownContact_NotFound|The test checks getting error when contact with id not found.|
|Get_ContactById_OK|The test checks successfull getting existing contact by id.|
|Get_AllContacts_OK|The test checks successfull getting all accounts. In response should exist control contact.|
|Get_AllAccounts_OK|The test checks successfull getting all contacts. In response should exist control account.|
|Get_AccountById_UnknownAccount_NotFound|The test checks getting error when account with id not found.|
|Get_AccountById_OK|The test checks successfull getting existing account by id.|
|Delete_RandomContact_OK|The test checks successfull account deletion.|
|Delete_RandomAccount_OK|The test checks successfull contact deletion.|
|Delete_NotExistingContact_NotFound|The test checks getting error when contact with id to delete not found.|
|Delete_NotExistingAccount_NotFound|The test checks getting error when account with id to delete not found.|


## Authors

- [@GorunovaMargarita](https://github.com/GorunovaMargarita)


## Tech Stack

**Test framework:** NUnit

**Logging:** NLog

**Reporting:** Allure

**Browser automation:** Selenium

**Rest client:** RestSharp

**Generator fake data:** Faker

**Specify the expected outcome of tests:** FluentAssertions


## Quick start

1. Register in [Sales Force](https://developer.salesforce.com) and activate your account with email.
2. Get API token via instruction [Sales Force CLI instruction](https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/quickstart_oauth.htm).
3. Clone repository [Sales Force tests repository](https://github.com/GorunovaMargarita/SalesForceTests). 
4. Open solution in Visual studio (or other for C#).
5. Create solution build configurations **Debug** and **Prod**.
6. Edit appsettings.json, appsettings.Debug.json, appsettings.Prod.json. Set your values.
6. Buid solution.

## Run Tests

For run test using .NET CLI, run the following command

```bash
  dotnet test
```
You can run part of test, example command 

```bash
  dotnet test --filter TestCategory=API
```
To read more about dotnet test command [MS Guide](https://learn.microsoft.com/ru-ru/dotnet/core/tools/dotnet-test).

In Visual Studio you have opportunity use Test Explorer.

## Generate Allure report
Firstly save a path where running tests data for a report saved.
1. Download and extract Allure.
2. Open folder with Allure bin, for example ``D:\Tools\Allure\allure-2.13.9\bin``.
3. Run CMD in this folder.
4. Run command 
```bash
  allure serve D:\DevProjects\DiplomaSolution\SalesForceTests\SalesForceTests\bin\Debug\net6.0\allure-results
```
where ``D:\DevProjects\DiplomaSolution\SalesForceTests\SalesForceTests\bin\Debug\net6.0\allure-results`` is the folder with results.

5. Allure report will be opened in your web browser.
## Feedback

If you have any feedback, please reach out to me at margo.aleksandrova@ya.ru.


