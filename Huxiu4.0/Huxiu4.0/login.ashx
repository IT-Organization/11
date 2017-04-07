<%@ WebHandler Language="C#" Class="login" %>

using System;
using System.Web;
using System.Web.SessionState;

public class login : IHttpHandler,IReadOnlySessionState {

    public void ProcessRequest (HttpContext context) {

        string userName = context.Request.Form[""].ToString().Trim();
        string pwd = context.Request.Form[""].ToString().Trim();
        string captcha = context.Request.Form[""].ToString().Trim();

    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}