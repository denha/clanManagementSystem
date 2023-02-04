using ClanManagement.BusinessLogic.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClanManagement.BusinessLogic.Data.Dto
{
    public class GetClanDto
    {
        public string Id {get;set;}

        public string Name { get; set; }
        public string ClanLeader { get; set; }
        public string Totem { get; set; }
        public string MinorTotem { get; set; }

        public string ClanSeat { get; set; }

        public string MottoId { get; set; }

        public ICollection<ClanMotto> ClanMotto { get; set; }

        public string Lang { get; set; }
    }
}
