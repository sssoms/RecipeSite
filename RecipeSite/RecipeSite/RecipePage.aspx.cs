using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecipeSite
{
    public partial class RecipePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string recipeID = Request.QueryString["ID"];
        }
    }
}