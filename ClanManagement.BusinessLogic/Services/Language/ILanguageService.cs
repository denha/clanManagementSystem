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
        public Task<ServiceResponse<GetLanguageDto>> CreateLanguage(AddLanguageDto language);
        public Task<ServiceResponse<List<GetLanguageDto>>> getLanguange();

        public Task<ServiceResponse<GetLanguageDto>> updateLanguage(String Id,UpdateLanguageDto lang);
    }
}
