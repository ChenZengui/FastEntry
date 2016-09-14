using System;
using System.Collections.Generic;
using System.Text;

namespace EPL
{
    public interface IBaiduSearch : IExplorerOpen
    {
        void Search(string url, string searchinputid, string content, string submitid);
    }
}
