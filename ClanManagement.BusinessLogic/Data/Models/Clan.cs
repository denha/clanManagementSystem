using ClanManagement.BusinessLogic.Data.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClanManagement.BusinessLogic.Data.Models
{   
    [Table("Clan")]
   public class Clan : AutoIdBaseEntity
    {  
        [Column("name")]
        [Required]
        public string Name { get; set; }

        [Column("clan_leader")]
        public string ClanLeader { get; set; }

        [Column("totem")]
        public string Totem { get; set; }

        [Column("minor_totem")]
        public string MinorTotem { get; set; }

        public string MottoId { get; set; }

        [Column("clan_seat")]
        public string ClanSeat { get; set; }

        [Column("lang_id")]
        public string Lang { get; set; }

        public ICollection<Name> ClanId { get; set; }

        [Column("ClanId")]
        public ICollection<ClanMotto> ClanMotto { get; set; }

        public ICollection<Language> Language { get; set; }

  
    }
}
