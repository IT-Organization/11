<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QRcode.aspx.cs" Inherits="QRcode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type ="text/javascript" src="Scripts/jquery-3.1.1.min.js" ></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    <img id="QRimg"  width="100" height="100" src="#" />
        <button onclick ="display();return false">test</button>
        <script type="text/javascript">
          //  alert(window.location.href);
            
            function display() {
                var str=window.location.href;
                var url="QRshare.ashx?str="+str;
                $("#QRimg").attr('src',url);
            };
        </script>
        <button onclick ="test();return false">testHeadInterface</button>
        <script>
            $.ajax({
                type: "POST",
                /*url:"try4.txt",*/
                url: "getActHead.ashx",
                //data:{pageNumber:i,pageSize:4},
                //发送给后台，请求第几页信息，每页信息多大
                //dataType:"json",
                async: true,
                success: function (data) {
                    alert("successful");
                }
            })

        </script>
        
    </div>
    </form>
</body>
</html>
