<%@ Page Title="" Language="C#" MasterPageFile="~/Site_Main.Master" AutoEventWireup="true" CodeBehind="EditEmployee.aspx.cs" Inherits="Ozoneserviceapp.EditEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblID" runat="server" Text="" Visible ="false"></asp:Label>
    
    <div class="form-group" style="padding-left:20px;">
    <br />
    คำนำหน้า : <asp:DropDownList CssClass="dropdown" ID="ddlTitle" runat="server">
        <asp:ListItem Value="1">นาย</asp:ListItem>
        <asp:ListItem Value="2">นาง</asp:ListItem>
        <asp:ListItem Value="3">นางสาว</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    <span>ชื่อ-นามสกุล : </span><asp:TextBox CssClass="form-control" ID="txtName" Width="20%" runat="server"></asp:TextBox>
    <br />
    ตำแหน่ง : <asp:DropDownList ID="ddlRole" runat="server" CssClass="dropdown" DataSourceID="sqlrole" DataTextField="RoleName" DataValueField="RoleId"></asp:DropDownList>
    <asp:SqlDataSource ID="sqlRole" runat="server" ConnectionString="<%$ ConnectionStrings:Ozoneservice_dbConnectionString %>" SelectCommand="SELECT * FROM [tbEmployeeRole]"></asp:SqlDataSource>
    <br />
    <br />
    Dropin : <asp:DropDownList ID="ddlDropin" runat="server" CssClass="dropdown" DataSourceID="SqlDataSource1" DataTextField="DropinName" DataValueField="DropinID"></asp:DropDownList>
    <asp:SqlDataSource ID="sqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Ozoneservice_dbConnectionString %>" SelectCommand="SELECT * FROM [tbDropin]"></asp:SqlDataSource>
    <br />
    <br />
    <asp:Button ID="btnUpdate" runat="server" Text="บันทึกข้อมูล" CssClass="btn btn-primary" OnClick="btnUpdate_Click"  />

    </div>
</asp:Content>
