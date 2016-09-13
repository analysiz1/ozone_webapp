<%@ Page Title="" Language="C#" MasterPageFile="~/Site_Main.Master" AutoEventWireup="true" CodeBehind="Training_Edit.aspx.cs" Inherits="Ozoneserviceapp.Training_Edit" %>
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
        <asp:Label ID="lblID" runat="server" Text="" Visible ="false"></asp:Label>
        <table align="center" class="table table-strip">
            <tr>
                <td style="padding: 5px;">
                    <asp:Label ID="lblTitle" runat="server" Text="Label">หัวข้อ</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTitle" runat="server" Width="198px" CssClass="form-control" Enabled="False"></asp:TextBox>
                </td>
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
                    <asp:TextBox ID="txtStartDate" runat="server" Width="198px" CssClass="form-control" type="date"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td style="padding: 5px;">
                    <asp:Label ID="lblDateEnd" runat="server" Text="Label">วันที่สิ้นสุดอบรม</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEndDate" runat="server" Width="198px" CssClass="form-control" type="date"></asp:TextBox>
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
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary"   Text="Save" OnClick="btnSave_Click" />
                </td>
                <td>
                    <asp:Button ID="btnBack" runat="server" CssClass="btn btn-danger"  Text="Back" OnClick="btnBack_Click"  />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
