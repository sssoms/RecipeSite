<%@ Page Language="C#" MasterPageFile="~/RecipeSite.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="RecipeSite.ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align:center;">Reset Your Password</h1>
    <div class="containerSmall">
            <h3>Answer this security question to be verified first</h3>
            <br />
            <asp:Label ID="lblSecurityQuestion" runat="server" Text=""></asp:Label>
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <asp:TextBox CssClass="txtStyle" ID="txtSecurityAnswer" runat="server"></asp:TextBox>
            <br />
            <asp:Button CssClass="buttonStyle" ID="btnVerify" runat="server" Text="Verify" OnClick="btnVerify_Click" />

            <br />

            <asp:Label ID="lblError" runat="server"></asp:Label>
            <br />

            <asp:Label ID="lblResetPassword" runat="server" Text="Enter a new password" Visible="False"></asp:Label><br />
            <asp:TextBox CssClass="txtStyle" ID="txtPassword" runat="server" Visible="False"></asp:TextBox><br />
            <asp:Button CssClass="buttonStyle" ID="btnReset" runat="server" Text="Reset Password" Visible="False" OnClick="btnReset_Click" />
            <br />

            <asp:Label ID="lblResetSuccessful" runat="server" Text="You've successfully reset your password!" Visible="False"></asp:Label>
            <br />
            <asp:Button CssClass="buttonStyle" ID="btnReturn" runat="server" Text="Return to Login Page" OnClick="btnReturn_Click" Visible="False" />
        </div>
</asp:Content>

