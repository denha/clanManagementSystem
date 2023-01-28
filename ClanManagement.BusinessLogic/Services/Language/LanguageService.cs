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
    public class LanguageService:ILanguageService
    {
        private readonly ClanMgtSysDbContext _context;
        private readonly IMapper _mapper;
        public LanguageService(ClanMgtSysDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<ServiceResponse<List<GetLanguageDto>>> getLanguange()
        {
            ServiceResponse<List<GetLanguageDto>> response = new ServiceResponse<List<GetLanguageDto>>();
            List<Language> allLanguage = await _context.Language.ToListAsync();
            //response.Data =    allLanguage.Select(c => _mapper.Map<GetLanguageDto>(c)).ToList();
            //return response;
            var res = allLanguage.Select(c => _mapper.Map<GetLanguageDto>(c)).ToList();
            response.Data = res;
            return response;
        }
        public async Task<ServiceResponse<GetLanguageDto>> CreateLanguage(AddLanguageDto language)
        {
            ServiceResponse<GetLanguageDto> result = new ServiceResponse<GetLanguageDto>();

            try
            {
                if (string.IsNullOrEmpty(language.Name))
                {
                    result.Message = "Language is empty";
                    result.Success = false;
                    return result;
                }

                /* if (bool.FalseString(language.isDefault))
                 {
                     result.Message = "isDefault is empty";
                     result.Success = false;
                     return result;
                 }*/

                Language langObj = new Language();
                langObj.Name = language.Name;
                langObj.IsDefault = language.isDefault;

                await _context.Language.AddAsync(langObj);
                await _context.SaveChangesAsync();

                result.Data = _mapper.Map<GetLanguageDto>(langObj);
                result.Message = "Language created";
                return result;
            }
            catch (Exception e)
            {
                result.Message = $"An Error has occured {e.Message}";
                result.Success = false;
                return result;
            }
        }

        
        public async Task<ServiceResponse<GetLanguageDto>> updateLanguage(string Id, UpdateLanguageDto lang)
        {
            ServiceResponse<GetLanguageDto> response = new ServiceResponse<GetLanguageDto>();
            try
            {
                if (string.IsNullOrEmpty(Id))
                {
                    response.Success = false;
                    response.Message = "Language ID cannot empty";
                }
                else
                {
                    var language = await _context.Language.FirstOrDefaultAsync(lng => lng.Id.Equals(Id));
                    if (language != null)
                    {
                        language.Name = lang.Name;
                        language.IsDefault = lang.isDefault;

                        await _context.SaveChangesAsync();
                        response.Data = _mapper.Map<GetLanguageDto>(language);
                    }
                    else
                    {
                        throw new ArgumentNullException();
                    }

                }

                return response;
            }catch(Exception e)
            {
                response.Message = $"An errored has {e.Message}";
                response.Success = false;
                return response;
            }


        }

        public async Task<ServiceResponse<GetLanguageDto>> deleteLanguage(string languageId)
        {
            ServiceResponse<GetLanguageDto> response = new ServiceResponse<GetLanguageDto>();
            var language = await _context.Language.FirstOrDefaultAsync(lng => lng.Id.Equals(languageId));
            try
            {
                if (language != null)
                {
                    _context.Language.Remove(language);
                    await _context.SaveChangesAsync();
                    response.Data = _mapper.Map<GetLanguageDto>(language);

                }
                else
                {
                    throw new ArgumentNullException();
                }
                return response;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = $"An error has occured {e.Message}";
                return response;
            }
        }
    }
}
