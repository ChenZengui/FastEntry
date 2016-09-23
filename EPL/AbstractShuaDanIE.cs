using Model;
using mshtml;
using SHDocVw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EPL
{
    /// <summary>
    /// 类实现了刷单接口。机器刷代替了人工刷
    /// </summary>
    public class AbstractShuaDanIE :AbstractOpenIE, IExplorerShuaDan
    {
        public void BeginShuaDan(ShuaDanEntity model, int intervals,int count)
        {
            OpenLink(model.URL);

            for (int i = 0; i < count; i++)
            {
                Run(model);
                Thread.Sleep(intervals);
            }
        }

        private void Run(ShuaDanEntity model)
        {
            InternetExplorer browser = null;
            if (IsOpened(model.URL, out browser))
            {
                #region 提交
                HTMLDocument doc = (HTMLDocument)browser.Document;
                if (model.SUBMITINPUTID != null && model.SUBMITINPUTID != "")
                {
                    IHTMLElement login = doc.getElementById(model.SUBMITINPUTID);
                    if (login != null)
                    {
                        login.click();
                    }
                }
                else if (model.SUBMITINPUTCLASS != null && model.SUBMITINPUTCLASS != "")
                {
                    bool clicked = false;
                    IHTMLElementCollection login2 = doc.getElementsByTagName("INPUT");
                    IHTMLElementCollection login1 = doc.getElementsByTagName("A");
                    foreach (IHTMLElement l in login2)
                    {
                        if (l.className == model.SUBMITINPUTCLASS)
                        {
                            l.click();
                            clicked = true;
                            break;
                        }
                    }
                    if (!clicked)
                    {
                        foreach (IHTMLElement l in login1)
                        {
                            if (l.className == model.SUBMITINPUTCLASS)
                            {
                                l.click();
                                clicked = true;
                                break;
                            }
                        }
                    }
                }
                #endregion
            }
            else
            {
                #region 网页没有打开，尝试打开
                OpenLink(model.URL);
                #endregion

                #region 如果已经打开，执行登录，如果没打开，则认为已经登录过
                if (IsOpened(model.URL, out browser))
                {
                    Run(model);
                }
                #endregion
            }
            return;
        }
    }
}
