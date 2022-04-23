using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeWepAPI.Models
{
    public class Recipe
    {
        private int userID;
        private int recipeID;
        private string recipeName;
        private string mainIngredient;
        private string cookingMethod;
        private string foodCategory;
        private byte[] picture;
        private int servings;
        private int cookingTime;
        private int userSavedNum;
        private float avgStarRating;
        private string instruction1;
        private string instruction2;
        private string instruction3;
        private string instruction4;
        private string instruction5;
        private string instruction6;
        private string instruction7;
        private string instruction8;
        private string instruction9;
        private string instruction10;
        private string ingredient1;
        private string ingredient2;
        private string ingredient3;
        private string ingredient4;
        private string ingredient5;
        private string ingredient6;
        private string ingredient7;
        private string ingredient8;

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public int RecipeID
        {
            get { return recipeID; }
            set { recipeID = value; }
        }

        public String RecipeName
        {
            get { return recipeName; }
            set { recipeName = value; }
        }

        public String MainIngredient
        {
            get { return mainIngredient; }
            set { mainIngredient = value; }
        }

        public String CookingMethod
        {
            get { return cookingMethod; }
            set { cookingMethod = value; }
        }

        public String FoodCategory
        {
            get { return foodCategory; }
            set { foodCategory = value; }
        }

        public byte[] Picture
        {
            get { return picture; }
            set { picture = value; }
        }
        
        public int Servings
        {
            get { return servings; }
            set { servings = value; }
        }

        public int CookingTime
        {
            get { return cookingTime; }
            set { cookingTime = value; }
        }

        public int UserSavedNum
        {
            get { return userSavedNum; }
            set { userSavedNum = value; }
        }

        public float AvgStarRating
        {
            get { return avgStarRating; }
            set { avgStarRating = value; }
        }

        public String Instruction1
        {
            get { return instruction1; }
            set { instruction1 = value; }
        }

        public String Instruction2
        {
            get { return instruction2; }
            set { instruction2 = value; }
        }

        public String Instruction3
        {
            get { return instruction3; }
            set { instruction3 = value; }
        }

        public String Instruction4
        {
            get { return instruction4; }
            set { instruction4 = value; }
        }

        public String Instruction5
        {
            get { return instruction5; }
            set { instruction5 = value; }
        }

        public String Instruction6
        {
            get { return instruction6; }
            set { instruction6 = value; }
        }

        public String Instruction7
        {
            get { return instruction7; }
            set { instruction7 = value; }
        }

        public String Instruction8
        {
            get { return instruction8; }
            set { instruction8 = value; }
        }

        public String Instruction9
        {
            get { return instruction9; }
            set { instruction9 = value; }
        }

        public String Instruction10
        {
            get { return instruction10; }
            set { instruction10 = value; }
        }

        public String Ingredient1
        {
            get { return ingredient1; }
            set { ingredient1 = value; }
        }

        public String Ingredient2
        {
            get { return ingredient2; }
            set { ingredient2 = value; }
        }

        public String Ingredient3
        {
            get { return ingredient3; }
            set { ingredient3 = value; }
        }

        public String Ingredient4
        {
            get { return ingredient4; }
            set { ingredient4 = value; }
        }

        public String Ingredient5
        {
            get { return ingredient5; }
            set { ingredient5 = value; }
        }

        public String Ingredient6
        {
            get { return ingredient6; }
            set { ingredient6 = value; }
        }

        public String Ingredient7
        {
            get { return ingredient7; }
            set { ingredient7 = value; }
        }

        public String Ingredient8
        {
            get { return ingredient8; }
            set { ingredient8 = value; }
        }

        public Recipe()
        {
        }

        public Recipe(int userID, int recipeID, string recipeName, string mainIngredient, string cookingMethod, string foodCategory, byte[] picture, int servings, int cookingTime, string instruction1)
        {
            UserID = userID;
            RecipeID = recipeID;
            RecipeName = recipeName;
            MainIngredient = mainIngredient;
            CookingMethod = cookingMethod;
            FoodCategory = foodCategory;
            Picture = picture;
            Servings = servings;
            CookingTime = cookingTime;
            Instruction1 = instruction1;
        }

    }
}
