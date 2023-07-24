using BusinessObject.SalesForce.Model;
using BusinessObject.SalesForce.UI.Pages;

namespace BusinessObject.SalesForce.UI.Steps
{
    public class AccountSteps
    {
        /// <summary>
        /// Init new account creation
        /// </summary>
        /// <param name="user">system user</param>
        /// <returns></returns>
        public NewAccountModal InitAccountCreation(User user = null)
        {
            user ??= UserBuilder.GetSalesForceUser();
            new LoginPage()
               .Open()
               .Login(user)
               .GoToAccountPage()
               .OpenNewAccountModal();
            return new NewAccountModal();
        }

        /// <summary>
        /// Open account page with account list
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
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
