using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeWepAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Utilities;


namespace RecipeWepAPI.Controllers
{
    [Route("api/[controller]")]

    public class RecipesController : Controller
    {
        // testing
        [HttpGet]
        [HttpGet("GetRecipe")]
        public Recipe GetRecipe()
        {
            Recipe recipe = null;
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            DataSet myDS;

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetRecipeByID";
            objCommand.Parameters.AddWithValue("@RecipeID", 3);
            myDS = objDB.GetDataSet(objCommand);

            if (myDS.Tables[0].Rows.Count > 0)
            {
                recipe = new Recipe();
                recipe.UserID = Convert.ToInt32(myDS.Tables[0].Rows[0]["UserID"]);
                recipe.RecipeID = Convert.ToInt32(myDS.Tables[0].Rows[0]["RecipeID"]);
                recipe.RecipeName = (String)myDS.Tables[0].Rows[0]["RecipeName"];
                recipe.MainIngredient = (String)myDS.Tables[0].Rows[0]["MainIngredient"];
                recipe.CookingMethod = (String)myDS.Tables[0].Rows[0]["CookingMethod"];
                recipe.FoodCategory = (String)myDS.Tables[0].Rows[0]["Category"];
                recipe.Servings = Convert.ToInt32(myDS.Tables[0].Rows[0]["Servings"]);
                recipe.CookingTime = Convert.ToInt32(myDS.Tables[0].Rows[0]["CookingTime"]);
                recipe.Picture = (byte[])myDS.Tables[0].Rows[0]["Picture"];

                recipe.Instruction1 = (String)myDS.Tables[0].Rows[0]["Instruction1"];
                recipe.Instruction2 = (String)myDS.Tables[0].Rows[0]["Instruction2"];
                recipe.Instruction3 = (String)myDS.Tables[0].Rows[0]["Instruction3"];
                recipe.Instruction4 = (String)myDS.Tables[0].Rows[0]["Instruction4"];
                recipe.Instruction5 = (String)myDS.Tables[0].Rows[0]["Instruction5"];
                recipe.Instruction6 = (String)myDS.Tables[0].Rows[0]["Instruction6"];
                recipe.Instruction7 = (String)myDS.Tables[0].Rows[0]["Instruction7"];
                recipe.Instruction8 = (String)myDS.Tables[0].Rows[0]["Instruction8"];
                recipe.Instruction9 = (String)myDS.Tables[0].Rows[0]["Instruction9"];
                recipe.Instruction10 = (String)myDS.Tables[0].Rows[0]["Instruction10"];

                recipe.Ingredient1 = (String)myDS.Tables[0].Rows[0]["Ingredient1"];
                recipe.Ingredient2 = (String)myDS.Tables[0].Rows[0]["Ingredient2"];
                recipe.Ingredient3 = (String)myDS.Tables[0].Rows[0]["Ingredient3"];
                recipe.Ingredient4 = (String)myDS.Tables[0].Rows[0]["Ingredient4"];
                recipe.Ingredient5 = (String)myDS.Tables[0].Rows[0]["Ingredient5"];
                recipe.Ingredient6 = (String)myDS.Tables[0].Rows[0]["Ingredient6"];
                recipe.Ingredient7 = (String)myDS.Tables[0].Rows[0]["Ingredient7"];
            //    if (myDS.Tables[0].Rows[0]["Ingredient8"] != null)
            //        recipe.Ingredient8 = (String)myDS.Tables[0].Rows[0]["Ingredient8"];
            }
            return recipe;
        }

        // this method receives RecipeID and returns a Recipe object with the field values from the database record
        [HttpGet("GetRecipeByID/{recipeID}")]
        public Recipe GetRecipeByID(int recipeID)
        {
            Recipe recipe = null;
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            DataSet myDS;

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetRecipeByID";
            objCommand.Parameters.AddWithValue("@RecipeID", recipeID);
            myDS = objDB.GetDataSet(objCommand);

            if (myDS.Tables[0].Rows.Count > 0)
            {
                recipe = new Recipe();
                recipe.UserID = Convert.ToInt32(myDS.Tables[0].Rows[0]["UserID"]);
                recipe.RecipeID = Convert.ToInt32(myDS.Tables[0].Rows[0]["RecipeID"]);
                recipe.RecipeName = (String)myDS.Tables[0].Rows[0]["RecipeName"];
                recipe.MainIngredient = (String)myDS.Tables[0].Rows[0]["MainIngredient"];
                recipe.CookingMethod = (String)myDS.Tables[0].Rows[0]["CookingMethod"];
                recipe.FoodCategory = (String)myDS.Tables[0].Rows[0]["Category"];
                recipe.Servings = Convert.ToInt32(myDS.Tables[0].Rows[0]["Servings"]);
                recipe.CookingTime = Convert.ToInt32(myDS.Tables[0].Rows[0]["CookingTime"]);
                recipe.Picture = (byte[])myDS.Tables[0].Rows[0]["Picture"];

                recipe.Instruction1 = (String)myDS.Tables[0].Rows[0]["Instruction1"];
                recipe.Instruction2 = (String)myDS.Tables[0].Rows[0]["Instruction2"];
                recipe.Instruction3 = (String)myDS.Tables[0].Rows[0]["Instruction3"];
                recipe.Instruction4 = (String)myDS.Tables[0].Rows[0]["Instruction4"];
                recipe.Instruction5 = (String)myDS.Tables[0].Rows[0]["Instruction5"];
                recipe.Instruction6 = (String)myDS.Tables[0].Rows[0]["Instruction6"];
                recipe.Instruction7 = (String)myDS.Tables[0].Rows[0]["Instruction7"];
                recipe.Instruction8 = (String)myDS.Tables[0].Rows[0]["Instruction8"];
                recipe.Instruction9 = (String)myDS.Tables[0].Rows[0]["Instruction9"];
                recipe.Instruction10 = (String)myDS.Tables[0].Rows[0]["Instruction10"];

                if (myDS.Tables[0].Rows[0]["Ingredient1"] != null)
                    recipe.Ingredient1 = (String)myDS.Tables[0].Rows[0]["Ingredient1"];
                if (myDS.Tables[0].Rows[0]["Ingredient2"] != null)
                    recipe.Ingredient2 = (String)myDS.Tables[0].Rows[0]["Ingredient2"];
                if (myDS.Tables[0].Rows[0]["Ingredient3"] != null)
                    recipe.Ingredient3 = (String)myDS.Tables[0].Rows[0]["Ingredient3"];
                if (myDS.Tables[0].Rows[0]["Ingredient4"] != null)
                    recipe.Ingredient4 = (String)myDS.Tables[0].Rows[0]["Ingredient4"];
                if (myDS.Tables[0].Rows[0]["Ingredient5"] != null)
                    recipe.Ingredient5 = (String)myDS.Tables[0].Rows[0]["Ingredient5"];
                if (myDS.Tables[0].Rows[0]["Ingredient6"] != null)
                    recipe.Ingredient6 = (String)myDS.Tables[0].Rows[0]["Ingredient6"];
                if (myDS.Tables[0].Rows[0]["Ingredient7"] != null)
                    recipe.Ingredient7 = (String)myDS.Tables[0].Rows[0]["Ingredient7"];
                if (myDS.Tables[0].Rows[0]["Ingredient8"] != null)
                    recipe.Ingredient8 = (String)myDS.Tables[0].Rows[0]["Ingredient8"];
            }
            return recipe;
        }


        // this method receivesa UserID and returns an ArrayList of integer that represents all the recipeIDs with a given UserID.
        [HttpGet("GetRecipesByUserID/{userID}")]
        public List<int> GetRecipeIDByUserID(int userID)
        {
            List<int> recipeIDList = new List<int>();
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            DataSet myDS;

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetRecipeIDByUserID";
            objCommand.Parameters.AddWithValue("@UserID", userID);

            myDS = objDB.GetDataSet(objCommand);
            int count = myDS.Tables[0].Rows.Count;

            for (int i = 0; i < count; i++)
            {
                recipeIDList.Add(Convert.ToInt32(myDS.Tables[0].Rows[i]["RecipeID"]));
            }
            return recipeIDList;
        }

        //// method add ingredients to user's ingredient list
        //[HttpPost("AddIngredientToUser/{userID}/{ingredient}")]
        //public void  AddIngredientToUser(int userID, int ingredientID)
        //{
        //    DBConnect objDB = new DBConnect();
        //    SqlCommand objcommand = new SqlCommand();

        //    objcommand.CommandType = CommandType.StoredProcedure;
        //    objcommand.CommandText = "TP_AddIngredient";
        //    objcommand.Parameters.AddWithValue("@UserID", userID);
        //    objcommand.Parameters.AddWithValue("@IngredientID", ingredientID);
        //}

        ////method to add recipe to favorite list
        //[HttpPost("AddRecipeToFavorite/{userID}/{RecipeID}")]
        //public void AddRecipeToFavorite(int userID, int RecipeID)
        //{
        //    DBConnect objDB = new DBConnect();
        //    SqlCommand objcommand = new SqlCommand();

        //    objcommand.CommandType = CommandType.StoredProcedure;
        //    objcommand.CommandText = "TP_AddRecipeFromFavorite";

        //}

        ////method to remove recipe from favorite list
        //[HttpPost("RemoveRecipeFromFavorite/{userID}/{RecipeID}")]
        //public void RemoveRecipeFromFavorite(int userID, int RecipeID)
        //{
        //    DBConnect objDB = new DBConnect();
        //    SqlCommand objcommand = new SqlCommand();

        //    objcommand.CommandType = CommandType.StoredProcedure;
        //    objcommand.CommandText = "TP_RemoveRecipeFromFavorite";
        //}




    }
}
