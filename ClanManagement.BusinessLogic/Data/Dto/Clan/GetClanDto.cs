using System;
using System.Collections.Generic;
using System.Text;

namespace ClanManagement.BusinessLogic.Data.Dto.Clan
{
    public class GetClanDto
    {
        public Guid ClanId {get;set;}

        public string Name { get; set; }
        public string ClanLeader { get; set; }
        public string Totem { get; set; }
        public string MinorTotem { get; set; }

        public string ClanSeat { get; set; }

        public string ClanMotto { get; set; }
    }
}
