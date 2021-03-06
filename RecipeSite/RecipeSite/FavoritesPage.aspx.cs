using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Data;
using System.Data.SqlClient;

namespace RecipeSite
{
    public partial class FavoritesPage : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        bool loggedin = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] != null)
                loggedin = (Boolean)Session["LoggedIn"];

            if (!IsPostBack && loggedin)
            {
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "ShowFavorite";
                objCommand.Parameters.AddWithValue("@user", Session["UserID"].ToString());
                DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

                rptRecipes.DataSource = myDS;
                rptRecipes.DataBind();
            }
            // if not logged in, redirect to log in page
            else if (!loggedin)
            {
                Response.Redirect("default.aspx");
            }

            RecipeSOAPWebAPISvc.RecipeSOAPWebAPI pxy = new RecipeSOAPWebAPISvc.RecipeSOAPWebAPI();
        }
    }
}