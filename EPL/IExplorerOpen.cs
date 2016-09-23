
namespace EPL
{
    /// <summary>
    /// 接口定义了浏览器打开一个链接
    /// </summary>
    public interface IExplorerOpen
    {
        /// <summary>
        /// 打开一个链接，包括判断url是否已经打开
        /// </summary>
        /// <param name="url"></param>
        /// <param name="delay"></param>
        void OpenLink(string url, int delay = 3000);
    }
}
