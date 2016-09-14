<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Ozoneservice.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>  
    <link href="bootstrap/css/bootstrap.css" rel="stylesheet" />
    <script src="bootstrap/js/bootstrap.js"></script>
</head>
<body>
     <form id="form1" runat="server" style=" margin-top:20%;">  
            <div class="container">  
                <div class="row">  
                    <div class="col-lg-3"></div>  
                    <div class="col-lg-6">  
                         
                            <!--<img src="Images/1.jpg" />-->
                            <h2 class="form-signin-heading">Please sign in </h2>  
                            <label for="inputEmail" class="sr-only">Username</label>  
                            <input type="text" id="inputUsername" class="form-control" placeholder="Username" runat="server" required autofocus>  
                                <label for="inputPassword" class="sr-only">Password</label>  
                                <input type="password" id="inputPassword" class="form-control" placeholder="Password" runat="server" required>  
                                    <div class="checkbox">                                         
                                    </div>  
                               <!-- <button class="btn btn-lg btn-primary btn-block" runat="server" type="submit">Sign in</button>--> 
                            <asp:Button ID="Btnlogin" runat="server" class="btn btn-lg btn-primary btn-block" Text="Sign in" OnClick="Btnlogin_Click" />
                         
                    </div>  
                    <div class="col-lg-3">
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Ozoneservice_dbConnectionString %>" SelectCommand="SELECT * FROM [tbEmployee]"></asp:SqlDataSource>
                    </div>  
                </div>  
            </div>  
        </form>
    
</body>


    
</html>
