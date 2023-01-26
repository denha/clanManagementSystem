using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClanManagement.BusinessLogic.Data;
using ClanManagement.BusinessLogic.Data.Dto.Name;
using ClanManagement.BusinessLogic.Data.Models;

namespace ClanManagement.BusinessLogic.Services
{
    public class NameService
    {
        private readonly IMapper _mapper;
        private readonly ClanMgtSysDbContext _context;
        public NameService(ClanMgtSysDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /*public async Task<ServiceResponse<GetNameDto>> CreateName(AddNameDto name)
        {
            ServiceResponse<GetNameDto> result = new ServiceResponse<GetNameDto>();
            try
            {
                

                if (string.IsNullOrEmpty(name.ClanId))
                {
                    result.Message = "Clan id is missing";
                    result.Success = false;
                    return result;
                }
                if (string.IsNullOrEmpty(name.Name))
                {
                    result.Message = "Name is missing";
                    result.Success = false;
                    return result;
                }

                Name nameObj = new Name();

                nameObj.Names = name.Name;
                nameObj.ClanId = name.ClanId;

                await _context.Name.AddAsync(nameObj);
                await _context.SaveChangesAsync();

                var DtoResult = _context.

            }catch(Exception e)
            {
                result.Message = $"An error has occured {e.Message}";
                result.Success = false;
                return result;
            }

        }*/
    }
}
