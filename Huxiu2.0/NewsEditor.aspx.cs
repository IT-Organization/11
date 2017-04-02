using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NewsFile_NewsEditor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id =Convert.ToInt32(Request.QueryString["id"]);

        if (!IsPostBack)
        {
            using (var db = new huxiuEntities())//把内容显示出来
            {
                News person = (from it in db.News where it.NewsId == id select it).FirstOrDefault();

                title.Text = person.NewsTitle;//标题

                editor.InnerHtml = person.NewsBody;//内容

                dates.Text = person.NewsDate.ToString();//发布时间

                link.Text = person.NewsLink;//链接
            }
        }
    }
    protected void btnEditor_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);

        if (title.Text.Trim().Length > 0 && editor.InnerHtml.Trim().Length > 0 && link.Text.Trim().Length > 0)
        {
            using (var db = new huxiuEntities())//修改短趣
            {
                News person = (from it in db.News where it.NewsId == id select it).FirstOrDefault();

                person.NewsTitle = title.Text.Trim();//标题
                person.NewsBody = UeditorHelper.change(editor.InnerHtml);//内容
                                                                         //  person.NewsDate = Convert.ToDateTime(dates.Text);//发布时间不做修改
                person.NewsLink = link.Text.Trim();//超链接
                                                   //  person.IsDel = false;//是否删除

                if (db.SaveChanges() == 1)
                    Response.Write("<script>alert('编辑成功');location='NewsEditor.aspx?id="+id+"'</script>");
                else
                    Response.Write("<script>alert('编辑失败请重试')</script>");
            }
        }

        else
            Response.Write("<script>alert('不能为空')</script>");
    }

    protected void lbtnEditor_Click(object sender, EventArgs e)
    {
        title.Enabled = true;
        ChangeFlag.Value = "1";
        link.Enabled = true;
        lbtnEditor.Visible = false;
        btnEditor.Visible = true;
    }

}