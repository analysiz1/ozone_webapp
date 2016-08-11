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
                <td><asp:TextBox ID="txtTitle" runat="server" Width="198px"></asp:TextBox></td>
                <td style="padding: 5px;">
                    <asp:Label ID="lblDateStart" runat="server" Text="Label" >วันที่เริ่มอบรม</asp:Label>
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

        <asp:Button ID="Button1" runat="server" Text="ค้นหา" CssClass="btn btn-primary" />
        <br />

            <%string[] Column = { "ลำดับ", "รหัสผู้เข้าอบรม", "คำนำหน้า", "ชื่อ-นามสกุล", "จังหวัด", "สำนักงาน/พื้นที่", "ตำแหน่ง" }; 
              
                System.Data.DataTable dt = new System.Data.DataTable(); 
              
                dt.Columns.Add("id");
                dt.Columns.Add("prefixName");
                dt.Columns.Add("nameSurname");
                dt.Columns.Add("province");
                dt.Columns.Add("area");
                dt.Columns.Add("position");

                System.Data.DataRow dr = dt.NewRow();

                dr["id"] = "OSO-42";
                dr["prefixName"] = "นางสาว";
                dr["nameSurname"] = "แก่นแก้ว  ชุมชาติ";
                dr["province"] = "สงขลา";
                dr["area"] = "อำเภอจะนะ";
                dr["position"] = "เจ้าหน้าที่ภาคสนาม";

                dt.Rows.Add(dr);
                
                dr = dt.NewRow();

                dr["id"] = "OYA-60";
                dr["prefixName"] = "นาย";
                dr["nameSurname"] = "อับดุลรอฮมาน ยามา";
                dr["province"] = "ยะลา";
                dr["area"] = "อำเภอยะลา";
                dr["position"] = "เจ้าหน้าที่ภาคสนาม";

                dt.Rows.Add(dr);
                
                dr = dt.NewRow();

                dr["id"] = "OPA-12";
                dr["prefixName"] = "นาย";
                dr["nameSurname"] = "มูตะผา เหลาะหม๊ะ";
                dr["province"] = "ปัตตานี";
                dr["area"] = "อำเภอเมือง";
                dr["position"] = "เจ้าหน้าที่ภาคสนาม";
                
                dt.Rows.Add(dr);
               
            %>
            <br />
            <table  class="table table-hover" >
            <tr>
                <%for (int i = 0; i < Column.Count(); i++)
                  {%>
                <td style="border: 1px solid #333; width: <%: (80/Column.Count()).ToString() %>%;" align="center">
                    <%: Column[i] %>
                </td>
                <%}%>
            </tr>
                
            <% 
            int j = 0;
                
            foreach(System.Data.DataRow drTemp in dt.Rows)
            {
                j++;
            %>      
                <tr>
                    <%
                    for (int i = -1; i < drTemp.Table.Columns.Count; i++)
                    {
                        if(i == -1)
                        {
                        %>

                            <td style="border: 1px solid #333; width: <%: (80/drTemp.Table.Columns.Count+1).ToString() %>%;" align="center">
                                <%: j %>
                            </td>
                        <%
                        }
                        else
                        {
                        %>
                            <td style="border: 1px solid #333; width: <%: (80/drTemp.Table.Columns.Count+1).ToString() %>%;" align="center">
                                <%: drTemp[i] %>
                            </td>
                        <%  
                        } 
                    }
                    %>
                </tr>
            <%
            } 
            %>
        </table>
        
        <p> ยอดรวมจำนวนผู้เข้าร่วมการอบรม/พัฒนาศักยภาพ </p>
        <p> (<%:dt.Rows.Count %>)</p>
        </div>
</asp:Content>
