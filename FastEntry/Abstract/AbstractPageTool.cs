using mshtml;
using SHDocVw;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FastEntry.Abstract
{
    public abstract class AbstractPageTool
    {
        public void OpenUrl(string url, int delay = 3000)
        {
            try
            {
                Process process = Process.Start("iexplore.exe", url);
                Thread.Sleep(delay);
            }
            catch
            {
                return;
            }
        }

        /// <summary>
        /// 判断网页是否已经打开，已经打开则返回true
        /// </summary>
        /// <param name="url"></param>
        /// <param name="bro">返回对打开的网页的引用</param>
        /// <returns></returns>
        public bool IsOpened(string url,out InternetExplorer bro)
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
        protected virtual void SetValue(InternetExplorer browser, string key, string value)
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
