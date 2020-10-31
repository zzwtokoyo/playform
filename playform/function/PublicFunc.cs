using CefSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using playform.function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace playform
{
    public class PublicFunc
    {
        /// <summary>
        /// 传递的json数据解析到播放信息类成员
        /// </summary>
        /// <param name="Command"></param>
        /// <returns></returns>
        public PlayFrmInfo CommandParseJsonToCallInfo(string Command)
        {
            JObject jo = (JObject)JsonConvert.DeserializeObject(Command);
            PlayFrmInfo playFrmInfo = new PlayFrmInfo
            {
                playno = jo["playno"].ToString(),
                LocationX = Int32.Parse(jo["LocationX"].ToString()),
                LocationY = Int32.Parse(jo["LocationY"].ToString()),
                SizeX = Int32.Parse(jo["SizeX"].ToString()),
                SizeY = Int32.Parse(jo["SizeY"].ToString()),
                title = jo["title"]==null?string.Empty: jo["title"].ToString(),
                streammode = jo["streammode"] == null? Int32.Parse("0") : Int32.Parse(jo["streammode"].ToString())
            };
            if (jo.Property("ptz") == null)
            {
                playFrmInfo.ptz = string.Empty;
                if (publicfunction.g_IsRecLog == "Yes")
                {
                    //Console.WriteLine(string.Format("播放号:{0},不开启控制摄像头功能", playFrmInfo.playno));
                    //RecordLog.GetInstance().WriteLog(Level.Info, string.Format("播放号:{0},不开启控制摄像头功能", playFrmInfo.playno));
                }
            }
            else
            {
                playFrmInfo.ptz = jo["ptz"].ToString();
            }
            return playFrmInfo;
        }

        /// <summary>
        /// 解析网页http字段信息
        /// </summary>
        /// <param name="Command"></param>
        /// <returns></returns>
        public WebFrmInfo ParseWebParam(string Command)
        {
            string strstart = "\"url\":\"";
            int strlength = strstart.Length;
            string UrlString = Command.Substring(Command.IndexOf(strstart) + strlength, Command.IndexOf("\",\"LocationX\":") - Command.IndexOf(strstart) - strlength);

            strstart = "\"LocationX\":";
            strlength = strstart.Length;
            string LocationX_String = Command.Substring(Command.IndexOf(strstart) + strlength, Command.IndexOf(",\"LocationY\":") - Command.IndexOf(strstart) - strlength);

            strstart = "\"LocationY\":";
            strlength = strstart.Length;
            string LocationY_String = Command.Substring(Command.IndexOf(strstart) + strlength, Command.IndexOf(",\"SizeX\":") - Command.IndexOf(strstart) - strlength);

            strstart = "\"SizeX\":";
            strlength = strstart.Length;
            string SizeX_String = Command.Substring(Command.IndexOf(strstart) + strlength, Command.IndexOf(",\"SizeY\":") - Command.IndexOf(strstart) - strlength);

            strstart = "\"SizeY\":";
            strlength = strstart.Length;
            string SizeY_String = Command.Substring(Command.IndexOf(strstart) + strlength, Command.IndexOf(",\"title\":") - Command.IndexOf(strstart) - strlength);

            strstart = "\"title\":\"";
            strlength = strstart.Length;
            string title_String = Command.Substring(Command.IndexOf(strstart) + strlength).Replace("\"}", "");

            WebFrmInfo webfrm = new WebFrmInfo
            {
                url = UrlString,
                LocationX = Int32.Parse(LocationX_String),
                LocationY = Int32.Parse(LocationY_String),
                SizeX = Int32.Parse(SizeX_String),
                SizeY = Int32.Parse(SizeY_String),
                title = title_String,
                extarData = string.Empty
            };
            return webfrm;
        }

        /// <summary>
        /// 打开截图网页
        /// </summary>
        /// <param name="url"></param>
        /// <param name="sizeX"></param>
        /// <param name="sizeY"></param>
        /// <param name="LocalX"></param>
        /// <param name="LocalY"></param>
        private void newCaptureChromeFrm(string url, int LocalX, int LocalY, int sizeX, int sizeY, string titleName)
        {
            try
            {
                if (!string.IsNullOrEmpty(url))
                {
                    simbrowser new_webFrame = new simbrowser(LocalX, LocalY, sizeX, sizeY)
                    {
                        Text = titleName
                    };
                    new_webFrame.loadchromeurl(url);
                    new_webFrame.Show();
                    publicfunction.g_ChromeFrmList.Add(new_webFrame);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("窗口打开失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 解析要打开的Chrome数据(不含扩展数据)
        /// </summary>
        /// <param name="jsonText"></param>
        public void CaptureChromeFrm(string jsonText)
        {
            publicfunction.stopTimer();
            WebFrmInfo playFrmInfo = ParseWebParam(jsonText);

            if (publicfunction.g_ChromeFrmList.Count > 0)
            {
                foreach (var webfrm in publicfunction.g_ChromeFrmList)
                {
                    if (webfrm.Text == playFrmInfo.title)
                    {
                        webfrm.Close();
                    }
                }
            }
            newCaptureChromeFrm(playFrmInfo.url, playFrmInfo.LocationX, playFrmInfo.LocationY, playFrmInfo.SizeX, playFrmInfo.SizeY, playFrmInfo.title);
        }

        private void openlnk(string path)
        {
            System.Diagnostics.Process.Start(@path);
            if (publicfunction.g_IsRecLog == "Yes")
            {
                RecordLog.GetInstance().WriteLog(Level.Info, string.Format("路径lnk:{0}", path));
            }
        }
        /// <summary>
        /// 打开lnk
        /// </summary>
        /// <param name="paths"></param>
        public void StartLnkPath(string paths)
        {
            try
            {
                publicfunction.stopTimer();
                string[] pathArray = { string.Empty };
                //多个路径
                if (paths.Contains(","))
                {
                    pathArray = paths.Split(',');
                }
                else
                {
                    pathArray[0] = paths;
                }
                //打开
                foreach(string path in pathArray)
                {
                    this.openlnk(path);
                }
            }
            catch(Exception ex)
            {
                if (publicfunction.g_IsRecLog == "Yes")
                {
                    RecordLog.GetInstance().WriteLog(Level.Info, string.Format("运行当前路径lnk异常:{0}",ex.Message));
                }
            }

        }

        /// <summary>
        /// chrome初始化参数
        /// </summary>
        public static void InitChromeSetting()
        {
            var Settings = new CefSettings();
            //配置浏览器属性
            Settings.CachePath = "cache";
            Settings.UserAgent = "";
            Settings.Locale = "zh-CN";
            Settings.AcceptLanguageList = "zh-CN";
            Settings.CefCommandLineArgs.Add("enable-media-stream", "1");
            Settings.CefCommandLineArgs.Add("disable-gpu", "1");
            Settings.CefCommandLineArgs.Add("no-proxy-server", "1");
            Settings.CefCommandLineArgs.Add("disable-direct-write", "1");
            Settings.CefCommandLineArgs.Add("--disable-web-security", "1");//关闭同源策略,允许跨域
            CefSharpSettings.LegacyJavascriptBindingEnabled = true;
            Cef.Initialize(Settings);
        }
    }
}
