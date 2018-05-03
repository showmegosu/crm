namespace Tourism.DAL
{
    public class ClientDto
    {
        public ClientDto()
        {
        }

        public ClientDto(int id, string surname)
        {
            Id = id;
            Surname = surname;
        }

        public int Id { get; set; }
        public string Surname { get; set; }
    }
}