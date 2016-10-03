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
            newUser.FirstName = forenameBox.Text;
            newUser.LastName = lastnameBox.Text;
            newUser.Email = emailBox.Text;
            newUser.Address = adressBox.Text;
            newUser.City = cityBox.Text;
            newUser.Zip = zipBox.Text;
            newUser.Password = passBox.Text;

            UserController usercon = new UserController();

            usercon.AddUser(newUser);

            if (!string.IsNullOrEmpty(newUser?.Email) && !string.IsNullOrEmpty(newUser.Password))
            {
                Session["User"] = newUser.UserId;
                Response.RedirectPermanent("~/Default.aspx");
            }
            else
            {
                Response.Redirect("~/Account/Register.aspx");
            }


        }
    }
}