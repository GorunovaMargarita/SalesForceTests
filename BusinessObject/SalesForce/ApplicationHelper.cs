using BusinessObject.SalesForce.Model;
using BusinessObject.SalesForce.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.SalesForce
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
               .Login(user);
            new ContactPage()
               .Open()
               .OpenNewContactModal();
            return new NewContactModal();
        }

        public NewAccountModal InitAccountCreation(User user)
        {
            new LoginPage()
               .Open()
               .Login(user);
            new AccountPage()
               .Open()
               .OpenNewAccountModal();
            return new NewAccountModal();
        }
    }
}
