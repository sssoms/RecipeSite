<%@ Page Language="C#" MasterPageFile="~/RecipeSite.Master" AutoEventWireup="true" CodeBehind="SendEmail.aspx.cs" Inherits="RecipeSite.SendEmail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="text-align:center;">Trouble Logging In?</h2>
    <div class="containerSmall">
            <asp:Label ID="Label2" runat="server" Text="Please enter your registered email. We will send you a link to reset your password."></asp:Label>
            <br />
            <br />
            <asp:TextBox CssClass="txtStyle" ID="txtEmail" runat="server"></asp:TextBox>
            &nbsp;&nbsp;
            <asp:Button CssClass="buttonStyle" ID="Button1" runat="server" OnClick="btnSend_Click" Text="SEND" />
            <br />
            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <br />
        </div>
</asp:Content>
