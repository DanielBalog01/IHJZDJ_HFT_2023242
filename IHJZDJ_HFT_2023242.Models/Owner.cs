using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IHJZDJ_HFT_2023242.Models
{
    public class Owner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OwnerId { get; set; }

        [Required]
        [StringLength(50)]
        public string OwnerName { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<Dog> Dogs { get; set; }
    }
}
