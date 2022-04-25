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
    public partial class LogIn : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.Cookies["LogIn_Info"] != null)
            {
                HttpCookie cookie = Request.Cookies["LogIn_Info"];
                txtEmail.Text = cookie.Values["Email"].ToString();
                //txtPassword.Text = cookie.Values["Password"].ToString();
            }

        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "" || txtPassword.Text == "")
            {
                lblError.Text = "Please enter your login info.";
            }
            else
            {
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_ValidateAccount";

                objCommand.Parameters.AddWithValue("@Email", txtEmail.Text);

                DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

                try
                {
                    //UserID = Convert.ToInt32(myDS.Tables[0].Rows[0]["UserID"]);
                    if (myDS.Tables[0].Rows[0]["Password"].ToString() == txtPassword.Text)
                    {
                        //allow for faster logins by storing and retrieving the user's login info using a cookie
                        if (ckbRememberMe.Checked)
                        {
                            HttpCookie myCookie = new HttpCookie("LogIn_Info");
                            myCookie.Values["Email"] = txtEmail.Text;
                            //myCookie.Values["Password"] = txtPassword.Text;
                            myCookie.Expires = DateTime.Now.AddYears(1);

                            Response.Cookies.Add(myCookie);
                        }
                        //if user didn't check "Remember me" and there is an existing cookie that stored login info, clean out the cookie
                        else if (!ckbRememberMe.Checked && Request.Cookies["LogIn_Info"] != null)
                        {
                            HttpCookie myCookie = Request.Cookies["LogIn_Info"];
                            myCookie.Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies.Add(myCookie);
                        }

                        //once account is validated, save UserID to session, redirect to HomePage
                        //Session["LoggedIn"] = true;
                        Session["UserID"] = Convert.ToInt32(myDS.Tables[0].Rows[0]["UserID"]);
                        Response.Redirect("HomePage.aspx");
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    lblError.Text = "Your login info does not exist. Please re-enter your email or password.";
                }
            }
        }
    }
}