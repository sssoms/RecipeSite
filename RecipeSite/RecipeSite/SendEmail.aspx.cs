using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.ComponentModel.DataAnnotations;

namespace RecipeSite
{
    public partial class SendEmail : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (IsValidEmail(txtEmail.Text))
            {
                lblError.Text = "";
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_ValidateAccount";

                objCommand.Parameters.AddWithValue("@Email", txtEmail.Text);
                DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

                try
                {
                    //if there is a user info associated with the email, send email about login info
                    if (myDS.Tables[0].Rows[0]["Email"].ToString() != null)
                    {
                        try
                        {
                            int userID = Convert.ToInt32(myDS.Tables[0].Rows[0]["UserID"]);
                            MailMessage mail = new MailMessage();
                            mail.From = new MailAddress("no-reply@recipesite.com");
                            mail.To.Add(new MailAddress(txtEmail.Text));
                            mail.Subject = "RECIPEASY Reset Password";
                            mail.Body = "<a href=\"http://cis-iis2.temple.edu/Spring2022/CIS3342_tuf88411/Project4/ResetPassword.aspx?ID=" + userID
                                + "\">Click here to reset your password for RECIPEASY</a>";
                            mail.IsBodyHtml = true;
                            mail.Priority = MailPriority.Normal;

                            SmtpClient smtpMailClient = new SmtpClient("smtp.temple.edu");
                            smtpMailClient.Send(mail);
                        }
                        catch(Exception ex)
                        {
                            lblError.Text = ex.ToString();
                        }

                        Response.Redirect("default.aspx");
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    lblError.Text = "There is no account with that email.";
                }
            }
            else
            {
                lblError.Text = "Enter a correct email address.";
            }
        }

        protected bool IsValidEmail(string email)
        {
            if (email == null)
                return false;
            else if (new EmailAddressAttribute().IsValid(email))
                return true;
            else
                return false;
        }
    }
}