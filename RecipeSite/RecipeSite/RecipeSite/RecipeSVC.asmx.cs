using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using Utilities;
using System.Collections;
using System.Data.SqlClient;

namespace RecipeSite
{
    /// <summary>
    /// Summary description for RecipeSVC
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class RecipeSVC : System.Web.Services.WebService
    {

        [WebMethod]
        public void AddIngredientToUser(int userID, int ingredientID)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objcommand = new SqlCommand();

            objcommand.CommandType = CommandType.StoredProcedure;
            objcommand.CommandText = "TP_AddIngredient";
            objcommand.Parameters.AddWithValue("@UserID", userID);
            objcommand.Parameters.AddWithValue("@IngredientID", ingredientID);

            objDB.DoUpdateUsingCmdObj(objcommand);
        }
        //method to add recipe to favorite list
        [WebMethod]
        public void AddRecipeToFavorite(int userID, int RecipeID)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objcommand = new SqlCommand();

            objcommand.CommandType = CommandType.StoredProcedure;
            objcommand.CommandText = "TP_AddRecipeFromFavorite";

            objDB.DoUpdateUsingCmdObj(objcommand);

        }

        //method to remove recipe from favorite list
        [WebMethod]
        public void RemoveRecipeFromFavorite(int userID, int RecipeID)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objcommand = new SqlCommand();

            objcommand.CommandType = CommandType.StoredProcedure;
            objcommand.CommandText = "TP_RemoveRecipeFromFavorite";

            objDB.DoUpdateUsingCmdObj(objcommand);
        }
    }
}
