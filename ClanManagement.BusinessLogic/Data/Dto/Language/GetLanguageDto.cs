using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClanManagement.BusinessLogic.Data.Dto
{
    public class GetLanguageDto
    {
        public string Name { get; set; }

        public bool isDefault { get; set; }

        public string Id { get; set; }

        public static implicit operator GetLanguageDto(List<GetLanguageDto> v)
        {
            throw new NotImplementedException();
        }
    }
}
