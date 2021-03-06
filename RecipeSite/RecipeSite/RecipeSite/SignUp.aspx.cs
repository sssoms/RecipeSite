using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Data.SqlClient;
using System.Data;

namespace RecipeSite
{
    public partial class SignUp : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        // create and add user to database
        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text == "" || txtPassword.Text == "" || txtFirstName.Text == "" ||  txtLastName.Text == "" || txtStreet.Text == "" || txtCity.Text == "" || DropDownListState.SelectedValue == "NN")
            {
                lblMessage.Text = "Please completely fill out all the information";
            }
            else
            {
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_CreateAccount";

                objCommand.Parameters.AddWithValue("@Username", txtUsername.Text);
                objCommand.Parameters.AddWithValue("@Password", txtPassword.Text);
                objCommand.Parameters.AddWithValue("@Email", txtEmail.Text);
                objCommand.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                objCommand.Parameters.AddWithValue("@LastName", txtLastName.Text);
                objCommand.Parameters.AddWithValue("@Street", txtStreet.Text);
                objCommand.Parameters.AddWithValue("@City", txtCity.Text);
                objCommand.Parameters.AddWithValue("@State", DropDownListState.SelectedValue);

                objDB.DoUpdateUsingCmdObj(objCommand);

                Response.Redirect("LogIn.aspx");
            }
            
        }
    }
}