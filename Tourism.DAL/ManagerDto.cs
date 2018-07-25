namespace Tourism.DAL
{
    public class ManagerDto
    {
        public int Id { get; set; }
        public string Surname { get; set; }

        public ManagerDto()
        {
        }

        public ManagerDto(int id, string surname)
        {
            Id = id;
            Surname = surname;
        }
    }
}