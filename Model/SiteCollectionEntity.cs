using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SiteCollectionEntity
    {
        private string _clickcount = "0";
        public string SITENAME { get; set; }

        public string URL { get; set; }

        public string CLICKCOUNT
        {
            get
            {
                return _clickcount;
            }
            set
            {
                _clickcount = value;
            }
        }
    }
}
