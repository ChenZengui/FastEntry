using Model;

namespace EPL
{
    /// <summary>
    /// 该接口定义了浏览器刷单的实现方式
    /// </summary>
    public interface IExplorerShuaDan :IExplorerOpen
    {
        /// <summary>
        /// 开始执行刷单过程
        /// </summary>
        /// <param name="model">刷单实体</param>
        /// <param name="intervals">频率，间隔毫秒</param>
        /// <param name="count">刷单次数</param>
        void BeginShuaDan(ShuaDanEntity model, int intervals, int count);
    }
}
