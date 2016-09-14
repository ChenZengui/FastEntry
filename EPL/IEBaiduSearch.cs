using mshtml;
using SHDocVw;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPL
{
    public class IEBaiduSearch :AbstractOpenIE, IBaiduSearch
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
                OpenLink(url, 1000);
                #endregion

                if (IsOpened(url, out browser))
                {
                    Search(url, searchinputid, content, submitid);
                }
            }
        }
    }
}
