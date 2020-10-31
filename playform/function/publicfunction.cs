using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace playform
{
    public class publicfunction
    {        
        /// <summary>
        /// http
        /// </summary>
        public static HttpListener g_httpPostRequest;
        /// <summary>
        /// Http线程
        /// </summary>
        public static Thread g_ThrednHttpPostRequest;
        /// <summary>
        /// http数据接收状态
        /// </summary>
        public static bool g_HttpGetStatus = false;
        /// <summary>
        /// http数据接收
        /// </summary>
        public static string g_HttpGetParams = string.Empty;
        /// <summary>
        /// 播放模式
        /// </summary>
        public static int g_CallMode = -1;
        /// <summary>
        /// 是否开启日志功能
        /// </summary>
        public static string g_IsRecLog = ConfigurationManager.AppSettings["IsLog"].ToString();
        /// <summary>
        /// 接口服务端口
        /// </summary>
        public static string g_port = ConfigurationManager.AppSettings["port"].ToString();
        /// <summary>
        /// 接口服务端口
        /// </summary>
        public static string g_clientport = ConfigurationManager.AppSettings["cilentport"].ToString();
        /// <summary>
        /// 接口服务端口
        /// </summary>
        public static string g_clienthost = ConfigurationManager.AppSettings["clienthost"].ToString();
        /// <summary>
        /// 接口服务端口
        /// </summary>
        public static string g_clientuser = ConfigurationManager.AppSettings["clientuser"].ToString();
        /// <summary>
        /// 接口服务端口
        /// </summary>
        public static string g_clientpwd = ConfigurationManager.AppSettings["clientpwd"].ToString();
        /// <summary>
        /// 接口服务端口
        /// </summary>
        public static string g_clientmode = ConfigurationManager.AppSettings["clientislan"].ToString();
        /// <summary>
        /// 弹出应用窗体的应用程序名称
        /// </summary>
        //public static string g_appName = ConfigurationManager.AppSettings["AppName"].ToString();
        /// <summary>
        /// 视频是否PTZ
        /// </summary>
        public static bool g_IsContrlPlay = false;
        /// <summary>
        /// 全局定时器
        /// </summary>
        public static System.Timers.Timer g_timersTimer = new System.Timers.Timer();
        /// <summary>
        /// 上次分屏数量
        /// </summary>
        public static int g_lastSplitCount = -1;
        /// <summary>
        /// chrome 窗口列表名称
        /// </summary>
        public static List<Form> g_ChromeFrmList = new List<Form>();
        /// <summary>
        /// 是否开启特效
        /// </summary>
        public static bool IsEffect = false;

        /// <summary>
        /// 启动定时器
        /// </summary>
        public static void startTimer(int millsecondes = 100)
        {
            publicfunction.g_timersTimer.Enabled = true;
            publicfunction.g_timersTimer.Interval = millsecondes;
            publicfunction.g_timersTimer.Start();
            if (publicfunction.g_IsRecLog == "Yes")
            {
                RecordLog.GetInstance().WriteLog(Level.Info, string.Format("定时任务启动"));
            }
        }
        /// <summary>
        /// 停止定时器
        /// </summary>
        public static void stopTimer()
        {
            if(publicfunction.g_timersTimer.Enabled == true)
            {
                publicfunction.g_timersTimer.Stop();
                publicfunction.g_timersTimer.Enabled = false;
                if (publicfunction.g_IsRecLog == "Yes")
                {
                    RecordLog.GetInstance().WriteLog(Level.Info, string.Format("定时任务停止"));
                }
            }
        }
        /// <summary>
        /// 重启定时器
        /// </summary>
        public static void rebootTimer()
        {
            if (publicfunction.g_timersTimer.Enabled == false)
            {
                publicfunction.g_timersTimer.Enabled = true;
                publicfunction.g_timersTimer.Start();
                if (publicfunction.g_IsRecLog == "Yes")
                {
                    RecordLog.GetInstance().WriteLog(Level.Info, string.Format("定时任务重启"));
                }
            }
        }

    }

    public enum OCXPlayAttrubute : int
    {
        /// <summary>
        /// 单视频播放
        /// </summary>
        singlePlay = 0,

        /// <summary>
        /// 创建网页窗口
        /// </summary>
        creatWebfrm,

        /// <summary>
        /// 拨打电话
        /// </summary>
        phonePlay,

        /// <summary>
        /// 截图窗口
        /// </summary>
        capturepic,

        /// <summary>
        /// 显示AR鹰眼云图
        /// </summary>
        showeagleeye,

        /// <summary>
        /// 最小化AR鹰眼云图
        /// 老葛的项目中最小化
        /// </summary>
        showeagleeyemin,
        /// <summary>
        /// 寻找进程
        /// </summary>
        judeprocess,

        /// <summary>
        /// 关闭窗体指令
        /// </summary>
        closechromewfm,

        /// <summary>
        /// 创建会议系统页面
        /// </summary>
        createMetting,

        /// <summary>
        /// 关闭指定播放窗口
        /// </summary>
        closeplaywfm,

        /// <summary>
        /// 可使用多视频播放模式
        /// </summary>
        selectMutilPlay,

        /// <summary>
        /// 关闭全部视频窗口
        /// </summary>
        closeSelectMutilPlay,
        /// <summary>
        /// 打开指定的快捷方式程序
        /// </summary>
        startlnkapp
    }

    /// <summary>
    /// windows窗体消息命令
    /// </summary>
    public enum WindowsCommand : int
    {
        /// <summary>
        /// 窗体关闭消息值
        /// </summary>
        WM_CLOSE = 0x0010,

        /// <summary>
        /// 自定义消息
        /// </summary>
        CUSTOM_MESSAGE = 0x400 + 2,

        WM_SYSCOMMAND = 0x112,

        WM_SYSCOMMAND2 = 0x0112,

        SC_MINIMIZE = 0xF020,

        SC_MAXIMIZE = 0xF030,

        SC_MAXIMIZE2 = 0xF030,

        SW_HIDE = 0,

        SW_SHOWNORMAL = 1,

        SW_NORMAL = 1,

        SW_SHOWMINIMIZED = 2,

        SW_SHOWMAXIMIZED = 3,

        SW_MAXIMIZE = 3,

        SW_SHOWNOACTIVATE = 4,

        SW_SHOW = 5,

        SW_MINIMIZE = 6,

        SW_SHOWMINNOACTIVE = 7,

        SW_SHOWNA = 8,

        SW_RESTORE = 9,

        SW_SHOWDEFAULT = 10,

        SW_FORCEMINIMIZE = 11,

        SW_MAX = 11,

        SPI_GETFOREGROUNDLOCKTIMEOUT = 0x2000,

        SPI_SETFOREGROUNDLOCKTIMEOUT = 0x2001,

        SPIF_UPDATEINIFILE = 0x0001,

        SPIF_SENDCHANGE = 0x0002,

        SWP_NOSIZE = 0x1,

        SWP_NOMOVE = 0x2,

        SWP_SHOWWINDOW = 0x40,

        SWP_NOACTIVATE = 0x0010,

        HWND_TOP = 0,

        HWND_BOTTOM = 1,

        HWND_TOPMOST = -1,

        HWND_NOTOPMOST = -2
    }

    /// <summary>
    /// 视频播放信息类
    /// </summary>
    public class PlayFrmInfo
    {
        public string playno = string.Empty;
        public int LocationX = 0;
        public int LocationY = 0;
        public int SizeX = 0;
        public int SizeY = 0;
        public string title = string.Empty;
        public string ptz = string.Empty;
        public int streammode = 0;
    }

    /// <summary>
    /// 视频扩展类
    /// </summary>
    public class PlayFrmExInfo
    {
        public string playno = string.Empty;
        public int LocationX = 0;
        public int LocationY = 0;
        public int SizeX = 0;
        public int SizeY = 0;
        public string title = string.Empty;
        public string ptz = string.Empty;
        public int splitcount = 1;    //分屏数量
        public int indexwindows = 0; //从index为0开始
        public int streammode = 0;
    }

    /// <summary>
    /// 网页窗口信息
    /// </summary>
    public class WebFrmInfo
    {
        public string url = string.Empty;
        public int LocationX = 0;
        public int LocationY = 0;
        public int SizeX = 0;
        public int SizeY = 0;
        public string title = string.Empty;
        public string extarData = string.Empty;
    }

    /// <summary>
    /// 网页窗口信息
    /// </summary>
    public class DefaultFrmInfo
    {
        public string path = string.Empty;
    }

    public class CloseWindows
    {
        public int index = 0;        
    }
}
