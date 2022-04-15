using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace RecipeSite
{
    public partial class UploadRecipe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Response.Redirect("MyRecipes.aspx");
            }
            else
            {
                //??? not working
                lblError.Text = "Please fill all the required fields!";
            }
        }

        public void UploadRecipeToDatabase()
        {

        }

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
            }
            catch (Exception ex)
            {

            }
        }

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
                return null;
            }
        }



        protected void btnAddIngredient2_Click(object sender, EventArgs e)
        {
            ddlIngredient2.Enabled = true;
            ddlIngredient2.Visible = true;
            btnAddIngredient3.Visible = true;
        }

        protected void btnAddIngredient3_Click(object sender, EventArgs e)
        {
            ddlIngredient3.Enabled = true;
            ddlIngredient3.Visible = true;
            btnAddIngredient4.Visible = true;
        }

        protected void btnAddIngredient4_Click(object sender, EventArgs e)
        {
            ddlIngredient4.Enabled = true;
            ddlIngredient4.Visible = true;
            btnAddIngredient5.Visible = true;
        }

        protected void btnAddIngredient5_Click(object sender, EventArgs e)
        {
            ddlIngredient5.Enabled = true;
            ddlIngredient5.Visible = true;
            btnAddIngredient6.Visible = true;
        }

        protected void btnAddIngredient6_Click(object sender, EventArgs e)
        {
            ddlIngredient6.Enabled = true;
            ddlIngredient6.Visible = true;
            btnAddIngredient7.Visible = true;
        }

        protected void btnAddIngredient7_Click(object sender, EventArgs e)
        {
            ddlIngredient7.Enabled = true;
            ddlIngredient7.Visible = true;
            btnAddIngredient8.Visible = true;
        }

        protected void btnAddIngredient8_Click(object sender, EventArgs e)
        {
            ddlIngredient8.Enabled = true;
            ddlIngredient8.Visible = true;
        }
    }
}