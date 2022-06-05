namespace GameDB.Models.DTOs
{
    public class GetGameDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int GameStudioId { get; set; }
    }
}
