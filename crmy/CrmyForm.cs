using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace crmy
{
    public class CrmyForm : Form
    {
        public CrmyForm()
        {
            // keep a sensible default, but don't overwrite titles set by derived forms
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime &&
                string.IsNullOrWhiteSpace(this.Text))
            {
                this.Text = "CRMY";
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // only set default if derived form didn't provide a title
            if (string.IsNullOrWhiteSpace(this.Text))
                this.Text = "CRMY";
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CrmyForm
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "CrmyForm";
            this.Load += new System.EventHandler(this.CrmyForm_Load);
            this.ResumeLayout(false);

        }

        private void CrmyForm_Load(object sender, EventArgs e)
        {

        }
    }
}
