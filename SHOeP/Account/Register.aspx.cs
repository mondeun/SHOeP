using System;
using System.Collections.Generic;
using System.Drawing;
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
            forenameVal.ForeColor = Color.Red;
            lastnameVal.ForeColor = Color.Red;
            emailVal.ForeColor = Color.Red;
            phoneVal.ForeColor = Color.Red;
            addressVal.ForeColor = Color.Red;
            zipVal.ForeColor = Color.Red;
            cityVal.ForeColor = Color.Red;
            passVal.ForeColor = Color.Red;
            confirmPassVal.ForeColor = Color.Red;
        }

        protected void CreateButton_Click(object sender, EventArgs e)
        {
            if (passBox.Text != confirmPassBox.Text) return;

            var newUser = new User
            {
                FirstName = forenameBox.Text,
                LastName = lastnameBox.Text,
                Email = emailBox.Text,
                Phone = phoneBox.Text,
                Address = addressBox.Text,
                Zip = zipBox.Text,
                City = cityBox.Text,
                Password = passBox.Text
            };
            newUser.HashAndSaltPassword();

            var usercon = new UserController();

            usercon.AddUser(newUser);

            if (!string.IsNullOrEmpty(newUser?.Email) && !string.IsNullOrEmpty(newUser.Password))
            {
                Session["User"] = newUser;
                Response.RedirectPermanent("../Default.aspx");
            }
            else
            {
                Response.Redirect("Register.aspx");
            }


        }
    }
}