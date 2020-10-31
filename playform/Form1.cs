using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace playform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string Camera_StreamID = "1";

        private void button1_Click(object sender, EventArgs e)
        {
            getversion.Text = axNGSWebClient1.GetProductVersion().ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int res = axNGSWebClient1.Login(ip.Text, Int32.Parse(port.Text.ToString()), user.Text, pwd.Text, Int32.Parse(islan.Text.ToString()));
            if(res ==1)
            {
                loginres.Text = "登陆成功";
            }
            else
            {
                loginres.Text = "登陆失败 ：" + res.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ///设置布局-1
            axNGSWebClient1.SetLayout(1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //设置布局-4
            axNGSWebClient1.SetLayout(4);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            axNGSWebClient1.StartLiveByIdEx(cameraid.Text.ToString(), Int32.Parse(streamid.Text.ToString()), 0, Int32.Parse(windowsid.Text.ToString()));
        }

        private void button9_Click(object sender, EventArgs e)
        {
            axNGSWebClient1.StopLiveInLayout(Int32.Parse(windowsid.Text.ToString()));
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            axNGSWebClient1.StopAllLiveInLayout();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int res = axNGSWebClient1.Logout();
            if(res == 1)
            {
                loginres.Text = "已经登出";
            }
            else
            {
                loginres.Text = "登出失败 :" + res.ToString();
            }
        }
    }
}
