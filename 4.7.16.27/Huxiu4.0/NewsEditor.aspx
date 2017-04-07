<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="NewsEditor.aspx.cs" Inherits="NewsFile_NewsEditor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <meta http-equiv="Content-Type" content="text/html;charset=utf-8"/>
    <script type="text/javascript" charset="utf-8" src="/ueditor/ueditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="/ueditor/ueditor.all.min.js"> </script>
    <script type="text/javascript" charset="utf-8" src="/ueditor/lang/zh-cn/zh-cn.js"></script>
    <script src="/webUploader/jquery-1.7.1.min.js"></script>

    <style type="text/css">
        div {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    标题：<asp:TextBox ID="title" MaxLength="45" Enabled="false" runat="server" ></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lbtnEditor" runat="server" Text="编辑" OnClick="lbtnEditor_Click"></asp:LinkButton>
        <br />
        内容：
                <br />
       <textarea id="editor" runat="server" type="text/plain" style="width: 1024px; height: 500px;"></textarea>
            <script type="text/javascript">
                var CheckF = $('#ChangeFlag').val();

                var ue = UE.getEditor('<%=editor.ClientID %>');
                ue.addListener('ready', function () {
                    if (CheckF != '1') {
                        ue.setDisabled();
                    }
                });       
            </script>
        <input id="ChangeFlag" runat="server" type="hidden" />

        <br />
        详情链接：<asp:TextBox ID="link" MaxLength="95"  Enabled="false" runat="server" ></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        发布时间：<asp:Label ID="dates" runat="server" ></asp:Label>
        <br />
        <asp:Button ID="btnEditor" Visible="false" runat="server" Text="编辑" OnClick="btnEditor_Click" />
    </div>
    </form>
</body>
</html>
