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
        int userID;
        //String webApiURL = "http://cis-iis2.temple.edu/Spring2022/CIS3342_tuf88411/WebAPI/api/Recipes/";
        String webApiURL = "http://localhost:59328/api/recipes/";
        protected void Page_Load(object sender, EventArgs e)
        {
            userID = Convert.ToInt32(Session["UserID"]);
            if (IsMyRecipe(userID))
            {
                btnEdit.Visible = true;
                btnEdit.Enabled = true;
            }
        }

        public int RecipeID
        {
            get { return recipeID; }
            set { recipeID = value; }
        }

        public override void DataBind()
        {
            String url = webApiURL + "GetRecipeByID/" + RecipeID;

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

            if (recipe != null)
            {
                lblName.Text = recipe.RecipeName;
                imgRecipe.ImageUrl = recipe.Picture;
                lblMainIngredient.Text = recipe.MainIngredient;
                lblCookingMethod.Text = recipe.CookingMethod;
                lblFoodCategory.Text = recipe.FoodCategory;
                lblUserSavedNum.Text = recipe.UserSavedNum.ToString();
                lblStarRating.Text = recipe.AvgStarRating.ToString();
            }
            else 
                lblName.Text = "no record";
        }

        protected void btnDetails_Click(object sender, EventArgs e)
        {
            //redirect to RecipePage.aspx
            Response.Redirect("RecipePage.aspx?ID=" + RecipeID, false);
        }

        public bool IsMyRecipe(int userID)
        {
            String url = webApiURL + "GetUserIDByRecipeID/" + RecipeID;
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();

            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            // deserialize a JSON string into a Recipe object
            JavaScriptSerializer js = new JavaScriptSerializer();
            int recipeUserID = js.Deserialize<int>(data);

            if (userID == recipeUserID)
                return true;
            else 
                return false;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditRecipe.aspx?ID=" + RecipeID, false);
        }
    }
}