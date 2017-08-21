<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewEmployeeList.aspx.cs" Inherits="WebApplication2.Screen2" %>

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
        <h2>Tyler Enterprise Application</h2>
       <br />
            <form class="form-horizontal" id="form1" runat="server">
                <div class="form-group">
                    <asp:Label ID="lbManager" runat="server" Text="Manager" class="control-label col-xs-4"></asp:Label>
                    <div class="col-xs-4">
                        <div class="dropdown">
                       <asp:DropDownList ID="ddlManagerList" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlManagerList_SelectedIndexChanged" AutoGenerateColumns = "ture" AutoPostBack="true" CssClass="form-control">
                          <asp:ListItem Text = "Select Manager" Value = "All"></asp:ListItem>
                                </asp:DropDownList>
		                </div>
                     </div>
                </div>
                <br />
                <div class="form-group">        
                        <div class="col-sm-offset-2 col-sm-8">
                            <asp:GridView ID="gdEmployee" runat="server" ShowHeaderWhenEmpty="true" CssClass= "table table-striped table-bordered table-condensed">
                    </asp:GridView>
                        </div>
                </div>
                <br />
                <div class="form-group">        
                    <div class="col-sm-offset-2 col-sm-8">
                        <asp:Button ID="btnAddEmployee" Text="Add New Employee" runat="server" OnClick="btnAddEmployee_Click" type="submit" class="btn btn-default" />
                     </div>
                </div>

            </form>
    </div>
</body>
</html>
