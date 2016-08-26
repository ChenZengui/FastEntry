using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastEntry.Model;

namespace FastEntry.Interface
{
    public interface ILogin
    {
        void Login(LoginEntity model);

        void OpenUrl(string url, int delay = 3000);
    }
}
