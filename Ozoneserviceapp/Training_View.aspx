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
                <td><asp:DropDownList ID="ddlTitle" runat="server" ></asp:DropDownList></td>
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
                    <asp:TextBox ID="txtAddress" runat="server" readonly="true" Width="198px" ></asp:TextBox>
                </td>
           
                <td style="padding: 5px;">
                    <asp:Label ID="lblOwner" runat="server" Text="Label">ผู้จัดการอบรม</asp:Label>
                </td>
                <td><asp:TextBox ID="txtOwner" runat="server" readonly="true" Width="198px"></asp:TextBox></td>
            
                <td style="padding: 5px;">
                    <asp:Label ID="lblParticipant" runat="server" Text="Label">จำนวนผู้เข้าร่วม</asp:Label>
                </td>
                <td> 
                    <asp:TextBox ID="txtParticipant" readonly="true" runat="server" Width="198px" 
                        onkeypress="return EnterEvent(event)" MaxLength="2"></asp:TextBox>
                </td>
            </tr>
            
            </table>

        <asp:Button ID="btnSearch" runat="server" Text="ค้นหา" CssClass="btn btn-primary" OnClick="btnSearch_Click" /> 
        <br />


        <asp:Label ID="lblTraining_View" runat="server" Text=""></asp:Label>

            
        </div>
</asp:Content>
