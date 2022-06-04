namespace GameDB.Models
{
    public class Genre_Game
    {
        public int Id { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; } = null!;

        public int GameId { get; set; }
        public Game Game { get; set; } = null!;
    }
}
