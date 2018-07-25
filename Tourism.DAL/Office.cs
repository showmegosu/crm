using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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