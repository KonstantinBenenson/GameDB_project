using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GameDB.Models.DTOs
{
    public class CreateGenreDTO
    {
        [Required(ErrorMessage = "You need to provide a name for a new Genre.")]
        public string Name { get; set; } = null!;
    }
}
