using System;

namespace UDP
{
    public static class EntryFactory
    {
        public static object Create(DataType dtype)
        {
            return Activator.CreateInstance(Type.GetType("UDP." + dtype.ToString() + "DataEntry"), dtype.ToString() + "data.xml");
        }
    }
}
