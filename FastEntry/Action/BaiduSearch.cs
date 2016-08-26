using FastEntry.Abstract;
using mshtml;
using SHDocVw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastEntry.Action
{
    public class BaiduSearch :AbstractPageTool
    {
        public void Search(string url, string searchinputid, string content, string submitid)
        {
            InternetExplorer browser = null;
            if (IsOpened(url, out browser))
            {
                HTMLDocument doc = (HTMLDocument)browser.Document;
                IHTMLInputElement input = (IHTMLInputElement)doc.getElementById(searchinputid);
                IHTMLElement submit = doc.getElementById(submitid);
                input.value = content.Trim();
                submit.click();
            }
            else
            {
                #region 网页没有打开，尝试打开
                OpenUrl(url,1000);
                #endregion

                if (IsOpened(url, out browser))
                {
                    Search(url, searchinputid, content, submitid);
                }
            }
        }
    }
}
