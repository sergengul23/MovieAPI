namespace Store.BUSINESS.DTOs.ResponseDTOs
{
    public class GenreDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Movies { get; set; }
    }
}
