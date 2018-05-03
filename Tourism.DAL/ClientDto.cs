namespace Tourism.DAL
{
    public class ClientDto
    {
        #region Properties

        public int Id { get; set; }
        public string Surname { get; set; }

        #endregion

        #region .ctor

        public ClientDto(int id, string surname)
        {
            Id = id;
            Surname = surname;
        }

        #endregion
    }
}