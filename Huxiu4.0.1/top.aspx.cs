using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class backstage_top : System.Web.UI.Page
{
    protected string name;          // = "大栗子";
    protected string url;           //= "http://www.baidu.com";
    protected string imgUrl;        //= "./images/icon-eg.jpeg";
    protected void Page_Load(object sender, EventArgs e)
    {
        //登陆后，用seesion 初始化
        //AdminName 的名字和postUrl,网址跳转管理

  
        if (Session["AdminID"] == null)
            Response.Write("<script>alert('账户过期请重新登录！');location='login.aspx'</script>");

        else if (!IsPostBack)
        {


            int adId = Convert.ToInt32(Session["AdminID"].ToString().Trim());
            try
            {
                using (var db = new huxiuEntities())
                {
                    Admin ad = db.Admin.SingleOrDefault(a => a.AdminId == adId);
                    name = ad.AdminName;
                    url = "admininfo.aspx?id=" + adId;
                    imgUrl = ad.AdminImage;
                }
            }
            catch
            {
                Response.Write("<script>alert('账户过期请重新登录！';location.href='login.aspx')</script>");
            }
        }
     



    }

    protected void Logout_Click(object sender, EventArgs e)
    {
        Session["AdminID"] = null;
        Response.Write("<script>alert('登出成功！跳转到虎嗅首页！');window.opener=null;window.open('','_self');window.close();</script>");
        //ClientScript.RegisterStartupScript(Page.GetType(), "", "<script language=javascript>window.opener=null;window.open('','_self');window.close();</script>");
    }
}