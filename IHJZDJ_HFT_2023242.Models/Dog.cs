using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace IHJZDJ_HFT_2023242.Models
{
    public class Dog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DogId { get; set; }
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }

        [ForeignKey("BreedId")]
        public int BreedId { get; set; }
        [ForeignKey("OwnerId")]
        public int OwnerId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Owner Owner { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Breed Breed { get; set; }
    }
}
