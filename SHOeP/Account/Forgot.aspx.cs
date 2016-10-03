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
            if (ForgotEmailTxtBox.Text != null) return;

            var userController = new UserController();
            var user = userController.GetUserByEmail(ForgotEmailTxtBox.Text);
            if (user == null) return;

            using (var SmtpClient = new SmtpClient())
            {
                var body = new StringBuilder();

                body.Append($"Hello {user.FirstName}, Here's your new password: ");
                user.GenerateNewPassword();
                body.Append($"{user.Password}\nPlease change this as soon as possible.");

                user.HashAndSaltPassword();
                userController.UpdateUser(user);

                SmtpClient.Host = "smtp.shoep.com";
                SmtpClient.Port = 587;
                SmtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                SmtpClient.PickupDirectoryLocation = @"C:\";

                var message = new MailMessage("dontreply@shoep.com", user.Email, "Your new Password", body.ToString());
                message.BodyEncoding = Encoding.UTF8;

                SmtpClient.Send(message);
            }
        }
    }
}