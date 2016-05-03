namespace PS3_RIP
{
    partial class settings
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lbxPatterns = new System.Windows.Forms.ListBox();
            this.cbxBrit = new System.Windows.Forms.CheckBox();
            this.cbxAust = new System.Windows.Forms.CheckBox();
            this.btnDef = new System.Windows.Forms.Button();
            this.btnAllow = new System.Windows.Forms.Button();
            this.cbx3d = new System.Windows.Forms.CheckBox();
            this.btnShowHide = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(777, 436);
            this.splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(334, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Settings";
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lbxPatterns);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.cbxBrit);
            this.splitContainer2.Panel2.Controls.Add(this.cbxAust);
            this.splitContainer2.Panel2.Controls.Add(this.btnDef);
            this.splitContainer2.Panel2.Controls.Add(this.btnAllow);
            this.splitContainer2.Panel2.Controls.Add(this.cbx3d);
            this.splitContainer2.Panel2.Controls.Add(this.btnShowHide);
            this.splitContainer2.Size = new System.Drawing.Size(777, 382);
            this.splitContainer2.SplitterDistance = 150;
            this.splitContainer2.TabIndex = 0;
            // 
            // lbxPatterns
            // 
            this.lbxPatterns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxPatterns.FormattingEnabled = true;
            this.lbxPatterns.ItemHeight = 16;
            this.lbxPatterns.Location = new System.Drawing.Point(0, 0);
            this.lbxPatterns.Name = "lbxPatterns";
            this.lbxPatterns.Size = new System.Drawing.Size(148, 380);
            this.lbxPatterns.TabIndex = 0;
            // 
            // cbxBrit
            // 
            this.cbxBrit.AutoSize = true;
            this.cbxBrit.Location = new System.Drawing.Point(72, 59);
            this.cbxBrit.Name = "cbxBrit";
            this.cbxBrit.Size = new System.Drawing.Size(119, 21);
            this.cbxBrit.TabIndex = 5;
            this.cbxBrit.Text = "British English";
            this.cbxBrit.UseVisualStyleBackColor = true;
            // 
            // cbxAust
            // 
            this.cbxAust.AutoSize = true;
            this.cbxAust.Location = new System.Drawing.Point(72, 32);
            this.cbxAust.Name = "cbxAust";
            this.cbxAust.Size = new System.Drawing.Size(93, 21);
            this.cbxAust.TabIndex = 4;
            this.cbxAust.Text = "Australian";
            this.cbxAust.UseVisualStyleBackColor = true;
            // 
            // btnDef
            // 
            this.btnDef.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDef.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDef.Location = new System.Drawing.Point(287, 346);
            this.btnDef.Name = "btnDef";
            this.btnDef.Size = new System.Drawing.Size(75, 23);
            this.btnDef.TabIndex = 3;
            this.btnDef.Text = "Default";
            this.btnDef.UseVisualStyleBackColor = true;
            // 
            // btnAllow
            // 
            this.btnAllow.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAllow.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAllow.Location = new System.Drawing.Point(184, 346);
            this.btnAllow.Name = "btnAllow";
            this.btnAllow.Size = new System.Drawing.Size(75, 23);
            this.btnAllow.TabIndex = 2;
            this.btnAllow.Text = "Allow";
            this.btnAllow.UseVisualStyleBackColor = true;
            // 
            // cbx3d
            // 
            this.cbx3d.AutoSize = true;
            this.cbx3d.Location = new System.Drawing.Point(72, 5);
            this.cbx3d.Name = "cbx3d";
            this.cbx3d.Size = new System.Drawing.Size(48, 21);
            this.cbx3d.TabIndex = 1;
            this.cbx3d.Text = "3D";
            this.cbx3d.UseVisualStyleBackColor = true;
            // 
            // btnShowHide
            // 
            this.btnShowHide.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShowHide.ForeColor = System.Drawing.Color.Green;
            this.btnShowHide.Location = new System.Drawing.Point(3, 3);
            this.btnShowHide.Name = "btnShowHide";
            this.btnShowHide.Size = new System.Drawing.Size(40, 23);
            this.btnShowHide.TabIndex = 0;
            this.btnShowHide.Text = "+";
            this.btnShowHide.UseVisualStyleBackColor = true;
            this.btnShowHide.Click += new System.EventHandler(this.btnShowHide_Click);
            // 
            // settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 436);
            this.Controls.Add(this.splitContainer1);
            this.Name = "settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Patterns";
            this.Load += new System.EventHandler(this.settings_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnShowHide;
        private System.Windows.Forms.ListBox lbxPatterns;
        private System.Windows.Forms.Button btnDef;
        private System.Windows.Forms.Button btnAllow;
        private System.Windows.Forms.CheckBox cbx3d;
        private System.Windows.Forms.CheckBox cbxAust;
        private System.Windows.Forms.CheckBox cbxBrit;
    }
}