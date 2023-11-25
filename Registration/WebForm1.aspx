<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Registration.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        Fill your Details<br />
        <br />
        <br />
        Full Name<div>
            <asp:TextBox ID="FullName" runat="server" Width="193px"></asp:TextBox>
        </div>
        <p>
            Employee ID</p>
        <asp:TextBox ID="Eid" runat="server" Width="193px"></asp:TextBox>
        <p>
            Department&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
        <asp:TextBox ID="Dept" runat="server" Width="190px"></asp:TextBox>
        <br />
        <br />
        Email ID<br />
        <asp:TextBox ID="mail" runat="server" Width="188px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <p style="margin-left: 80px">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
        </p>
    </form>
</body>
</html>
