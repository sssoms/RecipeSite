<%@ Page Title="" Language="C#" MasterPageFile="~/RecipeSite.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="RecipeSite.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class ="container">
    <h1>
        Welcome to RECIPEASY!
    </h1>
    <p>
        Here you can find recipes for any dish you can think of(not really).
    </p>

    </div>
</asp:Content>

<asp:Content CssClass="recipeContainer"  ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
