
namespace Unagi
{
    partial class UnagiExplorerRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public UnagiExplorerRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabMail = this.Factory.CreateRibbonTab();
            this.unagiGroup = this.Factory.CreateRibbonGroup();
            this.btnReportPhish = this.Factory.CreateRibbonButton();
            this.tabMail.SuspendLayout();
            this.unagiGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMail
            // 
            this.tabMail.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tabMail.ControlId.OfficeId = "TabMail";
            this.tabMail.Groups.Add(this.unagiGroup);
            this.tabMail.Label = "TabMail";
            this.tabMail.Name = "tabMail";
            // 
            // unagiGroup
            // 
            this.unagiGroup.Items.Add(this.btnReportPhish);
            this.unagiGroup.Label = "unagi";
            this.unagiGroup.Name = "unagiGroup";
            // 
            // btnReportPhish
            // 
            this.btnReportPhish.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnReportPhish.Image = global::Unagi.Properties.Resources.Phish;
            this.btnReportPhish.Label = "Report Phish";
            this.btnReportPhish.Name = "btnReportPhish";
            this.btnReportPhish.ShowImage = true;
            this.btnReportPhish.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnReportPhish_Click);
            // 
            // UnagiExplorerRibbon
            // 
            this.Name = "UnagiExplorerRibbon";
            this.RibbonType = "Microsoft.Outlook.Explorer";
            this.Tabs.Add(this.tabMail);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.UnagiExplorerRibbon_Load);
            this.tabMail.ResumeLayout(false);
            this.tabMail.PerformLayout();
            this.unagiGroup.ResumeLayout(false);
            this.unagiGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tabMail;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup unagiGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnReportPhish;
    }

    partial class ThisRibbonCollection
    {
        internal UnagiExplorerRibbon Ribbon1
        {
            get { return this.GetRibbon<UnagiExplorerRibbon>(); }
        }
    }
}
