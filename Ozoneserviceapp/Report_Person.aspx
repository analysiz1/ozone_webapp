<%@ Page Title="" Language="C#" MasterPageFile="~/Site_Main.Master" AutoEventWireup="true" CodeBehind="Report_Person.aspx.cs" Inherits="Ozoneservice.Train.Report2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-group" style="width:20%; margin-left:30px;">      
     
       <p>Drop In</p> <asp:DropDownList ID="ddl2" runat="server" CssClass="form-control" DataSourceID="Dropin" DataTextField="DropinName" DataValueField="DropinID" AutoPostBack="True" OnSelectedIndexChanged="ddl2_SelectedIndexChanged">       
        </asp:DropDownList>
        <asp:SqlDataSource ID="Dropin" runat="server" ConnectionString="<%$ ConnectionStrings:Ozoneservice_dbConnectionString %>" SelectCommand="SELECT * FROM [tbDropin]"></asp:SqlDataSource>
        <br />
        <p>ชื่อ-นามสกุลพนักงาน</p>
        <br />
        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>

        <br />
        <br />
          <asp:Button CssClass="btn tn-primary"  ID="Btns" runat="server" Text="ค้นหา" />


       
    </div>
    
     <asp:Label ID="lblEmp" runat="server" Text="Label"></asp:Label>
  
    <br />
    <br />
   
    <script type="text/javascript">


        function redirect(Empid)
        {
            window.location.assign("/Report_EmpDetail.aspx?empid="+Empid);
        }



    </script>


</asp:Content>
