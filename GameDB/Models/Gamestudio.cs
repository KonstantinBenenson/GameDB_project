using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GameDB.Models
{
    public class GameStudio : IModelBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        //One-to-Many
        public IEnumerable<Game> Games { get; set; }
    }
}
