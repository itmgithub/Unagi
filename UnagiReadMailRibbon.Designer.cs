
namespace Unagi
{
    partial class UnagiReadMailRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public UnagiReadMailRibbon()
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
            this.tabReadMessage = this.Factory.CreateRibbonTab();
            this.unagiGroup = this.Factory.CreateRibbonGroup();
            this.btnReportPhish = this.Factory.CreateRibbonButton();
            this.tabReadMessage.SuspendLayout();
            this.unagiGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabReadMessage
            // 
            this.tabReadMessage.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tabReadMessage.ControlId.OfficeId = "TabReadMessage";
            this.tabReadMessage.Groups.Add(this.unagiGroup);
            this.tabReadMessage.Label = "TabReadMessage";
            this.tabReadMessage.Name = "tabReadMessage";
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
            // UnagiReadMailRibbon
            // 
            this.Name = "UnagiReadMailRibbon";
            this.RibbonType = "Microsoft.Outlook.Mail.Read";
            this.Tabs.Add(this.tabReadMessage);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.UnagiReadMailRibbon_Load);
            this.tabReadMessage.ResumeLayout(false);
            this.tabReadMessage.PerformLayout();
            this.unagiGroup.ResumeLayout(false);
            this.unagiGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tabReadMessage;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup unagiGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnReportPhish;
    }

    partial class ThisRibbonCollection
    {
        internal UnagiReadMailRibbon UnagiReadMailRibbon
        {
            get { return this.GetRibbon<UnagiReadMailRibbon>(); }
        }
    }
}
