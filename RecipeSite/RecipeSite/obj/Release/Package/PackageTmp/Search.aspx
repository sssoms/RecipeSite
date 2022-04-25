<%@ Page Language="C#" MasterPageFile="~/RecipeSite.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="RecipeSite.Search" %>

<%@ Register Src ="RecipeCardDisplay.ascx" TagName="RecipeCardDisplay" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .container {
            width: 80%;
            margin: auto;
            padding: 1rem;
        }
        .boldfont{
            text-align: left; 
            font-family: 'Noto Sans-ExtraBold', sans-serif; 
            font-weight: 900; 
            font-size: 25px;
        }

        table {
            padding: .5rem;
        }

        td{
            font-weight: 500;
        }

    </style>   

    <div class ="container">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <h3>Find a Recipe</h3><br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            Search By
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSearchBy" runat="server" OnSelectedIndexChanged="ddlSearchBy_SelectedIndexChanged" AutoPostBack="True">
                                <asp:ListItem>Select</asp:ListItem>
                                <asp:ListItem>Main Ingredient</asp:ListItem>
                                <asp:ListItem>Cooking Method</asp:ListItem>
                                <asp:ListItem>Food Category</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblSelectedSearchBy" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSelectedSearchBy" runat="server" Visible="False"></asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>  
        </asp:UpdatePanel>
        <br />
        <asp:Button CssClass="buttonStyle" ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
    </div>
</asp:Content>
