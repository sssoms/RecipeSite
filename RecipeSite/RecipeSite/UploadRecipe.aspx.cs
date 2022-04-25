using RecipeSiteLibrary;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace RecipeSite
{
    public partial class UploadRecipe : System.Web.UI.Page
    {
        String webApiURL = "http://cis-iis2.temple.edu/Spring2022/CIS3342_tuf88411/WebAPI/api/Recipes/";
        //String webApiURL = "http://localhost:59328/api/recipes/";
        int userID, imgSize;
        string fileExtension, imgName;
        byte[] imgData;
        bool loggedin = false;

        protected void Page_Load(object sender, EventArgs e)
        {   
            userID = Convert.ToInt32(Session["UserID"]);
            if (Session["LoggedIn"] != null)
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
            }
            // if not logged in, redirect to log in page
            else if (!loggedin)
            {
                Response.Redirect("default.aspx");
            }

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            bool imgIsValid = RecipeImgExtIsValid();

            if (Page.IsValid && imgIsValid)
            {
                UploadRecipeToDatabase();
                Response.Redirect("MyRecipes.aspx");
            }
            else
            {
                lblError.Text = "Please fill all the required fields!";
            }
        }

        // upload new recipe
        public void UploadRecipeToDatabase()
        {
            string result;
            Recipe newRecipe = new Recipe();

            newRecipe.UserID = userID;
            newRecipe.RecipeName = txtRecipeName.Text;
            newRecipe.MainIngredient = ddlMainIngredient.SelectedValue;
            newRecipe.CookingMethod = ddlCookingMethod.SelectedValue;
            newRecipe.FoodCategory = ddlFoodCategory.SelectedValue;
            newRecipe.Picture = "data:image/png;base64," + Convert.ToBase64String(imgData);
            newRecipe.Servings = Convert.ToInt32(ddlServing.SelectedValue);
            newRecipe.CookingTime = Convert.ToInt32(ddlCookingTime.SelectedValue);
            newRecipe.Instruction1 = txtInstruction1.Text;
            newRecipe.Instruction2 = txtInstruction2.Text;
            newRecipe.Instruction3 = txtInstruction3.Text;
            newRecipe.Instruction4 = txtInstruction4.Text;
            newRecipe.Instruction5 = txtInstruction5.Text;
            newRecipe.Instruction6 = txtInstruction6.Text;
            newRecipe.Instruction7 = txtInstruction7.Text;
            newRecipe.Instruction8 = txtInstruction8.Text;
            newRecipe.Instruction9 = txtInstruction9.Text;
            newRecipe.Instruction10 = txtInstruction10.Text;
            newRecipe.Ingredient1 = ddlIngredient1.SelectedValue;
            newRecipe.Ingredient2 = ddlIngredient2.SelectedValue;
            newRecipe.Ingredient3 = ddlIngredient3.SelectedValue;
            newRecipe.Ingredient4 = ddlIngredient4.SelectedValue;
            newRecipe.Ingredient5 = ddlIngredient5.SelectedValue;
            newRecipe.Ingredient6 = ddlIngredient6.SelectedValue;
            newRecipe.Ingredient7 = ddlIngredient7.SelectedValue;
            newRecipe.Ingredient8 = ddlIngredient8.SelectedValue;

            // Serialize a Recipe object into a JSON string
            JavaScriptSerializer js = new JavaScriptSerializer();
            String jsonRecipe = js.Serialize(newRecipe);

            try
            {
                // send the Recipe objest to the Web API that will be used to update the associated recipe record (based on RecipeID) in the database
                WebRequest request = WebRequest.Create(webApiURL + "AddRecipe/");
                request.Method = "POST";
                request.ContentLength = jsonRecipe.Length;
                request.ContentType = "application/json";

                StreamWriter writer = new StreamWriter(request.GetRequestStream());
                writer.Write(jsonRecipe);
                writer.Flush();
                writer.Close();

                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();

                if (data == "1")
                {
                    result = "Your new recipe has been uploaded successfully!";
                }
                else if (data == "0")
                {
                    result = "Your recipe has not been uploaded.";
                }
                else
                    result = "Error has occurred. Please try again later.";
            }
            catch (Exception ex)
            {

            }
        }

        // validate file extension
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
                lblError.Text = "there is no file";
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

                // for Ingredient ddl, add an option of empty stsring
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