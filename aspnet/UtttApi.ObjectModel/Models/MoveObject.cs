using System.ComponentModel.DataAnnotations;

namespace UtttApi.ObjectModel.Models
{
    public class MoveObject
    {
        [Required]
        [Range(1, 2)]
        public MarkShape Mark { get; set; }

        [Required]
        [Range(0, 8)]
        public int LbIndex { get; set; }

        [Required]
        [Range(0, 8)]
        public int MarkIndex { get; set; }
    }
}