<%@ Page Title="" Language="C#" MasterPageFile="~/RecipeSite.Master" AutoEventWireup="true" CodeBehind="MyIngredientsListPage.aspx.cs" Inherits="RecipeSite.MyIngredientsListPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="lblDisplay" runat="server" Text=""></asp:Label>
    <table>
        <tr>
            <th>Ingredient ID</th>
            <th>Ingredient Name</th>
            <th>Remove</th>
        </tr>

        <asp:Repeater ID="rptIngredients" runat="server" OnItemCommand="rptIngredients_ItemCommand" >
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label ID="lblIngredientID" runat="server">
                            Text='<%# DataBinder.Eval(Container.DataItem, "Ingredient ID") %>'>
                        </asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblIngredientName" runat="server"
                            Text='<%# DataBinder.Eval(Container.DataItem, "Ingredient Name") %>'>

                        </asp:Label>
                    </td>
                    <td>
                        <asp:Button ID="btnRemove" Text="Remove Ingredient" runat="server" />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>
