using AutoMapper;
using ClanManagement.BusinessLogic.Data;
using ClanManagement.BusinessLogic.Data.Dto;
using ClanManagement.BusinessLogic.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClanManagement.BusinessLogic.Services
{
    public class ClanService:IClanService
    {
        private readonly ClanMgtSysDbContext _context;
        private readonly IMapper _mapper;
        public ClanService(ClanMgtSysDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<GetClanDto>> CreateClan(AddClanDto clan)
        {
            ServiceResponse<GetClanDto> response = new ServiceResponse<GetClanDto>();
            try
            {
                if (string.IsNullOrEmpty(clan.Name))
                {
                    response.Message = "Clan Name cannot be empty";
                    response.Success = false;
                }

                Clan clanObj = new Clan();
                clanObj.Name = clan.Name;
                clanObj.ClanLeader = clan.ClanLeader;
                clanObj.Totem = clan.Totem;
                clanObj.MinorTotem = clan.MinorTotem;
                clanObj.ClanSeat = clan.ClanSeat;
                clanObj.MottoId = clan.MottoId;
                clanObj.Lang = clan.Language;

                await _context.Clan.AddAsync(clanObj);
                await  _context.SaveChangesAsync();
                response.Data = _mapper.Map<GetClanDto>(clanObj);
                return response;
            }catch(Exception e)
            {
                response.Message = $"An erorr has occured {e.Message}";
                response.Success = false;
                return response;
            }
        }

        public async Task<ServiceResponse<List<GetClanDto>>> GetAllClan()
        {
            ServiceResponse<List<GetClanDto>> response = new ServiceResponse<List<GetClanDto>>();
            try
            {
                List<Clan> clans = await _context.Clan.Include(x => x.ClanMotto).ToListAsync();

                response.Data = clans.Select(clan => _mapper.Map<GetClanDto>(clan)).ToList();
                return response;

            }catch(Exception e)
            {
                response.Message = $"An error has occured ${e.Message}";
                response.Success = false;
                return response;
            }

        }

       public async  Task<ServiceResponse<GetClanDto>> GetClanById(string clanId)
        {
            ServiceResponse<GetClanDto> response = new ServiceResponse<GetClanDto>();
            try
            {

                Clan clan = await _context.Clan.Include(cln => cln.ClanMotto).Where(x => x.Id.Equals(clanId)).FirstOrDefaultAsync();
                response.Data = _mapper.Map<GetClanDto>(clan);
                return response;

            }catch(Exception e)
            {
                response.Success = false;
                response.Message = $"An error has occured {e.Message}";
                return response;
            }

        }

        public async Task<ServiceResponse<GetClanDto>> UpdateClan(string clanId, string lang, UpdateClanDto clan)
        {

            ServiceResponse<GetClanDto> response = new ServiceResponse<GetClanDto>();
            try
            {
                if (string.IsNullOrEmpty(clanId))
                {
                    response.Message = "Clan Id is missing";
                    response.Success = false;
                    return response;
                }
                if (string.IsNullOrEmpty(lang))
                {
                    response.Message = "Language is missing";
                    response.Success = false;
                    return response;
                }

                Clan cln = await _context.Clan.FirstOrDefaultAsync(x => x.Id.Equals(clanId) && x.Lang.Equals(lang));
                cln.ClanLeader = clan.ClanLeader;
                cln.ClanSeat = clan.ClanSeat;
                cln.MinorTotem = clan.MinorTotem;
                cln.MottoId = clan.MottoId;
                cln.Name = clan.Name;
                cln.Totem = clan.Totem;

                await _context.SaveChangesAsync();

                GetClanDto clanDto = new GetClanDto();
                clanDto.ClanLeader = clan.ClanLeader;
                clanDto.ClanSeat = clan.ClanSeat;
                clanDto.MinorTotem = clan.MinorTotem;
                clanDto.MottoId = clan.MottoId;
                clanDto.Name = clan.Name;
                clanDto.Totem = clan.Totem;

                response.Data = clanDto;
                return response;


            }
            catch (Exception e)
            {
                response.Message = $"An error has occured {e.Message}";
                response.Success = false;
                return response;
            }
        }
            public async Task<ServiceResponse<GetClanDto>> DeleteClan(string clanId)
            {

                ServiceResponse<GetClanDto> response = new ServiceResponse<GetClanDto>();
                try
                {
                    if (string.IsNullOrEmpty(clanId))
                    {
                        response.Message = "Clan Id is missing";
                        response.Success = false;
                        return response;
                    }
                    Clan ClanResults =    await _context.Clan.FirstOrDefaultAsync(x => x.Id.Equals(clanId));
                if (ClanResults == null)
                {
                    throw new ArgumentNullException();
                }
                    _context.Clan.Remove(ClanResults);
                    await _context.SaveChangesAsync();
                    response.Data = _mapper.Map<GetClanDto>(ClanResults);
                    return response;


                }catch(Exception e)
                {
                    response.Message = $"An error has occured ${e.Message}";
                    response.Success = false;
                    return response;
                }
            }
        }
    }



