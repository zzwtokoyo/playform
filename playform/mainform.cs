using playform.function;
using System;
using System.Configuration;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace playform
{
    public partial class mainform : Form
    {
        /// <summary>
        /// 可以获取和设置数量众多的windows系统参数
        /// </summary>
        /// <param name="uAction"></param>
        /// <param name="uParam"></param>
        /// <param name="lpvParam"></param>
        /// <param name="fuWinIni"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        public static extern int SystemParametersInfo(int uAction, int uParam, IntPtr lpvParam, int fuWinIni);
        /// <summary>
        /// 登陆状态
        /// </summary>
        public static int loginstatus = 0;

        public mainform()
        {
            if (publicfunction.g_IsRecLog == "Yes")
            {
                //Console.WriteLine(string.Format("播放号:{0},不开启控制摄像头功能", playFrmInfo.playno));
                RecordLog.GetInstance().WriteLog(Level.Info, string.Format("---Chromuin服务程序启动---"));
            }
            //判断是否启用特效
            if (ConfigurationManager.AppSettings["isEffect"] != null)
            {
                if ("Yes" == (ConfigurationManager.AppSettings["isEffect"].ToString()))
                {
                    publicfunction.IsEffect = true;
                }
                else
                    publicfunction.IsEffect = false;
            }
            #region 只能运行一个客户端程序

            System.Threading.Mutex mutex = new System.Threading.Mutex(true, Assembly.GetExecutingAssembly().GetName().Name, out bool flag);
            if (!flag)
            {
                MessageBox.Show("ChromeForm控件服务程序已经运行", "请确定", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Environment.Exit(1);//退出程序
            }

            #endregion 只能运行一个客户端程序
            InitializeComponent();

            #region 保证运行其他进程同时置顶该进程窗体

            int dwTimeout = -1;
            SystemParametersInfo((int)WindowsCommand.SPI_GETFOREGROUNDLOCKTIMEOUT, 0, (IntPtr)dwTimeout, 0);
            if (dwTimeout >= 100)
            {
                SystemParametersInfo((int)WindowsCommand.SPI_SETFOREGROUNDLOCKTIMEOUT, 0, IntPtr.Zero, (int)WindowsCommand.SPIF_SENDCHANGE | (int)WindowsCommand.SPIF_UPDATEINIFILE);
            }

            #endregion 保证运行其他进程同时置顶该进程窗体
            RunHttpFunc();
            //初始化Chrome设置
            PublicFunc.InitChromeSetting();

            this.startTimerEvent();
        }

        #region Http功能


        public void RunHttpFunc()
        {
            try
            {
                if (publicfunction.g_httpPostRequest == null)
                {
                    publicfunction.g_httpPostRequest = new System.Net.HttpListener();
                    string port = publicfunction.g_port;
                    string url = "http://localhost:" + port + "/method/";
                    publicfunction.g_httpPostRequest.Prefixes.Add(url);
                    publicfunction.g_httpPostRequest.Start();
                    //运行http线程
                    StartHttpThread();                    
                }
                if (publicfunction.g_IsRecLog == "Yes")
                {
                    //Console.WriteLine(string.Format("播放号:{0},不开启控制摄像头功能", playFrmInfo.playno));
                    RecordLog.GetInstance().WriteLog(Level.Info, string.Format("启动-HttpListener"));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Http服务程序运行异常:" + ex.Message);
            }
        }

        #endregion Http功能

        #region 启动Http线程

        public void StartHttpThread()
        {
            publicfunction.g_ThrednHttpPostRequest = new Thread(new ThreadStart(simhttp.httpPostRequestHandle))
            {
                IsBackground = true
            };
            publicfunction.g_ThrednHttpPostRequest.Start();
        }
        #endregion 启动Http线程

        /// <summary>
        /// 启动全局定时器
        /// </summary>
        private void startTimerEvent()
        {
            publicfunction.g_timersTimer.Elapsed += new System.Timers.ElapsedEventHandler(G_timersTimer_Elapsed);
            publicfunction.g_timersTimer.SynchronizingObject = this;
            publicfunction.startTimer(20);
        }
       
        private void Close_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确认退出服务程序？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (publicfunction.g_IsRecLog == "Yes")
                {
                    RecordLog.GetInstance().WriteLog(Level.Info, string.Format("---退出Chromuin服务程序启动---"));
                }
                this.Close();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void mainfrm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();   //隐藏窗体
                notifyIcon1.Visible = true; //使托盘图标可见
            }
        }

        private void mainfrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            publicfunction.g_httpPostRequest.Close();
            notifyIcon1.Dispose();
            this.Dispose();
        }

        /// <summary>
        /// 定时任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void G_timersTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (publicfunction.g_HttpGetStatus == true)
            {
                if (publicfunction.g_IsRecLog == "Yes")
                {
                    RecordLog.GetInstance().WriteLog(Level.Info, string.Format("当前势行接口信息命令:{0}", publicfunction.g_CallMode));
                }
                if (publicfunction.g_CallMode == (int)OCXPlayAttrubute.capturepic)
                {
                    //创建Chrome网页框架
                    PublicFunc publicFunc = new PublicFunc();
                    publicFunc.CaptureChromeFrm(publicfunction.g_HttpGetParams);
                }
                else if(publicfunction.g_CallMode == (int)OCXPlayAttrubute.startlnkapp)
                {
                    //打开指定的lnk快捷方式
                    PublicFunc publicFunc = new PublicFunc();
                    publicFunc.StartLnkPath(publicfunction.g_HttpGetParams);
                }
                publicfunction.g_CallMode = -1;
                publicfunction.g_HttpGetStatus = false;
                publicfunction.g_HttpGetParams = string.Empty;
            }
        }
    }
}