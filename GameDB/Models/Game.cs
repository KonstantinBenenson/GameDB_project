using System.ComponentModel.DataAnnotations;
namespace GameDB.Models
{
    public class Game : IModelBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        //Many-To-Many
        public IList<Genre_Game> Genre_Games { get; set; } = null!;

        //One-to-One
        public int GameStudioId { get; set; }
        public GameStudio GameStudio { get; set; } = null!;

    }
}
