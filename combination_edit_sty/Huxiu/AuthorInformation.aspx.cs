using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AuthorInformation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int ID = Convert.ToInt32(Request.QueryString["id"]);

        using (var db = new huxiuEntities())
        {
            Author author = db.Author.SingleOrDefault(a => a.AuthorId == ID);

            imgHead.ImageUrl = author.AuthorImage.ToString();

            lbName.Text = author.AuthorName;

            if (author.AuthorSex == true)
                lbSex.Text = "男";

            else
                lbSex.Text = "女";

            lbSummary.Text = author.AuthorSummary;
        }
    }
}