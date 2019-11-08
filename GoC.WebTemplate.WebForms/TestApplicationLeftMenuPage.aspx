﻿<%@ Page Title="" Language="C#" MasterPageFile="~/GoC.WebTemplate/GoCWebTemplate.Application.LeftMenu.Master" AutoEventWireup="true" CodeBehind="TestApplicationLeftMenuPage.aspx.cs" Inherits="GoC.WebTemplate.WebForms.TestApplicationLeftMenuPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<h1>GoC Web Template Samples - Left Side Menu</h1>
    <p><a href="http://www.gcpedia.gc.ca/wiki/Content_Delivery_Network/GoC_.NET_template_guide">Web Template Documentation (GCPedia)</a></p>

    <p>This sample uses the <code class="wb-prettify">"GoCWebTemplate.LeftMenu"</code> master page to demonstrate how the left menu is displayed and configured.</p>

    <p>The menu is set programmatically by populating the <code class="wb-prettify">"LeftMenuItems"</code> collection of the Web Template.</p>
    <p>The collection expects an object of type <code class="wb-prettify">"MenuSection"</code>, which has the following properties:</p>
    <ul>
        <li><code class="wb-prettify">Name</code>: name of the menu section.  This is the header of the menu</li>
        <li><code class="wb-prettify">Link</code>: the url of the menu section.  This is the header of the menu</li>
        <li><code class="wb-prettify">OpenInNewWindow</code>: default is false, but if set to true the link will open in a new window.</li>
        <li><code class="wb-prettify">List of MenuItem</code>: the links for this section of the side menu. This collection has the following properties
            <ul>
                <li><code class="wb-prettify">"href"</code>: the url of the link</li>
                <li><code class="wb-prettify">"name"</code>: the text of the link that is displayed</li>
                <li><code class="wb-prettify">OpenInNewWindow</code>: default is false, but if set to true the link will open in a new window.</li>
                <li><code class="wb-prettify">List of MenuItem</code>: the links for the 3rd level, menu of the side menu.</li>
            </ul>
        </li>
        <li>Although the class can take an unlimited number of sub menus, the Template limits the rendering of the menu to the 3rd level.</li>
    </ul>
    <p>For this sample, the menu items "Section A" and "sub 1" will open in a new window.</p>
    <p>When <code class="wb-prettify">OpenInNewWindow</code> is set to true, a span tag will be included for accessibility and to notify the user that the link will open a new window.</p>

    <div class="wb-prettify all-pre lang-vb linenums">
        <h3>C# Code Sample</h3>
        <pre>
GoC.WebTemplate.MenuSection leftMenu = new GoC.WebTemplate.MenuSection();

//set the header for this section of the menu
leftMenu.Name = "Section A";
leftMenu.Link = "http://www.servicecanada.gc.ca";
leftMenu.OpenInNewWindow = true;
//set the links for this section of the menu
leftMenu.Items.Add(new GoC.WebTemplate.MenuItem("http://www.tsn.ca", "TSN", new GoC.WebTemplate.MenuItem[] { 
                                                    new GoC.WebTemplate.MenuItem("http://www.cbc.ca", "sub 1", true), 
                                                    new GoC.WebTemplate.MenuItem("http://www.rds.ca", "sub 2") }));
leftMenu.Items.Add(new GoC.WebTemplate.MenuItem("http://www.cnn.ca", "CNN"));

//add section to template
this.WebTemplateMaster.WebTemplateModel.LeftMenuItems.Add(leftMenu);

//or can be done with a 1 liner
this.WebTemplateMaster.WebTemplateModel.LeftMenuItems.Add(new GoC.WebTemplate.MenuSection("Section B", new GoC.WebTemplate.MenuItem[] { 
                                                    new GoC.WebTemplate.MenuItem("http://www.rds.ca", "RDS"), 
                                                    new GoC.WebTemplate.MenuItem("http://www.lapresse.com", "La Presse") }));
        </pre>
    </div>
</asp:Content>

