<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RecipeCardDisplay.ascx.cs" Inherits="RecipeSite.RecipeCardDisplay" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<style>
        .recipeTable{
            margin:auto;
        }
        .recipeTable td{
            padding: 0.7rem;
            text-align: left;
        }
        .value{
            font-weight: bold;
        }
        .emptypng { 
             background-image: url(Images/emptyStarSm.png); 
             width: 25px; 
             height: 25px; 
        }
        .starpng { 
             background-image: url(Images/starSm.png); 
             width: 25px; 
             height: 25px; 
        }
        .doneStarpng { 
             background-image: url(Images/starSm.png); 
             width: 25px; 
             height: 25px; 
        }

</style>
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy>
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
        <tr>
            <td>
                <asp:Image ID="imgUserSavedNum" runat="server" Height="20px" ImageUrl="~/Images/heartIcon.png" />
                <asp:Label ID="lblUserSavedNum" runat="server"></asp:Label>
            </td>
            <td style="text-align:right;">
                <ajaxToolkit:Rating ID="Rating1" CssClassID="Rating1" runat="server" CurrentRating="0" MaxRating="5" EmptyStarCssClass="emptypng" FilledStarCssClass="starpng"
                        StarCssClass="starpng" WaitingStarCssClass="doneStarpng" Enabled="False" EnableTheming="False" ReadOnly="True"></ajaxToolkit:Rating>
            </td>
        </tr>
    </table>
    <br />
    <asp:Button CssClass="buttonStyle" ID="btnDetails" runat="server" Text="Click For Details" OnClick="btnDetails_Click" />&nbsp;&nbsp;
    <asp:Button CssClass="buttonStyle" ID="btnEdit" runat="server" Text="Edit" Visible="False" Enabled="False" OnClick="btnEdit_Click" />
    <br /><br />
</div>

