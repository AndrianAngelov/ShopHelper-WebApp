<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Site.Master" AutoEventWireup="true" ViewStateMode="Enabled"
    CodeBehind="Login.aspx.cs" Inherits="ShopHelperAsp.Login" ClientIDMode="Static" %>

<asp:Content ID="LoginHead" ContentPlaceHolderID="MainFormHead" runat="server">
    <meta name="description" content="ShopHelper-Login">
    <link href="../Css/Form_Login.css" rel="stylesheet" type="text/css" />
   <%-- <link href="../SVG/SVG_CSS/ShopHelper_Architecture.css" rel="stylesheet" type="text/css" />--%>
    <%--<?xml-stylesheet type="text/css" href="~/SVG/SVG_CSS/ShopHelper_Architecture.css" ?>--%>
</asp:Content>

<asp:Content ID="LoginContent" ContentPlaceHolderID="MainFormContentPlaceHolder" runat="server">

    <div id="login-decor">
        <p>
            Lorem Ipsum is simply dummy
            Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, 
            when an unknown printer took a galley of type and scrambled it to make a type specimen book. 
            It has survived not only five centuries, but also the leap into electronic typesetting, 
            remaining essentially unchanged.
        </p>
        <br />
        <p>
            Lorem Ipsum is simply dummy
            Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, 
        </p>
    </div>

    <div id="SVGContainer"> 
         <object id="object" data="../SVG/SVG.aspx" width="360" height="260"></object>
        <%-- <object id="object" data="../SVG/ShopHelper_Architecture.svg" type="image/svg+xml" width="360" height="260"></object>--%>
    </div>

    <div id="slick-login">
        <div id="login-header">
            <h1>Login Form</h1>
            <h3>Fill out the form below to login in Shop Helper</h3>
        </div>

        <div id="login-content" >
            <asp:Label ID="label_Username" runat="server" CssClass="loginLabel" Text="Username:" ClientIDMode="Static"
                AssociatedControlID="textBox_Username"></asp:Label>
            <asp:TextBox ID="textBox_Username" runat="server" CssClass="loginTextBox" TextMode="SingleLine" ClientIDMode="Static" ClientID="username"
                placeholder="username"></asp:TextBox>
            <asp:Label ID="label_Password" runat="server" CssClass="loginLabel" Text="Password:"
                AssociatedControlID="textBox_Password"></asp:Label>
            <asp:TextBox ID="textBox_Password" runat="server" CssClass="loginTextBox" TextMode="Password"
                placeholder="password"></asp:TextBox>
        </div>

        <div id="login-footer">
            <asp:Button ID="btn_Login" runat="server" OnClick="btn_Login_Click" Text="Login" />
            <div id="error-Mesage"><asp:Label ID="LabelErrorMsg" runat="server"></asp:Label></div>
        </div>
    </div>
</asp:Content>
