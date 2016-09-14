using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace EPL
{
    public interface IExplorerOpen
    {
        void OpenLink(string url, int delay = 3000);
    }
}
