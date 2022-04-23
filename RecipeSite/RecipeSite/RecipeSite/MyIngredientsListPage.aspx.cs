using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Data;
using System.Data.SqlClient;

namespace RecipeSite
{
    public partial class MyIngredientsListPage : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "ShowUserIngredients";
                objCommand.Parameters.AddWithValue("@user", Session["UserID"].ToString());
                DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

                rptIngredients.DataSource = myDS;
                rptIngredients.DataBind();



            }

        }

        protected void rptIngredients_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int rowIndex = e.Item.ItemIndex;

            // Retrieve a value from a control in the Repeater's Items collection

            Label myLabel = (Label)rptIngredients.Items[rowIndex].FindControl("lblIngredientName");

            String IngredientName = myLabel.Text;

            lblDisplay.Text = IngredientName + " has been removed from your ingredient list";

            // Remove ingredient entry from user ingredient table

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "RemoveUserIngredient";
            objCommand.Parameters.AddWithValue("@user", Session["UserID"].ToString());
            objCommand.Parameters.AddWithValue("@ingredient", rptIngredients.Items[rowIndex].FindControl("lblIngredientID"));
            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

        }
    }
}