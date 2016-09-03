<%@ Page Title="" Language="C#" MasterPageFile="~/Site_Main.Master" AutoEventWireup="true" CodeBehind="Training_Manage.aspx.cs" Inherits="Ozoneserviceapp.Training_Manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div align="center" >
        
        <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary" Text="สร้างหัวข้อใหม่" OnClick="btnAdd_Click"  />
        <br />
        <asp:Label ID="lblTrainning" runat="server" Text="Label"></asp:Label>
         <%--<%System.Data.DataTable dtTitle = dtTitleTraining;%>--%> 
        <!--<table style="border: 1px solid #000; width: 80%;" align="center" class="table-condensed">
            <tr >
                <td style="border: 1px solid #333; width: 60% ; align="center">
                    <p align ="center">ชื่อหัวข้อ</p>
                </td>
                <td style="border: 1px solid #333; width: 10% ; align="center">
                </td>
                <td style="border: 1px solid #333; width: 10% ; align="center">
                </td>
                <td  style="border: 1px solid #333; width: 10% ; align="center">

                </td>
            </tr>
            <%//foreach(System.Data.DataRow dr in dtTitleTraining.Rows)
              //{%>
                <tr>
                    <td style="border: 1px solid #333; width: 50% ; align="center">
                    <p align ="center"><%//Response.Write(dr["Trainning_Name"].ToString()); %>&nbsp ครั้งที่ &nbsp<% //Response.Write(dr["Trainning_no"].ToString());%> </p>
                    </td>
                    <td style="border: 1px solid #333; width: auto ; align="center">
                        <asp:Button ID="btnEdit"  runat="server" CssClass="btn btn-primary" value="" Text="แก้ไข" align ="center" />
                    </td>
                    <td style="border: 1px solid #333; width: auto ; align="center">
                        <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-primary" value="" Text="ลบ" align ="center" OnClientClick="return confirm('คุณต้องการบหัวข้อการอบรมนี้ ใช่หรือไม่ ?');" OnClick="btnDelete_Click"/>
                    </td>
                    <td>                                             
                      
                    </td>
                </tr>
            <%//} %>
        </table>-->
    </div>

    <script>

        function btnedit(id)
        {
          
            window.location.assign("/testpage.aspx?id="+id);

        }
        function btndelete(tid)
        {
            var status = 3;
            var obj = {                
                'Tid': tid,
                'Status': status
            }
            //   window.location.assign("/testpage.aspx?id=" + id);
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
                console.log("Delete Success");           

            }

            function OnFail(result) {
                alert('Request Failed');


            }
        }
        function btnmanage(id)
        {
            window.location.assign("/ManageTrainning.aspx?id=" + id);
        }


    </script>
    <script src="Scripts/jquery-3.1.0.js"></script>
</asp:Content>
