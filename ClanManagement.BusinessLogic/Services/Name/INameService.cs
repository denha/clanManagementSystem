using ClanManagement.BusinessLogic.Data.Dto.Name;
using ClanManagement.BusinessLogic.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClanManagement.BusinessLogic.Services
{
    public interface INameService
    {

        public Task<ServiceResponse<AddNameDto>> CreateName();
    }
}
