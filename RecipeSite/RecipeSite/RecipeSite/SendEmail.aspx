<%@ Page Language="C#" MasterPageFile="~/RecipeSite.Master" AutoEventWireup="true" CodeBehind="SendEmail.aspx.cs" Inherits="RecipeSite.SendEmail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div>
            Trouble Logging In?<br />
            <asp:Label ID="Label2" runat="server" Text="Please enter your registered email. We will send you a link to reset your password."></asp:Label>
            <br />
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblError" runat="server"></asp:Label>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="btnSend_Click" Text="SEND" />
            <br />
        </div>
</asp:Content>
