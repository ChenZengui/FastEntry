using System;
using Model;
using mshtml;
using SHDocVw;
using System.Diagnostics;
using System.Threading;

namespace EPL
{
    public abstract class AbstractLoginIE : AbstractOpenIE, IExplorerLogin
    {
        public virtual void Login(LoginEntity model)
        {
            InternetExplorer browser = null;

            OpenLink(model.URL);

            if (IsOpened(model.URL, out browser))
            {
                #region 网页已经打开，绑定数据
                BindData(browser, model);
                #endregion

                #region 提交
                HTMLDocument doc = (HTMLDocument)browser.Document;
                if (model.SUBMITID != null && model.SUBMITID != "")
                {
                    IHTMLElement login = doc.getElementById(model.SUBMITID);
                    if (login != null)
                    {
                        login.click();
                    }
                }
                else if (model.SUBMITCLASS != null && model.SUBMITCLASS != "")
                {
                    bool clicked = false;
                    IHTMLElementCollection login2 = doc.getElementsByTagName("INPUT");
                    IHTMLElementCollection login1 = doc.getElementsByTagName("A");
                    foreach (IHTMLElement l in login2)
                    {
                        if (l.className == model.SUBMITCLASS)
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
                            if (l.className == model.SUBMITCLASS)
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
                    Login(model);
                }
                #endregion
            }
            return;
        }

        #region 该方法用于绑定数据，特殊的绑定需要重写此方法，如绑定验证码
        /// <summary>
        /// 该方法用于绑定数据，特殊的绑定需要重写此方法，如绑定验证码
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="model"></param>
        protected virtual void BindData(InternetExplorer browser, LoginEntity model)
        {
            try
            {
                SetValue(browser, model.USERNAMEINPUTID, model.USERNAME);
                SetValue(browser, model.PASSWORDINPUTID, model.PASSWORD);
            }
            catch
            {
                return;
            }
        }
        #endregion
    }
}
