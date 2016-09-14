using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPL
{
    public interface IExplorerLogin : IExplorerOpen
    {
        void Login(LoginEntity model);
    }
}
