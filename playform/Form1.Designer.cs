namespace playform
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.getversion = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.pwd = new System.Windows.Forms.TextBox();
            this.ip = new System.Windows.Forms.TextBox();
            this.port = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.loginres = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.cameraid = new System.Windows.Forms.TextBox();
            this.streamid = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button21 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.user = new System.Windows.Forms.TextBox();
            this.islan = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.windowsid = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.axNGSWebClient1 = new AxNGSWebClientLib.AxNGSWebClient();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axNGSWebClient1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 259);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "获取版本号";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // getversion
            // 
            this.getversion.AutoSize = true;
            this.getversion.Location = new System.Drawing.Point(96, 264);
            this.getversion.Name = "getversion";
            this.getversion.Size = new System.Drawing.Size(41, 12);
            this.getversion.TabIndex = 2;
            this.getversion.Text = "版本号";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 288);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "登陆";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pwd
            // 
            this.pwd.Location = new System.Drawing.Point(98, 317);
            this.pwd.Name = "pwd";
            this.pwd.PasswordChar = '*';
            this.pwd.Size = new System.Drawing.Size(100, 21);
            this.pwd.TabIndex = 5;
            this.pwd.Text = "Admin";
            // 
            // ip
            // 
            this.ip.Location = new System.Drawing.Point(98, 344);
            this.ip.Name = "ip";
            this.ip.Size = new System.Drawing.Size(100, 21);
            this.ip.TabIndex = 6;
            this.ip.Text = "47.114.108.44";
            // 
            // port
            // 
            this.port.Location = new System.Drawing.Point(98, 371);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(100, 21);
            this.port.TabIndex = 7;
            this.port.Text = "12000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(216, 293);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "用户";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(216, 320);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "密码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(216, 347);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "地址";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(216, 374);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "端口";
            // 
            // loginres
            // 
            this.loginres.AutoSize = true;
            this.loginres.Location = new System.Drawing.Point(12, 344);
            this.loginres.Name = "loginres";
            this.loginres.Size = new System.Drawing.Size(53, 12);
            this.loginres.TabIndex = 12;
            this.loginres.Text = "登陆结果";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(98, 416);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 14;
            this.button4.Text = "1";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(179, 416);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 15;
            this.button5.Text = "4";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // cameraid
            // 
            this.cameraid.Location = new System.Drawing.Point(98, 446);
            this.cameraid.Name = "cameraid";
            this.cameraid.Size = new System.Drawing.Size(274, 21);
            this.cameraid.TabIndex = 18;
            this.cameraid.Text = "81ec2764-7827-4b80-bdd8-1c708c658ad2";
            // 
            // streamid
            // 
            this.streamid.Location = new System.Drawing.Point(259, 477);
            this.streamid.Name = "streamid";
            this.streamid.Size = new System.Drawing.Size(22, 21);
            this.streamid.TabIndex = 19;
            this.streamid.Text = "0";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(36, 513);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 20;
            this.button8.Text = "打开相机";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(125, 513);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 21;
            this.button9.Text = "关闭相机";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(218, 513);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(89, 23);
            this.button10.TabIndex = 22;
            this.button10.Text = "关闭所有相机";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button21);
            this.groupBox1.Controls.Add(this.button20);
            this.groupBox1.Controls.Add(this.button19);
            this.groupBox1.Controls.Add(this.button18);
            this.groupBox1.Controls.Add(this.button17);
            this.groupBox1.Controls.Add(this.button16);
            this.groupBox1.Controls.Add(this.button15);
            this.groupBox1.Controls.Add(this.button14);
            this.groupBox1.Controls.Add(this.button13);
            this.groupBox1.Controls.Add(this.button12);
            this.groupBox1.Controls.Add(this.button11);
            this.groupBox1.Location = new System.Drawing.Point(3, 539);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(391, 147);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PTZ";
            // 
            // button21
            // 
            this.button21.Location = new System.Drawing.Point(164, 81);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(67, 23);
            this.button21.TabIndex = 34;
            this.button21.Text = "zoom -";
            this.button21.UseVisualStyleBackColor = true;
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(164, 43);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(67, 23);
            this.button20.TabIndex = 33;
            this.button20.Text = "zoom ＋";
            this.button20.UseVisualStyleBackColor = true;
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(103, 97);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(31, 23);
            this.button19.TabIndex = 32;
            this.button19.Text = "↘";
            this.button19.UseVisualStyleBackColor = true;
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(103, 58);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(31, 23);
            this.button18.TabIndex = 31;
            this.button18.Text = "→";
            this.button18.UseVisualStyleBackColor = true;
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(103, 20);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(31, 23);
            this.button17.TabIndex = 30;
            this.button17.Text = "↗";
            this.button17.UseVisualStyleBackColor = true;
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(59, 20);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(31, 23);
            this.button16.TabIndex = 29;
            this.button16.Text = "↑";
            this.button16.UseVisualStyleBackColor = true;
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(59, 97);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(31, 23);
            this.button15.TabIndex = 28;
            this.button15.Text = "↓";
            this.button15.UseVisualStyleBackColor = true;
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(59, 58);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(31, 23);
            this.button14.TabIndex = 27;
            this.button14.Text = "·";
            this.button14.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(11, 97);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(31, 23);
            this.button13.TabIndex = 26;
            this.button13.Text = "↙";
            this.button13.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(11, 58);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(31, 23);
            this.button12.TabIndex = 25;
            this.button12.Text = "←";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(11, 20);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(31, 23);
            this.button11.TabIndex = 24;
            this.button11.Text = "↖";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // user
            // 
            this.user.Location = new System.Drawing.Point(98, 290);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(100, 21);
            this.user.TabIndex = 4;
            this.user.Text = "Admin";
            // 
            // islan
            // 
            this.islan.Location = new System.Drawing.Point(271, 290);
            this.islan.Name = "islan";
            this.islan.Size = new System.Drawing.Size(36, 21);
            this.islan.TabIndex = 24;
            this.islan.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(313, 293);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 25;
            this.label7.Text = "isLan";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 421);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 26;
            this.label1.Text = "设置布局";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 455);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 27;
            this.label8.Text = "相机ID";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(177, 480);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 28;
            this.label9.Text = "流ID(0或1)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 482);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 12);
            this.label10.TabIndex = 30;
            this.label10.Text = "窗口ID(从0开始)";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // windowsid
            // 
            this.windowsid.Location = new System.Drawing.Point(116, 477);
            this.windowsid.Name = "windowsid";
            this.windowsid.Size = new System.Drawing.Size(25, 21);
            this.windowsid.TabIndex = 29;
            this.windowsid.Text = "0";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(3, 374);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 31;
            this.button3.Text = "登出";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // axNGSWebClient1
            // 
            this.axNGSWebClient1.Enabled = true;
            this.axNGSWebClient1.Location = new System.Drawing.Point(3, 3);
            this.axNGSWebClient1.Name = "axNGSWebClient1";
            this.axNGSWebClient1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axNGSWebClient1.OcxState")));
            this.axNGSWebClient1.Size = new System.Drawing.Size(391, 249);
            this.axNGSWebClient1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 698);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.windowsid);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.islan);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.streamid);
            this.Controls.Add(this.cameraid);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.loginres);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.port);
            this.Controls.Add(this.ip);
            this.Controls.Add(this.pwd);
            this.Controls.Add(this.user);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.getversion);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.axNGSWebClient1);
            this.Name = "Form1";
            this.Text = "测试窗口";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axNGSWebClient1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxNGSWebClientLib.AxNGSWebClient axNGSWebClient1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label getversion;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox pwd;
        private System.Windows.Forms.TextBox ip;
        private System.Windows.Forms.TextBox port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label loginres;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox cameraid;
        private System.Windows.Forms.TextBox streamid;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.TextBox user;
        private System.Windows.Forms.TextBox islan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox windowsid;
        private System.Windows.Forms.Button button3;
    }
}

