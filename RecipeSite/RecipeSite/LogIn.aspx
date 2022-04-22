<%@ Page Language="C#" MasterPageFile="~/RecipeSite.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="RecipeSite.LogIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div>
            <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
            <br />
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
            <br />
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <asp:HyperLink ID="lnkSignUp" runat="server" href ="SignUp.aspx">Sign Up</asp:HyperLink>
            <asp:HyperLink ID="lnkForgotPW" runat="server" href ="SendEmail.aspx">Forgot Password?</asp:HyperLink>
            <br />
            <asp:Label ID="lblError" runat="server"></asp:Label>
            <br />
            <asp:CheckBox ID="ckbRememberMe" runat="server" Text="Remember Me" />
            <br />
            <asp:Button ID="btnLogIn" runat="server" Text="Log In" OnClick="btnLogIn_Click" />
            <br />
        </div>
</asp:Content>
