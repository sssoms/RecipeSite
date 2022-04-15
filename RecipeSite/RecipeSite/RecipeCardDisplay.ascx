<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RecipeCardDisplay.ascx.cs" Inherits="RecipeSite.RecipeCardDisplay" %>
<asp:Label ID="lblName" runat="server"></asp:Label>
<br />
<asp:Image ID="imgRecipe" runat="server" />
<br />
<table cellpaddin="6">
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
<asp:Button ID="btnDetails" runat="server" Text="Click For Details" />


