using ClanManagement.BusinessLogic.Data.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClanManagement.BusinessLogic.Data.Models
{
    public class Language: AutoIdBaseEntity
    {
        [Column("name")]
        public string Name { get; set; }  
        
        [Column("isDefault")]
        public bool IsDefault { get; set; }
    
    }
}
