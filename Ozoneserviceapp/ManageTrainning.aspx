<%@ Page Title="" Language="C#" MasterPageFile="~/Site_Main.Master" AutoEventWireup="true" CodeBehind="ManageTrainning.aspx.cs" Inherits="Ozoneservice.ManageTrainning" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
     
  
      
       <div class="form-group" style="width:20%; margin-left:30px;">       

       <p>Drop In</p> <asp:DropDownList ID="ddl2" runat="server" CssClass="form-control" DataSourceID="SqlDataSource2" DataTextField="DropinName" DataValueField="DropinID" OnSelectedIndexChanged="ddl2_SelectedIndexChanged" AutoPostBack="True">
           <asp:ListItem Selected="True" Value="0">Dropin</asp:ListItem>
        </asp:DropDownList>
           <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Ozoneservice_dbConnectionString %>" SelectCommand="SELECT * FROM [tbDropin]"></asp:SqlDataSource>
           <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Ozoneservice_dbConnectionString %>" SelectCommand="SELECT [DropinName] FROM [tbDropin]"></asp:SqlDataSource>
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
              //  alert(urlweb);
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

    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>

</asp:Content>
