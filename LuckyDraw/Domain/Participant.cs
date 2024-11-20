using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace LuckyDraw.Domain;

[Table("Participant")]
public class Participant
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [MaxLength(256)]
    public string? Name { get; set; }

    [Required]
    [MaxLength(256)]
    public required string IdentityNumber { get; set; }

    public virtual ICollection<Winner> Winners { get; set; } = [];
}
