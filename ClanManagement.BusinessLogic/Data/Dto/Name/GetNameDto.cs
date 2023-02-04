using ClanManagement.BusinessLogic.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClanManagement.BusinessLogic.Data.Dto
{
    public class GetNameDto
    {

        public string Name { get; set; }
        public string Gender { get; set; }
        public ICollection<Clan> Clan { get; set; }
    }
}
