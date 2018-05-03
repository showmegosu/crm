using System.Collections.Generic;

namespace Tourism.DAL
{
    public class Client
    {
        #region Properties

        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string FathersName { get; set; }
        public List<string> PhoneNumbers { get; set; }
        public List<string> Addresses { get; set; }

        #endregion

        #region .ctor

        public Client(int id, string surname)
        {
            Id = id;
            Surname= surname;
        }

        #endregion
    }
}