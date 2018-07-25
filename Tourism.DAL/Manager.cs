using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourism.DAL
{
    public class Manager
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string FathersName { get; set; }
        public string Email { get; set; }
        public string Skype { get; set; }
        public Company Company { get; set; }
        public Office Office { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime JoiningDate { get; set; }
        public int BaseSalary { get; set; }
    }
}