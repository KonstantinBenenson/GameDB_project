namespace GameDB.Models
{
    public class Gamestudio : IModelBase
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public IEnumerable<Videogame>? Videogames { get; set; }
    }
}
