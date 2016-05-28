<%@ Page Title="" Language="C#" MasterPageFile="~/UI/SubForms.master" AutoEventWireup="true"
    CodeBehind="Stores.aspx.cs" Inherits="ShopHelperAsp.UI.Manager.Stores" %>

<asp:Content ID="storeHead" ContentPlaceHolderID="subFormsHead" runat="server">
    <script type="text/javascript">
//        //    window.history.pushState("object or string", "Title", "/HomePage/Manager/Stores");
//        window.history.replaceState("object or string", "Title", "/HomePage/Manager/Stores");
    </script>
</asp:Content>
<asp:Content ID="storeContent" ContentPlaceHolderID="subFormsContent" runat="server">
    <div ID="storesContent" runat="server">
    </div>
</asp:Content>
