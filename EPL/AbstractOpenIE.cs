using mshtml;
using SHDocVw;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace EPL
{
    public class AbstractOpenIE : IExplorerOpen
    {
        /// <summary>
        /// 打开一个链接，包括判断url是否已经打开
        /// </summary>
        /// <param name="url"></param>
        /// <param name="delay"></param>
        public void OpenLink(string url, int delay = 3000)
        {
            if (IsOpened(url))
            {
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


        public bool IsOpened(string url)
        {
            InternetExplorer bro = null;
            return IsOpened(url, out bro);
        }
        /// <summary>
        /// 判断网页是否已经打开，已经打开则返回true
        /// </summary>
        /// <param name="url"></param>
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


        #region 网页文档设置输入框的值
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
