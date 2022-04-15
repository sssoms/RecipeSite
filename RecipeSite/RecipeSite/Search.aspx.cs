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
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ddlSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSearchBy.SelectedValue == "Select")
            {
                ddlSelectedSearchBy.Visible = false;
                ddlSelectedSearchBy.Items.Clear();
                lblSelectedSearchBy.Text = "";
            }
            else
            {
                lblSelectedSearchBy.Text = ddlSearchBy.SelectedValue;
                ddlSelectedSearchBy.Visible = true;
            }
                
            DataSet ddlDS = GetSelectedSearchByDataSet(ddlSearchBy.SelectedValue);

            ddlSelectedSearchBy.DataSource = ddlDS.Tables[0];
            ddlSelectedSearchBy.DataValueField = ddlDS.Tables[0].Columns[0].ToString();
            ddlSelectedSearchBy.DataTextField = ddlDS.Tables[0].Columns[0].ToString();
            ddlSelectedSearchBy.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //lblSelectedSearchBy.Text = ddlSearchBy.SelectedValue;
            DataSet recipeDS = GetRecipeDataSet(ddlSearchBy.SelectedValue, ddlSelectedSearchBy.SelectedValue);
            int count = recipeDS.Tables[0].Rows.Count;

            for (int recordNum = 0; recordNum < count; recordNum++)
            {
                //register the ASCX control 
                RecipeCardDisplay ctrl = (RecipeCardDisplay)LoadControl("RecipeCardDisplay.ascx");

                //set proterties for the RecipeCardDisplay object
                ctrl.RecipeID = Convert.ToInt32(recipeDS.Tables[0].Rows[0]["RecipeID"]);
                ctrl.DataBind();

                //Form.Controls.Add(ctrl);
            }
        }

        //get dataset of recipes filtered with selected searchby value
        public DataSet GetRecipeDataSet (string selectedSearchBy, string selectedValue)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            string str = selectedSearchBy.Replace(" ", "");
            
            objCommand.CommandText = "TP_GetRecipeIDBy" + str;
            objCommand.Parameters.AddWithValue("@SelectedValue", selectedValue);
            DataSet myDS;
            myDS = objDB.GetDataSet(objCommand);

            return myDS; 
        }

        //get dataset to bind to ddlSelectedSearchBy depending on what is selected on ddlSearchBy
        public DataSet GetSelectedSearchByDataSet(string selectedValue)
        {
            if (selectedValue == "Select")
            {
                return null;
            }

            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            DataSet myDS;

            switch (selectedValue)
            {
                case "Main Ingredient":
                    objCommand.CommandText = "TP_SearchByMainIngredient";
                    myDS = objDB.GetDataSet(objCommand);
                    break;
                case "Cooking Method":
                    objCommand.CommandText = "TP_SearchByCookingMethod";
                    myDS = objDB.GetDataSet(objCommand);
                    break;
                case "Food Category":
                    objCommand.CommandText = "TP_SearchByFoodCategories";
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