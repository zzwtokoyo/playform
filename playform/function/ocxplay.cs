using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace playform
{
    public class ocxplay
    {
        private static PublicFunc m_pfn = new PublicFunc();
        /// <summary>
        /// 上次视频播放窗体实例
        /// </summary>
        private static FrmOCXPlay m_lastOcxPlayForm = null;
        private delegate void playocx(int a);
        /// <summary>
        /// 单视频播放
        /// </summary>
        /// <param name="jsonText"></param>
        public static void MakeCall(string jsonText)
        {
            if (!string.IsNullOrEmpty(jsonText))
                playvideo(m_pfn.CommandParseJsonToCallInfo(jsonText));
        }

        /// <summary>
        /// 分屏视频播放
        /// </summary>
        /// <param name="jsonText"></param>
        public static void MakeCallEx(string jsonText)
        {
            if (!string.IsNullOrEmpty(jsonText))
                playvideoex(m_pfn.CommandParseJsonToCallExInfo(jsonText));
        }
        /// <summary>
        /// 关闭指定窗口
        /// </summary>
        /// <param name="jsonText"></param>
        public static void CloseWindows(string jsonText)
        {
            if (!string.IsNullOrEmpty(jsonText))
                closewindwos(m_pfn.CommandCloseWindows(jsonText));
        }

        /// <summary>
        /// 视屏播放功能
        /// </summary>
        /// <param name="playno"></param>
        /// <param name="locationx"></param>
        /// <param name="locationy"></param>
        /// <param name="sizex"></param>
        /// <param name="sizey"></param>
        private static void playvideo(PlayFrmInfo playInfo)
        {
            publicfunction.g_IsContrlPlay = false;
            FrmOCXPlay m_frm = null;
            try
            {
                if (m_lastOcxPlayForm == null)
                {
                    m_frm = new FrmOCXPlay(playInfo.LocationX, playInfo.LocationY, playInfo.SizeX, playInfo.SizeY)
                    {
                        TopMost = true,
                        Text = playInfo.title
                    };
                }
                else
                {
                    m_frm = m_lastOcxPlayForm;
                }
                m_frm.titleText = playInfo.title;
                m_frm.Show();
                m_lastOcxPlayForm = m_frm;
                //判断是否可控
                if (playInfo.ptz == "ptz")
                {
                    //冗余
                }
                //播放
                if (playInfo.playno.Contains(","))
                {
                    if (playInfo.playno.Split(',')[0] != "" && playInfo.playno.Split(',')[1] != "")
                    {
                        m_frm.showButton_HD();
                        m_frm.showButtonNormal();
                    }
                }
                m_frm.PlayCall(playInfo.playno,playInfo.streammode);
            }
            catch (Exception ex)
            {
                m_frm.Close();
                throw new Exception("ocx视频控件播放失败:" + ex.Message);
            }
        }

        public static FrmOCXPlay m_frmEx = null;
        //private static FrmOCXPlay m_lastOcxPlayFormEX = null;
        /// <summary>
        /// 分屏视频展示
        /// </summary>
        /// <param name="playInfo"></param>
        private static void playvideoex(PlayFrmExInfo playExInfo)
        {
            publicfunction.g_IsContrlPlay = false;
            try
            {
                if (m_lastOcxPlayForm == null)
                {
                    m_frmEx = new FrmOCXPlay(playExInfo.LocationX, playExInfo.LocationY, playExInfo.SizeX, playExInfo.SizeY)
                    {
                        TopMost = true,
                        Text = playExInfo.title
                    };
                    m_frmEx.hideButton_HD();
                    m_frmEx.hideButtonNormal();
                }
                else
                {
                    m_frmEx = m_lastOcxPlayForm;
                }
                m_frmEx.titleText = playExInfo.title;
                m_frmEx.Show();
                m_lastOcxPlayForm = m_frmEx;
                //判断是否可控
                if (playExInfo.ptz == "ptz")
                {
                    //冗余
                }
                //播放
                //if (playExInfo.playno.Contains(","))
                //{
                //    if (playExInfo.playno.Split(',')[0] != "" && playExInfo.playno.Split(',')[1] != "")
                //    {
                //        m_frmEx.hideButton_HD();
                //        m_frmEx.hideButtonNormal();
                //    }
                //}
                m_frmEx.PlayCallEx(playExInfo.playno,playExInfo.splitcount,playExInfo.indexwindows, playExInfo.streammode);
            }
            catch (Exception ex)
            {
                m_frmEx.Close();
                throw new Exception("ocx视频控件ex播放失败:" + ex.Message);
            }
        }

        /// <summary>
        /// 关闭指定窗口
        /// </summary>
        /// <param name="indexwindows"></param>
        private static void closewindwos(CloseWindows indexwindows)
        {
            if(m_frmEx == null)
            { return; }
            m_frmEx.CloseWindows(indexwindows.index);
        }
    }
}
