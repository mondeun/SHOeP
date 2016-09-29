using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Controllers;
using DAL.Models;

namespace SHOeP.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateButton_Click(object sender, EventArgs e)
        {
            User newUser = new DAL.Models.User();
            newUser.FirstName = forenameBox.ToString();
            newUser.LastName = lastnameBox.ToString();
            newUser.Email = emailBox.ToString();
            newUser.Address = adressBox.ToString();
            newUser.City = cityBox.ToString();
            newUser.Zip = zipBox.ToString();
            newUser.Password = passBox.ToString();

            UserController usercon = new UserController();

            usercon.AddUser(newUser);
        }
    }
}