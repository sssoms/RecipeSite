<%@ Page Title="" Language="C#" MasterPageFile="~/RecipeSite.Master" AutoEventWireup="true" CodeBehind="RecipePage.aspx.cs" Inherits="RecipeSite.RecipePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="border-color: black; border-style: solid; padding: 1em; line-height: 200%; margin-bottom: 1px;">
        <asp:Label ID="lblRecipeName" CssClass="recipeDisplayName" runat="server"></asp:Label>
        <div style="border-color: black; border-style: solid; padding: 1em; line-height: 200%; margin-bottom: 1px; width: 200px;">
            <asp:Image ID="RecipeImage" CssClass="imgRecipe" runat="server" Width="200px" />
        </div>
        <br />
        <asp:Label runat="server" ID="lblNumberOfSaves" Text=""></asp:Label>users have saved this recipe
        <h3>Main Ingredient
        </h3>
        <asp:Label runat="server" ID="lblMainIngredients" Text="Ingredients"></asp:Label>
        <h3>Cooking Method
        </h3>
        <asp:Label runat="server" ID="lblCookingMethod" Text="Cooking Method"></asp:Label>
        <h3>Food Category
        </h3>
        <asp:Label runat="server" ID="lblFoodCategory" Text="Food Categroy"></asp:Label>
        <h3>Servings
        </h3>
        <asp:Label runat="server" ID="lblServings" Text="Servings"></asp:Label>
        <h3>Cooking Time
        </h3>
        <asp:Label runat="server" ID="lblCookingTime" Text="Cooking Time"></asp:Label>
        <h3>Ingredients
        </h3>
        <asp:Label runat="server" ID="lblIngredient1" Text="Ingredients"></asp:Label>
        <asp:Label runat="server" ID="lblIngredient2" Text="Ingredients"></asp:Label>
        <asp:Label runat="server" ID="lblIngredient3" Text="Ingredients"></asp:Label>
        <asp:Label runat="server" ID="lblIngredient4" Text="Ingredients"></asp:Label>
        <asp:Label runat="server" ID="lblIngredient5" Text="Ingredients"></asp:Label>
        <asp:Label runat="server" ID="lblIngredient6" Text="Ingredients"></asp:Label>
        <asp:Label runat="server" ID="lblIngredient7" Text="Ingredients"></asp:Label>
        <asp:Label runat="server" ID="lblIngredient8" Text="Ingredients"></asp:Label>
        <h3>Instructions
        </h3>
        <asp:Label runat="server" ID="lblInstructions" Text="Instructions"></asp:Label>
    </div>
    <div id="ReviewSection" style="border-color: black; border-style: solid; padding: 1em; line-height: 200%; margin-bottom: 1px;">
        <div id="Review">
            <h2>Review
            </h2>
            <asp:TextBox runat="server" ID="txtReviewSection" TextMode="MultiLine" Rows="10" Width="100%"></asp:TextBox>
            <br />

            <asp:Button runat="server" ID="btnSubmitReview" Text="Submit Review" />
        </div>
        <div id="PastReviews" style="border-color: black; border-style: solid; padding: 1em; line-height: 200%; margin-bottom: 1px;">

            <asp:Label ID="lblDisplay" runat="server"></asp:Label>

        </div>
    </div>
</asp:Content>
