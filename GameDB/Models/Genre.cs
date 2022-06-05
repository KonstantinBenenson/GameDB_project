using GameDB.Models;
using System.ComponentModel.DataAnnotations;

namespace GameDB
{
    public class Genre : IModelBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        //Many-To-Many
        public IList<Genre_Game> Genre_Games { get; set; } = null!;
    }
}