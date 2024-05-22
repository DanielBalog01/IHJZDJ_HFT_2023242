﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace IHJZDJ_HFT_2023242.Models
{
    public class Breed
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeamId { get; set; }

        [Required]
        [StringLength(50)]
        public string TeamName { get; set; }
        public int ChampionshipWins { get; set; }
        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<Dog> Dogs { get; set; }

    }
}
