<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminInfo.aspx.cs" Inherits="admininfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>管理员信息</h1>


        <div  id="divImgHead">
            <!-- 添加头像控件-->
        </div>


        <h3>姓名：<asp:Label ID="lblName" runat="server"></asp:Label></h3>
        <h3>性别：<asp:Label ID="lblSex" runat="server"></asp:Label></h3>

        <div id="divPwd" runat ="server" visible="false">
        <h3>修改密码：<asp:TextBox ID="txtPwd" runat ="server"  MaxLength="16" TextMode="Password"></asp:TextBox></h3>
        <h3>再次确认：<asp:TextBox ID="txtRptPwd" runat ="server"  MaxLength="16" TextMode="Password"></asp:TextBox></h3>
        </div>

        <h3>密保问题:<asp:TextBox ID="txtProProtect" runat ="server" MaxLength="18" ReadOnly="true"></asp:TextBox></h3>
        <h3>密保答案:<asp:TextBox ID="txtProAnswer" runat ="server" MaxLength="18" ReadOnly="true"></asp:TextBox></h3>
        <h3><asp:Button ID="btnEdit" runat ="server" Text="编辑信息"  OnClick="btnEdit_Click"/></h3>
        <h3><asp:Button ID="btnSubmit" runat ="server" Text="提交修改" Visible="false" OnClick="btnSubmit_Click" /></h3>
    </div>
    </form>
</body>
</html>
