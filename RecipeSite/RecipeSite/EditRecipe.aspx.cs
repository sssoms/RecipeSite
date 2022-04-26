using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using RecipeSiteLibrary;

namespace RecipeSite
{
    public partial class EditRecipe : System.Web.UI.Page
    {
        String webApiURL = "http://cis-iis2.temple.edu/Spring2022/CIS3342_tuf88411/WebAPI/api/recipes/";
        //String webApiURL = "http://localhost:59328/api/recipes/";
        int userID, recipeID;
        bool loggedin = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            userID = Convert.ToInt32(Session["UserID"]);
            recipeID = Convert.ToInt32(Request.QueryString["ID"]);
            if(Session["LoggedIn"] != null)
                loggedin = (Boolean)Session["LoggedIn"];

            if (!IsPostBack && loggedin)
            {
                ddlCookingTime.DataSource = Enumerable.Range(1, 120).ToList();
                ddlCookingTime.DataBind();
                BindDDL(ddlMainIngredient);
                BindDDL(ddlCookingMethod);
                BindDDL(ddlFoodCategory);
                BindDDL(ddlIngredient1);
                BindDDL(ddlIngredient2);
                BindDDL(ddlIngredient3);
                BindDDL(ddlIngredient4);
                BindDDL(ddlIngredient5);
                BindDDL(ddlIngredient6);
                BindDDL(ddlIngredient7);
                BindDDL(ddlIngredient8);
                GetRecipeData();
            }
            // if not logged in, redirect to log in page
            else if (!loggedin)
            {
                Response.Redirect("default.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                UpdateRecipeToDatabase();
                Response.Redirect("MyRecipes.aspx");
            }
            else
            {
                lblError.Text = "Please fill all the required fields!";
            }
        }

        public void GetRecipeData()
        {
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


            txtRecipeName.Text = recipe.RecipeName;
            ddlMainIngredient.SelectedValue = recipe.MainIngredient;
            ddlCookingMethod.SelectedValue = recipe.CookingMethod;
            ddlServing.SelectedValue = recipe.FoodCategory;
            ddlServing.SelectedValue = recipe.Servings.ToString();
            ddlCookingTime.SelectedValue = recipe.CookingTime.ToString();
            txtInstruction1.Text = recipe.Instruction1;
            txtInstruction2.Text = recipe.Instruction2;
            txtInstruction3.Text = recipe.Instruction3;
            txtInstruction4.Text = recipe.Instruction4;
            txtInstruction5.Text = recipe.Instruction5;
            txtInstruction6.Text = recipe.Instruction6;
            txtInstruction7.Text = recipe.Instruction7;
            txtInstruction8.Text = recipe.Instruction8;
            txtInstruction9.Text = recipe.Instruction9;
            txtInstruction10.Text = recipe.Instruction10;
            ddlIngredient1.SelectedValue = recipe.Ingredient1;
            ddlIngredient2.SelectedValue = recipe.Ingredient2;
            ddlIngredient3.SelectedValue = recipe.Ingredient3;
            ddlIngredient4.SelectedValue = recipe.Ingredient4;
            ddlIngredient5.SelectedValue = recipe.Ingredient5;
            ddlIngredient6.SelectedValue = recipe.Ingredient6;
            ddlIngredient7.SelectedValue = recipe.Ingredient7;
            ddlIngredient8.SelectedValue = recipe.Ingredient8;
        }

        // set the selected value of ingredient dropdown list
        public void PutIngredientToDDL(DropDownList ddl, string ingrNum, DataSet myDS)
        {
            DropDownList ddlIngredient = ddl;

            // if ingredient data is null, set selected value as Select
            if (myDS.Tables[0].Rows[0][ingrNum].ToString() == "")
            {
                ddlIngredient.SelectedValue = "";
            }
            
            else
            {
                ddlIngredient.SelectedValue = myDS.Tables[0].Rows[0][ingrNum].ToString();
            }
        }

        public void PutInstructionsToTextbox(TextBox textbox, string instNum, DataSet myDS)
        {
            TextBox txtInstruction = textbox;
            textbox.Text = (String)myDS.Tables[0].Rows[0][instNum];
        }

        // update recipe 
        public void UpdateRecipeToDatabase()
        {
            try
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_UpdateRecipe";

                objCommand.Parameters.AddWithValue("@RecipeID", recipeID);
                objCommand.Parameters.AddWithValue("@RecipeName", txtRecipeName.Text);
                objCommand.Parameters.AddWithValue("@MainIngredient", ddlMainIngredient.SelectedValue);
                objCommand.Parameters.AddWithValue("@CookingMethod", ddlCookingMethod.SelectedValue);
                objCommand.Parameters.AddWithValue("@FoodCategory", ddlFoodCategory.SelectedValue);
                objCommand.Parameters.AddWithValue("@Servings", ddlServing.SelectedValue);
                objCommand.Parameters.AddWithValue("@CookingTime", ddlCookingTime.SelectedValue);
                objCommand.Parameters.AddWithValue("@Instruction1", txtInstruction1.Text);
                objCommand.Parameters.AddWithValue("@Instruction2", txtInstruction2.Text);
                objCommand.Parameters.AddWithValue("@Instruction3", txtInstruction3.Text);
                objCommand.Parameters.AddWithValue("@Instruction4", txtInstruction4.Text);
                objCommand.Parameters.AddWithValue("@Instruction5", txtInstruction5.Text);
                objCommand.Parameters.AddWithValue("@Instruction6", txtInstruction6.Text);
                objCommand.Parameters.AddWithValue("@Instruction7", txtInstruction7.Text);
                objCommand.Parameters.AddWithValue("@Instruction8", txtInstruction8.Text);
                objCommand.Parameters.AddWithValue("@Instruction9", txtInstruction9.Text);
                objCommand.Parameters.AddWithValue("@Instruction10", txtInstruction10.Text);

                objCommand.Parameters.AddWithValue("@Ingredient1", ddlIngredient1.SelectedValue);
                objCommand.Parameters.AddWithValue("@Ingredient2", ddlIngredient2.SelectedValue);
                objCommand.Parameters.AddWithValue("@Ingredient3", ddlIngredient3.SelectedValue);
                objCommand.Parameters.AddWithValue("@Ingredient4", ddlIngredient4.SelectedValue);
                objCommand.Parameters.AddWithValue("@Ingredient5", ddlIngredient5.SelectedValue);
                objCommand.Parameters.AddWithValue("@Ingredient6", ddlIngredient6.SelectedValue);
                objCommand.Parameters.AddWithValue("@Ingredient7", ddlIngredient7.SelectedValue);
                objCommand.Parameters.AddWithValue("@Ingredient8", ddlIngredient8.SelectedValue);

                int i = objDB.DoUpdate(objCommand);
                lblError.Text = i.ToString();
            }
            catch (Exception ex)
            {
                lblError.Text = "Error has occurred: " + ex.ToString();
            }


        }

       

        // bind dropdown lists from tables in database
        public void BindDDL(DropDownList ddl)
        {
            try
            {
                string str;

                if (ddl.ID.Substring(0, 13) == "ddlIngredient")
                {
                    str = "Ingredient";
                }
                else
                    str = ddl.ID.Replace("ddl", "");

                DataSet ddlDS = GetDDLDataSet(str);
                ddl.DataSource = ddlDS.Tables[0];
                ddl.DataValueField = ddlDS.Tables[0].Columns[0].ToString();
                ddl.DataTextField = ddlDS.Tables[0].Columns[0].ToString();
                ddl.DataBind();

                // for Ingredient ddl, add an option of empty string
                if (str == "Ingredient")
                {
                    ddl.Items.Insert(0, "");
                }
                // for other ddl, add an option of Other
                else
                {
                    ddl.Items.Add("Other");
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error has occurred: " + ex.ToString();
            }
        }

        // get dataset for dropdown lists that will be used in BindDDL()
        public DataSet GetDDLDataSet(string option)
        {
            try
            {
                DataSet myDS;
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;

                switch (option)
                {
                    case "MainIngredient":
                        objCommand.CommandText = "TP_SearchByMainIngredient";
                        myDS = objDB.GetDataSet(objCommand);
                        break;
                    case "CookingMethod":
                        objCommand.CommandText = "TP_SearchByCookingMethod";
                        myDS = objDB.GetDataSet(objCommand);
                        break;
                    case "FoodCategory":
                        objCommand.CommandText = "TP_SearchByFoodCategories";
                        myDS = objDB.GetDataSet(objCommand);
                        break;
                    case "Ingredient":
                        objCommand.CommandText = "TP_GetIngredientsList";
                        myDS = objDB.GetDataSet(objCommand);
                        break;
                    default:
                        myDS = null;
                        break;
                }
                return myDS;
            }
            catch (Exception ex)
            {
                lblError.Text = "Error has occurred: " + ex.ToString();
                return null;
            }
        }

    }
}