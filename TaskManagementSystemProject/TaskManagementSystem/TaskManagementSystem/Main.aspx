<%@ Page Language="C#" AutoEventWireup="true"  CodeBehind="Main.aspx.cs"  Inherits="TaskManagementSystem.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
</head>
<body>
    <form id="form1" runat="server">

        <div>
   <dx:ASPxGridView ID="ASPxGridView1" runat="server" Width="100%" AutoGenerateColumns="False"
    KeyFieldName="Task_Id"
    OnRowInserting="ASPxGridView1_RowInserting"
    OnRowUpdating="ASPxGridView1_RowUpdating" 
    OnRowDeleting="ASPxGridView1_RowDeleting"
    OnInitNewRow="ASPxGridView1_InitNewRow"
    OnStartRowEditing="ASPxGridView1_StartRowEditing"
    OnHeaderFilterFillItems="ASPxGridView1_HeaderFilterFillItems"      
    OnProcessColumnAutoFilter="ASPxGridView1_ProcessColumnAutoFilter"
    OnDataBinding="ASPxGridView1_DataBinding">
    
       <Settings ShowHeaderFilterButton="True" ShowGroupPanel="True" />
       <SettingsEditing Mode="EditFormAndDisplayRow" />
       <Settings ShowFilterRow="true" />
       <Settings ShowFilterBar="Auto" />
       <SettingsBehavior AllowFocusedRow="true" />
       <SettingsSearchPanel Visible="True"></SettingsSearchPanel>
       <Columns>
           <dx:GridViewCommandColumn VisibleIndex="1"
               ShowEditButton="True"
               ShowNewButtonInHeader="True"
               ShowDeleteButton="True" />

        <dx:GridViewDataTextColumn FieldName="Task_Id" Visible="false" >
            <Settings AllowDragDrop="True"></Settings>
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="Title" Caption="Title" VisibleIndex="2" Settings-AllowHeaderFilter="True"  PropertiesTextEdit-ValidationSettings-RequiredField-IsRequired="true"/>
        <dx:GridViewDataTextColumn FieldName="Description" Caption="Description" VisibleIndex="4" PropertiesTextEdit-ValidationSettings-RequiredField-IsRequired="true" />
        <dx:GridViewDataComboBoxColumn FieldName="StatusName" Caption="Status" VisibleIndex="3">
            <PropertiesComboBox
                ValueType="System.Int32"
                TextField="StatusName"
                ValueField="Status_Id"
                EnableCallbackMode="true">
            </PropertiesComboBox>
            <EditFormSettings Visible="True" />
        </dx:GridViewDataComboBoxColumn>
        <dx:GridViewDataTextColumn FieldName="CreatedBy" Caption="CreatedBy" VisibleIndex="5" />
        <dx:GridViewDataTextColumn FieldName="AssignedTo" Caption="AssignedTo" VisibleIndex="6" PropertiesTextEdit-ValidationSettings-RequiredField-IsRequired="true" />
        <dx:GridViewDataTextColumn FieldName="CreatedAt" Visible="false" Caption="CreatedAt" VisibleIndex="0" />

    </Columns>
</dx:ASPxGridView>

        </div>
    </form>
</body>
</html>
