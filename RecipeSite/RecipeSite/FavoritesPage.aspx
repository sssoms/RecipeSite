<%@ Page Title="" Language="C#" MasterPageFile="~/RecipeSite.Master" AutoEventWireup="true" CodeBehind="FavoritesPage.aspx.cs" Inherits="RecipeSite.FavoritesPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <th>Recipe ID</th>
            <th>Recipe Name</th>
        </tr>

        <asp:Repeater ID="rptRecipes" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label ID="lblRecipeID" runat="server">
                            Text='<%# DataBinder.Eval(Container.DataItem, "RecipeID") %>'>
                        </asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblRecipeName" runat="server"
                            Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName") %>'>

                        </asp:Label>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>
