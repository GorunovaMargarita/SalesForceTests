using BusinessObject.SalesForce.Model;
using BusinessObject.SalesForce.UI.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.SalesForce.UI.Steps
{
    public class ContactSteps
    {
        /// <summary>
        /// Init account creation
        /// </summary>
        /// <param name="user">SalesForce user</param>
        /// <returns>ContactModal page</returns>
        public ContactModal InitContactCreation(User user = null)
        {
            user ??= UserBuilder.GetSalesForceUser();
            new LoginPage()
               .Open()
               .Login(user)
               .GoToContactPage()
               .OpenContactModal();
            return new ContactModal();
        }

        /// <summary>
        /// Open contact page with contact list
        /// </summary>
        /// <param name="user">SalesForce user</param>
        /// <returns>ContactPage page</returns>
        public ContactPage OpenContactPage(User user = null)
        {
            user ??= UserBuilder.GetSalesForceUser();
            new LoginPage()
                .Open()
                .Login(user)
                .GoToContactPage();
            return new ContactPage();
        }
    }
}
