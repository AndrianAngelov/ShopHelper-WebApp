<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Site.Master" AutoEventWireup="true"
    CodeBehind="Home.aspx.cs" Inherits="ShopHelperAsp.UI.Home" %>

<asp:Content ID="HomeHead" ContentPlaceHolderID="MainFormHead" runat="server">
    <script type="text/javascript">
//        window.history.pushState("object or string", "Title", "/HomePage");
////        window.history.replaceState("object or string", "Title", "/HomePage");
    </script>
</asp:Content>

<asp:Content ID="HomeContent1" ContentPlaceHolderID="MainFormContentPlaceHolder" runat="server">
    <div ID="homeContent" runat="server">
    </div>
</asp:Content>
