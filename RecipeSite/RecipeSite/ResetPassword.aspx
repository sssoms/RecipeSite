<%@ Page Language="C#" MasterPageFile="~/RecipeSite.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="RecipeSite.ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .giveMargin{
            margin-bottom: 1rem;
        }
        .auto-style1 {
            width: 45%;
            margin: auto;
        }
    </style>

    <h1 style="text-align:center;">Reset Your Password</h1>
    <div class="auto-style1">
        <asp:Label ID="Label1" runat="server" Text="Answer this security question to be verified first" Font-Bold="True" Font-Size="Large"></asp:Label>
        <br />
        <br />

                <asp:Label CssClass="giveMargin" ID="lblSecurityQuestion" runat="server" Text=""></asp:Label><br />
                <asp:TextBox CssClass="txtStyle" ID="txtSecurityAnswer" runat="server"></asp:TextBox>
                <asp:Button CssClass="buttonStyle" ID="btnVerify" runat="server" Text="Verify" OnClick="btnVerify_Click" />

        
        <br />
        <asp:TextBox CssClass="txtStyle" ID="txtPassword" runat="server" Visible="False" TextMode="Password"></asp:TextBox>
        <asp:Button CssClass="buttonStyle" ID="btnReset" runat="server" Text="Reset Password" Visible="False" OnClick="btnReset_Click" />
        <br />

        <asp:Button CssClass="buttonStyle" ID="btnReturn" runat="server" Text="Return to Login Page" OnClick="btnReturn_Click" Visible="False" />
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label>
    </div>
</asp:Content>

