using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace RecipeSite
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        int userID;
        Random rnd = new Random();
        int rndNum;

        protected void Page_Load(object sender, EventArgs e)
        {
            userID = 1; //Convert.ToInt32(Request.QueryString["ID"]);
            if (!IsPostBack)
            {
                // randomly select one security question out of 3 questions
                rndNum = rnd.Next(1, 3);
                lblSecurityQuestion.Text = rndNum.ToString();
            }
        }
        protected void btnVerify_Click(object sender, EventArgs e)
        {
            try
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_ValidateSecurityAnswer";
                objCommand.Parameters.AddWithValue("@UserID", userID);
                DataSet myDS = objDB.GetDataSet(objCommand);

                string str = "SecurityAnswer" + rndNum;
                string securityAnswer = (String)myDS.Tables[0].Rows[0][str];
                Label1.Text = securityAnswer;

                if (securityAnswer == txtSecurityAnswer.Text)
                {
                    lblResetPassword.Visible = false;
                    lblSecurityQuestion.Visible = false;
                    txtSecurityAnswer.Visible = false;
                    btnVerify.Visible = false;
                    lblResetPassword.Visible = true;
                    txtPassword.Visible = true;
                    btnReset.Visible = true;
                }
                else
                {
                    lblError.Text = "Your answer doesn't match our data.";
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                lblError.Text = ex.ToString();//"Your answer doesn't match our data.";
            }
            catch (Exception ex)
            {
                lblError.Text = ex.ToString();
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_ResetPassword";
                objCommand.Parameters.AddWithValue("@UserID", userID);
                objCommand.Parameters.AddWithValue("@Password", txtPassword.Text);

                int result = objDB.DoUpdate(objCommand);

                if (result == 1)
                {
                    txtPassword.Visible = false;
                    btnReset.Visible = false;
                    lblResetSuccessful.Visible = true;
                    btnReturn.Visible = true;
                }
                else if (result == 0)
                {
                    lblError.Text = "Your password has not been updated";
                }
                else
                    lblError.Text = "An error occurred. Please try agin later.";
            }
            catch (Exception ex)
            {
                lblError.Text = ex.ToString();
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }
    }
}