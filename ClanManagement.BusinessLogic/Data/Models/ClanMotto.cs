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

        public string ClanId { get; set; }

        public string LanguageId { get; set; }
    }
}
