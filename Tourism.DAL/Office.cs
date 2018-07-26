using System.Collections.Generic;

namespace Tourism.DAL
{
    public class Office
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public List<string> PhoneNumbers { get; set; }
        public Company Company { get; set; }
    }
}