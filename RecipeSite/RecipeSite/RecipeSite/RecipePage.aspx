<%@ Page Title="" Language="C#" MasterPageFile="~/RecipeSite.Master" AutoEventWireup="true" CodeBehind="RecipePage.aspx.cs" Inherits="RecipeSite.RecipePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="border-color: black; border-style: solid; padding: 1em; line-height: 200%; margin-bottom: 1px;">
        <div style="border-color: black; border-style: solid; padding: 1em; line-height: 200%; margin-bottom: 1px; width: 200px;">
            <asp:Image ID="RecipeImage" runat="server" ImageUrl="~/Images/NoImage.jpeg" Width="200px" />
        </div>
        <br />
        <asp:Label runat="server" ID="lblNumberOfSaves" Text=" X Users have saved this recipe"></asp:Label>
        <h3>Main Ingredient
        </h3>
        <asp:Label runat="server" ID="lblMainIngredients" Text="Ingredients"></asp:Label>
        <h3>Cooking Method
        </h3>
        <asp:Label runat="server" ID="lblCookingMethod" Text="Cooking Method"></asp:Label>
        <h3>Food Category
        </h3>
        <asp:Label runat="server" ID="lblFoodCategory" Text="Food Categroy"></asp:Label>
        <h3>Ingredients
        </h3>
        <asp:Label runat="server" ID="lblIngredients" Text="Ingredients"></asp:Label>
        <h3>Instructions
        </h3>
        <asp:Label runat="server" ID="lblInstructions" Text="Instructions"></asp:Label>
    </div>
    <div id="ReviewSection" style="border-color: black; border-style: solid; padding: 1em; line-height: 200%; margin-bottom: 1px;">
        <div id="Review">
            <h2>Review (might add option to add picture)
            </h2>
            <asp:TextBox runat="server" ID="txtReviewSection" TextMode="MultiLine" Rows="10" Width="100%"></asp:TextBox>
            <br />

            <asp:Button runat="server" ID="btnSubmitReview" Text="Submit Review" />
        </div>
        <div id="PastReviews" style="border-color: black; border-style: solid; padding: 1em; line-height: 200%; margin-bottom: 1px;">
            area to display reviews from other users
        </div>
    </div>
</asp:Content>
