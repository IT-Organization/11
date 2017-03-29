using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Authors : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            using (var db = new huxiuEntities())
            {
                var datascore = from it in db.Author orderby it.AuthorName select it;

                var ds = datascore.ToList();

                Session["ds"] = ds;

                DataBindToRepeater(1, ds);
            }
        }
    }

    protected void Rpt_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string content = txtSearch.Text;

        using (var db = new huxiuEntities())
        {
            var datascore = from it in db.Author orderby it.AuthorName select it;

            if (content.Length != 0)
            {
                datascore = from it in db.Author where it.AuthorName.IndexOf(content) >= 0 orderby it.AuthorName select it;
            }

            var ds = datascore.ToList();

            Session["ds"] = ds;

            DataBindToRepeater(1, ds);

            lbNow.Text = "1";
        }
    }

    private void DataBindToRepeater(int currentPage, List<Author> datascore)
    {
        PagedDataSource pds = new PagedDataSource();

        pds.AllowPaging = true;

        pds.PageSize = 5;

        pds.DataSource = datascore;

        lbTotal.Text = pds.PageCount.ToString();

        pds.CurrentPageIndex = currentPage - 1;

        Rpt.DataSource = pds;

        Rpt.DataBind();
    }

    protected void btnUp_Click(object sender, EventArgs e)
    {
        List<Author> ds = (List<Author>)Session["ds"];

        if (Convert.ToInt32(lbNow.Text) - 1 < 1)
            lbNow.Text = "1";

        else
            lbNow.Text = Convert.ToString(Convert.ToInt32(lbNow.Text) - 1);

        DataBindToRepeater(Convert.ToInt32(lbNow.Text), ds);
    }

    protected void btnDrow_Click(object sender, EventArgs e)
    {
        List<Author> ds = (List<Author>)Session["ds"];

        if (Convert.ToInt32(lbNow.Text) + 1 > Convert.ToInt32(lbTotal.Text))
            lbNow.Text = Convert.ToString(Convert.ToInt32(lbTotal.Text));

        else
            lbNow.Text = Convert.ToString(Convert.ToInt32(lbNow.Text) + 1);

        DataBindToRepeater(Convert.ToInt32(lbNow.Text), ds);
    }

    protected void btnFirst_Click(object sender, EventArgs e)
    {
        List<Author> ds = (List<Author>)Session["ds"];

        lbNow.Text = "1";

        DataBindToRepeater(Convert.ToInt32(lbNow.Text), ds);
    }

    protected void btnLast_Click(object sender, EventArgs e)
    {
        List<Author> ds = (List<Author>)Session["ds"];

        lbNow.Text = Convert.ToString(Convert.ToInt32(lbTotal.Text));

        DataBindToRepeater(Convert.ToInt32(lbNow.Text), ds);
    }

    protected void btnJump_Click(object sender, EventArgs e)
    {
        List<Author> ds = (List<Author>)Session["ds"];

        int i = 0;

        if (int.TryParse(txtJump.Text, out i))
        {
            if (Convert.ToInt32(txtJump.Text) < 1)
                lbNow.Text = "1";

            else if (Convert.ToInt32(txtJump.Text) > Convert.ToInt32(lbTotal.Text))
                lbNow.Text = Convert.ToString(Convert.ToInt32(lbTotal.Text));

            else
                lbNow.Text = Convert.ToString(Convert.ToInt32(txtJump.Text));
        }

        else
            lbNow.Text = Convert.ToString(Convert.ToInt32(lbTotal.Text));

        DataBindToRepeater(Convert.ToInt32(lbNow.Text), ds);
    }
}