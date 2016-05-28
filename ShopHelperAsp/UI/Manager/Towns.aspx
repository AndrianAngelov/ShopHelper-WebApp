<%@ Page Title="" Language="C#" MasterPageFile="~/UI/SubForms.master" AutoEventWireup="true"
    CodeBehind="Towns.aspx.cs" Inherits="ShopHelperAsp.UI.Manager.Towns" %>

<asp:Content ID="townsHead" ContentPlaceHolderID="subFormsHead" runat="server">
    <script type="text/javascript">
        //        //    window.history.pushState("object or string", "Title", "/HomePage/Manager/Stores");
        //        window.history.replaceState("object or string", "Title", "/HomePage/Manager/Towns");
    </script>
</asp:Content>
<asp:Content ID="townsContent" ContentPlaceHolderID="subFormsContent" runat="server">
    <%--<div ID="tContent" runat="server">
    </div>--%>
    <h1>Здравейте вие сте в Towns старницата</h1>
</asp:Content>
