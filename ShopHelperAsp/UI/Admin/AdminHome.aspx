<%@ Page Title="" Language="C#" MasterPageFile="~/UI/SubForms.master" AutoEventWireup="true"
    CodeBehind="AdminHome.aspx.cs" Inherits="ShopHelperAsp.UI.Admin.AdminHome" %>

<asp:Content ID="adminHead" ContentPlaceHolderID="subFormsHead" runat="server">
</asp:Content>

<asp:Content ID="adminContent" ContentPlaceHolderID="subFormsContent" runat="server">
<asp:UpdatePanel ID="UpdatePanelCountriesTowns" UpdateMode="Conditional"
        runat="server" class="panel">
        <ContentTemplate>
            Controls inside an update panel causing partial postback:
            <br />
            <asp:DropDownList ID="DropDownListCountries" runat="server"
                DataTextField="Name" DataValueField="Name"
                AutoPostBack="true" OnSelectedIndexChanged="DropDownListCountries_Changed">
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownListTowns" runat="server"
                DataTextField="Name" DataValueField="Name">
            </asp:DropDownList>
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
