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
                    <asp:DropDownList ID="ddlTitle" runat="server" Width="198px">
                    </asp:DropDownList>
                </td>
                <td style="padding: 5px;">
                    <asp:Label ID="lblDateStart" runat="server" Text="Label">วันที่เริ่มอบรม</asp:Label>
                </td> 
                <td>
                
                    <input type="text" name="dateStart" id="dateStart" value="" runat="server" style="width:198px"/> 
                </td>
            
                <td style="padding: 5px;">
                    <asp:Label ID="lblDateEnd" runat="server" Text="Label">วันที่สิ้นสุดอบรม</asp:Label>
                </td>
                <td>
                    <input type="text" name="dateEnd" id="dateEnd" value="" runat="server" style="width:198px"/> 
                
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
                    <asp:Label ID="lblParticipant" runat="server" Text="Label">จำนวนผู้เข้าร่วม</asp:Label>
                </td>
                <td> 
                    <asp:TextBox ID="txtParticipant" runat="server" Width="198px" 
                        onkeypress="return EnterEvent(event)" MaxLength="2"></asp:TextBox>
                </td>
            </tr>
            
        </table>


        <%string[] Province = {"กรุงเทพฯ","เชียงใหม่","เชียงราย","ตาก","สงขลา","ยะลา","ปัตตานี","นราธิวาส"}; %>
        <%string[] DataNew = { "1", "2", "3", "4", "5", "6", "7", "8" }; %>
        <%string[] DataOld = { "1", "2", "3", "4", "5", "6", "7", "8" }; %>

        <p align="center">รายละเอียดผู้เข้าร่วม </p>

        <table style="border: 1px solid #000; width: 80%;" align="center" class="table-condensed">
            <tr>
                <%foreach (string _province in Province)
                  {%>
                <td style="border: 1px solid #333; width: <%: (80/Province.Count()).ToString() %>%;" align="center">
                    <%:_province%>
                </td>
                <%}%>
            </tr>
        </table>
        
        <table style="border: 1px solid #000; width: 80%;" align="center" class=" table-condensed">
            <tr>
                <% for (int i = 0; i < (Province.Count() * 2); i++)
                   {%>
                <td style="border: 1px solid #333; width: <%: (80/(Province.Count() * 2)).ToString() %>%;" align="center">
                    <%
                            if (i % 2 == 0)
                            {
                            
                    %>
                            รายใหม่
                        <%
                            }
                            else
                            {
                        %>
                            รายเก่า
                        <%
                            }
                        %>
                </td>
                <%} %>
            </tr>
        </table>
        
        <table style="border: 1px solid #000; width: 80%;" align="center">
            <tr>
                <% int j = 0; %>
                <% for (int i = 0; i < (Province.Count() * 2); i++)
                   {%>
                <td style="border: 1px solid #333; width: <%: (80/(Province.Count() * 2)).ToString() %>%;" align="center">
                    <%
                       if (i % 2 == 0)
                       {
                            
                    %>
                    <%: DataNew[j].ToString() %>
                    <%
                            }
                            else
                            {
                    %>
                    <%: DataOld[j].ToString() %>
                    <%
                                j++;
                            }
                    %>
                </td>
                <%} %>
            </tr>
        </table>

        <table style="border: 1px solid #000; width: 80%;" align="center">
            <tr>
                <%for(int i =0 ; i < Province.Count();i++)
                  {%>
                <td style="border: 1px solid #333; width: <%: (80/Province.Count()).ToString() %>%;" align="center">
                    <%: int.Parse(DataNew[i]) + int.Parse(DataOld[i]) %>
                </td>
                <%}%>
            </tr>
        </table>
        

        <%string[] Department = { "ส่วนกลาง", "ผู้ประสานงานภาค", "ผู้จัดการศูนย์", "จนท.ธุรการ-การเงิน", "เจ้าหน้าที่ภาคสนาม", "แกนนำอาสาสมัคร", "อาสาสมัคร" }; %>
        <%string[] DepAmount = { "1", "2", "3", "4", "5", "6", "7" };%>

        <p align="center"> ตำแหน่งงาน </p>
        
        <table style="border: 1px solid #000; width: 80%;" align="center">
            <tr>
                <%for (int i = 0; i < Department.Count(); i++)
                  {%>
                <td style="border: 1px solid #333; width: <%: (80/Department.Count()).ToString() %>%;" align="center">
                    <%: Department[i] %>
                </td>
                <%}%>
            </tr>

            <tr>
                <%for (int i = 0; i < DepAmount.Count(); i++)
                  {%>
                <td style="border: 1px solid #333; width: <%: (80/DepAmount.Count()).ToString() %>%;" align="center">
                    <%: DepAmount[i] %>
                </td>
                <%}%>
            </tr>
        </table>


    </div>

</asp:Content>
