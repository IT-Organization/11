using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// UeditorHelper 的摘要说明
/// </summary>
public class UeditorHelper
{
    public UeditorHelper()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    static public string change(string x)//对富文本编辑器中获取的内容 html标签进行处理，避免它存到数据库的时候被转义
    {
        x = x.Replace("&lt;", "<");//对一些特殊字符进行替换
        x = x.Replace("&gt;", ">");
        x = x.Replace("&quot;", "\"");

        return x;
    }
}