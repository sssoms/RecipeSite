<%@ Page Title="" Language="C#" MasterPageFile="~/RecipeSite.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="RecipeSite.SignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <h1>Sign Up
        </h1>
        <div>
            <asp:Label runat="server" ID="lblMessage"></asp:Label>
                <br />
            Username
            <asp:TextBox runat="server" ID="txtUsername"></asp:TextBox>
            <br />
            Password
            <asp:TextBox runat="server" ID="txtPassword"></asp:TextBox>            
            <br />
            Email
            <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>
            <br />
            First Name
            <asp:TextBox runat="server" ID="txtFirstName"></asp:TextBox>
            <br />
            Last Name
            <asp:TextBox runat="server" ID="txtLastName"></asp:TextBox>
            <br />
            Street
            <asp:TextBox runat="server" ID="txtStreet"></asp:TextBox>
            <br />
            City
            <asp:TextBox runat="server" ID="txtCity"></asp:TextBox>
            <br />
            State 
            <asp:DropDownList ID="DropDownListState" runat="server">
                <asp:ListItem Value="NN">Unselected</asp:ListItem>
                <asp:ListItem Value="AL">Alabama</asp:ListItem>
                <asp:ListItem Value="AK">Alaska</asp:ListItem>
                <asp:ListItem Value="AZ">Arizona</asp:ListItem>
                <asp:ListItem Value="AR">Arkansas</asp:ListItem>
                <asp:ListItem Value="CA">California</asp:ListItem>
                <asp:ListItem Value="CO">Colorado</asp:ListItem>
                <asp:ListItem Value="CT">Connecticut</asp:ListItem>
                <asp:ListItem Value="DC">District of Columbia</asp:ListItem>
                <asp:ListItem Value="DE">Delaware</asp:ListItem>
                <asp:ListItem Value="FL">Florida</asp:ListItem>
                <asp:ListItem Value="GA">Georgia</asp:ListItem>
                <asp:ListItem Value="HI">Hawaii</asp:ListItem>
                <asp:ListItem Value="ID">Idaho</asp:ListItem>
                <asp:ListItem Value="IL">Illinois</asp:ListItem>
                <asp:ListItem Value="IN">Indiana</asp:ListItem>
                <asp:ListItem Value="IA">Iowa</asp:ListItem>
                <asp:ListItem Value="KS">Kansas</asp:ListItem>
                <asp:ListItem Value="KY">Kentucky</asp:ListItem>
                <asp:ListItem Value="LA">Louisiana</asp:ListItem>
                <asp:ListItem Value="ME">Maine</asp:ListItem>
                <asp:ListItem Value="MD">Maryland</asp:ListItem>
                <asp:ListItem Value="MA">Massachusetts</asp:ListItem>
                <asp:ListItem Value="MI">Michigan</asp:ListItem>
                <asp:ListItem Value="MN">Minnesota</asp:ListItem>
                <asp:ListItem Value="MS">Mississippi</asp:ListItem>
                <asp:ListItem Value="MO">Missouri</asp:ListItem>
                <asp:ListItem Value="MT">Montana</asp:ListItem>
                <asp:ListItem Value="NE">Nebraska</asp:ListItem>
                <asp:ListItem Value="NV">Nevada</asp:ListItem>
                <asp:ListItem Value="NH">New Hampshire</asp:ListItem>
                <asp:ListItem Value="NJ">New Jersey</asp:ListItem>
                <asp:ListItem Value="NM">New Mexico</asp:ListItem>
                <asp:ListItem Value="NY">New York</asp:ListItem>
                <asp:ListItem Value="NC">North Carolina</asp:ListItem>
                <asp:ListItem Value="ND">North Dakota</asp:ListItem>
                <asp:ListItem Value="OH">Ohio</asp:ListItem>
                <asp:ListItem Value="OK">Oklahoma</asp:ListItem>
                <asp:ListItem Value="OR">Oregon</asp:ListItem>
                <asp:ListItem Value="PA">Pennsylvania</asp:ListItem>
                <asp:ListItem Value="RI">Rhode Island</asp:ListItem>
                <asp:ListItem Value="SC">South Carolina</asp:ListItem>
                <asp:ListItem Value="SD">South Dakota</asp:ListItem>
                <asp:ListItem Value="TN">Tennessee</asp:ListItem>
                <asp:ListItem Value="TX">Texas</asp:ListItem>
                <asp:ListItem Value="UT">Utah</asp:ListItem>
                <asp:ListItem Value="VT">Vermont</asp:ListItem>
                <asp:ListItem Value="VA">Virginia</asp:ListItem>
                <asp:ListItem Value="WA">Washington</asp:ListItem>
                <asp:ListItem Value="WV">West Virginia</asp:ListItem>
                <asp:ListItem Value="WI">Wisconsin</asp:ListItem>
                <asp:ListItem Value="WY">Wyoming</asp:ListItem>
            </asp:DropDownList>
            <br />

            <h3>Create security questions and their answers for account recovery</h3>
            <asp:Label ID="lblSecurityQuesiont1" runat="server"></asp:Label>
            <asp:TextBox ID="txtSecurityQuestion1" runat="server"></asp:TextBox>

            <asp:Label ID="lblSecurityAnswer1" runat="server"></asp:Label>
            <asp:TextBox ID="txtSecurityAnswer1" runat="server"></asp:TextBox>

            <asp:Label ID="lblSecurityQuestion2" runat="server"></asp:Label>
            <asp:TextBox ID="txtSecurityQuestion2" runat="server"></asp:TextBox>

            <asp:Label ID="lblSecurityAnswer2" runat="server"></asp:Label>
            <asp:TextBox ID="txtSecurityAnswer2" runat="server"></asp:TextBox>

            <asp:Label ID="lblSecurityQuestion3" runat="server"></asp:Label>
            <asp:TextBox ID="txtSecurityQuestion3" runat="server"></asp:TextBox>

            <asp:Label ID="lblSecurityAnswer3" runat="server"></asp:Label>
            <asp:TextBox ID="txtSecurityAnswer3" runat="server"></asp:TextBox>




            <asp:Button runat="server" id="btnSignUp" Text="Sign Up" OnClick="btnSignUp_Click"/>


    </div>
</asp:Content>
