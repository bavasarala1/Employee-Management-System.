<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="WebApplication2.Screen1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>S-Squared Personnel System</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <style>
        h2 {color: #7284b7;} 
    </style>
</head>
<body>
    <div class="container" align="center">
        <h2 align="center">Add New Employee</h2>
        <br />
            <form class="form-horizontal" id="form1" runat="server">
            
                <div class="form-group">
                  <asp:Label ID="lbManager" runat="server" Text="Manager" class="control-label col-xs-4"></asp:Label>
                  <div class="col-xs-4">
                   <div class="dropdown">
			             <asp:DropDownList ID="ddlManagerList" runat="server" OnSelectedIndexChanged="ddlManagerList_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control">
                         <asp:ListItem Text="Please Select" Value="All"></asp:ListItem>
                         </asp:DropDownList>
		            </div>
                  </div>
                </div>

                <br />
                <div class="form-group">
                    <asp:Label ID="lbEmployeeId" runat="server" Text="Employee Id" class="control-label col-xs-4"></asp:Label>
                  <div class="col-xs-4">          
                     <asp:TextBox ID="tbEmployeeId" runat="server"  class="form-control"></asp:TextBox>
                  </div>
                </div>

                <br />
                <div class="form-group">
                  <asp:Label ID="lbFirstName" runat="server" Text="FirstName" class="control-label col-xs-4"></asp:Label>
                      <div class="col-xs-4">          
                          <asp:TextBox ID="tbFirstName" runat="server" class="form-control"></asp:TextBox>
                      </div>
                </div>

                <br />
                <div class="form-group">
                     <asp:Label ID="lbLastName" runat="server" Text="LastName" class="control-label col-xs-4"></asp:Label>
                      <div class="col-xs-4">          
                          <asp:TextBox ID="tbLastName" runat="server" class="form-control"></asp:TextBox>
                      </div>
                </div>

                <br />
                <div class="form-group">
                    <asp:Label ID="lbRoles" runat="server" Text="Roles" class="control-label col-xs-4"></asp:Label>
                  <div class="col-xs-4">          
                    <asp:ListBox ID="libRoles" runat="server" SelectionMode="Multiple" CssClass="form-control">
                        <asp:ListItem>Support</asp:ListItem>
                        <asp:ListItem>IT</asp:ListItem>
                        <asp:ListItem>Product Manager</asp:ListItem>
                        <asp:ListItem>Software Engineer</asp:ListItem>
                        <asp:ListItem>Software Developer</asp:ListItem>
                    </asp:ListBox>
                  </div>
                </div>

                <br />
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-8">
                        <asp:Label ID="lblStatus" runat="server" Visible="false"></asp:Label>
                    </div>
                </div>

                <br />
                <div class="form-group">        
                  <div class="col-sm-offset-2 col-sm-8">
                      <asp:Button ID="bSave" runat="server" Text="Save" OnClick="bSave_Click" class="btn btn-default" />
                      <asp:Button ID="bCancel" runat="server" Text="Cancel" class="btn btn-default" OnClick="bCancel_Click" />
                  </div>
                </div>
        </form>
    </div>
</body>
</html>
