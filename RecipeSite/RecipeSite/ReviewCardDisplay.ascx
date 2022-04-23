<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReviewCardDisplay.ascx.cs" Inherits="RecipeSite.WebUserControl1" %>
<asp:Label ID="lblName" runat="server"></asp:Label>
<br />
<div class="imgContainer">
    <asp:Image CssClass="imgRecipe" ID="imgRecipe" runat="server" />
</div>
<table cellpadding="6">
    <tr>
        <td>
            <asp:Label ID="lblReviewTitle" runat="server"></asp:Label>
        </td>
        <td>
           
        </td>
        <td>
            <asp:Label ID="lblReviewUsername" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblReviewText" runat="server"></asp:Label>
        </td>
    </tr>
</table>