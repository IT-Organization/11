using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AuthorFile_AuthorEditor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int id = Convert.ToInt32( Request.QueryString["id"]);

            using (var db = new huxiuEntities())
            {
                Author person =(from it in db.Author where it.AuthorId == id select it).FirstOrDefault();

                name.Text = person.AuthorName;

                image.ImageUrl = person.AuthorImage;

                sex.SelectedValue = person.AuthorSex.ToString();

                summary.Text = person.AuthorSummary;
            }
        }
    }

    protected void btnEditor_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);

        using(var db=new huxiuEntities())
        {
            Author person = (from it in db.Author where it.AuthorId == id select it).FirstOrDefault();

            person.AuthorName = name.Text;

            person.AuthorSex = sex.SelectedValue == "1" ? true : false;

            person.AuthorSummary = summary.Text;

            if(Request.Form["lb"]!="")
                person.AuthorImage = "~/File/" + Request.Form["lb"];

            if (db.SaveChanges() == 1)
                Response.Write("<script>alert('编辑成功');location='AuthorEditor.aspx?id="+id+"'</script>");
            else
                Response.Write("<script>alert('编辑失败请重试')</script>");
        }
    }

    protected void btnEditors_Click(object sender, EventArgs e)
    {
        name.Enabled = true;
        sex.Enabled = true;
        btnEditor.Visible = true;
        btnEditors.Visible = false;
        summary.Enabled = true;
        uploader.Style.Add("display", "block");//把后台div显示出来
    }
}