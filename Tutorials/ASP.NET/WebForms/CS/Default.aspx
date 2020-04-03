<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="Default.aspx.cs" Inherits="AspNetWebFormsApplication._Default" %>

<%@ Register assembly="DevExpress.Xpo.v20.1, Version=20.1.1.0, Culture=neutral, PublicKeyToken=B88D1754D700E49A" namespace="DevExpress.Xpo" tagprefix="cc1" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Customers</h1>

    <dx:ASPxButton ID="btnNewCustomer" runat="server" Text="Add New Customer" OnClick="btnNewCustomer_Click" />

    <dx:ASPxGridView ID="CustomerGrid" runat="server" KeyFieldName="Oid" AutoGenerateColumns="False" DataSourceID="CustomerDataSource" 
        SettingsBehavior-ConfirmDelete="true"
        SettingsEditing-Mode="PopupEditForm"
        SettingsPopup-EditForm-HorizontalAlign="WindowCenter"
        SettingsPopup-EditForm-VerticalAlign="WindowCenter"
        SettingsLoadingPanel-Mode="ShowAsPopup"
        SettingsLoadingPanel-Delay="0"
        Settings-ShowHeaderFilterButton="true"
        SettingsEditing-EditFormColumnCount="1"
        SettingsText-PopupEditFormCaption="Edit Customer" 
        OnInitNewRow="CustomerGrid_InitNewRow">
        <Columns>
            <dx:GridViewCommandColumn VisibleIndex="0" ShowEditButton="true" ShowDeleteButton="true">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn Caption="Oid" FieldName="Oid" ReadOnly="True" PropertiesTextEdit-ValidationSettings-RequiredField-IsRequired="true" VisibleIndex="1" SortOrder="Descending">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="First Name" FieldName="FirstName" PropertiesTextEdit-ValidationSettings-RequiredField-IsRequired="true" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Last Name" FieldName="LastName" PropertiesTextEdit-ValidationSettings-RequiredField-IsRequired="true" VisibleIndex="3">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataColumn EditFormSettings-Visible="False">
                <DataItemTemplate>
                    <dx:ASPxButton runat="server" Text="Orders" OnClick="btnEditOrders_Click"></dx:ASPxButton>
                </DataItemTemplate>
            </dx:GridViewDataColumn>
        </Columns>
    </dx:ASPxGridView>

    <asp:HiddenField ID="CustomerIdHiddenField" runat="server" Value="-1" />

    <dx:ASPxPopupControl ID="OrderPopup" runat="server" PopupHorizontalOffset="16" PopupVerticalOffset="16" Width="800" AllowDragging="true" 
        CloseAction="CloseButton" HeaderText="Orders" Modal="true">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxButton ID="btnNewOrder" runat="server" Text="Add New Order" OnClick="btnNewOrder_Click" />
                <dx:ASPxGridView ID="OrderGrid" runat="server" KeyFieldName="Oid" DataSourceID="OrderDataSource" AutoGenerateColumns="false"
                    OnBeforePerformDataSelect="OrderGrid_BeforePerformDataSelect"
                    SettingsBehavior-ConfirmDelete="true"
                    SettingsEditing-Mode="PopupEditForm"
                    SettingsPopup-EditForm-HorizontalAlign="WindowCenter"
                    SettingsPopup-EditForm-VerticalAlign="WindowCenter"
                    SettingsLoadingPanel-Mode="ShowAsPopup"
                    SettingsLoadingPanel-Delay="0"
                    Settings-ShowHeaderFilterButton="true"
                    SettingsEditing-EditFormColumnCount="1"
                    SettingsText-PopupEditFormCaption="Edit Order" 
                    OnInitNewRow="OrderGrid_InitNewRow">
                    <SettingsEditing EditFormColumnCount="1" Mode="PopupEditForm"></SettingsEditing>
                    <Settings ShowHeaderFilterButton="True"></Settings>
                    <SettingsBehavior ConfirmDelete="True"></SettingsBehavior>
                    <SettingsPopup>
                        <EditForm HorizontalAlign="WindowCenter" VerticalAlign="WindowCenter"></EditForm>
                    </SettingsPopup>
                    <SettingsLoadingPanel Mode="ShowAsPopup" Delay="0"></SettingsLoadingPanel>
                    <SettingsText PopupEditFormCaption="Edit Order"></SettingsText>
                    <Columns>
                        <dx:GridViewCommandColumn VisibleIndex="0" ShowEditButton="true" ShowDeleteButton="true">
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn Caption="Oid" FieldName="Oid" ReadOnly="True" PropertiesTextEdit-ValidationSettings-RequiredField-IsRequired="true" VisibleIndex="1" SortOrder="Descending">
                            <PropertiesTextEdit>
                                <ValidationSettings>
                                    <RequiredField IsRequired="True"></RequiredField>
                                </ValidationSettings>
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn Caption="Order Date" FieldName="OrderDate" PropertiesDateEdit-ValidationSettings-RequiredField-IsRequired="true" VisibleIndex="2">
                            <PropertiesDateEdit>
                                <ValidationSettings>
                                    <RequiredField IsRequired="True"></RequiredField>
                                </ValidationSettings>
                            </PropertiesDateEdit>
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn Caption="Product Name" FieldName="ProductName" PropertiesTextEdit-ValidationSettings-RequiredField-IsRequired="true" VisibleIndex="3">
                            <PropertiesTextEdit>
                                <ValidationSettings>
                                    <RequiredField IsRequired="True"></RequiredField>
                                </ValidationSettings>
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataSpinEditColumn Caption="Freight" FieldName="Freight" PropertiesSpinEdit-ValidationSettings-RequiredField-IsRequired="true" VisibleIndex="4">
                            <PropertiesSpinEdit DisplayFormatString="g">
                                <ValidationSettings>
                                    <RequiredField IsRequired="True"></RequiredField>
                                </ValidationSettings>
                            </PropertiesSpinEdit>
                        </dx:GridViewDataSpinEditColumn>
                        <dx:GridViewDataComboBoxColumn Caption="Customer" FieldName="Customer!Key" VisibleIndex="5">
                            <PropertiesComboBox DataSourceID="CustomerDataSource" TextField="ContactName" ValueField="Oid" ValueType="System.Int32" />
                        </dx:GridViewDataComboBoxColumn>
                    </Columns>
                </dx:ASPxGridView>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>

    <cc1:XpoDataSource ID="CustomerDataSource" runat="server" 
        ServerMode="true" TypeName="XpoTutorial.Customer">
    </cc1:XpoDataSource>

    <cc1:XpoDataSource ID="OrderDataSource" runat="server" 
        ServerMode="true"
        Criteria="Customer.Oid=?" TypeName="XpoTutorial.Order">
        <CriteriaParameters>
            <asp:SessionParameter Name="p0" SessionField="OrderListCustomerOid" />
        </CriteriaParameters>
    </cc1:XpoDataSource>

</asp:Content>