namespace Store.BUSINESS.DTOs.ResponseDTOs
{
    public class ActorDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public bool HasAnOscar { get; set; }
        public List<string> Movies { get; set; }
    }
}
