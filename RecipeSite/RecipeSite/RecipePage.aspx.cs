using RecipeSiteLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Utilities;

namespace RecipeSite
{
    public partial class RecipePage : System.Web.UI.Page
    {
        //String webApiURL = "http://cis-iis2.temple.edu/Spring2022/CIS3342_tuf88411/WebAPI/api/Recipes/";
        String webApiURL = "http://localhost:59328/api/recipes/";
        int recipeID, userID;
        bool loggedin = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] != null)
                loggedin = (Boolean)Session["LoggedIn"];
            
            // if not logged in, redirect to log in page
            if (!loggedin)
            {
                Response.Redirect("default.aspx");
            }

            userID = Convert.ToInt32(Session["UserID"]);
            recipeID = Convert.ToInt32(Request.QueryString["ID"]);
            GetRecipeData();
            LoadReviews();

        }

        public void GetRecipeData()
        {
            //String url = webApiURL + "GetRecipeByID/" + recipeID;
            String url = webApiURL + "GetRecipeByID/" + recipeID;

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

            if (recipe != null) {
                lblRecipeName.Text = recipe.RecipeName;
                RecipeImage.ImageUrl = recipe.Picture;
                lblMainIngredients.Text = recipe.MainIngredient;
                lblCookingMethod.Text = recipe.CookingMethod;
                lblFoodCategory.Text = recipe.FoodCategory;
                lblServings.Text = recipe.Servings.ToString();
                lblCookingTime.Text = recipe.CookingTime.ToString();
                lblInstructions.Text = CompleteInstruction(recipe.Instruction1, recipe.Instruction2, recipe.Instruction3, recipe.Instruction4, recipe.Instruction5, recipe.Instruction6,
                    recipe.Instruction7, recipe.Instruction8, recipe.Instruction9, recipe.Instruction10);
                lblNumberOfSaves.Text = recipe.UserSavedNum + " ";

                // need to incorporate method to highlight? ingredients that matches the user's Ingredients list.
                lblIngredient1.Text = recipe.Ingredient1;
                lblIngredient2.Text = recipe.Ingredient2;
                lblIngredient3.Text = recipe.Ingredient3;
                lblIngredient4.Text = recipe.Ingredient4;
                lblIngredient5.Text = recipe.Ingredient5;
                lblIngredient6.Text = recipe.Ingredient6;
                lblIngredient7.Text = recipe.Ingredient7;
                lblIngredient8.Text = recipe.Ingredient8;
            }
        }

        public string CompleteInstruction(string inst1, string inst2, string inst3, string inst4, string inst5, string inst6, string inst7, string inst8, string inst9, string inst10)
        {
            string instruction = NumberedInstruction(inst1, 1);
            if (inst2 != "")
                instruction += NumberedInstruction(inst2, 2);
            if (inst3 != "")
                instruction += NumberedInstruction(inst3, 3);
            if (inst4 != "")
                instruction += NumberedInstruction(inst4, 4);
            if (inst5 != "")
                instruction += NumberedInstruction(inst5, 5);
            if (inst6 != "")
                instruction += NumberedInstruction(inst6, 6);
            if (inst7 != "")
                instruction += NumberedInstruction(inst7, 7);
            if (inst8 != "")
                instruction += NumberedInstruction(inst8, 8);
            if (inst9 != "")
                instruction += NumberedInstruction(inst9, 9);
            if (inst10 != "")
                instruction += NumberedInstruction(inst10, 10);

            return instruction;
        }

        public string NumberedInstruction(string inst, int num)
        {
            string numberedInst = "" + num + ". " + inst + "<br/>";
            return numberedInst;
        }
        public void LoadReviews()
        {
            DBConnect objDB = new DBConnect();
            int count = 0;
            objDB.GetDataSet("SELECT Review FROM TP_RecipeReview WHERE RecipeID = " + recipeID, out count);

            if(count != 0)
            {
                for (int recordNumber = 0; recordNumber < count; recordNumber++)
                {
                    ReviewCardDisplay ctrl = (ReviewCardDisplay)LoadControl("ReviewCardDisplay.ascx");

                    ctrl.DataBind();

                    Page.Master.FindControl("PastReviews").Controls.Add(ctrl);
                }
            }
            else
            {
                lblDisplay.Text = "This recipe does not have any reviews";
            }

            
        }
    }
}