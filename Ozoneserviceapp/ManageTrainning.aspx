<%@ Page Title="" Language="C#" MasterPageFile="~/Site_Main.Master" AutoEventWireup="true" CodeBehind="ManageTrainning.aspx.cs" Inherits="Ozoneservice.ManageTrainning" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
     
    <!-- <asp:Button  CssClass="btn btn-danger" style="margin-left:30px;" ID="Btncreate" runat="server" Text="สร้างหัวข้อการอบรม" OnClick="Btncreate_Click" />
    <br />
    <br />   
        <div class="form-group" style="width:20%; margin-left:30px;">
        <p>หัวข้ออบรม</p> <asp:DropDownList ID="ddl1" runat="server" CssClass="form-control" >
        <asp:ListItem>ยาเสพติด 1</asp:ListItem>
        <asp:ListItem>ยาเสพติด 2</asp:ListItem>
        <asp:ListItem>ยาเสพติด 3</asp:ListItem>
        <asp:ListItem>ยาเสพติด 4</asp:ListItem>
        </asp:DropDownList>      -->
      
       <div class="form-group" style="width:20%; margin-left:30px;">       

       <p>Drop In</p> <asp:DropDownList ID="ddl2" runat="server" CssClass="form-control">
        <asp:ListItem>ประชาชื่น</asp:ListItem>
        <asp:ListItem>เชียงใหม่</asp:ListItem>
        <asp:ListItem>เชียงราย</asp:ListItem>
        <asp:ListItem>สงขลา</asp:ListItem>
        </asp:DropDownList>
        <br />
        <p>ชื่อ-นามสกุลพนักงาน</p>
        <br />
        <asp:TextBox ID="txtEmpname" runat="server" CssClass="form-control"></asp:TextBox>
        <br />       
          <asp:Button CssClass="btn tn-primary"  ID="Btn_Search" runat="server" Text="ค้นหา" OnClick="Btn_Search_Click" />
    </div>
    
  
    <br />
    <br />
    <p>หัวข้ออบรม :  <asp:Label ID="TrainningName" runat="server" Text=""></asp:Label>   </p>
    <br />
    <asp:Label ID="lblEmp" runat="server" Text=""></asp:Label>

    <script type="text/javascript">
        function addtraining(id, status, tid) {
            // debugger;
            /*
           alert(ids);            
            alert(status);
            alert(tid);            
            */
            var obj = {
                'Empid': id,
                'Tid': tid,
                'Status': status
            }
            $.ajax({
                url: "Trainning_process.ashx",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: obj,
                responseType: "json",
                success: OnComplete,
                error: OnFail
            });
            //return false;
            function OnComplete(result) {
                // debugger;         
                console.log("Success");
               /*  var Emp_id = substring(result, 0, 3);
                 var StatusEmp = substring(result, 3, 2);              
            

                   if (statusEmp == 1) // blue --> red
                   {
                       $(Empid).removeClass("btn-primary").addClass("btn-danger");
                   }
                   else // red --> blue
                   {
                       $(Empid).removeClass("btn-danger").addClass("btn-primary");
                   }*/
                var urlweb = "/ManageTrainning.aspx?id=" + tid;
                alert(urlweb);
                $.ajax({
                    url: urlweb,
                    context: document.body,
                    success: function (s, x) {
                        $(this).html(s);
                    }
                });

            }

            function OnFail(result) {
                alert('Request Failed');
              

            }
        }
      
    </script>

    <script src="Scripts/jquery-3.1.0.js"></script>

</asp:Content>
