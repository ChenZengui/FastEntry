using System.Collections.Generic;

namespace UDP
{
    public abstract class BaseEntry<T>
    {
        private string sourcePath = "";

        public BaseEntry(string path)
        {
            this.sourcePath = path;
        }

        public string Path {
            get { return sourcePath; }
            set { sourcePath = value; }
        }


        public abstract T GetEntity(dynamic condition);

        public abstract IList<T> GetEntities(dynamic condition);

        public abstract bool InsertEntity(T entity);

        public abstract bool InsertEntities(IList<T> list);

        public abstract bool DeleteEntity(dynamic condition);

        public abstract bool DeleteEntities(IList<T> list);

        public abstract bool UpdateEntity(T entity);

        public abstract bool UpdateEntities(IList<T> list);
    }
}
