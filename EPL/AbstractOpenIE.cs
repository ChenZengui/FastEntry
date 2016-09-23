using mshtml;
using SHDocVw;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace EPL
{
    /// <summary>
    /// 抽象类定义了对IE浏览器基本的操作
    /// </summary>
    public class AbstractOpenIE : IExplorerOpen
    {
        #region 引入接口
        /// 该函数设置由不同线程产生的窗口的显示状态  
        /// </summary>  
        /// <param name="hWnd">窗口句柄</param>  
        /// <param name="cmdShow">指定窗口如何显示。查看允许值列表，请查阅ShowWlndow函数的说明部分</param>  
        /// <returns>如果函数原来可见，返回值为非零；如果函数原来被隐藏，返回值为零</returns>  
        [DllImport("User32.dll")]  
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow); 
 
        /// <summary>  
        ///  该函数将创建指定窗口的线程设置到前台，并且激活该窗口。键盘输入转向该窗口，并为用户改各种可视的记号。  
        ///  系统给创建前台窗口的线程分配的权限稍高于其他线程。   
        /// </summary>  
        /// <param name="hWnd">将被激活并被调入前台的窗口句柄</param>  
        /// <returns>如果窗口设入了前台，返回值为非零；如果窗口未被设入前台，返回值为零</returns>  
        [DllImport("User32.dll")]  
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        #endregion

        #region OpenLink 打开一个链接，包括判断url是否已经打开
        /// <summary>
        /// 打开一个链接，包括判断url是否已经打开
        /// </summary>
        /// <param name="url"></param>
        /// <param name="delay"></param>
        /// <exception cref="System.Exception">当url为空时抛出</exception>
        public void OpenLink(string url, int delay = 3000)
        {
            if (IsOpened(url))
            {
                ShowIEExplore();
                return;
            }
            try
            {
                ShellWindows shellWindows = new SHDocVw.ShellWindowsClass();
                int count = 0;
                foreach (InternetExplorer i in shellWindows)
                {
                    if (i.Name == "Internet Explorer")
                    {
                        count++;
                    }
                }
                if (count == 0)
                {
                    Process.Start("iexplore.exe", url);
                }                    
                else
                {
                    object objFlags = 2048;
                    object objTargetFrameName = "";
                    object objPostData = "";
                    object objHeaders = "";
                    InternetExplorer webBrowser1 = (InternetExplorer)shellWindows.Item(0);                    
                    webBrowser1.RegisterAsBrowser = true;//注册为浏览器窗口
                    webBrowser1.Navigate2(url, ref objFlags, ref objTargetFrameName, ref objPostData, ref objHeaders);
                }
                Thread.Sleep(delay);
            }
            catch
            {
                return;
            }
        }
        #endregion

        #region IsOpened 判断网页是否已经打开，已经打开则返回true
        /// <summary>
        /// 判断网页是否已经打开，已经打开则返回true
        /// </summary>
        /// <param name="url">地址</param>
        /// <returns></returns>
        public bool IsOpened(string url)
        {
            InternetExplorer bro = null;
            return IsOpened(url, out bro);
        }

        /// <summary>
        /// 判断网页是否已经打开，已经打开则返回true
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="bro">返回对打开的网页的引用</param>
        /// <returns></returns>
        public bool IsOpened(string url, out InternetExplorer bro)
        {
            bro = null;
            try
            {
                ShellWindows shellwindows = new ShellWindowsClass();

                
                foreach (InternetExplorer browser in shellwindows)
                {
                    if (browser.LocationURL.Contains(url))
                    {
                        bro = browser;
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
        #endregion

        #region ShowIEExplore 该方法将IE浏览器显示到最前端
        /// <summary>
        /// 该方法将IE浏览器显示到最前端
        /// </summary>
        private void ShowIEExplore()
        {
            ShellWindows shellWindows = new ShellWindowsClass();
            foreach (InternetExplorer bro in shellWindows)
            {
                string filename = System.IO.Path.GetFileNameWithoutExtension(bro.FullName).ToLower();
                if (filename.Equals("iexplore"))
                {
                    try
                    {
                        ShowWindowAsync((IntPtr)bro.HWND, 9);//显示  
                        SetForegroundWindow((IntPtr)bro.HWND);//当到最前端  
                    }
                    catch
                    {
                        return;
                    }
                }
            }
        }
        #endregion

        #region SetValue 网页文档设置输入框的值
        /// <summary>
        /// 设置值对
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        protected void SetValue(InternetExplorer browser, string key, string value)
        {
            try
            {
                HTMLDocument doc = (HTMLDocument)browser.Document;
                HTMLInputElement input = (HTMLInputElement)doc.getElementById(key);
                input.value = value;
            }
            catch
            {
                return;
            }
        }
        #endregion
    }
}
