<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RecipeCardDisplay.ascx.cs" Inherits="RecipeSite.RecipeCardDisplay" %>
<div class ="recipeCardDisplayContainer">
    <asp:Label ID="lblName" CssClass="recipeDisplayName" runat="server"></asp:Label>
    <br />
    <div class="imgContainer">
        <asp:Image CssClass="imgRecipe" ID="imgRecipe" runat="server" />
    </div>
    <table class="recipeTable" cellpadding ="6">
        <tr>
            <td>
                Main Ingredient
            </td>
            <td>
                <asp:Label ID="lblMainIngredient" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Cooking Method
            </td>
            <td>
                <asp:Label ID="lblCookingMethod" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Food Category
            </td>
            <td>
                <asp:Label ID="lblFoodCategory" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:Button ID="btnDetails" runat="server" Text="Click For Details" OnClick="btnDetails_Click" /><br /><br />
</div>

