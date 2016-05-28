<%@ Page Title="" Language="C#" MasterPageFile="~/UI/SubForms.master" 
AutoEventWireup="true" CodeBehind="RolesCenter.aspx.cs" Inherits="ShopHelperAsp.UI.Admin.RolesCenter" 
EnableEventValidation="false"%>
<%@ Import Namespace="ShopHelperAsp.Data.Entities" %>
<%@ Import Namespace="ShopHelperAsp.Data.BLL" %>

<asp:Content ID="rolesHead" ContentPlaceHolderID="subFormsHead" runat="server">
    <link href="../../Css/Form_RolesCenter.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="rolesContent" ContentPlaceHolderID="subFormsContent" runat="server">
    <div id="alert" title="">
    </div>

    <asp:ObjectDataSource ID="ObjectDataSourceApplications" runat="server" 
        SelectMethod="GetApplications" 
        TypeName="ShopHelperAsp.Data.BLL.ApplicationsBLL">
        <SelectParameters>
            <asp:Parameter DefaultValue="False" Name="includeOptionAll" Type="Object" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="ObjectDataSourceRoles" runat="server"
        SelectMethod="GetRolesApplications"
        TypeName="ShopHelperAsp.Data.BLL.RolesBLL">
    </asp:ObjectDataSource>

    <div id="PanelCreateDeleteRolesWrapper">
        <asp:Panel ID="PanelCreateNewRole" runat="server" CssClass="panelsContainers">
            <div id="PanelCreateNewRoleHeader" class="panelsHeaders">
                <h3>Insert new role</h3>
                <hr />
            </div>
            <asp:UpdatePanel id="UpdatePanelInsertNewRole" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ButtonCancelInsertRole" EventName="Click"/>
                </Triggers>
                <ContentTemplate>
                    <asp:UpdateProgress ID="LoaderNewRole" runat="server"
                        AssociatedUpdatePanelID="UpdatePanelInsertNewRole"
                        Visible="true" 
                        DisplayAfter="100" >
                        <ProgressTemplate >
                            <asp:Image ID="LoadImageNewRole" runat="server" ImageUrl="~/Images/loading.gif" />
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <div id="PanelCreateNewRoleContent" class="panelsContents" runat="server">
                        <asp:Label CssClass="panelsLabels row leftCol" runat="server" Text="Choose application:"></asp:Label>
                        <asp:DropDownList ID="DropDownApplicationsInsertRole" CssClass="panelsDropDowns row rightCol"
                            runat="server" DataSourceID="ObjectDataSourceApplications" DataTextField="ApplicationName"
                            DataValueField="ApplicationName" OnSelectedIndexChanged="DropDownApplicationsInsertRole_SelectedIndexChanged"
                            AutoPostBack="false">
                        </asp:DropDownList>
                        <asp:Label ID="LabelRoleName" CssClass="panelsLabels row leftCol" runat="server"
                            Text="RoleName:" AssociatedControlID="TextBoxRoleName"></asp:Label>
                        <asp:TextBox ID="TextBoxRoleName" CssClass="panelsTextBoxes row rightCol" runat="server"
                            TextMode="SingleLine" placeholder="role name"></asp:TextBox>
                        <p id="InsertNewRoleMessage" runat="server" visible="false">
                        </p>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="panelsFooters">
                <asp:Button ID="ButtonInsertRole" CssClass="buttons" runat="server" Text="Insert"
                    OnClick="ButtonInsertRole_Click" />
                <asp:Button ID="ButtonCancelInsertRole" CssClass="buttons" runat="server" Text="Cancel"
                    OnClick="ButtonCancelInsertRole_Click" />
            </div>
        </asp:Panel>

        <asp:Panel ID="PanelDeleteRole" runat="server" CssClass="panelsContainers">
            <div class="panelsHeaders">
                <h3>Delete role</h3>
                <hr />
            </div>
            <asp:UpdatePanel id="UpdatePanelDeleteRole" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ButtonCancelDeleteRole" EventName="Click"/>
                </Triggers>
                <ContentTemplate>
                    <asp:UpdateProgress ID="LoaderDeleteRole" runat="server"
                        AssociatedUpdatePanelID="UpdatePanelDeleteRole"
                        Visible="true" 
                        DisplayAfter="100" >
                        <ProgressTemplate >
                            <asp:Image ID="LoadImageDeleteRole" runat="server" ImageUrl="~/Images/loading.gif" />
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <div class="panelsContents">
                        <asp:Label CssClass="panelsLabels row leftCol" runat="server" Text="Choose application:"></asp:Label>
                        <asp:DropDownList ID="DropDownApplicationsDeleteRole" CssClass="panelsDropDowns row rughtCol"
                            runat="server" DataSourceID="ObjectDataSourceApplications" DataTextField="ApplicationName"
                            DataValueField="ApplicationName" AutoPostBack="true" OnSelectedIndexChanged="DropDownApplicationsDeleteRole_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:Label CssClass="panelsLabels row leftCol" runat="server" Text="Rols for Application:"></asp:Label>
                        <asp:CheckBoxList ID="CheckBoxListApplicationRoles" runat="server">
                        </asp:CheckBoxList>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="panelsFooters">
                <asp:Button ID="ButtonDeleteRole" CssClass="buttons" runat="server" Text="Delete"
                    OnClick="ButtonDeleteRole_Click" />
                <asp:Button ID="ButtonCancelDeleteRole" CssClass="buttons" runat="server" Text="Cancel"
                    OnClick="ButtonCancelDeleteRole_Click" />
            </div>
        </asp:Panel>
    </div>
    <div id="PanelEditAndGridViewRolesWrapper">
        <asp:Panel ID="PanelEditRole" runat="server" CssClass="panelsContainers">
            <div class="panelsHeaders">
                <h3>
                    Edit role</h3>
                <hr />
            </div>
            <asp:UpdatePanel ID="UpdatePanelEditRole" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ButtonCancelEditRole" EventName="Click" />
                </Triggers>
                <ContentTemplate>
                    <asp:UpdateProgress ID="LoaderEditeRole" runat="server" AssociatedUpdatePanelID="UpdatePanelEditRole"
                        Visible="true" DisplayAfter="100">
                        <ProgressTemplate>
                            <asp:Image ID="LoadImageEditRole" runat="server" ImageUrl="~/Images/loading.gif" />
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <div class="panelsContents">
                        <asp:Label ID="Label1" CssClass="panelsLabels row leftCol" runat="server" Text="Choose application:"></asp:Label>
                        <asp:DropDownList ID="DropDownApplicationsEditRole" CssClass="panelsDropDowns row rughtCol"
                            runat="server" DataSourceID="ObjectDataSourceApplications" DataTextField="ApplicationName"
                            DataValueField="ApplicationName" AutoPostBack="true" OnSelectedIndexChanged="DropDownApplicationsEditRole_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:Label ID="Label2" CssClass="panelsLabels row leftCol" runat="server" Text="Rols for Application:"></asp:Label>
                        <asp:CheckBoxList ID="CheckBoxListApplicationEditRoles" runat="server">
                        </asp:CheckBoxList>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="panelsFooters">
                <asp:Button ID="ButtonEditRole" CssClass="buttons" runat="server" Text="Delete" OnClick="ButtonEditRole_Click" />
                <asp:Button ID="ButtonCancelEditRole" CssClass="buttons" runat="server" Text="Cancel"
                    OnClick="ButtonCancelEditRole_Click" />
            </div>
        </asp:Panel>
        <asp:GridView ID="GridViewApplicationsRoles" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="ApplicationName" ControlStyle-CssClass="applicationsRolesHeader">
                    <ItemTemplate>
                        <asp:Literal ID="AppName" runat="server" Text='<%# ((Application)Container.DataItem).ApplicationName%>'></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Roles">
                    <ItemTemplate>
                        <asp:DataList ID="DataListRoles" runat="server" DataSource="<%# ((Application)Container.DataItem).ApplicationRoles%>">
                            <ItemTemplate>
                                <%# Container.DataItem %>
                            </ItemTemplate>
                        </asp:DataList>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div>
        <asp:Button ID="TestBtn" CssClass="buttons" runat="server" Text="Test"
                    OnClick="TestBtn_Click" />
    </div>
    <script type="text/javascript">
        function showCreateInsertRoleLoader() {
            var loaderInsertRole = $("#LoaderNewRole");
            loaderInsertRole.css("display", "block");
        }
        function showDeleteRoleLoader() {
            var loaderDeleteRole = $("#LoaderDeleteRole");
            loaderDeleteRole.css("display", "block");
        }

        $('#ButtonInsertRole').click(showCreateInsertRoleLoader);
        $('#ButtonDeleteRole').click(showDeleteRoleLoader);
        $('#ButtonCancelInsertRole').click(showCreateInsertRoleLoader);
        $('#ButtonCancelDeleteRole').click(showDeleteRoleLoader);

</script>
</asp:Content>
