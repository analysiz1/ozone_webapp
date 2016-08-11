<%@ Page Title="" Language="C#" MasterPageFile="~/Site_Main.Master" AutoEventWireup="true" CodeBehind="Report2-1.aspx.cs" Inherits="Ozoneservice.Report2_1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table  class="table table-bordered "  style="margin-left:30px;"  >
       <tr class="headtable"><!-- Headtable -->
            <td>รหัสผู้เข้าร่วม</td>
            <td>OO_2224</td>                                
        </tr>                      
         <tr class="headtable"><!-- Headtable -->
            <td>ชื่อ-นามสกุล</td>
            <td>นายพีรพล ลิ้มทองคำ</td>                                
        </tr>
        <tr class="headtable"><!-- Headtable -->
            <td>สถานะ</td>
            <td>ปฏิบัติงาน</td>                                
        </tr>
        <tr class="headtable"><!-- Headtable -->
            <td>ตำแหน่ง</td>
            <td>เจ้าหน้าที่ IT</td>                                
        </tr>
        <tr class="headtable"><!-- Headtable -->
            <td>จังหวัด</td>
            <td>กรุงเทพ</td>                                
        </tr>
        

        </table>

    <h2 style="margin-left:30px;">ประวัติการอบรม</h2>
    <table  class="table table-hover "  style="margin-left:30px;"  >
        <tr class="headtable"><!-- Headtable -->
            <td>ลำดับ</td>
            <td>เรื่อง/หัวข้อ</td>
            <td>จำนวนครั้งที่เข้าร่วมการอบรม</td>                        
        </tr>

        <tr class="headtable"><!-- Content -->
            <td>1</td>
            <td>ต่อต้านยาเสพติด</td>
            <td>2 ครั้ง</td>                        
        </tr>
        <tr class="headtable"><!-- Content -->
            <td>2</td>
            <td>การเลิกยา</td>
            <td>2 ครั้ง</td>                        
        </tr>
        <tr class="headtable"><!-- Content -->
            <td>3</td>
            <td>การป้องกันภัยจากยาเสพติด</td>
            <td>2 ครั้ง</td>                        
        </tr>
        </table>

    <button onclick="goBack()" style="margin-left:30px;"  class="btn btn-primary" >Back</button>

<script>
    function goBack() {
        window.history.back();
    }
</script>

</asp:Content>
