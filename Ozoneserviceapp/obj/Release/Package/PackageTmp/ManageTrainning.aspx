<%@ Page Title="" Language="C#" MasterPageFile="~/Site_Main.Master" AutoEventWireup="true" CodeBehind="ManageTrainning.aspx.cs" Inherits="Ozoneservice.ManageTrainning" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <div class="form-group" style="width:20%; margin-left:30px;">
        <p>จังหวัด</p> <asp:DropDownList ID="ddl1" runat="server" CssClass="form-control" >
        <asp:ListItem>กรุงเทพ</asp:ListItem>
        <asp:ListItem>เชียงใหม่</asp:ListItem>
        <asp:ListItem>เชียงราย</asp:ListItem>
        <asp:ListItem>สงขลา</asp:ListItem>
        </asp:DropDownList>
        <br />
       <p>Drop In</p> <asp:DropDownList ID="ddl2" runat="server" CssClass="form-control">
        <asp:ListItem>ประชาชื่น</asp:ListItem>
        <asp:ListItem>เชียงใหม่</asp:ListItem>
        <asp:ListItem>เชียงราย</asp:ListItem>
        <asp:ListItem>สงขลา</asp:ListItem>
        </asp:DropDownList>
        <br />
        <p>ชื่อ-นามสกุลพนักงาน</p>
        <br />
        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>

        <br />
        <br />
          <asp:Button CssClass="btn tn-primary"  ID="Btns" runat="server" Text="ค้นหา" />
    </div>
    
  
    <br />
    <br />
   <div class="table-responsive">
    <table  class="table table-hover "  style="margin-left:30px;"  >
        <tr class="headtable"><!-- Headtable -->
            <td>ลำดับ</td>
            <td>รหัสพนักงาน</td>            
            <td>คำนำหน้า</td>
            <td>ชื่อ-นามสกุล</td>
            <td>จังหวัด</td>
            <td>สำนักงาน/พื้นที่</td>            
            <td>ตำแหน่ง</td>
            <td></td>
        </tr>
        <tr><!-- Contentdata-->
            <td>1</td>
            <td>92324</td>            
            <td>นาย</td>
            <td>พีรพล ลิ้มทองคำ</td>
            <td>กรุงเทพ</td>
            <td>กรุงเทพ</td>            
            <td>เจ้าหน้าที่ IT</td>
            <td>
                <asp:Button ID="btn" runat="server" Text="เข้ารับการอบรม" CssClass="btn btn-primary"  />
            </td>        
        </tr>

        <tr><!-- Contentdata-->
            <td>2</td>
            <td>92324</td>            
            <td>นาย</td>
            <td>พีรพล ลิ้มทองคำ</td>
            <td>กรุงเทพ</td>
            <td>กรุงเทพ</td>            
            <td>เจ้าหน้าที่ IT</td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="เข้ารับการอบรม" CssClass="btn btn-primary"  />
            </td>
        
        </tr>

        <tr ><!-- Contentdata-->
            <td>3</td>
            <td>92324</td>            
            <td>นาย</td>
            <td>พีรพล ลิ้มทองคำ</td>
            <td>กรุงเทพ</td>
            <td>กรุงเทพ</td>            
            <td>เจ้าหน้าที่ IT</td>
            <td>
                <asp:Button ID="Button2" runat="server" Text="ยกเลิกการเข้าอบรม" CssClass="btn btn-danger"  />
            </td>
        
        </tr>

        <tr><!-- Contentdata-->
            <td>4</td>
            <td>92324</td>            
            <td>นาย</td>
            <td>พีรพล ลิ้มทองคำ</td>
            <td>กรุงเทพ</td>
            <td>กรุงเทพ</td>            
            <td>เจ้าหน้าที่ IT</td>
            <td>
                <asp:Button ID="Button3" runat="server" Text="ยกเลิกการเข้าอบรม" CssClass="btn btn-danger"  />
            </td>
        
        </tr>
       


    </table>
     </div>
</asp:Content>
