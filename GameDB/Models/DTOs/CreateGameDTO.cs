using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GameDB.Models.DTOs
{
    public class CreateGameDTO
    {
        [Required]
        public string Name { get; set; } = null!;

        [Range(1, int.MaxValue, ErrorMessage = "Value must be higher than 1")]
        [Required]
        public int GameStudioId { get; set; }
        public IEnumerable<int> GenresId { get; set; }
    }
}
