<%@ Page Title="" Language="C#" MasterPageFile="~/Site_Main.Master" AutoEventWireup="true" CodeBehind="Training_Record.aspx.cs" Inherits="Ozoneservice.UI.Training.Training_Record" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">

        function EnterEvent(e) {

            if (!(e.keyCode >= 48 && e.keyCode <= 57)) {
                e.preventDefault();
            }
        }

    </script>

    <div>
        <table align="center" class="table table-strip">
            <tr>
                <td style="padding: 5px;">
                    <asp:Label ID="lblTitle" runat="server" Text="Label">หัวข้อ</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTitle" runat="server" Width="198px" CssClass="form-control"></asp:TextBox></td>

            </tr>

            <tr>
                <td style="padding: 5px;">
                    <asp:Label ID="lblOwner" runat="server" Text="Label">ผู้จัดการอบรม</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtOwner" runat="server" Width="198px" CssClass="form-control"></asp:TextBox></td>

            </tr>

            <tr>
                <td style="padding: 5px;">
                    <asp:Label ID="lblAddress" runat="server" Text="Label">สถานที่</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server" Width="198px" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td style="padding: 5px;">
                    <asp:Label ID="lblDateStart" runat="server" Text="Label">วันที่เริ่มอบรม</asp:Label>
                </td>
                <td>

                    <input type="text" name="dateStart" id="dateStart" class ="form-control" value="" runat="server" style="width: 198px;"  />
                    <asp:TextBox ID="tbDate" runat="server" type="date"></asp:TextBox> <!-- Date picker-->
                </td>
            </tr>

            <tr>
                <td style="padding: 5px;">
                    <asp:Label ID="lblDateEnd" runat="server" Text="Label">วันที่สิ้นสุดอบรม</asp:Label>
                </td>
                <td>
                    <input type="text" name="dateEnd" id="dateEnd"  class="form-control" value="" runat="server" style="width: 198px;"  />

                </td>
            </tr>

            <tr>
                <td style="padding: 5px;">
                    <asp:Label ID="lblParticipant" runat="server"  Text="Label">จำนวนผู้เข้าร่วม</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtParticipant" runat="server"  CssClass="form-control" Width="198px"
                        onkeypress="return EnterEvent(event)" MaxLength="2"></asp:TextBox>
                </td>
            </tr>

        </table>

        <table align="center">
            <tr>
                <td>    
                    <asp:Button ID="btnConfirm" runat="server" CssClass="btn btn-primary"   Text="Confirm" onclick="btnConfirm_Click" />
                </td>
                <td>
                    <asp:Button ID="btnClear" runat="server" CssClass="btn btn-danger"  Text="Clear" onclick="btnClear_Click" />
                </td>
            </tr>
        </table>
    </div>

</asp:Content>
