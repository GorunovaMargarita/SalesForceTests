using BusinessObject.SalesForce.Model;
using BusinessObject.SalesForce.UI.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.SalesForce.UI
{
    public class ApplicationHelper
    {
        private IWebDriver driver;
        public ApplicationHelper(IWebDriver driver)
        {
            this.driver = driver;
        }
        public NewContactModal InitContactCreation(User user)
        {
            new LoginPage()
               .Open()
               .Login(user)
               .GoToContactPage()
               .OpenNewContactModal();
            return new NewContactModal();
        }

        public NewAccountModal InitAccountCreation(User user)
        {
            new LoginPage()
               .Open()
               .Login(user)
               .GoToAccountPage()
               .OpenNewAccountModal();
            return new NewAccountModal();
        }

        public AccountPage OpenAccountPage(User user = null)
        {
            if(user == null)
            {
                user = UserBuilder.GetSalesForceUser();
            }
            new LoginPage()
                .Open()
                .Login(user)
                .GoToAccountPage();
            return new AccountPage();
        }

        public ContactPage OpenContactPage(User user = null)
        {
            if (user == null)
            {
                user = UserBuilder.GetSalesForceUser();
            }
            new LoginPage()
                .Open()
                .Login(user)
                .GoToContactPage();
            return new ContactPage();
        }
    }
}
