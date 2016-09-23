
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
