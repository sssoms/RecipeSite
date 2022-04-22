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

                recipe.Ingredient1 = myDS.Tables[0].Rows[0]["Ingredient1"].ToString();
                recipe.Ingredient2 = myDS.Tables[0].Rows[0]["Ingredient2"].ToString();
                recipe.Ingredient3 = myDS.Tables[0].Rows[0]["Ingredient3"].ToString();
                recipe.Ingredient4 = myDS.Tables[0].Rows[0]["Ingredient4"].ToString();
                recipe.Ingredient5 = myDS.Tables[0].Rows[0]["Ingredient5"].ToString();
                recipe.Ingredient6 = myDS.Tables[0].Rows[0]["Ingredient6"].ToString();
                recipe.Ingredient7 = myDS.Tables[0].Rows[0]["Ingredient7"].ToString();
                recipe.Ingredient8 = myDS.Tables[0].Rows[0]["Ingredient8"].ToString();
            }
            return recipe;
        }

        // thie method recevies a UserID and returns an ArrayList of Recipes associated with the UserID
        [HttpGet("GetRecipesByUserID/{userID}")]
        public List<Recipe> GetRecipesByUserID(int userID)
        {
            List<Recipe> recipeList = new List<Recipe>();
            List<int> recipeIDList = GetRecipeIDsByUserID(userID);

            int count = recipeIDList.Count;

            for (int i = 0; i < count; i++)
            {
                Recipe recipe = GetRecipeByID(recipeIDList[0]);
                recipeList.Add(recipe);
            }
            return recipeList;
        }

        // this method receives a UserID and returns an ArrayList of integer that represents all the recipeIDs with a given UserID.
        [HttpGet("GetRecipeIDsByUserID/{userID}")]
        public List<int> GetRecipeIDsByUserID(int userID)
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

        // this method receives an UserID and a Recipe object and insert a new recipe to database
        // then returns the number of rows succesfully inserted (-1 if error occurred)
        [HttpPost("AddRecipe")]
        public int AddRecipe(int userID, Recipe recipe)
        {
            int result;
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_CreateNewRecipe";

            objCommand.Parameters.AddWithValue("@UserID", recipe.UserID);
            objCommand.Parameters.AddWithValue("@RecipeName", recipe.RecipeName);
            objCommand.Parameters.AddWithValue("@MainIngredient", recipe.MainIngredient);
            objCommand.Parameters.AddWithValue("@CookingMethod", recipe.CookingMethod);
            objCommand.Parameters.AddWithValue("@FoodCategory", recipe.FoodCategory);
            objCommand.Parameters.AddWithValue("@Picture", recipe.Picture);
            objCommand.Parameters.AddWithValue("@Servings", recipe.Servings);
            objCommand.Parameters.AddWithValue("@CookingTime", recipe.CookingTime);
            objCommand.Parameters.AddWithValue("@Instruction1", recipe.Instruction1);
            objCommand.Parameters.AddWithValue("@Instruction2", recipe.Instruction2);
            objCommand.Parameters.AddWithValue("@Instruction3", recipe.Instruction3);
            objCommand.Parameters.AddWithValue("@Instruction4", recipe.Instruction4);
            objCommand.Parameters.AddWithValue("@Instruction5", recipe.Instruction5);
            objCommand.Parameters.AddWithValue("@Instruction6", recipe.Instruction6);
            objCommand.Parameters.AddWithValue("@Instruction7", recipe.Instruction7);
            objCommand.Parameters.AddWithValue("@Instruction8", recipe.Instruction8);
            objCommand.Parameters.AddWithValue("@Instruction9", recipe.Instruction9);
            objCommand.Parameters.AddWithValue("@Instruction10", recipe.Instruction10);
            objCommand.Parameters.AddWithValue("@Ingredient1", recipe.Ingredient1);
            objCommand.Parameters.AddWithValue("@Ingredient2", recipe.Ingredient2);
            objCommand.Parameters.AddWithValue("@Ingredient3", recipe.Ingredient3);
            objCommand.Parameters.AddWithValue("@Ingredient4", recipe.Ingredient4);
            objCommand.Parameters.AddWithValue("@Ingredient5", recipe.Ingredient5);
            objCommand.Parameters.AddWithValue("@Ingredient6", recipe.Ingredient6);
            objCommand.Parameters.AddWithValue("@Ingredient7", recipe.Ingredient7);
            objCommand.Parameters.AddWithValue("@Ingredient8", recipe.Ingredient8);

            result = objDB.DoUpdate(objCommand);
            return result;
        }

        // this method receives a Recipe object and update the recipe associated with the RecipeID of the Recipe Objectwith update data in the Recipe object
        // then returns the number of rows succesfully updated (-1 if error occurred)
        [HttpPut("UpdateRecipe")]
        //[HttpPut("UpdateRecipe/{recipeID}")]
        public int UpdateRecipe(Recipe updatedRecipe)
        {
            int result;

            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_UpdateRecipe";

            objCommand.Parameters.AddWithValue("@RecipeID", updatedRecipe.RecipeID);
            objCommand.Parameters.AddWithValue("@RecipeName", updatedRecipe.RecipeName);
            objCommand.Parameters.AddWithValue("@MainIngredient", updatedRecipe.MainIngredient);
            objCommand.Parameters.AddWithValue("@CookingMethod", updatedRecipe.CookingMethod);
            objCommand.Parameters.AddWithValue("@FoodCategory", updatedRecipe.FoodCategory);
            objCommand.Parameters.AddWithValue("@Picture", updatedRecipe.Picture);
            objCommand.Parameters.AddWithValue("@Servings", updatedRecipe.Servings);
            objCommand.Parameters.AddWithValue("@CookingTime", updatedRecipe.CookingTime);
            objCommand.Parameters.AddWithValue("@Instruction1", updatedRecipe.Instruction1);
            objCommand.Parameters.AddWithValue("@Instruction2", updatedRecipe.Instruction2);
            objCommand.Parameters.AddWithValue("@Instruction3", updatedRecipe.Instruction3);
            objCommand.Parameters.AddWithValue("@Instruction4", updatedRecipe.Instruction4);
            objCommand.Parameters.AddWithValue("@Instruction5", updatedRecipe.Instruction5);
            objCommand.Parameters.AddWithValue("@Instruction6", updatedRecipe.Instruction6);
            objCommand.Parameters.AddWithValue("@Instruction7", updatedRecipe.Instruction7);
            objCommand.Parameters.AddWithValue("@Instruction8", updatedRecipe.Instruction8);
            objCommand.Parameters.AddWithValue("@Instruction9", updatedRecipe.Instruction9);
            objCommand.Parameters.AddWithValue("@Instruction10", updatedRecipe.Instruction10);
            objCommand.Parameters.AddWithValue("@Ingredient1", updatedRecipe.Ingredient1);
            objCommand.Parameters.AddWithValue("@Ingredient2", updatedRecipe.Ingredient2);
            objCommand.Parameters.AddWithValue("@Ingredient3", updatedRecipe.Ingredient3);
            objCommand.Parameters.AddWithValue("@Ingredient4", updatedRecipe.Ingredient4);
            objCommand.Parameters.AddWithValue("@Ingredient5", updatedRecipe.Ingredient5);
            objCommand.Parameters.AddWithValue("@Ingredient6", updatedRecipe.Ingredient6);
            objCommand.Parameters.AddWithValue("@Ingredient7", updatedRecipe.Ingredient7);
            objCommand.Parameters.AddWithValue("@Ingredient8", updatedRecipe.Ingredient8);

            result = objDB.DoUpdate(objCommand);
            return result;
        }

        // this method receives an UserID and a RecipdID and delete the recipe associated with the UserID & RecipeID
        // then returns the number of rows succesfully deleted (-1 if error occurred)
        [HttpDelete("DeleteRecipe")]
        public int DeleteRecipe(int userID, int recipeID)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_DeleteRecipe";

            objCommand.Parameters.AddWithValue("@UserID", userID);
            objCommand.Parameters.AddWithValue("@RecipeID", recipeID);

            int result = objDB.DoUpdate(objCommand);
            return result;
        }





        // method add ingredients to user's ingredient list
        [HttpPost("AddIngredientToUser/{userID}/{ingredient}")]
        public void  AddIngredientToUser(int userID, int ingredientID)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objcommand = new SqlCommand();

            objcommand.CommandType = CommandType.StoredProcedure;
            objcommand.CommandText = "TP_AddIngredient";
            objcommand.Parameters.AddWithValue("@UserID", userID);
            objcommand.Parameters.AddWithValue("@IngredientID", ingredientID);
        }

        //method to add recipe to favorite list
        [HttpPost("AddRecipeToFavorite/{userID}/{RecipeID}")]
        public void AddRecipeToFavorite(int userID, int RecipeID)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objcommand = new SqlCommand();

            objcommand.CommandType = CommandType.StoredProcedure;
            objcommand.CommandText = "TP_AddRecipeFromFavorite";

        }

        //method to remove recipe from favorite list
        [HttpPost("RemoveRecipeFromFavorite/{userID}/{RecipeID}")]
        public void RemoveRecipeFromFavorite(int userID, int RecipeID)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objcommand = new SqlCommand();

            objcommand.CommandType = CommandType.StoredProcedure;
            objcommand.CommandText = "TP_RemoveRecipeFromFavorite";
        }

    }
}
