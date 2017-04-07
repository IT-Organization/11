using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admininfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminID"] == null)
            Response.Write("<script>alert('账户过期请重新登录！');location='login.aspx'</script>");

        else
        {

        divPwd.Visible = false;
        txtProProtect.ReadOnly = true;
        txtProAnswer.ReadOnly = true;
        btnEdit.Visible = true;
        btnSubmit.Visible = false;
        
        int id = Convert.ToInt32(Request.QueryString["id"].ToString());
        if (!initInfo(id))
        {
            Response.Write("<script>window.location.reload();</script>");
            return;
        }

        }


    }
    private bool initInfo(int ID)
    {
        try
        {
            using (var db=new huxiuEntities())
            {
                Admin ad = db.Admin.SingleOrDefault(a=>a.AdminId==ID);
                if (ad == null)
                    return false;
                image.ImageUrl = ad.AdminImage;//头像
                lblName.Text = ad.AdminName;
                lblSex.Text = ad.AdminSex ? "男" : "女";
                txtProProtect.Text = ad.AdminProblem;
                txtProAnswer.Text = ad.AdminAnswer;
            }
            return true;
        }
        catch
        {
            return false;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        // SEESION 获取 ID
        int ID = 8;

        if(txtProAnswer.Text.Trim()=="" || txtProProtect.Text.Trim()=="" || txtPwd.Text.Trim() =="" || txtRptPwd.Text.Trim()=="")
            Response.Write("<script>alert('请输入合法数据!')</script>");
        else
        {
            if (txtPwd.Text == txtRptPwd.Text)
            {
                //保存修改
                try
                {
                    using(var db=new huxiuEntities())
                    {
                        Admin ad = db.Admin.SingleOrDefault(a => a.AdminId == ID);
                        ad.AdminPassword = Security.SHA1_Hash(Security.MD5_hash(txtPwd.Text.Trim()));
                        ad.AdminImage = "~/File" + Request.Form["lb"];
                        ad.AdminProblem = txtProProtect.Text.Trim();
                        ad.AdminAnswer = txtProAnswer.Text.Trim();
                        db.SaveChanges();
                    }
                    Response.Write("<script>alert('修改成功!');</script>");

                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
            else
            {
                Response.Write("<script>alert('两次密码不一样，请检查!')</script>");

            }
        }
            
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        divPwd.Visible =true;
        txtProProtect.ReadOnly = false;
        txtProAnswer.ReadOnly = false;
        btnSubmit.Visible = true;
        btnEdit.Visible = false;

    }
}