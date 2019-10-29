﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using GoC.WebTemplate.Components.Core.Services;
using GoC.WebTemplate.CoreMVC.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace GoC.WebTemplate.CoreMVC.Sample.Controllers
{
    public class GoCWebTemplateSamplesController : WebTemplateBaseController
    {
        public GoCWebTemplateSamplesController(ModelAccessor modelAccessor)
            : base(modelAccessor) { }

        public IActionResult BaseSettingsSample()
        {
            //Page Title
            WebTemplateModel.HeaderTitle = "Basic Settings";

            //Metatags
            WebTemplateModel.HTMLHeaderElements.Add("<meta charset='UTF-8'>");
            WebTemplateModel.HTMLHeaderElements.Add("<meta name='singer' content='Elvis'>");
            WebTemplateModel.HTMLHeaderElements.Add("<meta http-equiv='default-style' content='sample'>");

            //Date Modifiied
            WebTemplateModel.DateModified = new DateTime(2019,10,23);

            //Version Identifier
            WebTemplateModel.VersionIdentifier = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;

            //Screen Identifier
            WebTemplateModel.ScreenIdentifier = "BASE-SETTING-SAMPLE";

            //Contact Links
            WebTemplateModel.ContactLinks.Add(new Components.Entities.Link { Href = "http://travel.gc.ca/" });

            return View();
        }
        
    }
}
