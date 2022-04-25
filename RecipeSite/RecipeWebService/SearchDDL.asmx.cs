using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using Utilities;

namespace RecipeWebService
{
    /// <summary>
    /// Summary description for SearchDDL
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SearchDDL : System.Web.Services.WebService
    {

        [WebMethod]
        public List<string> GetDDLItems(string selectedValue)
        {
            List<string> ddlItems = new List<string>();

            if (selectedValue == "Select")
            {
                return null;
            }

            try
            {
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

                int count = myDS.Tables[0].Rows.Count;
                for (int recordNum = 0; recordNum < count; recordNum++)
                {
                    ddlItems.Add((String)myDS.Tables[0].Rows[recordNum][0]);
                }
                return ddlItems;
            }
            catch (Exception ex)
            {
                ddlItems.Add("Error");
                return ddlItems;
            }
        }
    }
}
