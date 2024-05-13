namespace PWToEE
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            lblAuthToken = new Label();
            txtbAuthToken = new TextBox();
            lblWorldId = new Label();
            txtbWorldId = new TextBox();
            btnDownload = new Button();
            cbAuthToken = new CheckBox();
            statusStrip1 = new StatusStrip();
            tsslblStatus = new ToolStripStatusLabel();
            tssStatus = new ToolStripStatusLabel();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // lblAuthToken
            // 
            lblAuthToken.AutoSize = true;
            lblAuthToken.Location = new Point(76, 9);
            lblAuthToken.Name = "lblAuthToken";
            lblAuthToken.Size = new Size(64, 15);
            lblAuthToken.TabIndex = 0;
            lblAuthToken.Text = "AuthToken";
            // 
            // txtbAuthToken
            // 
            txtbAuthToken.Location = new Point(44, 35);
            txtbAuthToken.Name = "txtbAuthToken";
            txtbAuthToken.Size = new Size(145, 23);
            txtbAuthToken.TabIndex = 0;
            txtbAuthToken.UseSystemPasswordChar = true;
            // 
            // lblWorldId
            // 
            lblWorldId.AutoSize = true;
            lblWorldId.Location = new Point(76, 86);
            lblWorldId.Name = "lblWorldId";
            lblWorldId.Size = new Size(50, 15);
            lblWorldId.TabIndex = 2;
            lblWorldId.Text = "WorldID";
            // 
            // txtbWorldId
            // 
            txtbWorldId.Location = new Point(44, 104);
            txtbWorldId.Name = "txtbWorldId";
            txtbWorldId.Size = new Size(142, 23);
            txtbWorldId.TabIndex = 1;
            // 
            // btnDownload
            // 
            btnDownload.Location = new Point(64, 133);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(86, 21);
            btnDownload.TabIndex = 4;
            btnDownload.Text = "Download";
            btnDownload.UseVisualStyleBackColor = true;
            btnDownload.Click += btnDownload_Click;
            // 
            // cbAuthToken
            // 
            cbAuthToken.AutoSize = true;
            cbAuthToken.Location = new Point(54, 64);
            cbAuthToken.Name = "cbAuthToken";
            cbAuthToken.Size = new Size(110, 19);
            cbAuthToken.TabIndex = 5;
            cbAuthToken.Text = "Save AuthToken";
            cbAuthToken.UseVisualStyleBackColor = true;
            cbAuthToken.CheckedChanged += cbAuthToken_CheckedChanged;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { tsslblStatus, tssStatus });
            statusStrip1.Location = new Point(0, 179);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(238, 22);
            statusStrip1.TabIndex = 6;
            statusStrip1.Text = "statusStrip1";
            // 
            // tsslblStatus
            // 
            tsslblStatus.Name = "tsslblStatus";
            tsslblStatus.Size = new Size(42, 17);
            tsslblStatus.Text = "Status:";
            // 
            // tssStatus
            // 
            tssStatus.Name = "tssStatus";
            tssStatus.Size = new Size(0, 17);
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(238, 201);
            Controls.Add(statusStrip1);
            Controls.Add(cbAuthToken);
            Controls.Add(btnDownload);
            Controls.Add(txtbWorldId);
            Controls.Add(lblWorldId);
            Controls.Add(txtbAuthToken);
            Controls.Add(lblAuthToken);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PixelWalker To EEO";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAuthToken;
        private TextBox txtbAuthToken;
        private Label lblWorldId;
        private TextBox txtbWorldId;
        private Button btnDownload;
        private CheckBox cbAuthToken;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tsslblStatus;
        private ToolStripStatusLabel tssStatus;
    }
}
