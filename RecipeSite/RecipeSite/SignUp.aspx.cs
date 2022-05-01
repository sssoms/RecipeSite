using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Data.SqlClient;
using System.Data;
using System.Web.Script.Serialization;

namespace RecipeSite
{
    public partial class SignUp : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            // load sequrity questions from the database
            SecurityQuestionSvc.SecurityQuestion pxy = new SecurityQuestionSvc.SecurityQuestion();
            string[] sqList = pxy.GetSecurityQuestions();
            lblSecurityQuestion1.Text = sqList[0];
            lblSecurityQuestion2.Text = sqList[1];
            lblSecurityQuestion3.Text = sqList[2];
        }
        // create and add user to database
        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text == "" || txtPassword.Text == "" || txtFirstName.Text == "" ||  txtLastName.Text == "" || txtStreet.Text == "" || txtCity.Text == "" || DropDownListState.SelectedValue == "NN" 
                                        || txtSecurityAnswer1.Text == "" || txtSecurityAnswer2.Text == "" || txtSecurityAnswer3.Text == "")
            {
                lblMessage.Text = "Please completely fill out all the information";
            }
            else
            {
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_CreateAccount";

                objCommand.Parameters.AddWithValue("@Username", txtUsername.Text);
                objCommand.Parameters.AddWithValue("@Password", EncryptString(txtPassword.Text));
                objCommand.Parameters.AddWithValue("@Email", txtEmail.Text);
                objCommand.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                objCommand.Parameters.AddWithValue("@LastName", txtLastName.Text);
                objCommand.Parameters.AddWithValue("@Street", txtStreet.Text);
                objCommand.Parameters.AddWithValue("@City", txtCity.Text);
                objCommand.Parameters.AddWithValue("@State", DropDownListState.SelectedValue);
                objCommand.Parameters.AddWithValue("@SecurityQuestion1", lblSecurityQuestion1.Text);
                objCommand.Parameters.AddWithValue("@SecurityAnswer1", txtSecurityAnswer1.Text);
                objCommand.Parameters.AddWithValue("@SecurityQuestion2", lblSecurityQuestion2.Text);
                objCommand.Parameters.AddWithValue("@SecurityAnswer2", txtSecurityAnswer2.Text);
                objCommand.Parameters.AddWithValue("@SecurityQuestion3", lblSecurityQuestion3.Text);
                objCommand.Parameters.AddWithValue("@SecurityAnswer3", txtSecurityAnswer3.Text);

                int result  = objDB.DoUpdateUsingCmdObj(objCommand);

                Response.Redirect("default.aspx");
            }
            
        }
        public string EncryptString(string strEncrypted)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }
    }
}