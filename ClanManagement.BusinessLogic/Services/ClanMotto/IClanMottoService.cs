using ClanManagement.BusinessLogic.Data.Dto;
using ClanManagement.BusinessLogic.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClanManagement.BusinessLogic.Services
{
    public interface IClanMottoService
    {
        Task<ServiceResponse<GetClanMottoDto>> CreateClanMotto(AddClanMottoDto clanMotto);

        Task<ServiceResponse<List<GetClanMottoDto>>> GetClanMotto();

        Task<ServiceResponse<List<GetClanMottoDto>>> GetClanMottoByClanId(string clanId);

        Task<ServiceResponse<GetClanMottoDto>> UpdateClanMotto(string clanId, UpdateClanMottoDto clan,string langId);

        Task<ServiceResponse<GetClanMottoDto>> DeleteClanMotto(string id);
    }
}
