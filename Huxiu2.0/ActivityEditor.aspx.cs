using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ActivityEditor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id =Convert.ToInt32( Request.QueryString["id"]);//获取id

        if (!IsPostBack)
        {
            using(var db= new huxiuEntities())
            {
                Activity person = (from it in db.Activity where it.ActivityId == id select it).FirstOrDefault();

                title.Text = person.ActivityTitle;//标题

                editor.InnerHtml = person.ActivityWhat;//内容

                image.ImageUrl = person.ActivityImage;//封面

                when.Text = person.ActivityWhen.ToString();//时间

                requestedDeliveryDateTextBox.Text= person.ActivityWhen.ToString();//时间

                where.Text = person.ActivityWhere;//地点

                tips.Text = person.ActivityTips;//备注
            }
        }
    }

    /// 日期选择图标被点击
    /// </summary>
    protected void ImageButton_Click(object sender, EventArgs eventArgs)
    {
        //控制日历的显示与隐藏
            calendar.Visible = !calendar.Visible;
    }

    /// <summary>
    /// 选择日期，通过AJAX触发
    /// </summary>
    protected void RequestedDeliveryDateCalendar_SelectionChanged(object sender, EventArgs eventArgs)
    {
        requestedDeliveryDateTextBox.Text = requestedDeliveryDateCalendar.SelectedDate.ToShortDateString();

        // 隐藏日历
        calendar.Visible = false;

        //设置日历下textbox的焦点，方便用户输入。移除或改变下行代码设置为您自己的控件
        
    }
    protected void btnEditor_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);

        if (title.Text.Trim().Length > 0 && editor.InnerHtml.Trim().Length > 0 && where.Text.Length > 0 && tips.Text.Length > 0)
        {
            using (var db = new huxiuEntities())
            {

                Activity person = (from it in db.Activity where it.ActivityId == id select it).FirstOrDefault();

                person.ActivityTitle = title.Text;

                person.ActivityWhat = UeditorHelper.change(editor.InnerHtml);//富文本编辑器里的内容

                if (Request.Form["lb"] != "")
                    person.ActivityImage = "~/File/" + Request.Form["lb"];

                if (requestedDeliveryDateTextBox.Text.Trim().Length > 0)
                    person.ActivityWhen = requestedDeliveryDateTextBox.Text;

                person.ActivityWhere = where.Text;

                person.ActivityTips = tips.Text;

                if (db.SaveChanges() == 1)
                    Response.Write("<script>alert('编辑成功');location='ActivityEditor.aspx?id="+id+"'</script>");
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
        lbtnEditor.Visible = false;
        ChangeFlag.Value = "1";
        UpdatePanel1.Visible = true;
        when.Visible = false;//活动时间标签隐藏
        where.Enabled = true;
        tips.Enabled = true;
        btnEditor.Visible = true;
        uploader.Style.Add("display", "block");//把后台div显示出来

    }
}