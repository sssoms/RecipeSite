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
            if (ddlSearchBy.SelectedValue != "Select")
            {
                lblSelectedSearchBy.Text = ddlSearchBy.SelectedValue;
            }
            DataSet ddlDS = GetSelectedSearchByDataSet(ddlSearchBy.SelectedValue);

            ddlSelectedSearchBy.DataSource = ddlDS.Tables[0];
            ddlSelectedSearchBy.DataValueField = ddlDS.Tables[0].Columns[0].ToString();
            ddlSelectedSearchBy.DataTextField = ddlDS.Tables[0].Columns[0].ToString();
            ddlSelectedSearchBy.DataBind();
        }

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
                    objCommand.CommandText = "TP_SearchByFoodCategories";
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            lblSelectedSearchBy.Text = ddlSearchBy.SelectedValue;
        }
    }
}