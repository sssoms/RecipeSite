using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Data;
using System.Data.SqlClient;
using RecipeSiteLibrary;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace RecipeSite
{
    public partial class ReviewCardDisplay : System.Web.UI.UserControl
    {
        int reviewID;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public int ReviewID
        {
            get { return reviewID; }
            set { reviewID = value; }
        }

        public override void DataBind()
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetReviewByReviewID";
            objCommand.Parameters.AddWithValue("@reviewID", reviewID);

            DataSet reviewDS = objDB.GetDataSet(objCommand);

            if (reviewDS != null)
            {
                // deserialize the binary data to reconstruct the Review object
                Byte[] reviewBA = (Byte[])reviewDS.Tables[0].Rows[0]["theReview"];
                BinaryFormatter deSr = new BinaryFormatter();
                MemoryStream ms = new MemoryStream(reviewBA);
                Review review = (Review)deSr.Deserialize(ms);

                lblReviewTitle.Text = review.Title;
                lblReviewText.Text = review.Text;
                Rating1.CurrentRating = review.StarRating;
            }
        }
    }
}