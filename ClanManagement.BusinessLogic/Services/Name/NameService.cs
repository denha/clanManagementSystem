using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClanManagement.BusinessLogic.Data;
using ClanManagement.BusinessLogic.Data.Dto;
using ClanManagement.BusinessLogic.Data.Models;

namespace ClanManagement.BusinessLogic.Services
{
    public class NameService:INameService
    {
        private readonly IMapper _mapper;
        private readonly ClanMgtSysDbContext _context;
        public NameService(ClanMgtSysDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetNameDto>> CreateName(AddNameDto name)
        {
            ServiceResponse<GetNameDto> response = new ServiceResponse<GetNameDto>();
            try
            {
                if (string.IsNullOrEmpty(name.ClanId))
                {
                    response.Success = false;
                    response.Message = "Clan cannot be empty";
                    return response;
                }

                Name nameObj = new Name();
                nameObj.Names = name.Name;
                //nameObj.ClanId = name.ClanId;

                await _context.Name.AddAsync(nameObj);
                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetNameDto>(nameObj);
                return response;

            }catch(Exception e)
            {
                response.Message = $"An errored has occured {e.Message}";
                response.Success = false;
                return response;
            }
        }
    }
}
