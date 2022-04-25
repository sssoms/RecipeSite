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
    public partial class ReviewCardDisplay : System.Web.UI.UserControl
    {
        //RecipeSVC.RecipeSOAP pxy = new RecipeSVC.RecipeSOAP();
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
            objCommand.CommandText = "TP_GetReviews";
            objCommand.Parameters.AddWithValue("@recipe", recipeID);

            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            if (ds != null)
            {

                lblReviewTitle.Text = (string)ds.Tables[0].Rows[0]["ReviewTitle"];
                lblReviewUsername.Text = (string)ds.Tables[0].Rows[0]["Username"];
                lblReviewText.Text = (string)ds.Tables[0].Rows[0]["Review"];
                imgRecipe.ImageUrl = "data:image/png;base64," + Convert.ToBase64String((byte[])ds.Tables[0].Rows[0]["Picture"]);

            }


        }
    }
}