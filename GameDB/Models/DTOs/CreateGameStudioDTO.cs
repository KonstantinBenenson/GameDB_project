using GameDB.Services;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GameDB.Models.DTOs
{
    public class CreateGameStudioDTO 
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
