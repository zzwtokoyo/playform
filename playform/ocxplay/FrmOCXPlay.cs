using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

/*类说明
 * 作者：zhongzw
 * 时间：2019/4/12
 *
 * 说明：OCX视频功能
 * 功能：OCX播放，挂断功能
 */

using System.Configuration;
using System.IO;
using System.Runtime.InteropServices;
using playform.function;

namespace playform
{
    public partial class FrmOCXPlay : Form
    {
        /// <summary>
        /// 默认主码流运行 0主码流 1辅码流
        /// </summary>
        private static int streamstatus = 0; //
        private static string m_playno = string.Empty;
        public string titleText = string.Empty;
        /// <summary>
        /// ocx插件
        /// </summary>
        //private AxNGSWebClientLib.AxNGSWebClient m_PlayOcx = new AxNGSWebClientLib.AxNGSWebClient();

        public FrmOCXPlay()
        {
            InitializeComponent();
        }
        public FrmOCXPlay(int localx, int localy, int xsize, int ysize)
        {
            try
            {
                InitializeComponent();
                this.Size = new Size(xsize, ysize);
                this.Location = new Point(localx, localy);
                this.StartPosition = FormStartPosition.Manual;
                toolStrip1.BackColor = Color.FromArgb(1, 4, 22);                
            }
            catch(Exception ex)
            {
                if (publicfunction.g_IsRecLog == "Yes")
                {
                    RecordLog.GetInstance().WriteLog(Level.Info, string.Format("创建视屏窗口失败 ：{0}", ex.Message));
                }
            }
        }

        private void FrmOCXPlay_Load(object sender, EventArgs e)
        {
            try
            {
                this.panel1.Parent = this;
                this.panel1.Dock = DockStyle.Fill;
                if (AxOxcNGClient.GetInstance().g_axNGSWebClient1 != null)
                {
                    this.panel1.Controls.Add(AxOxcNGClient.GetInstance().g_axNGSWebClient1);
                }
                AxOxcNGClient.GetInstance().g_axNGSWebClient1.Parent = this.panel1;
                AxOxcNGClient.GetInstance().g_axNGSWebClient1.Dock = DockStyle.Fill;
                AxOxcNGClient.GetInstance().g_axNGSWebClient1.BringToFront();
                //toolStripLabel2.Text = titleText;
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.Show();
                }
            }
            catch(Exception ex)
            {
                if (publicfunction.g_IsRecLog == "Yes")
                {
                    RecordLog.GetInstance().WriteLog(Level.Info, string.Format("视频窗口显示异常 ：{0}", ex.Message));
                }
            }
        }


        /// <summary>
        /// 视频播放,默认主流播放
        /// </summary>
        /// <param name="playno"></param>
        public int PlayCall(string playno , int streammod = 0)
        {
            int iRet = 0;
            try
            {
                if (publicfunction.g_lastSplitCount != 1)
                {
                    AxOxcNGClient.GetInstance().g_axNGSWebClient1.SetLayout(1);
                    publicfunction.g_lastSplitCount = 1;
                    if (publicfunction.g_IsRecLog == "Yes")
                    {
                        RecordLog.GetInstance().WriteLog(Level.Info, string.Format("设置单窗口播放"));
                    }
                }
                if (string.IsNullOrEmpty(playno))
                {
                    publicfunction.stopTimer();
                    MessageBox.Show("视频播放id为空，请输入正确播放id");
                    if (publicfunction.g_IsRecLog == "Yes")
                    {
                        RecordLog.GetInstance().WriteLog(Level.Info, string.Format("视频播放id为空，请输入正确播放id"));
                    }
                    return iRet;
                }
                iRet = AxOxcNGClient.GetInstance().g_axNGSWebClient1.StartLiveById(playno.ToString(), streamstatus,
                    0);
                if (iRet != 1)
                {
                    publicfunction.stopTimer();
                    Console.WriteLine("视频播放失败");
                    return iRet;
                }
                streamstatus = streammod;
                m_playno = playno.ToString();
                if (publicfunction.g_IsRecLog == "Yes")
                {
                    RecordLog.GetInstance().WriteLog(Level.Info, string.Format("播放视频源：{0},视频流模式: {1}", playno, streammod));
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("视频播放异常：" + ex.Message);
            }
            return iRet;
        }

        /// <summary>
        /// 多窗口播放
        /// </summary>
        /// <param name="playno"></param>
        /// <param name="splitcount"></param>
        /// <param name="windows"></param>
        /// <param name="streammod"></param>
        /// <returns></returns>
        public int PlayCallEx(string playno,int splitcount,int windows, int streammod = 0)
        {
            int iRet = 0;
            try
            {
                if(publicfunction.g_lastSplitCount != splitcount)
                {
                    AxOxcNGClient.GetInstance().g_axNGSWebClient1.SetLayout(splitcount);
                    publicfunction.g_lastSplitCount = splitcount;
                    if (publicfunction.g_IsRecLog == "Yes")
                    {
                        RecordLog.GetInstance().WriteLog(Level.Info, string.Format("设置分屏数量: {0}", splitcount));
                    }
                }
                if (string.IsNullOrEmpty(playno))
                {
                    publicfunction.stopTimer();
                    MessageBox.Show("视频播放id为空，请输入正确播放id");
                    if (publicfunction.g_IsRecLog == "Yes")
                    {
                        RecordLog.GetInstance().WriteLog(Level.Info, string.Format("视频播放id为空，请输入正确播放id"));
                    }
                    return iRet;
                }
                iRet = AxOxcNGClient.GetInstance().g_axNGSWebClient1.StartLiveByIdEx(playno.ToString(), streamstatus,
                    0, windows);
                if (iRet != 1)
                {
                    publicfunction.stopTimer();
                    Console.WriteLine("视频播放失败");
                    return iRet;
                }
                streamstatus = streammod;
                m_playno = playno.ToString();
                if (publicfunction.g_IsRecLog == "Yes")
                {
                    RecordLog.GetInstance().WriteLog(Level.Info, string.Format("播放视频源：{0}，分屏数量: {1},播放窗口：{2},视频流模式: {3}",
                        playno,splitcount,windows,streammod));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("视频播放异常：" + ex.Message);
            }
            return iRet;
        }

        public int CloseWindows(int indexwindows)
        {
            int iRet = 0;
            try
            {
                iRet = AxOxcNGClient.GetInstance().g_axNGSWebClient1.StopLiveInLayout(indexwindows);
                if (iRet != 1)
                {
                    publicfunction.stopTimer();
                    Console.WriteLine("关闭视窗失败");
                    return iRet;
                }
                if (publicfunction.g_IsRecLog == "Yes")
                {
                    RecordLog.GetInstance().WriteLog(Level.Info, string.Format("关闭指定窗口 ：{0}", indexwindows));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("关闭视窗失败：" + ex.Message);
            }
            return iRet;
        }

        
        /// <summary>
        /// 关闭窗口-停止视频流
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void closewindows_button_Click(object sender, EventArgs e)
        {
            AxOxcNGClient.GetInstance().g_axNGSWebClient1.StopAllLiveInLayout();
            if (this.WindowState == FormWindowState.Normal)
            {
                this.Hide();
            }
        }
        private void screenshot_button_Click(object sender, EventArgs e)
        {

        }
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern bool ReleaseCapture();

        private const int WM_NCLBUTTONDOWN = 0x00A1;
        private const int HTCAPTION = 2;

        private new void MouseMove(object sender, MouseEventArgs e)
        {
            this.TopMost = true;
            if (e.Button == MouseButtons.Left && e.Clicks == 1)  // 按下的是鼠标左键
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, (IntPtr)HTCAPTION, IntPtr.Zero);    // 拖动窗体
            }
        }

        private void toolStrip1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                if (this.WindowState == FormWindowState.Normal)
                {
                    WindowState = FormWindowState.Maximized;
                    Size_ToolStripMenuItem.Text = "还原";
                }
                else if (WindowState == FormWindowState.Maximized)
                {
                    WindowState = FormWindowState.Normal;
                    Size_ToolStripMenuItem.Text = "最大化";
                }
            }
        }

        private void Size_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.FindForm().WindowState == FormWindowState.Normal)
            {
                this.FindForm().WindowState = FormWindowState.Maximized;
                Size_ToolStripMenuItem.Text = "还原";
            }
            else if (this.FindForm().WindowState == FormWindowState.Maximized)
            {
                this.FindForm().WindowState = FormWindowState.Normal;
                Size_ToolStripMenuItem.Text = "最大化";
            }
        }

        private void Close_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closewindows_button.PerformClick();
        }

        private void toolStrip1_Paint(object sender, PaintEventArgs e)
        {
            if ((sender as ToolStrip).RenderMode == ToolStripRenderMode.System)
            {
                Rectangle rect = new Rectangle(0, 0, this.toolStrip1.Width - 2, this.toolStrip1.Height - 2);
                e.Graphics.SetClip(rect);
            }
        }

        private void FrmOCXPlay_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        /// <summary>
        /// 播放高清视频
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //主码流
            try
            {
                if (streamstatus != 0)
                {
                    streamstatus = 0;
                    AxOxcNGClient.GetInstance().g_axNGSWebClient1.StartLiveById(m_playno, streamstatus,
                        0);
                    if (publicfunction.g_IsRecLog == "Yes")
                    {
                        RecordLog.GetInstance().WriteLog(Level.Info, string.Format("切换为主流播放"));
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("主码流错误信息:" + ex.Message);
            }
        }
        /// <summary>
        /// 播放标准视频
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //辅主码流
            try
            {
                if (streamstatus != 1)
                {
                    streamstatus = 1;
                    AxOxcNGClient.GetInstance().g_axNGSWebClient1.StartLiveById(m_playno, streamstatus,
                        0);
                    if (publicfunction.g_IsRecLog == "Yes")
                    {
                        RecordLog.GetInstance().WriteLog(Level.Info, string.Format("切换为辅流播放"));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("辅码流错误信息:" + ex.Message);
            }
        }

        /// <summary>
        /// 主流按钮显示
        /// </summary>
        public void showButton_HD()
        {
            this.toolStripButton1.Enabled = true;
            this.toolStripButton1.Visible = true;
        }
        /// <summary>
        /// 辅流按钮显示
        /// </summary>
        public void showButtonNormal()
        {
            this.toolStripButton2.Enabled = true;
            this.toolStripButton2.Visible = true;
        }

        /// <summary>
        /// 主流按钮隐藏
        /// </summary>
        public void hideButton_HD()
        {
            this.toolStripButton1.Enabled = false;
            this.toolStripButton1.Visible = false;
        }
        /// <summary>
        /// 辅流按钮隐藏
        /// </summary>
        public void hideButtonNormal()
        {
            this.toolStripButton2.Enabled = false;
            this.toolStripButton2.Visible = false;
        }

        /// <summary>
        /// 窗口变化时更换标题文字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmOCXPlay_VisibleChanged(object sender, EventArgs e)
        {
            toolStripLabel2.Text = titleText;
            this.Refresh();
        }
    }
}
