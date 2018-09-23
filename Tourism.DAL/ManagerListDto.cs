using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourism.DAL
{
    public class ManagerListDto
    {
        public int Id { get; set; }
        public string Surname { get; set; }

        public ManagerListDto(int id, string surname)
        {
            Id = id;
            Surname = surname;
        }
    }
}
