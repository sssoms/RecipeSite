<%@ Page Language="C#" MasterPageFile="~/RecipeSite.Master" AutoEventWireup="true" CodeBehind="UploadRecipe.aspx.cs" Inherits="RecipeSite.UploadRecipe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <h2>Add Your Recipe</h2>
        <table>
            <tr>
                <td>
                    Recipe Name
                </td>
                <td>
                    <asp:TextBox ID="txtRecipeName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valRecipeName" ControlToValidate ="txtRecipeName" runat="server" ErrorMessage="* Required" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Upload Picture
                </td>
                <td>
                    <asp:FileUpload ID="fulRecipeImg" runat="server" Width="188px" />
                    <asp:RequiredFieldValidator ID="valRecipeImg" ControlToValidate="fulRecipeImg" runat="server" ErrorMessage="* Required" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:Label ID="lblImgError" runat="server" Font-Size="Small" ForeColor="Red" Text="*Supported image formats: .jpg, .jpeg" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Main Ingredient
                </td>
                <td>
                    <asp:DropDownList ID="ddlMainIngredient" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Cooking Method
                </td>
                <td>
                    <asp:DropDownList ID="ddlCookingMethod" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Food Category
                </td>
                <td>
                    <asp:DropDownList ID="ddlFoodCategory" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Servings
                </td>
                <td>
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
                <td>
                    <asp:DropDownList ID="ddlCookingTime" runat="server"></asp:DropDownList>
                    min
                </td>
            </tr>
            <tr>
                
                <td>
                    Ingredients
                </td>
                <td>
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
                <td>
                    <asp:TextBox ID="txtInstruction1" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valInstruction1" ControlToValidate="txtInstruction1" runat="server" ErrorMessage="* Required" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator><br />
                    <asp:TextBox ID="txtInstruction2" runat="server"></asp:TextBox><br />
                    <asp:TextBox ID="txtInstruction3" runat="server"></asp:TextBox><br />
                    <asp:TextBox ID="txtInstruction4" runat="server"></asp:TextBox><br />
                    <asp:TextBox ID="txtInstruction5" runat="server"></asp:TextBox><br />
                    <asp:TextBox ID="txtInstruction6" runat="server"></asp:TextBox><br />
                    <asp:TextBox ID="txtInstruction7" runat="server"></asp:TextBox><br />
                    <asp:TextBox ID="txtInstruction8" runat="server"></asp:TextBox><br />
                    <asp:TextBox ID="txtInstruction9" runat="server"></asp:TextBox><br />
                    <asp:TextBox ID="txtInstruction10" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:Button ID="btnSaveDraft" runat="server" Text="Save Draft" />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
    </div>
</asp:Content>
