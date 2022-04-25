using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;

namespace RecipeSite
{
    public partial class Search : System.Web.UI.Page
    {
        String webApiURL = "http://cis-iis2.temple.edu/Spring2022/CIS3342_tuf88411/WebAPI/api/Recipes/";
        //String webApiURL = "http://localhost:59328/api/recipes/";
        bool loggedin = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] != null)
                loggedin = (Boolean)Session["LoggedIn"];

            // if not logged in, redirect to log in page
            if (!loggedin)
            {
                Response.Redirect("default.aspx");
            }
            LoadRecipes();
        }

        protected void ddlSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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

                    SearchDDLSvc.SearchDDL pxy = new SearchDDLSvc.SearchDDL();
                    string[] ddlItems = pxy.GetDDLItems(ddlSearchBy.SelectedValue);

                    ddlSelectedSearchBy.DataSource = ddlItems;
                    ddlSelectedSearchBy.DataBind();
                }

            }
            catch (Exception ex)
            {

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
        }

        public void LoadRecipes()
        {
            try
            {
                List<int> recipeIDs = GetRecipeIDList(ddlSearchBy.SelectedValue.Replace(" ", ""), ddlSelectedSearchBy.SelectedValue);
                int count = recipeIDs.Count;

                for (int recordNum = 0; recordNum < count; recordNum++)
                {
                    //register the ASCX control 
                    RecipeCardDisplay ctrl = (RecipeCardDisplay)LoadControl("RecipeCardDisplay.ascx");

                    //set proterties for the RecipeCardDisplay object
                    ctrl.RecipeID = Convert.ToInt32(recipeIDs[recordNum]);
                    ctrl.DataBind();

                    this.PlaceHolder1.Controls.Add(ctrl);
                }
            }
            catch (Exception ex)
            {

            }
        }


        //get a list of recipeIDs that are filtered with selected searchby value
        public List<int> GetRecipeIDList(string searchBy, string selectedValue)
        {
            String url = webApiURL + "GetRecipeIDsBySearch/" + searchBy + "/" + selectedValue;

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