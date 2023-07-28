using BusinessObject.SalesForce.Model;
using BusinessObject.SalesForce.UI.Pages;

namespace BusinessObject.SalesForce.UI.Steps
{
    public class AccountSteps
    {
        /// <summary>
        /// Init new account creation
        /// </summary>
        /// <param name="user">SalesForce user</param>
        /// <returns>AccountModal page</returns>
        public AccountModal InitAccountCreation(User user = null)
        {
            user ??= UserBuilder.GetSalesForceUser();
            new LoginPage()
               .Open()
               .Login(user)
               .GoToAccountPage()
               .OpenNewAccountModal();
            return new AccountModal();
        }

        /// <summary>
        /// Open account page with account list
        /// </summary>
        /// <param name="user">SalesForce user</param>
        /// <returns>AccountPage page</returns>
        public AccountPage OpenAccountPage(User user = null)
        {
            user ??= UserBuilder.GetSalesForceUser();
            new LoginPage()
                .Open()
                .Login(user)
                .GoToAccountPage();
            return new AccountPage();
        }
    }
}
