<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuthorInformation.aspx.cs" Inherits="AuthorInformation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Image ID="imgHead" runat="server" Height="100px" Width="100px"  /><br />
        姓名：<asp:Label ID="lbName" runat="server" ></asp:Label><br />
        性别：<asp:Label ID="lbSex" runat="server" ></asp:Label><br />
        个人简介：<asp:Label ID="lbSummary" runat="server" ></asp:Label>
    
    </div>
    </form>
</body>
</html>
