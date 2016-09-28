using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Controllers;

namespace SHOeP.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginUser(object sender, EventArgs e)
        {
            var userController = new UserController();
            var user = userController.GetUserByLoginCredentials(LoginUserTxtBox.Text, LoginPassTxtBox.Text);

            if (!string.IsNullOrEmpty(user?.Email) && !string.IsNullOrEmpty(user.Password))
            {
                Session[user.Email] = user.Email;
                Response.RedirectPermanent("~/Default.aspx");
            }
        }
    }
}