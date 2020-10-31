namespace playform
{
    partial class FrmOCXPlay
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Size_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Close_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closewindows_button = new System.Windows.Forms.ToolStripButton();
            this.screenshot_button = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.Navy;
            this.toolStrip1.ContextMenuStrip = this.contextMenuStrip1;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closewindows_button,
            this.screenshot_button,
            this.toolStripLabel1,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripLabel2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(354, 35);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.Paint += new System.Windows.Forms.PaintEventHandler(this.toolStrip1_Paint);
            this.toolStrip1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.toolStrip1_MouseDoubleClick);
            this.toolStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            this.toolStrip1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Size_ToolStripMenuItem,
            this.Close_ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(113, 48);
            // 
            // Size_ToolStripMenuItem
            // 
            this.Size_ToolStripMenuItem.Name = "Size_ToolStripMenuItem";
            this.Size_ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.Size_ToolStripMenuItem.Text = "最大化";
            this.Size_ToolStripMenuItem.Click += new System.EventHandler(this.Size_ToolStripMenuItem_Click);
            // 
            // Close_ToolStripMenuItem
            // 
            this.Close_ToolStripMenuItem.Name = "Close_ToolStripMenuItem";
            this.Close_ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.Close_ToolStripMenuItem.Text = "关闭";
            this.Close_ToolStripMenuItem.Click += new System.EventHandler(this.Close_ToolStripMenuItem_Click);
            // 
            // closewindows_button
            // 
            this.closewindows_button.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.closewindows_button.AutoSize = false;
            this.closewindows_button.BackgroundImage = global::playform.Properties.Resources.Close_easyi_bk;
            this.closewindows_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.closewindows_button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.closewindows_button.ForeColor = System.Drawing.Color.White;
            this.closewindows_button.Image = global::playform.Properties.Resources.Close_easyi_bk;
            this.closewindows_button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.closewindows_button.Name = "closewindows_button";
            this.closewindows_button.Size = new System.Drawing.Size(28, 28);
            this.closewindows_button.Text = "关闭窗体";
            this.closewindows_button.Click += new System.EventHandler(this.closewindows_button_Click);
            this.closewindows_button.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // screenshot_button
            // 
            this.screenshot_button.AutoSize = false;
            this.screenshot_button.BackgroundImage = global::playform.Properties.Resources.screenshot;
            this.screenshot_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.screenshot_button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.screenshot_button.ForeColor = System.Drawing.Color.White;
            this.screenshot_button.Image = global::playform.Properties.Resources.screenshot;
            this.screenshot_button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.screenshot_button.Name = "screenshot_button";
            this.screenshot_button.Size = new System.Drawing.Size(28, 28);
            this.screenshot_button.Text = "截图";
            this.screenshot_button.Visible = false;
            this.screenshot_button.Click += new System.EventHandler(this.screenshot_button_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(0, 32);
            this.toolStripLabel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripButton1.ForeColor = System.Drawing.Color.White;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(46, 32);
            this.toolStripButton1.Text = "主流";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.BackColor = System.Drawing.Color.Transparent;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripButton2.ForeColor = System.Drawing.Color.White;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(46, 32);
            this.toolStripButton2.Text = "辅流";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(24, 32);
            this.toolStripLabel2.Text = "    ";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(354, 235);
            this.panel1.TabIndex = 1;
            // 
            // FrmOCXPlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 270);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmOCXPlay";
            this.Text = "FrmOCXPlay";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmOCXPlay_FormClosing);
            this.Load += new System.EventHandler(this.FrmOCXPlay_Load);
            this.VisibleChanged += new System.EventHandler(this.FrmOCXPlay_VisibleChanged);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton screenshot_button;
        private System.Windows.Forms.ToolStripButton closewindows_button;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Size_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Close_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
    }
}
