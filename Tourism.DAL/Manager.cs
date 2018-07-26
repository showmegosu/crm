using System.Collections.Generic;

namespace Tourism.DAL
{
    public class Manager
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string FathersName { get; set; }
        public List<string> PhoneNumbers { get; set; }
        public string Email { get; set; }
        public string Skype { get; set; }
        public string Company { get; set; }
        public string Office { get; set; }
        public string Address { get; set; }
        public string DateOfBirth { get; set; }
        public string JoiningDate { get; set; }
        public int BaseSalary { get; set; }

        public Manager(int id, string surname)
        {
            Id = id;
            Surname = surname;
        }
        public Manager()
        {
            PhoneNumbers = new List<string>();
        }
    }
}