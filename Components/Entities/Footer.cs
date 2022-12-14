using Newtonsoft.Json;
using System.Collections.Generic;

namespace GoC.WebTemplate.Components.Entities
{
    public class Footer
    {
        public string CdnEnv { get; set; }
        public string SubTheme { get; set; }

        [JsonProperty(DefaultValueHandling=DefaultValueHandling.Include)]
        public bool ShowFooter { get; set; }
        public List<Link> ContactLinks { get; set; }
        public List<FooterLink> PrivacyLink { get; set; }
        public List<FooterLink> TermsLink { get; set; } 
        public string LocalPath { get; set; }
    }
}