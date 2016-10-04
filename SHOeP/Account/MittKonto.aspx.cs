using DAL.Controllers;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SHOeP.Account
{
    public partial class MittKonto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /* Visa User info */
            var userController = new UserController();
            /* Har ska vänta på Session--------------*/

            var user = userController.GetUserById(3);

            lblFN.Text += user.FirstName;
            lblEfterN.Text += user.LastName;
            lblPost.Text += user.Email;
            lblPhone.Text += user.Phone;
            lblAdress.Text += user.Address;
            lblCode.Text += user.Zip;
            lblCity.Text += user.City;
            lblPassword.Text += user.Password;



        }

        protected void btnShicka_Click(object sender, EventArgs e)
        {
        
            User newUser = new DAL.Models.User();
            newUser.FirstName = txtFirstname.Text;
            newUser.LastName = txtLastname.Text;
            newUser.Email = txtMail.Text;
            newUser.Address = txtAddress.Text;
            newUser.City = txtCity.Text;
            newUser.Zip = txtZip.Text;
            newUser.Password = txtPassword.Text;

            UserController usercon = new UserController();

            usercon.UpdateUser(newUser);

            if (!string.IsNullOrEmpty(newUser?.Email) && !string.IsNullOrEmpty(newUser.Password))
            {
                Session["User"] = newUser;
                Response.RedirectPermanent("~/Default.aspx");
            }
            else
            {
                Response.Redirect("~/Account/MittKonto.aspx");
            }


        }
    
    }
}