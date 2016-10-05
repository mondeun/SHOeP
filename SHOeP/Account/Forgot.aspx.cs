using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Controllers;

namespace SHOeP.Account
{
    public partial class Forgot : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SendNewPassword(object sender, EventArgs e)
        {
            if (ForgotEmailTxtBox.Text == null) return;

            var userController = new UserController();
            var user = userController.GetUserByEmail(ForgotEmailTxtBox.Text);
            if (user == null) return;

            using (var smtpClient = new SmtpClient())
            {
                var body = new StringBuilder();
                user.GenerateNewPassword();

                body.Append($"Hello {user.FirstName}, Here's your new password: {user.Password}");
                body.Append("Please change this as soon as possible.");

                user.HashAndSaltPassword();
                userController.UpdateUser(user);

                smtpClient.Host = "smtp.shoep.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = false;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                smtpClient.PickupDirectoryLocation = @"C:\Emails";

                var message = new MailMessage("dontreply@shoep.com", user.Email, "Your new Password", body.ToString())
                {
                    BodyEncoding = Encoding.Default
                };

                smtpClient.Send(message);
            }
            Response.Redirect("../Default.aspx");
        }
    }
}