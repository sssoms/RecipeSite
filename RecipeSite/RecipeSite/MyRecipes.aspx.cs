using RecipeSiteLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
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
                List<int> recipeIDs = GetRecipeIDList(userID);
                int count = recipeIDs.Count;

                for (int recordNum = 0; recordNum < count; recordNum++)
                {
                    RecipeCardDisplay ctrl = (RecipeCardDisplay)LoadControl("RecipeCardDisplay.ascx");

                    ctrl.RecipeID = Convert.ToInt32(recipeIDs[recordNum]);
                    ctrl.DataBind();

                    Page.Master.FindControl("ContentPlaceHolder1").Controls.Add(ctrl);
                }

                /*
                DataSet myRecipeDS = GetRecipeIDDataSet(userID);
                int count = myRecipeDS.Tables[0].Rows.Count;

                for (int recordNum = 0; recordNum <count; recordNum++)
                {
                    RecipeCardDisplay ctrl = (RecipeCardDisplay)LoadControl("RecipeCardDisplay.ascx");

                    ctrl.RecipeID = Convert.ToInt32(myRecipeDS.Tables[0].Rows[recordNum]["RecipeID"]);
                    ctrl.DataBind();

                    Page.Master.FindControl("ContentPlaceHolder1").Controls.Add(ctrl);
                }*/
            }
            catch (Exception ex)
            {

            }
        }

        public List<int> GetRecipeIDList(int userID)
        {
            String url = "http://cis-iis2.temple.edu/Spring2022/CIS3342_tuf88411/WebAPI/api/Recipes/GetRecipeIDsByUserID/" + userID;

            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();

            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            // deserialize a JSON string into a list of RecipeIDs
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<int> recipeIDs = js.Deserialize<List<int>>(data);

            return recipeIDs;
        }

        /*
        //get RecipeID dataset by UserID
        public DataSet GetRecipeIDDataSet(int userID)
        {
            String url = "http://cis-iis2.temple.edu/Spring2022/CIS3342_tuf88411/WebAPI/api/Recipes/GetRecipeByID/" + recipeID;

            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();

            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            // deserialize a JSON string into a Recipe object
            JavaScriptSerializer js = new JavaScriptSerializer();
            Recipe recipe = js.Deserialize<Recipe>(data);

            
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
            

        }*/
    }
}