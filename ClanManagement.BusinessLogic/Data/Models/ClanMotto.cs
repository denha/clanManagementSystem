using ClanManagement.BusinessLogic.Data.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClanManagement.BusinessLogic.Data.Models
{
    public class ClanMotto:AutoIdBaseEntity
    {
        [Column("motto")]
        public string Motto { get; set; }

        [Column("clan_id")]
        public string ClanId { get; set; }
    }
}
