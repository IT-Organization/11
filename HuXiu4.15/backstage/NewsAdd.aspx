<%@ Page Language="C#" AutoEventWireup="true"  ValidateRequest="false" CodeFile="NewsAdd.aspx.cs" Inherits="NewsFile_NewsAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<%--     <meta http-equiv="Content-Type" content="text/html;charset=utf-8"/>
    <script type="text/javascript" charset="utf-8" src="/ueditor/ueditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="/ueditor/ueditor.all.min.js"> </script>
    <script type="text/javascript" charset="utf-8" src="/ueditor/lang/zh-cn/zh-cn.js"></script>
      <style type="text/css">
        div{
            width:100%;
        }
    </style>--%>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        标题：<asp:TextBox ID="title" MaxLength="45" runat="server" Width="340px" ></asp:TextBox>
        <br />
        <br />
        内容：
        <br />   
        <asp:TextBox ID="content" runat="server" MaxLength="45" TextMode="MultiLine" Height="205px" Width="410px"></asp:TextBox>
        <br />
        <br />
        详情链接：<asp:TextBox ID="link" MaxLength="95" runat="server" Width="316px" ></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnAdd" runat="server" Text="增加" OnClick="btnAdd_Click" />
    </div>
    </form>
</body>
</html>
