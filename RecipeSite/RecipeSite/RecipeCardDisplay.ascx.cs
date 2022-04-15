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
    public partial class RecipeCardDisplay : System.Web.UI.UserControl
    {
        int recipeID;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public int RecipeID
        {
            get { return recipeID; }
            set { recipeID = value; }
        }

        public override void DataBind()
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetRecipeByID";
            objCommand.Parameters.AddWithValue("@RecipeID", RecipeID);
            DataSet myDS;
            myDS = objDB.GetDataSet(objCommand);

            lblName.Text = (String)myDS.Tables[0].Rows[0]["RecipeName"];
            lblMainIngredient.Text = (String)myDS.Tables[0].Rows[0]["MainIngredient"];
            lblCookingMethod.Text = (String)myDS.Tables[0].Rows[0]["CookingMethod"];
            lblFoodCategory.Text = (String)myDS.Tables[0].Rows[0]["Category"];
        }

        protected void btnDetails_Click(object sender, EventArgs e)
        {
            //redirect to RecipePage.aspx
        }
    }
}