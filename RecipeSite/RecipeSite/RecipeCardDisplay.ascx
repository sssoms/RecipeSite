<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RecipeCardDisplay.ascx.cs" Inherits="RecipeSite.RecipeCardDisplay" %>
<style>
        table{
            margin:auto;
        }
        td{
            padding: 0.7rem;
            text-align: left;
        }
        .value{
            font-weight: bold;
        }

</style>
<div class ="recipeCardDisplayContainer">
    <asp:Label ID="lblName" CssClass="recipeDisplayName" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
    <br />
    <div class="imgContainer">
        <asp:Image CssClass="imgRecipe" ID="imgRecipe" runat="server" />
    </div>
    <table class="recipeTable" cellpadding ="6">
        <tr>
            <td>
                Main Ingredient
            </td>
            <td class="value">
                <asp:Label ID="lblMainIngredient" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Cooking Method
            </td>
            <td class="value">
                <asp:Label ID="lblCookingMethod" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Food Category
            </td>
            <td class="value">
                <asp:Label ID="lblFoodCategory" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:Image ID="imgUserSavedNum" runat="server" Height="20px" ImageUrl="~/Images/heartIcon.png" />
    <asp:Label ID="lblUserSavedNum" runat="server"></asp:Label>
&nbsp;&nbsp;
    <asp:Label ID="lblStarRating" runat="server"></asp:Label>
    <br />
    <asp:Button CssClass="buttonStyle" ID="btnDetails" runat="server" Text="Click For Details" OnClick="btnDetails_Click" /><br /><br />
</div>

