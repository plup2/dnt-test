﻿<%@ Page Title="" Language="C#" MasterPageFile="~/GoC.WebTemplate/GoCWebTemplate.Master" AutoEventWireup="true" CodeBehind="FeedbackandShareThisPageSample.aspx.cs" Inherits="FeedbackandShareThisPageSample" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <h1>GoC Web Template Samples - Feedback Link and Share This Page Link</h1>
    <p><a href="http://www.gcpedia.gc.ca/wiki/Content_Delivery_Network/GoC_.NET_template_guide">Web Template Documentation (GCPedia)</a></p>

    <h2>Report a Problem Link (formerly Feedback Link)</h2>
    <p>The Report a Problem Link is a way for the users of your site to provide feedback on their experience navigating through the site or to report an issue.  Displaying the link is optional but it cannot be contextualized and Portfolio Web or the Principal Publisher should be contacted to help you determine if it should be displayed on your site. The URL of the link is pre-defined by the theme but can be modified in the web.config or programmatically.</p>

    <p>To display the link</p>
        <ul>
            <li>Set the key <code class="wb-prettify">"GoC.WebTemplate.ShowFeedbackLink"</code> in the web.config to "true".</li>
            <li>or set the property programmatically. <code class="wb-prettify">"this.WebTemplateMaster.WebTemplateCore.ShowFeedbackLink = true;"</code></li>
            <li>If you wish to redirect the user to your own pages instead of the default canada.ca page, set the key <code class="wb-prettify">"FeedbackLinkURL"</code> in the web.config to the url of your page.</li>
            <li>or set the property programmatically. <code class="wb-prettify">"this.WebTemplateMaster.WebTemplateCore.FeedbackLinkURL = [page];"</code></li>
        </ul>
            
    <h2>Share This Page Link</h2>
    <p>The "Share This Page" Link is a way for the users to share the URL of the site via Social Media .  Displaying the link is optional and Portfolio Web or the Principal Publisher should be contacted to help you determine if it should be displayed on your site.</p>

    <p>To display the Share This Page link</p>
        <ul>
            <li>Set the key <code class="wb-prettify">"GoC.WebTemplate.ShowSharePageLink"</code> in the web.config to "true".</li>
            <li>or set the property programmatically. <code class="wb-prettify">"this.WebTemplateMaster.WebTemplateCore.ShowSharePageLink = true;"</code></li>
        </ul>
    <p>If you decide to show the link, you must provide the list of Social Media sites to be displayed to the user by programatically populating the <code class="wb-prettify">"SharePageMediaSites"</code> collection of the Web Template.</p>
    <p>If the collection <code class="wb-prettify">"SharePageMediaSites"</code> is left empty, the link will not be displayed.</p>
    
     <p>The collection is of type <code class="wb-prettify">"SocialMediaSites"</code> which is an enum of the Web Template.</p>
   
    <div class="wb-prettify all-pre lang-vb linenums">
        <h3>C# Code Sample</h3>
        <pre>
//Display the FeedbackLink
this.WebTemplateMaster.WebTemplateCore.ShowFeedbackLink = true; //this could be set in the web.config, key = "GoC.WebTemplate.showFeedbackLink"
this.WebTemplateMaster.WebTemplateCore.FeedbackLink.URL = "http://www.aircanada.com/en/customercare/customersolutions.html";
            
//Specify the Share This Page with Media sites.
this.WebTemplateMaster.WebTemplateCore.ShowSharePageLink = true; //this could be set in the web.config, key = "GoC.WebTemplate.showSharePageLink"
this.WebTemplateMaster.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.bitly);
this.WebTemplateMaster.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.facebook);
this.WebTemplateMaster.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.twitter);
        </pre>
    </div>
    <!-- #include virtual="SamplesNavigation.html" -->
</asp:Content>
