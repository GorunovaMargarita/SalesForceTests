# SalesForceTests
This solution is a test framework for produc SalesForce. It has 3 layer architecture: buissness object of Sales Force, core with code that can be reused, and test for SalesForce. This solution was created by me during my c# automation testing learning in TeachMeSkills school.


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


## Quik start
1. Register in [Sales Force](https://developer.salesforce.com) and activate your account with email.
2. Get API token via instruction [Sales Force CLI instruction](https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/quickstart_oauth.htm).
3. Clone repository [Sales Force tests repository](https://github.com/GorunovaMargarita/SalesForceTests). 
4. Open solution in Visual studio (or other for C#).
5. Create solution build configurations **Build** and **Prod**.
6. Edit appsettings.json, appsettings.Debug.json, appsettings.Prod.json. Set your values.
6. Buid solution.

## Running Tests

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

