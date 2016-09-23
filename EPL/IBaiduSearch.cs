
namespace EPL
{
    /// <summary>
    /// 接口定义了百度搜索的实现方式
    /// </summary>
    public interface IBaiduSearch : IExplorerOpen
    {
        /// <summary>
        /// 百度搜索内容
        /// </summary>
        void Search(string url, string searchinputid, string content, string submitid);
    }
}
