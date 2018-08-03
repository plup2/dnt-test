﻿using System;

namespace GoC.WebTemplate.WebForm.Sample.Pages
{
    public partial class Redirect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //this page has no visual and will not be displayed to the user
                                             
            string targetURL = Server.HtmlDecode(this.Request.QueryString.Get("targetUrl"));
            
            //add any necessary clean up code (clear session, logout user, etc...)

            //redirect user to link they had clicked
            if (!string.IsNullOrEmpty(targetURL))
            {
                Response.Redirect(targetURL);
            }
            else
            { 
                // decide how you want to handle this situation
            }            
        }
    }
}