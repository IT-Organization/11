﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class News1 : System.Web.UI.Page
{
    public static List<News> ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            using (var db = new huxiuEntities())
            {
                var datascore = from it in db.News orderby it.NewsDate  descending select it;

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
            var datascore = from it in db.News orderby it.NewsDate descending select it;

            if (content.Length != 0)
            {
                datascore = from it in db.News where it.NewsTitle.IndexOf(content) >= 0 orderby it.NewsDate descending select it;
            }

            var ds = datascore.ToList();

            Session["ds"] = ds;

            DataBindToRepeater(1, ds);

            lbNow.Text = "1";
        }
    }

    private void DataBindToRepeater(int currentPage, List<News> datascore)
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
        List<News> ds = (List<News>)Session["ds"];

        if (Convert.ToInt32(lbNow.Text) - 1 < 1)
            lbNow.Text = "1";

        else
            lbNow.Text = Convert.ToString(Convert.ToInt32(lbNow.Text) - 1);

        DataBindToRepeater(Convert.ToInt32(lbNow.Text), ds);
    }

    protected void btnDrow_Click(object sender, EventArgs e)
    {
        List<News> ds = (List<News>)Session["ds"];

        if (Convert.ToInt32(lbNow.Text) + 1 > Convert.ToInt32(lbTotal.Text))
            lbNow.Text = Convert.ToString(Convert.ToInt32(lbTotal.Text));

        else
            lbNow.Text = Convert.ToString(Convert.ToInt32(lbNow.Text) + 1);

        DataBindToRepeater(Convert.ToInt32(lbNow.Text), ds);
    }

    protected void btnFirst_Click(object sender, EventArgs e)
    {
        List<News> ds = (List<News>)Session["ds"];

        lbNow.Text = "1";

        DataBindToRepeater(Convert.ToInt32(lbNow.Text), ds);
    }

    protected void btnLast_Click(object sender, EventArgs e)
    {
        List<News> ds = (List<News>)Session["ds"];

        lbNow.Text = Convert.ToString(Convert.ToInt32(lbTotal.Text));

        DataBindToRepeater(Convert.ToInt32(lbNow.Text), ds);
    }

    protected void btnJump_Click(object sender, EventArgs e)
    {
        List<News> ds = (List<News>)Session["ds"];

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