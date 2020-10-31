using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace playform
{
    /// <summary>
    /// 鹰眼控制类
    /// </summary>
    public class AREagleEye
    {
        [DllImport("user32.dll", EntryPoint = "PostMessage")]
        public static extern int PostMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        [DllImport("User32.dll ", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);//关键方法

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int SendMessage(IntPtr HWnd, uint Msg, int WParam, int LParam);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// 激活窗体
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="fAltTab"></param>
        [DllImport("user32.dll")]
        public static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);

        /// <summary>
        /// 激活当前窗体至前端
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);

        [DllImport("kernel32")]
        public static extern IntPtr GetCurrentThreadId();

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);

        /// <summary>
        /// 切换键盘输入焦点
        /// </summary>
        /// <param name="idAttach"></param>
        /// <param name="idAttachTo"></param>
        /// <param name="fAttach"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern IntPtr AttachThreadInput(IntPtr idAttach, IntPtr idAttachTo, int fAttach);

        [DllImport("user32.dll")]
        private static extern IntPtr GetFocus();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool ShowWindow(IntPtr hWnd, int State);

        /// <summary>
        /// 该函数改变一个子窗口，弹出式窗口或顶层窗口的尺寸，位置和Z序。
        /// 子窗口，弹出式窗口，及顶层窗口根据它们在屏幕上出现的顺序排序、顶层窗口设置的级别最高，并且被设置为Z序的第一个窗口。
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="hWndlnsertAfter"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="cx"></param>
        /// <param name="cy"></param>
        /// <param name="Flags"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndlnsertAfter, int X, int Y, int cx, int cy, uint Flags);

        /// <summary>
        /// 最小化其他应用程序
        /// </summary>
        /// <param name="processName"></param>
        //public static void MiniSizeAppication(string processName)
        //{
        //    Process[] processs = Process.GetProcessesByName(processName);
        //    if (processs != null)
        //    {
        //        foreach (Process p in processs)
        //        {
        //            IntPtr handle = FindWindow(null, p.MainWindowTitle);
        //            PostMessage(handle, (int)WindowsCommand.WM_SYSCOMMAND, (int)WindowsCommand.SC_MINIMIZE, 0);
        //        }
        //    }
        //}
        public static void MiniSizeAppication(string processName)
        {
            publicfunction.stopTimer();
            Process[] processes = Process.GetProcessesByName(processName);
            if (processes.Length > 0)
            {
                IntPtr myIntPtr = processes[0].MainWindowHandle;
                //获取当前活动窗口的线程句柄
                IntPtr threadId1 = (IntPtr)GetCurrentThreadId();
                //获得指定句柄的线程句柄
                IntPtr threadId2 = (IntPtr)GetWindowThreadProcessId(myIntPtr, IntPtr.Zero);
                //将两个线程的输入队列联系起来，只有这样，GetFocus函数才能获得其它线程中的焦点窗口
                AttachThreadInput(threadId2, threadId1, 1);
                //最小显示窗体
                ShowWindow(myIntPtr, (int)WindowsCommand.SW_NORMAL);
                ShowWindow(myIntPtr, (int)WindowsCommand.SW_SHOWMINIMIZED);
                //SetWindowPos(myIntPtr, (IntPtr)WindowsCommand.HWND_TOPMOST, 0, 0, 0, 0, (int)WindowsCommand.SWP_NOSIZE | (int)WindowsCommand.SWP_NOMOVE);
                SetWindowPos(myIntPtr, (IntPtr)WindowsCommand.HWND_NOTOPMOST, 0, 0, 0, 0, (int)WindowsCommand.SWP_NOSIZE | (int)WindowsCommand.SWP_NOMOVE);
                SetForegroundWindow(myIntPtr);
                AttachThreadInput(threadId2, threadId1, 0);
            }
        }

        
        public static bool JudePorcess(string processName)
        {
            publicfunction.stopTimer();
            //Process[] processList = Process.GetProcessesByName(processName);
            int total = 19999;
            Process[] processList = Process.GetProcesses();
            foreach (Process process in processList)
            {
                if(process.ProcessName == processName)
                {
                    total = 0;
                }
            }
            if(total != 0)
            {
                //MessageBox.Show("找不到进程:" + processName);
                return false;
            }

            return true;
            //if(processList.Length == 0)
            //{
            //    MessageBox.Show("找不到进程:" + processName);
            //}
            //processList.Initialize();
            //foreach (Process process in processList)
            //{
            //    if (process.ProcessName == processName)
            //    {
            //        continue;
            //    }
            //    else
            //    {
            //        MessageBox.Show("找不到进程:" + processName);
            //        return;
            //    }
            //}

        }

        /// <summary>
        /// 最大化其他应用程序
        /// </summary>
        /// <param name="processName"></param>
        public static void MaxSizeAppication(string processName)
        {
            publicfunction.stopTimer();
            Process[] processes = Process.GetProcessesByName(processName);
            if (processes.Length > 0)
            {
                IntPtr myIntPtr = processes[0].MainWindowHandle;
                //获取当前活动窗口的线程句柄
                IntPtr threadId1 = (IntPtr)GetCurrentThreadId();
                //获得指定句柄的线程句柄
                IntPtr threadId2 = (IntPtr)GetWindowThreadProcessId(myIntPtr, IntPtr.Zero);
                //将两个线程的输入队列联系起来，只有这样，GetFocus函数才能获得其它线程中的焦点窗口
                AttachThreadInput(threadId2, threadId1, 1);
                //最大化显示窗体
                ShowWindow(myIntPtr, (int)WindowsCommand.SW_SHOWMINIMIZED);
                //老葛的项目中取消最大化
                ShowWindow(myIntPtr, (int)WindowsCommand.SW_SHOWNORMAL);
                SetWindowPos(myIntPtr, (IntPtr)WindowsCommand.HWND_TOPMOST, 0, 0, 0, 0, (int)WindowsCommand.SWP_NOSIZE | (int)WindowsCommand.SWP_NOMOVE);
                //SetWindowPos(myIntPtr, (IntPtr)WindowsCommand.HWND_NOTOPMOST, 0, 0, 0, 0, (int)WindowsCommand.SWP_NOSIZE | (int)WindowsCommand.SWP_NOMOVE);
                SetForegroundWindow(myIntPtr);
                AttachThreadInput(threadId2, threadId1, 0);
            }
        }

        /// <summary>
        /// 判断指定进程是否存在
        /// </summary>
        /// <param name="processname"></param>
        //public static void JudeProcess(string processname)
        //{
        //    System.Diagnostics.Process[] processList = System.Diagnostics.Process.GetProcesses();
        //    foreach (System.Diagnostics.Process process in processList)
        //    {
        //        if (process.ProcessName == processname)
        //        {
        //            MessageBox.Show(string.Format("查找到当前进程:{0}存在", processname));
        //            break;
        //        }
        //    }
        //}

        /// <summary>
        /// 最大化其他应用程序
        /// </summary>
        /// <param name="processName"></param>
        public static void FrontWfm(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);
            if (processes.Length > 0)
            {
                IntPtr myIntPtr = processes[0].MainWindowHandle;
                //获取当前活动窗口的线程句柄
                IntPtr threadId1 = (IntPtr)GetCurrentThreadId();
                //获得指定句柄的线程句柄
                IntPtr threadId2 = (IntPtr)GetWindowThreadProcessId(myIntPtr, IntPtr.Zero);
                //将两个线程的输入队列联系起来，只有这样，GetFocus函数才能获得其它线程中的焦点窗口
                AttachThreadInput(threadId2, threadId1, 1);
                //最大化显示窗体
                SetWindowPos(myIntPtr, (IntPtr)WindowsCommand.HWND_TOPMOST, 0, 0, 0, 0, (int)WindowsCommand.SWP_NOSIZE | (int)WindowsCommand.SWP_NOMOVE);
                SetWindowPos(myIntPtr, (IntPtr)WindowsCommand.HWND_NOTOPMOST, 0, 0, 0, 0, (int)WindowsCommand.SWP_NOSIZE | (int)WindowsCommand.SWP_NOMOVE);
                SetForegroundWindow(myIntPtr);
                AttachThreadInput(threadId2, threadId1, 0);
            }
        }
    }
}