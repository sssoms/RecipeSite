using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace RecipeSite
{
    public partial class MyRecipes : System.Web.UI.Page
    {
        int userID;

        protected void Page_Load(object sender, EventArgs e)
        {
            userID = 1;//Convert.ToInt32(Session["UserID"]);
            LoadMyRecipes();
        }

        public void LoadMyRecipes()
        {
            try
            {
                DataSet myRecipeDS = GetRecipeIDDataSet(userID);
                int count = myRecipeDS.Tables[0].Rows.Count;

                for (int recordNum = 0; recordNum <count; recordNum++)
                {
                    RecipeCardDisplay ctrl = (RecipeCardDisplay)LoadControl("RecipeCardDisplay.ascx");

                    ctrl.RecipeID = Convert.ToInt32(myRecipeDS.Tables[0].Rows[recordNum]["RecipeID"]);
                    ctrl.DataBind();

                    Page.Master.FindControl("ContentPlaceHolder1").Controls.Add(ctrl);
                }
            }
            catch (Exception ex)
            {

            }
        }

        //get RecipeID dataset by UserID
        public DataSet GetRecipeIDDataSet(int userID)
        {
            try
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                DataSet myDS;

                objCommand.CommandText = "TP_GetRecipeIDByUserID";
                objCommand.Parameters.AddWithValue("@UserID", userID);
                myDS = objDB.GetDataSet(objCommand);

                return myDS;
            }
            catch (Exception ex)
            {
                return null;
            }


        }
    }
}