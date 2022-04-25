<%@ Page Language="C#" MasterPageFile="~/RecipeSite.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="RecipeSite.LogIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .loginContainer{
            font-size: 16px;
            text-align: center;
            background-color: #F1F2F2;
            width: 30%;
            margin:auto;
            margin-top: 5rem;
            padding: 3rem;
        }
        a{
            font-size: 13px;
        }
        a.hyperLink {
            text-decoration: none;
        }
        a.hyperLink:visited {
            text-decoration: none;
        }
        .label {
            text-align: left;
        }
        table{
            margin:auto;
            text-align: left;
        }

    </style>

    <div class="loginContainer">
        <h1 style ="margin-top:0; padding-top:0;">Sign In</h1><br />
        <table>
            <tr>
                <td>
                    <asp:Label CssClass="label" ID="lblEmail" runat="server" Text="Email"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="padding-top:0;">
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label CssClass="label" ID="lblPassword" runat="server" Text="Password"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="padding-top:0;">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:HyperLink CssClass="hyperLink" ID="lnkSignUp" runat="server" href ="SignUp.aspx">Sign Up / </asp:HyperLink>
                </td>
                <td style="text-align: right;">
                    <asp:HyperLink CssClass="hyperLink" ID="lnkForgotPW" runat="server" href ="SendEmail.aspx">Forgot Password?</asp:HyperLink>
                </td>
            </tr>
        </table>
       
        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <asp:CheckBox ID="ckbRememberMe" runat="server" Text="Remember Me" />
        <br />
        <asp:Button CssClass="buttonStyle" ID="btnLogIn" runat="server" Text="Log In" OnClick="btnLogIn_Click" />
        <br />
    </div>
</asp:Content>
