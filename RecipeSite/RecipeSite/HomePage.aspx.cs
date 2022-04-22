using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecipeSite
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadAllRecipes();


        }

        public void LoadAllRecipes()
        {
            try
            {
                List<int> recipeIDs = GetRecipeIDList();
                int count = recipeIDs.Count;

                for (int recordNum = 0; recordNum < count; recordNum++)
                {
                    RecipeCardDisplay ctrl = (RecipeCardDisplay)LoadControl("RecipeCardDisplay.ascx");

                    ctrl.RecipeID = Convert.ToInt32(recipeIDs[recordNum]);
                    ctrl.DataBind();

                    Page.Master.FindControl("ContentPlaceHolder2").Controls.Add(ctrl);
                }
            }
            catch (Exception ex)
            {

            }
        }


        public List<int> GetRecipeIDList()
        {
            String url = "http://cis-iis2.temple.edu/Spring2022/CIS3342_tuf88411/WebAPI/api/Recipes/GetRecipeIDs/";
            //String url = "http://localhost:59328/api/recipes/GetRecipeIDs";

            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();

            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            // deserialize a JSON string into a list of RecipeIDs
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<int> recipeIDs = js.Deserialize<List<int>>(data);

            return recipeIDs;
        }
    }
}