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
    public partial class EditRecipe : System.Web.UI.Page
    {
        int userID, imgSize, recipeID;
        string fileExtension, imgName;
        byte[] imgData;

        protected void Page_Load(object sender, EventArgs e)
        {
            userID = 1;//Convert.ToInt32(Session["UserID"]);
            recipeID = 4; //Convert.ToInt32(Session["RecipeID"]);

            if (!IsPostBack)
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
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            bool imgIsValid = RecipeImgExtIsValid();

            if (Page.IsValid && imgIsValid)
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
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetRecipeByID";
            objCommand.Parameters.AddWithValue("@RecipeID", recipeID);
            DataSet myDS;
            myDS = objDB.GetDataSet(objCommand);

            txtRecipeName.Text = (String)myDS.Tables[0].Rows[0]["RecipeName"];
            ddlMainIngredient.SelectedValue = (String)myDS.Tables[0].Rows[0]["MainIngredient"];
            ddlCookingMethod.SelectedValue = (String)myDS.Tables[0].Rows[0]["CookingMethod"];
            ddlFoodCategory.SelectedValue = (String)myDS.Tables[0].Rows[0]["Category"];
            ddlServing.SelectedValue = myDS.Tables[0].Rows[0]["Servings"].ToString();
            ddlCookingTime.SelectedValue = myDS.Tables[0].Rows[0]["CookingTime"].ToString();
            imgData = (byte[])myDS.Tables[0].Rows[0]["Picture"];

            PutIngredientToDDL(ddlIngredient1, "Ingredient1", myDS);
            PutIngredientToDDL(ddlIngredient2, "Ingredient2", myDS);
            PutIngredientToDDL(ddlIngredient3, "Ingredient3", myDS);
            PutIngredientToDDL(ddlIngredient4, "Ingredient4", myDS);
            PutIngredientToDDL(ddlIngredient5, "Ingredient5", myDS);
            PutIngredientToDDL(ddlIngredient6, "Ingredient6", myDS);
            PutIngredientToDDL(ddlIngredient7, "Ingredient7", myDS);
            PutIngredientToDDL(ddlIngredient8, "Ingredient8", myDS);

            /*
            ddlIngredient1.SelectedValue = (String)myDS.Tables[0].Rows[0]["Ingredient1"];
            ddlIngredient2.SelectedValue = (String)myDS.Tables[0].Rows[0]["Ingredient2"];
            ddlIngredient3.SelectedValue = (String)myDS.Tables[0].Rows[0]["Ingredient3"];
            ddlIngredient4.SelectedValue = (String)myDS.Tables[0].Rows[0]["Ingredient4"];
            ddlIngredient5.SelectedValue = (String)myDS.Tables[0].Rows[0]["Ingredient5"];
            ddlIngredient6.SelectedValue = (String)myDS.Tables[0].Rows[0]["Ingredient6"];
            ddlIngredient7.SelectedValue = (String)myDS.Tables[0].Rows[0]["Ingredient7"];
            ddlIngredient8.SelectedValue = (String)myDS.Tables[0].Rows[0]["Ingredient8"];
            */

            txtInstruction1.Text = (String)myDS.Tables[0].Rows[0]["Instruction1"];
            txtInstruction2.Text = (String)myDS.Tables[0].Rows[0]["Instruction2"];
            txtInstruction3.Text = (String)myDS.Tables[0].Rows[0]["Instruction3"];
            txtInstruction4.Text = (String)myDS.Tables[0].Rows[0]["Instruction4"];
            txtInstruction5.Text = (String)myDS.Tables[0].Rows[0]["Instruction5"];
            txtInstruction6.Text = (String)myDS.Tables[0].Rows[0]["Instruction6"];
            txtInstruction7.Text = (String)myDS.Tables[0].Rows[0]["Instruction7"];
            txtInstruction8.Text = (String)myDS.Tables[0].Rows[0]["Instruction8"];
            txtInstruction9.Text = (String)myDS.Tables[0].Rows[0]["Instruction9"];
            txtInstruction10.Text = (String)myDS.Tables[0].Rows[0]["Instruction10"];
        }

        // set the selected value of ingredient dropdown list
        public void PutIngredientToDDL(DropDownList ddl, string ingrNum, DataSet myDS)
        {
            DropDownList ddlIngredient = ddl;
            
            // if ingredient data is null, set selected value as Select
            if (myDS.Tables[0].Rows[0][ingrNum] is null)
            {
                ddlIngredient.SelectedValue = "Select";
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
                objCommand.CommandText = "TP_EditRecipe";

                objCommand.Parameters.AddWithValue("@RecipeID", recipeID);
                objCommand.Parameters.AddWithValue("@RecipeName", txtRecipeName.Text);
                objCommand.Parameters.AddWithValue("@MainIngredient", ddlMainIngredient.SelectedValue);
                objCommand.Parameters.AddWithValue("@CookingMethod", ddlCookingMethod.SelectedValue);
                objCommand.Parameters.AddWithValue("@FoodCategory", ddlFoodCategory.SelectedValue);
                objCommand.Parameters.AddWithValue("@Picture", imgData);
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

                if (ddlIngredient1.SelectedValue != "Select")
                {
                    objCommand.Parameters.AddWithValue("@Ingredient1", ddlIngredient1.SelectedValue);
                }
                if (ddlIngredient2.SelectedValue != "Select")
                {
                    objCommand.Parameters.AddWithValue("@Ingredient2", ddlIngredient2.SelectedValue);
                }
                if (ddlIngredient3.SelectedValue != "Select")
                {
                    objCommand.Parameters.AddWithValue("@Ingredient3", ddlIngredient3.SelectedValue);
                }
                if (ddlIngredient4.SelectedValue != "Select")
                {
                    objCommand.Parameters.AddWithValue("@Ingredient4", ddlIngredient4.SelectedValue);
                }
                if (ddlIngredient5.SelectedValue != "Select")
                {
                    objCommand.Parameters.AddWithValue("@Ingredient5", ddlIngredient5.SelectedValue);
                }
                if (ddlIngredient6.SelectedValue != "Select")
                {
                    objCommand.Parameters.AddWithValue("@Ingredient6", ddlIngredient6.SelectedValue);
                }
                if (ddlIngredient7.SelectedValue != "Select")
                {
                    objCommand.Parameters.AddWithValue("@Ingredient7", ddlIngredient7.SelectedValue);
                }
                if (ddlIngredient8.SelectedValue != "Select")
                {
                    objCommand.Parameters.AddWithValue("@Ingredient8", ddlIngredient8.SelectedValue);
                }
                int i = objDB.DoUpdate(objCommand);
                lblError.Text = i.ToString();
            }
            catch (Exception ex)
            {
                lblError.Text = "Error has occurred: " + ex.ToString();
            }
        }

        // validate fileupload
        public bool RecipeImgExtIsValid()
        {
            bool valid = false;

            // if there is a file, check the extension to see it's valid
            if (fulRecipeImg.HasFile)
            {
                imgSize = fulRecipeImg.PostedFile.ContentLength;
                imgData = new byte[imgSize];

                fulRecipeImg.PostedFile.InputStream.Read(imgData, 0, imgSize);
                imgName = fulRecipeImg.PostedFile.FileName;

                fileExtension = imgName.Substring(imgName.LastIndexOf("."));
                fileExtension = fileExtension.ToLower();

                if (fileExtension == ".jpg" || fileExtension == ".jpeg")
                {
                    valid = true;
                }
                // if extension isn't valid, set the boolean value as false and show the error mesage
                else
                {
                    valid = false;
                    lblImgError.Visible = true;
                }
                return valid;
            }
            else
            {
                valid = true;
                return valid;
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

                // for Ingredient ddl, add an option of Select 
                if (str == "Ingredient")
                {
                    ddl.Items.Insert(0, "Select");
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