namespace EarthQuakes
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.ddlPeriod = new System.Windows.Forms.ComboBox();
            this.lblDetails = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1008, 473);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // refreshBtn
            // 
            this.refreshBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshBtn.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.refreshBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.refreshBtn.Location = new System.Drawing.Point(12, 436);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(32, 25);
            this.refreshBtn.TabIndex = 1;
            this.refreshBtn.Text = "Ѻ";
            this.refreshBtn.UseVisualStyleBackColor = false;
            this.refreshBtn.Visible = false;
            // 
            // ddlPeriod
            // 
            this.ddlPeriod.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ddlPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPeriod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ddlPeriod.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ddlPeriod.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ddlPeriod.FormattingEnabled = true;
            this.ddlPeriod.Items.AddRange(new object[] {
            "Last day",
            "Last week",
            "Last month",
            "Important"});
            this.ddlPeriod.Location = new System.Drawing.Point(50, 436);
            this.ddlPeriod.Name = "ddlPeriod";
            this.ddlPeriod.Size = new System.Drawing.Size(100, 23);
            this.ddlPeriod.TabIndex = 2;
            this.ddlPeriod.SelectedIndexChanged += new System.EventHandler(this.ddlPeriod_SelectedIndexChanged);
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.lblDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDetails.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDetails.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDetails.Location = new System.Drawing.Point(852, 441);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(43, 15);
            this.lblDetails.TabIndex = 3;
            this.lblDetails.Text = "Details";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Earthquakes notifier";
            this.notifyIcon1.Visible = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 473);
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.ddlPeriod);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Earthquakes";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public PictureBox pictureBox1;
        public Button refreshBtn;
        public ComboBox ddlPeriod;
        public Label lblDetails;
        public NotifyIcon notifyIcon1;
    }
}