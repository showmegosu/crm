using System.Collections.Generic;

namespace Tourism.DAL
{
    public class Office
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<string> PhoneNumbers { get; set; }
        public int Company { get; set; }

        public Office(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Office()
        {
            PhoneNumbers = new List<string>();
        }
    }
}