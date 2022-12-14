using System;

namespace GoC.WebTemplate.Components.Configs.Cdts
{
    public class CdtsEnvironment : ICdtsEnvironment
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string CDN { get; set; }
        public string SubTheme { get; set; }
        public bool IsVersionRNCombined { get; set; }
        public bool IsEncryptionModifiable { get; set; }
        public string LocalPath { get; set; }
        public string Theme { get; set; }
        public string AppendToTitle { get; set; }
        public int FooterSectionLimit { get; set; }
        public bool CanHaveMultipleContactLinks { get; set; }
        public bool CanHaveContactLinkInAppTemplate { get; set; }
        public bool CanUseWebAnalytics { get; set; }

        public bool ThemeIsGCWeb()
        {
            return Theme.Equals(CdtsThemes.GCWeb.ToString(), StringComparison.OrdinalIgnoreCase);
        }

        public enum CdtsThemes
        {
            GCWeb,
            GCIntranet
        }
    }
}