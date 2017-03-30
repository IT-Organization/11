﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Passage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            using (var db = new huxiuEntities())
            {
                var datascore = from it in db.PassageInformation orderby it.PublishDate descending select it;

                var ds = datascore.ToList();

                Session["ds"] = ds;

                DataBindToRepeater(1, ds);
            }

            using (var db = new huxiuEntities())
            {
                var datascore = from it in db.PassageCategory select it;

                this.DropDownList.DataSource = datascore.ToList();

                this.DropDownList.DataValueField = "PCategoryId";

                this.DropDownList.DataTextField = "CategoryName";

                this.DropDownList.DataBind();

                ListItem item = new ListItem();

                item.Text = "全部";

                item.Value = "0";

                this.DropDownList.Items.Insert(0, item);

            }
        }           
    }

    protected void Rpt_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string content = txtSearch.Text;

        int category = 0;

        if(Session["category"] != null)
        {
            category = Convert.ToInt32(Session["category"].ToString());

        }

        using (var db = new huxiuEntities())
        {
            var datascore = from it in db.PassageInformation orderby it.PublishDate descending select it; 

            if(RbtnPassage.Checked == true)
            {
                if (content.Length == 0)
                {
                    if (category == 0)
                    {
                        if (RbtnViews.Checked == true)
                        {
                            datascore = from it in db.PassageInformation orderby it.PageViews descending select it;
                        }
                    }

                    else if (category != 0)
                    {
                        if (RbtnTime.Checked == true)
                        {
                            datascore = from it in db.PassageInformation where it.PassageCategory == category orderby it.PublishDate descending select it;
                        }

                        else if (RbtnViews.Checked == true)
                        {
                            datascore = from it in db.PassageInformation where it.PassageCategory == category orderby it.PageViews descending select it;
                        }
                    }
                }

                if (content.Length != 0)
                {
                    if (category == 0)
                    {
                        if (RbtnTime.Checked == true)
                        {
                            datascore = from it in db.PassageInformation where it.PassageTitle.IndexOf(content) >= 0 orderby it.PublishDate descending select it;
                        }

                        else if (RbtnViews.Checked == true)
                        {
                            datascore = from it in db.PassageInformation where it.PassageTitle.IndexOf(content) >= 0 orderby it.PageViews descending select it;
                        }
                    }

                    else if (category != 0)
                    {
                        if (RbtnTime.Checked == true)
                        {
                            datascore = from it in db.PassageInformation where it.PassageTitle.IndexOf(content) >= 0 && it.PassageCategory == category orderby it.PublishDate descending select it;
                        }

                        else if (RbtnViews.Checked == true)
                        {
                            datascore = from it in db.PassageInformation where it.PassageTitle.IndexOf(content) >= 0 && it.PassageCategory == category orderby it.PageViews descending select it;
                        }
                    }
                }
            }

            else if(RbtnAuthor.Checked == true)
            {
                if (content.Length == 0)
                {
                    if (category == 0)
                    {
                        if (RbtnViews.Checked == true)
                        {
                            datascore = from it in db.PassageInformation orderby it.PageViews descending select it;
                        }
                    }

                    else if (category != 0)
                    {
                        if (RbtnTime.Checked == true)
                        {
                            datascore = from it in db.PassageInformation where it.PassageCategory == category orderby it.PublishDate descending select it;
                        }

                        else if (RbtnViews.Checked == true)
                        {
                            datascore = from it in db.PassageInformation where it.PassageCategory == category orderby it.PageViews descending select it;
                        }
                    }
                }

                if (content.Length != 0)
                {
                    if (category == 0)
                    {
                        if (RbtnTime.Checked == true)
                        {
                            datascore = from it in db.PassageInformation where it.AuthorName.IndexOf(content) >= 0 orderby it.PublishDate descending select it;
                        }

                        else if (RbtnViews.Checked == true)
                        {
                            datascore = from it in db.PassageInformation where it.AuthorName.IndexOf(content) >= 0 orderby it.PageViews descending select it;
                        }
                    }

                    else if (category != 0)
                    {
                        if (RbtnTime.Checked == true)
                        {
                            datascore = from it in db.PassageInformation where it.AuthorName.IndexOf(content) >= 0 && it.PassageCategory == category orderby it.PublishDate descending select it;
                        }

                        else if (RbtnViews.Checked == true)
                        {
                            datascore = from it in db.PassageInformation where it.AuthorName.IndexOf(content) >= 0 && it.PassageCategory == category orderby it.PageViews descending select it;
                        }
                    }
                }
            }
            var ds = datascore.ToList();

            Session["ds"] = ds;

            DataBindToRepeater(1, ds);

            lbNow.Text = "1";
        }
    }

    protected void DropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DropDownList.SelectedIndex = DropDownList.Items.IndexOf(DropDownList.Items.FindByValue("0"));

        string category = DropDownList.SelectedValue;
        
        Session["category"] = category;
    }


    protected void RbtnTime_CheckedChanged(object sender, EventArgs e)
    {
        if (RbtnTime.Checked == true)
        {
            RbtnViews.Checked = false;
        }          
    }

    protected void RbtnViews_CheckedChanged(object sender, EventArgs e)
    {
        if (RbtnViews.Checked == true)
        {
            RbtnTime.Checked = false;
        }           
    }

    void DataBindToRepeater(int currentPage, List<PassageInformation> datascore)
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
        List<PassageInformation> ds = (List<PassageInformation>)Session["ds"];

        if (Convert.ToInt32(lbNow.Text) - 1 < 1)
            lbNow.Text = "1";

        else
            lbNow.Text = Convert.ToString(Convert.ToInt32(lbNow.Text) - 1);

        DataBindToRepeater(Convert.ToInt32(lbNow.Text), ds);
    }

    protected void btnDrow_Click(object sender, EventArgs e)
    {
        List<PassageInformation> ds = (List<PassageInformation>)Session["ds"];

        if (Convert.ToInt32(lbNow.Text) + 1 > Convert.ToInt32(lbTotal.Text))
            lbNow.Text = Convert.ToString(Convert.ToInt32(lbTotal.Text));

        else
            lbNow.Text = Convert.ToString(Convert.ToInt32(lbNow.Text) + 1);

        DataBindToRepeater(Convert.ToInt32(lbNow.Text), ds);
    }

    protected void btnFirst_Click(object sender, EventArgs e)
    {
        List<PassageInformation> ds = (List<PassageInformation>)Session["ds"];

        lbNow.Text = "1";

        DataBindToRepeater(Convert.ToInt32(lbNow.Text), ds);
    }

    protected void btnLast_Click(object sender, EventArgs e)
    {
        List<PassageInformation> ds = (List<PassageInformation>)Session["ds"];

        lbNow.Text = Convert.ToString(Convert.ToInt32(lbTotal.Text));

        DataBindToRepeater(Convert.ToInt32(lbNow.Text), ds);
    }

    protected void btnJump_Click(object sender, EventArgs e)
    {
        List<PassageInformation> ds = (List<PassageInformation>)Session["ds"];

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



    protected void RbtnPassage_CheckedChanged(object sender, EventArgs e)
    {
        if(RbtnPassage.Checked == true)
        {
            RbtnAuthor.Checked = false;
        }
    }

    protected void RbtnAuthor_CheckedChanged(object sender, EventArgs e)
    {
        if(RbtnAuthor.Checked == true)
        {
            RbtnPassage.Checked = false;
        }
    }
}