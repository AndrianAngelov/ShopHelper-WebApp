<%@ Page Title="" Language="C#" MasterPageFile="~/UI/SubForms.master" AutoEventWireup="true"
    CodeBehind="UsersAccounts.aspx.cs" Inherits="ShopHelperAsp.UI.Admin.UsersAccounts" 
    EnableEventValidation="false"  
    MaintainScrollPositionOnPostback="true" %>
<%--<%@ MasterType 
    virtualpath="~/UI/Admin/Admin.master" 
%>--%>
<%@ Import Namespace="ShopHelperAsp.Data.Entities" %>
<%@ Import Namespace="ShopHelperAsp.Data.BLL" %>

<asp:Content ID="usersAccountsHead" ContentPlaceHolderID="subFormsHead" runat="server">
    <link href="../../Css/Form_UsersAccounts.css" rel="stylesheet" type="text/css" />
    <link href="../../Css/Validation.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/ExternalLibs/jquery.fileDownload.js" type="text/javascript"></script>
    <%--<meta http-equiv="Refresh" content="2"/>--%>
    <script type="text/javascript">
        function previewFile() 
        {
            var preview = document.querySelector('#<%=ProfileImage.ClientID %>');
            var file = document.querySelector('#<%=UploadProfileImage.ClientID %>').files[0];
            var reader = new FileReader();

            reader.onloadend = function () 
            {
                preview.src = reader.result;
            }

            if (file) 
            {
                reader.readAsDataURL(file);
            }
            else 
            {
                preview.src = "";
            }
        }

        function previewFileEdit() 
        {
            var preview = document.querySelector('#ProfileImageEdit');
            var file = document.querySelector('#UploadProfileImageEdit').files[0];
            var reader = new FileReader();

            reader.onloadend = function () 
            {
                preview.src = reader.result;
            }

            if (file) 
            {
                reader.readAsDataURL(file);
            }
            else 
            {
                preview.src = "";
            }
        }
    </script>
</asp:Content>

<asp:Content ID="usersAccountsContent" ContentPlaceHolderID="subFormsContent" runat="server">
    <div id="alert" title="">
    </div>

    <asp:ObjectDataSource ID="ObjectDataSourceApplications" runat="server" 
        SelectMethod="GetApplications" 
        TypeName="ShopHelperAsp.Data.BLL.ApplicationsBLL">
        <SelectParameters>
            <asp:Parameter DefaultValue="False" Name="includeOptionAll" Type="Object" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="ObjectDataSourceAllOption" runat="server" 
        SelectMethod="GetApplications" 
        TypeName="ShopHelperAsp.Data.BLL.ApplicationsBLL">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="includeOptionAll" Type="Object" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <div ID="InsertUserContainer" class="panelsContainers" >
        <div id="InsertUserHeader" class="panelsHeaders">
            <h3 class="panelHeaderTitele">
                Insert new user</h3>
            <hr />
        </div>
        <div id="InsertUserContent" class="panelsContents" runat="server">
            <asp:UpdateProgress ID="LoaderNewUser" runat="server"
                AssociatedUpdatePanelID="UpdatePanelInserNewUser"
                Visible="true" 
                DisplayAfter="100" >
                <ProgressTemplate >
                    <asp:Image ID="LoadImageNewUser" runat="server" ImageUrl="~/Images/loading.gif" />
                </ProgressTemplate>
            </asp:UpdateProgress>

            <div id="ImageContainer">
                <asp:Image ID="ProfileImage" runat="server" Height="50px" Width="50px" />
            </div>
            <input ID="UploadProfileImage" type="file" name="file" onchange="previewFile()" runat="server" />
                    
            <asp:Label ID="LabelUsername" runat="server" CssClass="panelsLabels row leftCol"
                Text="Username:" AssociatedControlID="TextBoxUsername"></asp:Label>
            <asp:TextBox ID="TextBoxUsername" runat="server" 
                CssClass="panelsTextBoxes row rightCol"
                TextMode="SingleLine" 
                placeholder="username" 
                CausesValidation="true"
                ValidationGroup="ValidationGroupNames">
            </asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorFirstName" CssClass="validationMessage" runat="server" ControlToValidate="TextBoxUsername"
                ErrorMessage="RequiredFieldValidator" ValidationGroup="ValidationGroupNames"><span class="validationArrow"></span>Required field!</asp:RequiredFieldValidator>
            
            <asp:Label ID="LabelPassword" runat="server" CssClass="panelsLabels row leftCol"
                Text="Password:" AssociatedControlID="TextBoxPassword"></asp:Label>
            <asp:TextBox ID="TextBoxPassword" runat="server" CssClass="panelsTextBoxes row rightCol"
                TextMode="SingleLine" placeholder="password" CausesValidation="true">
            </asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserPassword" CssClass="validationMessage" runat="server" ControlToValidate="TextBoxPassword"
                    ErrorMessage="RequiredFieldValidator" ValidationGroup="ValidationGroupNames"><span class="validationArrow"></span>Required field!</asp:RequiredFieldValidator>

            <asp:UpdatePanel ID="UpdatePanelInserNewUser" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="DropDownApplicationNewUser" EventName="SelectedIndexChanged" />
                    <%--<asp:AsyncPostBackTrigger ControlID="ButtonCancel" EventName="Click" />--%>
                </Triggers>
                <ContentTemplate>
                    <asp:Label runat="server" CssClass="panelsLabels row leftCol" Text="Choose application:"></asp:Label>
                    <asp:DropDownList ID="DropDownApplicationNewUser" CssClass="panelsDropDowns row rightCol"
                        runat="server" AutoPostBack="true" DataSourceID="ObjectDataSourceApplications"
                        DataTextField="ApplicationName" DataValueField="ApplicationName" OnSelectedIndexChanged="DropDownApplicationNewUser_SelectedIndexChanged"
                        onchange="showCreateUserLoader()">
                    </asp:DropDownList>
                    <asp:Label runat="server" CssClass="panelsLabels row leftCol" Text="Add User To Role:"></asp:Label>
                    <asp:CheckBoxList ID="CheckBoxListApplicationRoles" runat="server">
                    </asp:CheckBoxList>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="validationMessage" runat="server" ControlToValidate="TextBoxUsername"
            ErrorMessage="RequiredFieldValidator" ValidationGroup="ValidationGroupNames"><span class="validationArrow"></span>Required field!</asp:RequiredFieldValidator>--%>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:Panel id="rolesIsValid" runat="server" Visible="false"><asp:Panel id="editNameIsValid" runat="server" ></asp:Panel>Required field!</asp:Panel>
        </div>
        <div id="InsertUserFooter" class="panelsFooters">
            <asp:Button ID="ButtonInsert" CssClass="accountsButtons" runat="server" Text="Insert"
                OnClick="ButtonInsert_Click" />
            <asp:Button ID="ButtonCancel" CssClass="accountsButtons" runat="server" 
                Text="Cancel" OnClick="ButtonCancel_Click" OnClientClick="hideValidationMsg()"/>
        </div>
    </div>

    <div id="PageInfoUsersAccounts" class="pageInfo">
        <h3>Users Accounts</h3>
        <p>
            Тук можете да управлявате служителите в
            цялата мрежа от офиси използващи <strong>Shop Helper-Inventory Management System</strong>.
        </p>
        <ul>
            <li><h4>Insert New User</h4>
                <ul>
                    <li>Възможност за добавяне на снимка към всеки потребител</li>
                    <li>Бързо избиране на необходимия офис</li>
                    <li>Добре защитена GUID паролас</li>
                    <li>Добавяне на потребител към роля от списъка с роли за съответния офис</li>
                </ul>
            </li>
            <li><h4>Edit,Delete,Update Exist Users</h4>
                <ul>
                    <li>Възможност за добавяне на снимка към всеки потребител</li>
                    <li>Бързо избиране на необходимия офис</li>
                    <li>Бързо избиране на необходимия офис</li>
                </ul>
            </li>
        </ul>
       
    </div>

    <div id="Users-wrapper">
        <asp:UpdatePanel Id="UpdatePanelUsers" runat="server" UpdateMode="Conditional" >
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="DropDownApplications" EventName="SelectedIndexChanged"/>
                <asp:PostBackTrigger ControlID="ButtonExportToPDF"/>
                <%--<asp:PostBackTrigger ControlID="ButtonUpdate"/>--%>
            </Triggers>
            <ContentTemplate>
            <div id="Users-container" class="panaelsContainers">
                <div id="UsersHeader" class="panaelsHeaders">
                    <h3 class="panaelsHeadersTitles">
                        <asp:Literal ID="UsersHeaderTitle" runat="server"></asp:Literal></h3>
                    <hr />
                    <asp:DropDownList ID="DropDownApplications" runat="server" 
                        AutoPostBack="True" 
                        DataSourceID="ObjectDataSourceAllOption"
                        DataTextField="ApplicationName" 
                        DataValueField="ApplicationName" 
                        OnSelectedIndexChanged="DropDownApplications_SelectedIndexChanged"
                        onchange="showListViewLoader()">
                    </asp:DropDownList>
                    <asp:Button ID="ButtonExportToPDF" runat="server" Text="Export to PDF" 
                    OnClick="ButtonExportToPDF_Click" OnClientClick="showListViewLoader()"/>
                </div>
                
                <asp:ListView ID="ListViewUsers" runat="server" OnItemEditing="ListViewUsers_ItemEditing"
                    OnItemCanceling="ListViewUsers_ItemCanceling" OnItemDeleting="ListViewUsers_ItemDeleting"
                    OnItemUpdating="ListViewUsers_ItemUpdating">
                    <LayoutTemplate>
                        <div id="UsersContent" class="panelsContents">
                            <asp:UpdateProgress ID="Loader" runat="server"
                                AssociatedUpdatePanelID="UpdatePanelUsers"
                                Visible="true" 
                                DisplayAfter="100" >
                                <ProgressTemplate >
                                    <asp:Image ID="LoadImage" runat="server" 
                                    ImageUrl="~/Images/loading.gif" />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                        </div>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <div class="users-items">
                            <div class="items-headers">
                                <div class="imgContainer">
                                    <asp:Image ID="UserImage" runat="server" Height="50px" Width="50" ImageUrl='<%# ((UserApplication)Container.DataItem).ProfileImageURL %>' />
                                </div>
                                <div id="UsersItemsHeaderTextWrapper">
                                    <h4>
                                        <asp:Label ID="LiteralUserName" runat="server" Text='<%# ((UserApplication)Container.DataItem).UserName %>'>
                                        </asp:Label>
                                    </h4>
                                    <h5>
                                        <asp:Label ID="LiteralUserRoles" runat="server" Text='<%# ((UserApplication)Container.DataItem).UserRolesString %>'>
                                        </asp:Label>
                                    </h5>
                                </div>
                            </div>
                            <ul>
                                <li>
                                    <h5>AppName:</h5>
                                    <asp:Literal ID="LiteralAppName" runat="server" Text='<%# ((UserApplication)Container.DataItem).AppName %>'>
                                    </asp:Literal>
                                </li>
                                <li>
                                    <h5>
                                        IsOnline:</h5>
                                    <%# ((UserApplication)Container.DataItem).IsOnline%></li>
                                <li>
                                    <h5>
                                        LastActivityDate:</h5>
                                    <%# ((UserApplication)Container.DataItem).LastActivityDate.ToString("d MMM yyyy", System.Globalization.CultureInfo.InvariantCulture)%></li>
                                <li>
                                    <h5>
                                        CreationDate:</h5>
                                    <%# ((UserApplication)Container.DataItem).CreationDate.ToString("d MMM yyyy", System.Globalization.CultureInfo.InvariantCulture)%></li>
                            </ul>
                            <div id="item-footer">
                                <asp:Button ID="ButtonEdit" CssClass="accountsButtons" runat="server" CommandName="Edit"
                                    Text="Edit" />
                                <asp:Button ID="ButtonDelete" CssClass="accountsButtons" runat="server" CommandName="Delete"
                                    Text="Delete" />
                            </div>
                        </div>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <div class="users-items">
                            <div class="items-headers items-headers-edit">
                                <div class="imgContainer">
                                    <asp:Image ID="ProfileImageEdit" runat="server" Height="50px" Width="50px" 
                                    ImageUrl='<%# ((UserApplication)((ListViewItem)Container).DataItem).ProfileImageURL %>' 
                                    CausesValidation="false"/>
                                </div>
                                <%--<span id="editNameContainerIsValid" runat="server"><span id="editNameIsValid" runat="server"></span>Required field!</span>--%>
                                <asp:Panel id="editNameContainerIsValid" runat="server"><asp:Panel id="editNameIsValid" runat="server"></asp:Panel>Required field!</asp:Panel>
                                <input ID="UploadProfileImageEdit" type="file" name="file" onchange="previewFileEdit()"
                                    runat="server" CausesValidation="false"/>
                                
                            <asp:UpdatePanel id="UpdatePanelEdit" runat="server">
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="ButtonUpdate"/>
                                </Triggers>
                                <ContentTemplate>
                                    <div id="EditUserNameContainer">
                                        <asp:Label ID="LabelEditUserName" CssClass="row leftCol" runat="server" Text="Username:"
                                            AssociatedControlID="TextBoxUsernameEdit"></asp:Label>
                                        <asp:TextBox ID="TextBoxUsernameEdit" CssClass="row rightCol" runat="server" 
                                        Text='<%# ((UserApplication)((ListViewItem)Container).DataItem).UserName %>'/>
                                        <asp:Literal ID="LiteralOldUserName" runat="server" Text='<%# ((UserApplication)((ListViewItem)Container).DataItem).UserName %>'
                                            Visible="false"></asp:Literal>

                                        <asp:Label ID="LabelResetPassword" CssClass="row leftCol" runat="server" Text="ResetPassword:"
                                            AssociatedControlID="TextBoxResetPassword"></asp:Label>
                                        <asp:TextBox ID="TextBoxResetPassword" CssClass="row rightCol" runat="server"/>

                                        <asp:Label ID="Label1" runat="server" CssClass="row leftCol" Text="RolesOfUser:" AssociatedControlID="CheckBoxListRolesOfUser"></asp:Label>
                                        <asp:CheckBoxList ID="CheckBoxListRolesOfUser" runat="server" CausesValidation="false">
                                        </asp:CheckBoxList>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            </div>
                            <ul>
                                <li>
                                    <h5>AppName:</h5>
                                    <asp:Literal ID="LiteralAppNameEdit" runat="server" Text='<%# ((UserApplication)((ListViewItem)Container).DataItem).AppName %>'>
                                    </asp:Literal>
                                </li>
                                <li>
                                    <h5>
                                        IsOnline:</h5>
                                    <%# ((UserApplication)((ListViewItem)Container).DataItem).IsOnline%></li>
                                <li>
                                    <h5>
                                        LastActivityDate:</h5>
                                    <%# ((UserApplication)((ListViewItem)Container).DataItem).LastActivityDate.ToString("d MMM yyyy", System.Globalization.CultureInfo.InvariantCulture)%></li>
                                <li>
                                    <h5>
                                        CreationDate:</h5>
                                    <%# ((UserApplication)((ListViewItem)Container).DataItem).CreationDate.ToString("d MMM yyyy", System.Globalization.CultureInfo.InvariantCulture)%></li>
                            </ul>
                            <div id="item-footer">
                                <asp:Button ID="ButtonUpdate" CssClass="accountsButtons" runat="server" CommandName="Update"
                                    Text="Update" OnClientClick="showListViewLoader()"/>
                                <asp:Button ID="ButtonCancelEdit" CssClass="accountsButtons" runat="server" CommandName="Cancel"
                                    Text="Cancel"/>
                            </div>
                        </div>
                    </EditItemTemplate>
                </asp:ListView>
                <div id="DataPagerUsersContainer" class="panelsFooters">
                    <asp:DataPager ID="DataPagerUsers" runat="server" PagedControlID="ListViewUsers"
                        PageSize="6" OnPreRender="DataPagerUsers_PreRender">
                        <Fields>
                            <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowNextPageButton="false"
                                ShowPreviousPageButton="false" />
                            <asp:NumericPagerField />
                            <asp:NextPreviousPagerField ShowLastPageButton="true" ShowNextPageButton="false"
                                ShowPreviousPageButton="false" />
                        </Fields>
                    </asp:DataPager>
                </div>
            </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    <asp:Panel ID="Panel1" runat="server">
       <%-- <asp:Button ID="testBtn" runat="server" Text="testBtn" OnClick="testBtn_Click" OnClientClick="window.open('http://res.cloudinary.com/hzgrm4rdh/image/upload/PDFs/UsersTest.pdf')" />--%>
       
        <asp:Button ID="testBtn" runat="server" Text="testBtn" OnClick="testBtn_Click"/>
       <%-- <asp:Button ID="testBtn" runat="server" Text="testBtn" OnClick="testBtn_Click" OnClientClick="getPdf()" />--%>
    </asp:Panel>
    <asp:HiddenField ID="savePdfVersion" runat="server" />
    </div>

    <script type="text/javascript">
        function showCreateUserLoader() {
            var loaderNewUser = $("#LoaderNewUser");
            loaderNewUser.css("display", "block");
        }
        function showListViewLoader() {
            var loaderUsers = $("#Loader");
            loaderUsers.css("display", "block");
        }
        function hideListViewLoader() {
            var loaderUsers = $("#Loader");
            loaderUsers.css("display", "none");
        }


        $('#ButtonCancel').click(showCreateUserLoader);
        $('#ButtonInsert').click(showCreateUserLoader);
        $('#ButtonExportToPDF').click(showListViewLoader());

        function getPdf() {
            var pdfVersion = $('#savePdfVersion').val();
            var pdfPath = 'http://res.cloudinary.com/hzgrm4rdh/image/upload/' + pdfVersion + '/PDFs/Users.pdf';
            window.open(pdfPath,'_blank');
        }
        function hideValidationMsg() {
            var validationMsg = $(".validationMessageContainer");
            validationMsg.css("visibility", "hidden");
        }
        function showValidationMsg() {
            var validationMsg = $(".validationMessageContainer");
            validationMsg.css("visibility", "visible");
        }

        function showValidationMsgEditMode() {
            var validationMsg = $(".editNameContainerIsValid");
            validationMsg.css("visibility", "visible");
        }

        pageLoad = function () {
            $('#Loader').hide();
        };
    </script>
    <div>
        <asp:Literal ID="TestLiteral" runat="server" Text="text"></asp:Literal></div>
</asp:Content>
