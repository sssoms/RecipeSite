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
    /// Summary description for SecurityQuestion
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class SecurityQuestion : System.Web.Services.WebService
    {

        [WebMethod]
        public List<string> GetSecurityQuestions()
        {
            List<string> sqList = new List<string>();

            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetSecurityQuestions";
            DataSet sqDS = objDB.GetDataSet(objCommand);

            int count = sqDS.Tables[0].Rows.Count;

            for (int recordNum = 0; recordNum < count; recordNum++)
            {
                sqList.Add((String)sqDS.Tables[0].Rows[recordNum]["Question"]);
            }

            return sqList;
        }

        [WebMethod]
        public string GetSecurityAnswer(int userID, int rndNum)
        {
            try
            {
                string answer;

                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_GetSecurityAnswer";

                string securityAnswerNum = "SecurityAnswer" + rndNum;

                objCommand.Parameters.AddWithValue("@UserID", userID);

                DataSet saDS = objDB.GetDataSet(objCommand);

                answer = (String)saDS.Tables[0].Rows[0][rndNum];

                return answer;
            }
            catch (Exception ex)
            {
                return "Error has occurred." + ex.ToString();
            }
        }
    }
}
