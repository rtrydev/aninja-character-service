using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace aninja_character_service.Dtos;

public class CharacterWriteDto
{
    [Required]
    [StringLength(50)]
    public string OriginalName { get; set; } = "";
    [Required]
    [StringLength(50)]
    public string TranslatedName { get; set; } = "";
    [StringLength(150)]
    public string? ImageUrl { get; set; }
    [DefaultValue("Female")]
    public string Gender { get; set; }
    [Required]
    [StringLength(50)]
    public string VoiceActor { get; set; } = "";
    [StringLength(150)]
    public string? VoiceActorImageUrl { get; set; }
    [StringLength(1000)]
    public string Description { get; set; } = "";
}
