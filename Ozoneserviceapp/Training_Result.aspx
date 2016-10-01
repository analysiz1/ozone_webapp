<%@ Page Title="" Language="C#" MasterPageFile="~/Site_Main.Master" AutoEventWireup="true" CodeBehind="Training_Result.aspx.cs" Inherits="Ozoneservice.UI.Training.Training_Result" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <table align="center" class="table table-bordered" >
            <tr>
                <td style="padding: 5px;">
                    <asp:Label ID="lblTitle" runat="server" Text="Label">หัวข้อ</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlTitle" runat="server" Width="198px" OnSelectedIndexChanged ="ddlTitle_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                </td>
                <td style="padding: 5px;">
                    <asp:Label ID="lblDateStart" runat="server" Text="Label" >วันที่เริ่มอบรม</asp:Label>
                </td> 
                <td>
                    <asp:TextBox ID="txtdateStart" runat="server" readonly="true" Width="198px" ></asp:TextBox>
                </td>
            
                <td style="padding: 5px;">
                    <asp:Label ID="lblDateEnd" runat="server" Text="Label">วันที่สิ้นสุดอบรม</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtdateEnd" runat="server" readonly="true" Width="198px" ></asp:TextBox>
                </td>  
            </tr>

            <tr>
                <td style="padding: 5px;">
                    <asp:Label ID="lblAddress" runat="server" Text="Label">สถานที่</asp:Label>
                </td>
                <td> 
                    <asp:TextBox ID="txtAddress" runat="server" Width="198px" ></asp:TextBox>
                </td>
           
                <td style="padding: 5px;">
                    <asp:Label ID="lblOwner" runat="server" Text="Label">ผู้จัดการอบรม</asp:Label>
                </td>
                <td><asp:TextBox ID="txtOwner" runat="server" Width="198px"></asp:TextBox></td>
            
                <td style="padding: 5px;">
                    <asp:Label ID="lblParticipant" runat="server" Text="Label">เป้าหมายผู้เข้าอบรม</asp:Label>
                </td>
                <td> 
                    <asp:TextBox ID="txtParticipant" runat="server" Width="198px" 
                        onkeypress="return EnterEvent(event)" MaxLength="2"></asp:TextBox>
                </td>
            </tr>
            
        </table>

        <asp:Label ID="lblTraining_Result1" runat="server" Text=""></asp:Label>
        
        <br>

        <asp:Label ID="lblTraining_Result2" runat="server" Text=""></asp:Label>


    </div>

</asp:Content>
