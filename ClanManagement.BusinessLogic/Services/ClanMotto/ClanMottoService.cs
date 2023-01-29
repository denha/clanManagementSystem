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
using Microsoft.EntityFrameworkCore;

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
            try
            {

                if (string.IsNullOrEmpty(clanMotto.Motto))
                {
                    result.Success = false;
                    result.Message = "Motto is empty";
                    return result;
                }

                if (string.IsNullOrEmpty(clanMotto.LanguageId))
                {
                    result.Success = false;
                    result.Message = "Language cannot be  is empty";
                    return result;
                }

                if (string.IsNullOrEmpty(clanMotto.ClanId))
                {
                    result.Success = false;
                    result.Message = "Clan cannot be  is empty";
                    return result;
                }
                ClanMotto clanMottoObj =new  ClanMotto();

                clanMottoObj.Motto = clanMotto.Motto;
                clanMottoObj.ClanId = clanMotto.ClanId;
                clanMottoObj.LanguageId = clanMotto.LanguageId;
                

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

      public async  Task<ServiceResponse<List<GetClanMottoDto>>> GetClanMotto()
        {
            ServiceResponse<List<GetClanMottoDto>> response = new ServiceResponse<List<GetClanMottoDto>>();
            try
            {
                var results = await _context.ClanMotto.ToListAsync();
                List<GetClanMottoDto> listofNames = results.Select(motto => _mapper.Map<GetClanMottoDto>(motto)).ToList();
                response.Data = listofNames;
                return response;
                
            }catch(Exception e)
            {
                response.Message = $"An errored has occured {e.Message}";
                response.Success = false;
                return response;
            }
        }

        public async Task<ServiceResponse<List<GetClanMottoDto>>> GetClanMottoByClanId(string clanId)
        {
            ServiceResponse<List<GetClanMottoDto>> response = new ServiceResponse<List<GetClanMottoDto>>();
            try
            {
                if (string.IsNullOrEmpty(clanId))
                {
                    response.Message = "clan id cannot be empty";
                    response.Success = false;
                    return response;
                }
                var ListOfClanMotto = await _context.ClanMotto.Where(clan => clan.ClanId.Equals(clanId)).ToListAsync();
                response.Data = ListOfClanMotto.Select(motto => _mapper.Map<GetClanMottoDto>(motto)).ToList();
                return response;
            }catch(Exception e)
            {
                response.Message = $"An error has occured {e.Message}";
                response.Success = false;
                return response;
            }
        }

       public async Task<ServiceResponse<GetClanMottoDto>> UpdateClanMotto(string clanId, UpdateClanMottoDto clan, string langId)
        {
            ServiceResponse<GetClanMottoDto> response = new ServiceResponse<GetClanMottoDto>();
            try
            {
                if (string.IsNullOrEmpty(clanId))
                {
                    response.Message = "Clan Id cannot be empty";
                    response.Success = false;
                    return response;
                }

                if (string.IsNullOrEmpty(langId))
                {
                    response.Message = "Lang Id cannot be empty";
                    response.Success = false;
                    return response;
                }
                ClanMotto results = await _context.ClanMotto.Where(motto => motto.ClanId.Equals(clanId) && motto.LanguageId.Equals(langId)).FirstOrDefaultAsync(); 
                ClanMotto clanMottoObj = new ClanMotto();
                clanMottoObj.Motto = clan.Motto;
                

                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetClanMottoDto>(results);
                return response;

            }catch(Exception e)
            {
                response.Message = $"An error has occured {e.Message}";
                response.Success = false;
                return response;
            }
        }

        public async Task<ServiceResponse<GetClanMottoDto>> DeleteClanMotto(string id)
        {
            ServiceResponse<GetClanMottoDto> results = new ServiceResponse<GetClanMottoDto>();

            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    results.Message = "Clan Id cannot be empty";
                    results.Success = false;
                }
               var clan = await  _context.ClanMotto.Where(clan => clan.Id.Equals(id)).FirstOrDefaultAsync();
                if (clan == null)
                {
                    throw new ArgumentNullException();
                }
                _context.ClanMotto.Remove(clan);
                await _context.SaveChangesAsync();
                results.Data = _mapper.Map<GetClanMottoDto>(clan);
                return results;
            }catch(Exception e)
            {
                results.Message = $"An error has occured {e.Message}";
                results.Success = false;
                return results;
            }
        }
    }
}
