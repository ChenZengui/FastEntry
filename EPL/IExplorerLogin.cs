using Model;

namespace EPL
{
    /// <summary>
    /// 接口定义了浏览器实现登录,不同浏览器实现登录时均需实现该接口
    /// </summary>
    public interface IExplorerLogin : IExplorerOpen
    {
        /// <summary>
        /// 登录网站的方法。
        /// 不同的浏览器和不同的网站具体登录方式不一定相同
        /// </summary>
        /// <param name="model">用于登录的实体</param>
        void Login(LoginEntity model);
    }
}
