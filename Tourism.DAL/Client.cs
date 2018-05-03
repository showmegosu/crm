using System.Collections.Generic;

namespace Tourism.DAL
{
    public class Client
    {
        public long Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string FathersName { get; set; }
        public List<object> PhoneNumbers { get; set; }
        public List<object> Addresses { get; set; }

        public Client(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}