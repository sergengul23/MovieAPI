namespace Store.BUSINESS.DTOs.RequestDTOs
{
    public class CreateDirectorDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public bool HasAnOscar { get; set; }
    }
}
