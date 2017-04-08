<%@ Page Language="C#" AutoEventWireup="true"  ValidateRequest="false" CodeFile="NewsAdd.aspx.cs" Inherits="NewsFile_NewsAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <meta http-equiv="Content-Type" content="text/html;charset=utf-8"/>
    <script type="text/javascript" charset="utf-8" src="/ueditor/ueditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="/ueditor/ueditor.all.min.js"> </script>
    <script type="text/javascript" charset="utf-8" src="/ueditor/lang/zh-cn/zh-cn.js"></script>
      <style type="text/css">
        div{
            width:100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        标题：<asp:TextBox ID="title" MaxLength="45" runat="server" ></asp:TextBox>
        <br />
        内容：
        <br />   
        <textarea id="editor" runat="server" type="text/plain"  style="width:701px; height:318px;" ></textarea>
        <script type="text/javascript">
            var ue = UE.getEditor('<%=editor.ClientID %>');
        </script>
        <br />
        详情链接：<asp:TextBox ID="link" MaxLength="95" runat="server" ></asp:TextBox>
        <br />
        <asp:Button ID="btnAdd" runat="server" Text="增加" OnClick="btnAdd_Click" />
    </div>
    </form>
</body>
</html>
