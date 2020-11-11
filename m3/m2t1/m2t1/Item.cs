using System;

namespace m2t1
{
    public class Item
    {
        public string itype { get; set; }
        public string fullName { get; set; }
        public string name { get; set; }
        public float length { get; set; }
        public DateTime creationDateTime { get; set; }

        public Item(string itype, string fullName, string name, float length, DateTime creationDateTime)
        {
            this.itype = itype;
            this.fullName = fullName;
            this.name = name;
            this.length = length;
            this.creationDateTime = creationDateTime;
        }

        public Item()
        {
        }
    }
}
