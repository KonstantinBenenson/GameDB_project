using System.ComponentModel.DataAnnotations.Schema;

namespace GameDB.Models
{
    public class Videogame : IModelBase
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Genre { get; set; } = null!;
                
        public int GamestudioId { get; set; }
        [ForeignKey("GamestudioId")]
        public Gamestudio Gamestudio { get; set; } = null!;

    }
}
