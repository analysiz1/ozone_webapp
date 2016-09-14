<%@ Page Title="" Language="C#" MasterPageFile="~/Site_Main.Master" AutoEventWireup="true" CodeBehind="Report_EmpDetail.aspx.cs" Inherits="Ozoneservice.Report2_1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h2 style="margin-left:30px;">ข้อมูลพนักงาน</h2>
    <asp:Label ID="EmpDetail" runat="server" Text=""></asp:Label>

    <h2 style="margin-left:30px;">ประวัติการอบรม</h2>
    <asp:Label ID="EmpTrain" runat="server" Text="Label"></asp:Label>

    <button onclick="goBack()" style="margin-left:30px;"  class="btn btn-primary" >Back</button>

<script>
    function goBack() {
        window.history.back();
    }
</script>

</asp:Content>
