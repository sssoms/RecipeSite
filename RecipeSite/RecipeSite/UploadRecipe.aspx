<%@ Page Language="C#" MasterPageFile="~/RecipeSite.Master" AutoEventWireup="true" CodeBehind="UploadRecipe.aspx.cs" Inherits="RecipeSite.UploadRecipe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        table{
            margin:auto;
        }
        td{
            padding: 0.7rem;
            font-weight: bold;
        }
        .auto-style1 {
            width: 650px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align:center;">Add Your Recipe</h1>
    <div class="container">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <table>
            <tr>
                <td>
                    Recipe Name
                </td>
                <td class="auto-style1">
                    <asp:TextBox CssClass="txtStyle" ID="txtRecipeName" runat="server" Width="250px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valRecipeName" ControlToValidate ="txtRecipeName" runat="server" ErrorMessage="* Required" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Upload Picture
                </td>
                <td class="auto-style1">
                    <asp:FileUpload ID="fulRecipeImg" runat="server" Width="188px" />
                    <asp:RequiredFieldValidator ID="valRecipeImg" ControlToValidate="fulRecipeImg" runat="server" ErrorMessage="* Required" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:Label ID="lblImgError" runat="server" Font-Size="Small" ForeColor="Red" Text="*Supported image formats: .jpg, .jpeg" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Main Ingredient
                </td>
                <td class="auto-style1">
                    <asp:DropDownList ID="ddlMainIngredient" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Cooking Method
                </td>
                <td class="auto-style1">
                    <asp:DropDownList ID="ddlCookingMethod" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Food Category
                </td>
                <td class="auto-style1">
                    <asp:DropDownList ID="ddlFoodCategory" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Servings
                </td>
                <td class="auto-style1">
                    <asp:DropDownList ID="ddlServing" runat="server">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Cooking Time
                </td>
                <td style="font-weight: normal;" class="auto-style1">
                    <asp:DropDownList ID="ddlCookingTime" runat="server"></asp:DropDownList>
                    min
                </td>
            </tr>
            <tr>
                
                <td>
                    Ingredients
                </td>
                <td class="auto-style1">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlIngredient1" runat="server"></asp:DropDownList><br />
                            <asp:DropDownList ID="ddlIngredient2" runat="server"></asp:DropDownList><br />
                            <asp:DropDownList ID="ddlIngredient3" runat="server"></asp:DropDownList><br />
                            <asp:DropDownList ID="ddlIngredient4" runat="server"></asp:DropDownList><br />
                            <asp:DropDownList ID="ddlIngredient5" runat="server"></asp:DropDownList><br />
                            <asp:DropDownList ID="ddlIngredient6" runat="server"></asp:DropDownList><br />
                            <asp:DropDownList ID="ddlIngredient7" runat="server"></asp:DropDownList><br />
                            <asp:DropDownList ID="ddlIngredient8" runat="server"></asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td>
                    Instructions
                </td>
                <td class="auto-style1" style="padding-right: 1px;">
                    1. <asp:TextBox CssClass="txtStyle" ID="txtInstruction1" runat="server" Rows="2" TextMode="MultiLine" Width="500px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valInstruction1" ControlToValidate="txtInstruction1" runat="server" ErrorMessage="* Required" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator><br />
                    2. <asp:TextBox CssClass="txtStyle" ID="txtInstruction2" runat="server" Rows="2" TextMode="MultiLine" Width="500px"></asp:TextBox><br />
                    3. <asp:TextBox CssClass="txtStyle" ID="txtInstruction3" runat="server" Rows="2" TextMode="MultiLine" Width="500px"></asp:TextBox><br />
                    4. <asp:TextBox CssClass="txtStyle" ID="txtInstruction4" runat="server" Rows="2" TextMode="MultiLine" Width="500px"></asp:TextBox><br />
                    5. <asp:TextBox CssClass="txtStyle" ID="txtInstruction5" runat="server" Rows="2" TextMode="MultiLine" Width="500px"></asp:TextBox><br />
                    6. <asp:TextBox CssClass="txtStyle" ID="txtInstruction6" runat="server" Rows="2" TextMode="MultiLine" Width="500px"></asp:TextBox><br />
                    7. <asp:TextBox CssClass="txtStyle" ID="txtInstruction7" runat="server" Rows="2" TextMode="MultiLine" Width="500px"></asp:TextBox><br />
                    8. <asp:TextBox CssClass="txtStyle" ID="txtInstruction8" runat="server" Rows="2" TextMode="MultiLine" Width="500px"></asp:TextBox><br />
                    9. <asp:TextBox CssClass="txtStyle" ID="txtInstruction9" runat="server" Rows="2" TextMode="MultiLine" Width="500px"></asp:TextBox><br />
                    10.<asp:TextBox CssClass="txtStyle" ID="txtInstruction10" runat="server" Rows="2" TextMode="MultiLine" Width="500px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button CssClass="buttonStyle" ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                </td>
            </tr>
        </table>
        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
    </div>
</asp:Content>
