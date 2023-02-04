using ClanManagement.BusinessLogic.Data.Dto;
using ClanManagement.BusinessLogic.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClanManagement.BusinessLogic.Services
{
   public  interface IClanService
    {
        Task<ServiceResponse<GetClanDto>> CreateClan(AddClanDto clan);

        Task<ServiceResponse<List<GetClanDto>>> GetAllClan();


        Task<ServiceResponse<GetClanDto>> GetClanById(string clanId);

        Task<ServiceResponse<GetClanDto>> UpdateClan(string clanId, string lang, UpdateClanDto clan);

        Task<ServiceResponse<GetClanDto>> DeleteClan(string clanId);
    }
}
