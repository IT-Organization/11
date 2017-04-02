using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NewsFile_NewsAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (title.Text.Trim().Length > 0 && editor.InnerHtml.Trim().Length > 0 && link.Text.Trim().Length > 0)
        {
            using (var db = new huxiuEntities())
            {
                News person = new News
                {
                    NewsTitle = title.Text.Trim(),
                    NewsBody = UeditorHelper.change(editor.InnerHtml),
                    NewsDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), //发表时间
                    NewsLink = link.Text.Trim(),
                    IsDel = false
                };

                db.News.Add(person);

                if (db.SaveChanges() == 1)
                    Response.Write("<script>alert('添加成功');location='NewsList.aspx'</script>");
                else
                    Response.Write("<script>alert('添加失败请重试')</script>");
            }
        }
        else
            Response.Write("<script>alert('不能为空')</script>");
    }
     
}