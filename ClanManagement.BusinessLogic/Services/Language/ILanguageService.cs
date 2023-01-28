using ClanManagement.BusinessLogic.Data.Dto;
using ClanManagement.BusinessLogic.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClanManagement.BusinessLogic.Services
{
    public interface ILanguageService
    {
         Task<ServiceResponse<GetLanguageDto>> CreateLanguage(AddLanguageDto language);
         Task<ServiceResponse<List<GetLanguageDto>>> getLanguange();

         Task<ServiceResponse<GetLanguageDto>> updateLanguage(string Id,UpdateLanguageDto lang);

         Task<ServiceResponse<GetLanguageDto>> deleteLanguage(string languageId);
    }
}
