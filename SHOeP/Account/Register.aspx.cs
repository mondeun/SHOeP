﻿using System;
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
            if (passBox.Text != confirmPassBox.Text) return;

            User newUser = new DAL.Models.User();
            newUser.FirstName = forenameBox.Text;
            newUser.LastName = lastnameBox.Text;
            newUser.Email = emailBox.Text;
            newUser.Address = addressBox.Text;
            newUser.City = cityBox.Text;
            newUser.Zip = zipBox.Text;
            newUser.Password = passBox.Text;
            newUser.HashAndSaltPassword();

            UserController usercon = new UserController();

            usercon.AddUser(newUser);

            if (!string.IsNullOrEmpty(newUser?.Email) && !string.IsNullOrEmpty(newUser.Password))
            {
                Session["User"] = newUser;
                Response.RedirectPermanent("~/Default.aspx");
            }
            else
            {
                Response.Redirect("~/Account/Register.aspx");
            }


        }
    }
}