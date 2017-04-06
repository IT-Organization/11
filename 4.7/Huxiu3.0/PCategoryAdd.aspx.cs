using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PCategoryAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (name.Text.Trim().Length > 0)
        {
            using(var db=new huxiuEntities())
            {
                PassageCategory person = new PassageCategory
                {
                    CategoryName = name.Text.Trim()
                };
                db.PassageCategory.Add(person);
                if (db.SaveChanges() == 1)
                {
                    Response.Write("<script>alert('添加成功');location='PassageList.aspx'</script>");
                }
                else
                    Response.Write("<script>alert('添加失败请重试')</script>");
            }
        }
        else
            Response.Write("<script>alert('不能为空！')</script>");
    }
      
}