using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CefSharp.WinForms;
using CefSharp;
using System.Configuration;

namespace playform
{
    public partial class simbrowser : Form
    {
        /// <summary>
        /// 支持js控件内部调用
        /// </summary>
        JsEvent JsEvent = new JsEvent();

        /// <summary>
        /// chrome插件
        /// </summary>
        private static ChromiumWebBrowser browser;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="LocationX"></param>
        /// <param name="LocationY"></param>
        /// <param name="xsize"></param>
        /// <param name="ysize"></param>
        public simbrowser(int LocationX, int LocationY, int xsize, int ysize)
        {
            InitializeComponent();
            Rectangle rectangle = this.ClientRectangle;
            //int SubWidth = rectangle.Size.Width - panel1.Size.Width;
            int SubHeight = rectangle.Size.Height - panel1.Size.Height;

            Size = new Size(xsize, ysize + SubHeight);
            Location = new Point(LocationX, LocationY);
            StartPosition = FormStartPosition.Manual;
            this.TopMost = true;
            toolStrip1.BackColor = Color.FromArgb(1, 4, 22);
        }

        /// <summary>
        /// 打开url
        /// </summary>
        /// <param name="url"></param>
        public void loadchromeurl(string url)
        {
            try
            {
                toolStripLabel1.Text = this.Text;
                browser = new ChromiumWebBrowser(url);
                browser.LifeSpanHandler = new OpenPageSelf();
                browser.Parent = panel1;
                panel1.Controls.Add(browser);
                browser.Dock = DockStyle.Fill;
                browser.KeyboardHandler = new CEFKeyBoardHander();
                browser.RegisterJsObject("jsObjectX", this.JsEvent, new BindingOptions() { CamelCaseJavascriptNames = false });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chrome框架加载异常: " + ex.Message, "错误！", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void playform_FormClosing(object sender, FormClosingEventArgs e)
        {
            browser = null;
            /// <summary>
            /// 是否开启特效
            /// </summary>
            if (publicfunction.IsEffect == true)
            {
                Win32.AnimateWindow(this.Handle, 200, Win32.AW_SLIDE | Win32.AW_HIDE | Win32.AW_BLEND);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStrip1_Paint(object sender, PaintEventArgs e)
        {
            if ((sender as ToolStrip).RenderMode == ToolStripRenderMode.System)
            {
                Rectangle rect = new Rectangle(0, 0, this.toolStrip1.Width - 2, this.toolStrip1.Height - 2);
                e.Graphics.SetClip(rect);
            }
        }

        #region 处理窗口得拖动效果
        private const int WM_NCLBUTTONDOWN = 0x00A1;
        private const int HTCAPTION = 2;
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern bool ReleaseCapture();
        private new void MouseMove(object sender, MouseEventArgs e)
        {
            this.TopMost = true;
            if (e.Button == MouseButtons.Left)  // 按下的是鼠标左键
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, (IntPtr)HTCAPTION, IntPtr.Zero);    // 拖动窗体
            }
        }
        #endregion

        private void simbrowser_Load(object sender, EventArgs e)
        {
            /// <summary>
            /// 是否开启特效
            /// </summary>
            if (publicfunction.IsEffect == true)
            {
                Win32.AnimateWindow(this.Handle, 200, Win32.AW_BLEND);
            }
        }
    }
    /// <summary>
    /// Chrome在自己窗口打开链接
    /// </summary>
    internal class OpenPageSelf : ILifeSpanHandler
    {
        public bool DoClose(IWebBrowser browserControl, IBrowser browser)
        {
            return false;
        }

        public void OnAfterCreated(IWebBrowser browserControl, IBrowser browser)
        {
        }

        public void OnBeforeClose(IWebBrowser browserControl, IBrowser browser)
        {
        }

        public bool OnBeforePopup(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl,
                                    string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures,
                                    IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            newBrowser = null;
            var chromiumWebBrowser = (ChromiumWebBrowser)browserControl;
            chromiumWebBrowser.Load(targetUrl);
            return true;
        }
    }

    /// <summary>
    /// 开启调试模式
    /// </summary>
    internal class CEFKeyBoardHander : IKeyboardHandler
    {
        public bool OnKeyEvent(IWebBrowser browserControl, IBrowser browser, KeyType type, int windowsKeyCode, int nativeKeyCode, CefEventFlags modifiers, bool isSystemKey)
        {
            if (type == KeyType.KeyUp && Enum.IsDefined(typeof(Keys), windowsKeyCode))
            {
                var key = (Keys)windowsKeyCode;
                switch (key)
                {
                    case Keys.F12:
                        browser.ShowDevTools();
                        break;
                    case Keys.F5:
                        if (modifiers == CefEventFlags.ControlDown)
                        {
                            browser.Reload(true); //强制忽略缓存
                        }
                        else
                        {
                            browser.Reload();
                        }
                        break;
                }
            }
            return false;
        }

        public bool OnPreKeyEvent(IWebBrowser browserControl, IBrowser browser, KeyType type, int windowsKeyCode, int nativeKeyCode, CefEventFlags modifiers, bool isSystemKey, ref bool isKeyboardShortcut)
        {
            return false;
        }
    }

}
