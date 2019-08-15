using System;

namespace IpCheckerView
{
    partial class IpCheckerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.IPListView = new BrightIdeasSoftware.ObjectListView();
            this.Ips = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Info = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.GetIPS = new System.Windows.Forms.Button();
            this.checkip = new System.Windows.Forms.Button();
            this.Malicious = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.IPListView)).BeginInit();
            this.SuspendLayout();
            // 
            // IPListView
            // 
            this.IPListView.AccessibleName = "IPListView";
            this.IPListView.AllColumns.Add(this.Ips);
            this.IPListView.AllColumns.Add(this.Info);
            this.IPListView.AllColumns.Add(this.Malicious);
            this.IPListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Ips,
            this.Info,
            this.Malicious});
            this.IPListView.HideSelection = false;
            this.IPListView.Location = new System.Drawing.Point(26, 81);
            this.IPListView.Margin = new System.Windows.Forms.Padding(2);
            this.IPListView.Name = "IPListView";
            this.IPListView.Size = new System.Drawing.Size(585, 342);
            this.IPListView.TabIndex = 0;
            this.IPListView.UseCompatibleStateImageBehavior = false;
            this.IPListView.View = System.Windows.Forms.View.Details;
            // 
            // Ips
            // 
            this.Ips.AspectName = "IPAddress";
            this.Ips.CellPadding = null;
            this.Ips.Text = "Ip";
            this.Ips.Width = 120;
            // 
            // Info
            // 
            this.Info.AspectName = "IPInfo";
            this.Info.CellPadding = null;
            this.Info.Text = "Info";
            this.Info.Width = 280;
            // 
            // GetIPS
            // 
            this.GetIPS.Location = new System.Drawing.Point(26, 27);
            this.GetIPS.Name = "GetIPS";
            this.GetIPS.Size = new System.Drawing.Size(137, 35);
            this.GetIPS.TabIndex = 1;
            this.GetIPS.Text = "Get IPS";
            this.GetIPS.UseVisualStyleBackColor = true;
            this.GetIPS.Click += new System.EventHandler(this.GetIPS_Click);
            // 
            // checkip
            // 
            this.checkip.Location = new System.Drawing.Point(179, 27);
            this.checkip.Name = "checkip";
            this.checkip.Size = new System.Drawing.Size(137, 35);
            this.checkip.TabIndex = 2;
            this.checkip.Text = "Check IP";
            this.checkip.UseVisualStyleBackColor = true;
            this.checkip.Click += new System.EventHandler(this.Checkip_ClickAsync);
            // 
            // Malicious
            // 
            this.Malicious.AspectName = "IsMalicious";
            this.Malicious.CellPadding = null;
            this.Malicious.Text = "Malicious";
            this.Malicious.Width = 166;
            // 
            // IpCheckerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 440);
            this.Controls.Add(this.checkip);
            this.Controls.Add(this.GetIPS);
            this.Controls.Add(this.IPListView);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "IpCheckerForm";
            this.Text = "IpCheckerForm";
            ((System.ComponentModel.ISupportInitialize)(this.IPListView)).EndInit();
            this.ResumeLayout(false);

        }



        #endregion

        private BrightIdeasSoftware.ObjectListView IPListView;
        private System.Windows.Forms.Button GetIPS;
        private System.Windows.Forms.Button checkip;
        private BrightIdeasSoftware.OLVColumn Ips;
        private BrightIdeasSoftware.OLVColumn Info;
        private BrightIdeasSoftware.OLVColumn Malicious;
    }
}