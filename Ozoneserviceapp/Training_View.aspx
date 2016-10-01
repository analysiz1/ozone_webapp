<%@ Page Title="" Language="C#" MasterPageFile="~/Site_Main.Master" AutoEventWireup="true" CodeBehind="Training_View.aspx.cs" Inherits="Ozoneservice.UI.Training.Training_View" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display:block;" align="center">
            <table class="table table-bordered">
            <tr>
                <td style="padding: 5px;">
                    <asp:Label ID="lblTitle" runat="server" Text="Label">หัวข้อ</asp:Label>
                </td>
                <td><asp:DropDownList ID="ddlTitle" CssClass="form-control"  runat="server" onselectedindexchanged="btnSearch_Click" AutoPostBack="True"></asp:DropDownList></td>
                <td style="padding: 5px;">
                    <asp:Label ID="lblDateStart" runat="server" Text="Label" >วันที่เริ่มอบรม</asp:Label>
                </td> 
                <td>
                    <asp:TextBox ID="txtdateStart" CssClass="form-control" runat="server" readonly="true" Width="198px" ></asp:TextBox>
                </td>
            
                <td style="padding: 5px;">
                    <asp:Label ID="lblDateEnd" runat="server" Text="Label">วันที่สิ้นสุดอบรม</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtdateEnd" CssClass="form-control" runat="server" readonly="true" Width="198px" ></asp:TextBox>
                </td>  
            </tr>

            <tr>
                <td style="padding: 5px;">
                    <asp:Label ID="lblAddress" runat="server" Text="Label">สถานที่</asp:Label>
                </td>
                <td>  
                    <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server" readonly="true" Width="198px" ></asp:TextBox>
                </td>
           
                <td style="padding: 5px;">
                    <asp:Label ID="lblOwner" runat="server" Text="Label">ผู้จัดการอบรม</asp:Label>
                </td>
                <td><asp:TextBox ID="txtOwner" CssClass="form-control" runat="server" readonly="true" Width="198px"></asp:TextBox></td>
            
                <td style="padding: 5px;">
                    <asp:Label ID="lblParticipant" runat="server" Text="Label">เป้าหมายผู้เข้าอบรม</asp:Label>
                </td>
                <td> 
                    <asp:TextBox ID="txtParticipant" CssClass="form-control" readonly="true" runat="server" Width="198px" 
                        onkeypress="return EnterEvent(event)" MaxLength="2"></asp:TextBox>
                </td>
            </tr>
            
            </table>

        <%--<asp:Button ID="btnSearch" runat="server" Text="ค้นหา" CssClass="btn btn-primary" OnClick="btnSearch_Click" />--%> 
        <br />


        <asp:Label ID="lblTraining_View" runat="server" Text=""></asp:Label>

            
        <script type="text/javascript">
            function addtraining(id, status, tid) {
                // debugger; 
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
                    var drop = 1;
                    console.log("Success");  
                    console.log("Add person complete");

                    var urlweb = "/Training_View.aspx?id="+tid;
                    window.location.assign(urlweb);

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
                    //var urlweb = "/ManageTrainning.aspx?id=" + tid;
              
                  /*  $.ajax({
                        url: urlweb,
                        context: document.body,
                        success: function (s, x) {
                            $(this).html(s);
                        }
                    });*/

                }

                function OnFail(result) {
                    alert('Request Failed');
              

                }
            }
      
    </script>

    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>

        </div>
</asp:Content>
