using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClanManagement.BusinessLogic.Data.Models.Common
{
    class GuidBaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public GuidBaseEntity()
        {
            Id = Guid.NewGuid();
        }

        
        
    }
}
