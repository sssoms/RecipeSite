<%@ Page Language="C#" MasterPageFile="~/RecipeSite.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="RecipeSite.ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div style="width: 80%; margin:auto; padding:1rem;">
            <h1>Reset Your Password</h1><br />
            <h3>Answer this security question to be verified first</h3>
            <br />
            <asp:Label ID="lblSecurityQuestion" runat="server" Text=""></asp:Label>
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <asp:TextBox ID="txtSecurityAnswer" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnVerify" runat="server" Text="Verify" OnClick="btnVerify_Click" />

            <br />

            <asp:Label ID="lblError" runat="server"></asp:Label>
            <br />

            <asp:Label ID="lblResetPassword" runat="server" Text="Enter a new password" Visible="False"></asp:Label><br />
            <asp:TextBox ID="txtPassword" runat="server" Visible="False"></asp:TextBox><br />
            <asp:Button ID="btnReset" runat="server" Text="Reset Password" Visible="False" OnClick="btnReset_Click" />
            <br />

            <asp:Label ID="lblResetSuccessful" runat="server" Text="You've successfully reset your password!" Visible="False"></asp:Label>
            <br />
            <asp:Button ID="btnReturn" runat="server" Text="Return to Login Page" OnClick="btnReturn_Click" Visible="False" />
        </div>
</asp:Content>

