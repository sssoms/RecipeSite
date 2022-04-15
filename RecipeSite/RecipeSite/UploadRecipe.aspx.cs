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
    public partial class UploadRecipe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindDDL(ddlMainIngredient);
            BindDDL(ddlCookingMethod);
            BindDDL(ddlFoodCategory);
            BindIngredientDDL(ddlIngredient1);
            BindIngredientDDL(ddlIngredient2);
            BindIngredientDDL(ddlIngredient3);
            BindIngredientDDL(ddlIngredient4);
            BindIngredientDDL(ddlIngredient5);
            BindIngredientDDL(ddlIngredient6);
            BindIngredientDDL(ddlIngredient7);
            BindIngredientDDL(ddlIngredient8);
        }

        public void BindDDL(DropDownList ddl)
        {
            string str = ddl.ID.Replace("ddl", "");

            DataSet ddlDS = GetDDLDataSet(str);
            ddl.DataSource = ddlDS.Tables[0];
            ddl.DataValueField = ddlDS.Tables[0].Columns[0].ToString();
            ddl.DataTextField = ddlDS.Tables[0].Columns[0].ToString();
            ddl.DataBind();
        }

        public void BindIngredientDDL(DropDownList ddl)
        {
            DataSet ddlDS = GetDDLDataSet("Ingredient");
            ddl.DataSource = ddlDS.Tables[0];
            ddl.DataValueField = ddlDS.Tables[0].Columns[0].ToString();
            ddl.DataTextField = ddlDS.Tables[0].Columns[0].ToString();
            ddl.DataBind();
        }

        public DataSet GetDDLDataSet(string option)
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
    }
}