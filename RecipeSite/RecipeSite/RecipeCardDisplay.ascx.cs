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
using RecipeSiteLibrary;

namespace RecipeSite
{
    public partial class RecipeCardDisplay : System.Web.UI.UserControl
    {
        int recipeID;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public int RecipeID
        {
            get { return recipeID; }
            set { recipeID = value; }
        }

        public override void DataBind()
        {
            /*
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

            lblName.Text = recipe.RecipeName;
            imgRecipe.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(recipe.Picture);
            lblMainIngredient.Text = recipe.MainIngredient;
            lblCookingMethod.Text = recipe.CookingMethod;
            lblFoodCategory.Text = recipe.FoodCategory;
            */

            ///*
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetRecipeByID";
            objCommand.Parameters.AddWithValue("@RecipeID", RecipeID);
            DataSet myDS;
            myDS = objDB.GetDataSet(objCommand);
            
            lblName.Text = (String)myDS.Tables[0].Rows[0]["RecipeName"];
            imgRecipe.ImageUrl = "data:image/png;base64," + Convert.ToBase64String((byte[])myDS.Tables[0].Rows[0]["Picture"]);
            lblMainIngredient.Text = (String)myDS.Tables[0].Rows[0]["MainIngredient"];
            lblCookingMethod.Text = (String)myDS.Tables[0].Rows[0]["CookingMethod"];
            lblFoodCategory.Text = (String)myDS.Tables[0].Rows[0]["Category"];
            //*/
        }

        protected void btnDetails_Click(object sender, EventArgs e)
        {
            //redirect to RecipePage.aspx
            Response.Redirect("RecipePage.aspx?ID=" + RecipeID, false);
        }
    }
}