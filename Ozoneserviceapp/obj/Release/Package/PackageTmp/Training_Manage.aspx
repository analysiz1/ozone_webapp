<%@ Page Title="" Language="C#" MasterPageFile="~/Site_Main.Master" AutoEventWireup="true" CodeBehind="Training_Manage.aspx.cs" Inherits="Ozoneserviceapp.Training_Manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div align="center" >
        <br />
         <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-info" Text="สร้างหัวข้ออบรม" OnClick="btnAdd_Click"  />
         <br />     
         <br />   
        <asp:Label ID="lblTrainning" runat="server" Text="Label"></asp:Label>
       
       
    </div>

    <script>

        function btnedit(id)
        {
            window.location.assign("/Training_Edit.aspx?id=" + id);
        }
        function btndelete(tid) /*ลบการอบรม*/
        {
            if (confirm('คุณต้องการลบหัวข้ออบรม ใช่หรือไม่?')) {
                // window.location.assign("/testpage.aspx?id=" + id);
                var obj = {                   
                    'Tid': tid,
                    'Status': 11
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
                function OnComplete(result) {
                    var urlweb = "/Training_Manage.aspx";

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
        }
        function btnmanage(id)
        {
            window.location.assign("/ManageTrainning.aspx?id=" + id);
        }


    </script>
</asp:Content>
