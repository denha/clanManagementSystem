using ClanManagement.BusinessLogic.Data;
using ClanManagement.BusinessLogic.Data.Dto;
using ClanManagement.BusinessLogic.Data.Models;
using ClanManagement.BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace ClanManagement.BusinessLogic.Services
    
{
    public class ClanMottoService :IClanMottoService
    {
        private readonly ClanMgtSysDbContext _context;
        private readonly IMapper _mapper;
        public ClanMottoService(ClanMgtSysDbContext dbContext,IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<GetClanMottoDto>> CreateClanMotto(AddClanMottoDto clanMotto)
        {
            ServiceResponse<GetClanMottoDto> result = new ServiceResponse<GetClanMottoDto>();

            if (string.IsNullOrEmpty(clanMotto.Motto))
            {
                result.Success = false;
                result.Message = "Motto is empty";
                return result;
            }
            try
            {
                ClanMotto clanMottoObj =new  ClanMotto();
                clanMottoObj.Motto = clanMotto.Motto;
                await _context.ClanMotto.AddAsync(clanMottoObj);
                await _context.SaveChangesAsync();

                result.Data = _mapper.Map<GetClanMottoDto>(clanMottoObj);
                result.Message = "Clan motto created";
                return result;

            }
            catch (Exception e)
            {
                result.Message = $"Clan motto not created {e.Message}";
                result.Success = false;
                return result;
            }

        }
    }
}
