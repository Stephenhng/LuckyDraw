using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuckyDraw.Domain;

[Table("Winner")]
public class Winner
{
    [Key]
    [Required]
    [ForeignKey("Participant")]
    public int ParticipantId { get; set; }
    public virtual Participant? Participant { get; set; }

    [Required]
    [ForeignKey("Prize")]
    public int PrizeId { get; set; }
    public virtual Prize? Prize { get; set; }
}
