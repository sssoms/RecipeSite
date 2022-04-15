<%@ Page Language="C#" MasterPageFile="~/RecipeSite.Master" AutoEventWireup="true" CodeBehind="UploadRecipe.aspx.cs" Inherits="RecipeSite.UploadRecipe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Add Your Recipe</h2>
        <table>
            <tr>
                <td>
                    Recipe Name
                </td>
                <td>
                    <asp:TextBox ID="txtRecipeName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Main Ingredient
                </td>
                <td>
                    <asp:DropDownList ID="ddlMainIngredient" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Cooking Method
                </td>
                <td>
                    <asp:DropDownList ID="ddlCookingMethod" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Food Category
                </td>
                <td>
                    <asp:DropDownList ID="ddlFoodCategory" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Servings
                </td>
                <td>
                    <asp:TextBox ID="txtServings" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Cooking Time
                </td>
                <td>
                    <asp:TextBox ID="txtCookingTime" runat="server"></asp:TextBox>min
                </td>
            </tr>
            <tr>
                <td>
                    Ingredients
                </td>
                <td>
                    <asp:DropDownList ID="ddlIngredient1" runat="server"></asp:DropDownList><br />
                    <asp:DropDownList ID="ddlIngredient2" runat="server"></asp:DropDownList><br />
                    <asp:DropDownList ID="ddlIngredient3" runat="server"></asp:DropDownList><br />
                    <asp:DropDownList ID="ddlIngredient4" runat="server"></asp:DropDownList><br />
                    <asp:DropDownList ID="ddlIngredient5" runat="server"></asp:DropDownList><br />
                    <asp:DropDownList ID="ddlIngredient6" runat="server"></asp:DropDownList><br />
                    <asp:DropDownList ID="ddlIngredient7" runat="server"></asp:DropDownList><br />
                    <asp:DropDownList ID="ddlIngredient8" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Instructions
                </td>
                <td>
                    <asp:TextBox ID="txtInstruction1" runat="server"></asp:TextBox><br />
                    <asp:TextBox ID="txtInstruction2" runat="server"></asp:TextBox><br />
                    <asp:TextBox ID="txtInstruction3" runat="server"></asp:TextBox><br />
                    <asp:TextBox ID="txtInstruction4" runat="server"></asp:TextBox><br />
                    <asp:TextBox ID="txtInstruction5" runat="server"></asp:TextBox><br />
                    <asp:TextBox ID="txtInstruction6" runat="server"></asp:TextBox><br />
                    <asp:TextBox ID="txtInstruction7" runat="server"></asp:TextBox><br />
                    <asp:TextBox ID="txtInstruction8" runat="server"></asp:TextBox><br />
                    <asp:TextBox ID="txtInstruction9" runat="server"></asp:TextBox><br />
                    <asp:TextBox ID="txtInstruction10" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
