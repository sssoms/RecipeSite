<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReviewCardDisplay.ascx.cs" Inherits="RecipeSite.ReviewCardDisplay" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<style>
        table{
            margin:auto;
        }
        td{
            padding: 0.7rem;
            text-align: left;
        }
        .value{
            font-weight: bold;
        }
        .emptypng { 
             background-image: url(Images/emptyStarSm.png); 
             width: 25px; 
             height: 25px; 
        }
        .starpng { 
             background-image: url(Images/starSm.png); 
             width: 25px; 
             height: 25px; 
        }
        .doneStarpng { 
             background-image: url(Images/starSm.png); 
             width: 25px; 
             height: 25px; 
        }

</style>

<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy>
<table cellpadding="6">
    <tr>
        <td>
           <asp:Label ID="lblReviewTitle" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <ajaxToolkit:Rating ID="Rating1" runat="server" CurrentRating="0" MaxRating="5" EmptyStarCssClass="emptypng" FilledStarCssClass="starpng"
                        StarCssClass="starpng" WaitingStarCssClass="doneStarpng" Enabled="False" EnableTheming="False" ReadOnly="True"></ajaxToolkit:Rating>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblReviewText" runat="server"></asp:Label>
        </td>
    </tr>
</table>
<div class="imgContainer">
    <asp:Image CssClass="imgRecipe" ID="imgRecipe" runat="server" />
</div>